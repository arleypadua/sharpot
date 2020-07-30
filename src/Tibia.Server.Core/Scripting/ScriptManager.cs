using Microsoft.CSharp;
using Microsoft.VisualBasic;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using Tibia.Server.Core.Data.Scripts;
using Tibia.Server.Core.Properties;

namespace Tibia.Server.Core.Scripting
{
    public class ScriptManager
    {
        private static CSharpCodeProvider cSharpCodeProvider = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
        private static VBCodeProvider vBCodeProvider = new VBCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
        private static List<IScript> loadedScripts = new List<IScript>();

        private static StringBuilder errorLog;

        public static string LoadAllScripts(Game game)
        {
            // load scripts from the current assembly
            LoadScript(game, Assembly.GetExecutingAssembly());

            errorLog = new StringBuilder();
            foreach (string directory in Settings.Default.ScriptsDirectory.Split(';'))
            {
                if (!Directory.Exists(directory)) continue;
                foreach (string path in Directory.GetFiles(directory))
                {
                    // TODO: concatenate files, then load
                    if (!File.Exists(path)) continue;
                    LoadScript(game, path);
                }
            }
            return errorLog.ToString();
        }

        public static void ReloadAllScripts(Game game)
        {
            UnloadAllScripts();
            LoadAllScripts(game);
        }

        public static void UnloadAllScripts()
        {
            foreach (IScript script in loadedScripts)
            {
                script.Stop();
            }
            loadedScripts.Clear();
        }

        public static void LoadScript(Game game, string path)
        {
            Assembly assembly = null;
            switch (Path.GetExtension(path))
            {
                case ".exe":
                case ".dll":
                    assembly = LoadAssembly(path);
                    break;
                case ".cs":
                    assembly = CompileScript(path, cSharpCodeProvider);
                    break;
                case ".vb":
                    assembly = CompileScript(path, vBCodeProvider);
                    break;
            }

            LoadScript(game, assembly);
        }

        public static void LoadScript(Game game, Assembly assembly)
        {
            if (assembly != null)
            {
                foreach (IScript script in FindInterfaces<IScript>(assembly))
                {
                    loadedScripts.Add(script);
                    script.Start(game);
                }
                foreach (ICommand cmd in FindInterfaces<ICommand>(assembly))
                {
                    Commands.RegisterCommand(cmd);
                }
                foreach (IActionItem actionItem in FindInterfaces<IActionItem>(assembly))
                {
                    ActionItems.RegisterAction(actionItem);
                }
            }
        }

        public static Assembly CompileScript(string path, CodeDomProvider provider)
        {
            CompilerParameters compilerParameters = new CompilerParameters
            {
                GenerateExecutable = false,
                GenerateInMemory = true,
                IncludeDebugInformation = false
            };

            compilerParameters.ReferencedAssemblies.Add("System.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Core.dll");
            compilerParameters.ReferencedAssemblies.Add("System.Data.Linq.dll");
            compilerParameters.ReferencedAssemblies.Add(System.Reflection.Assembly.GetExecutingAssembly().Location);
            CompilerResults results = provider.CompileAssemblyFromFile(compilerParameters, path);
            if (!results.Errors.HasErrors)
            {
                return results.CompiledAssembly;
            }
            else
            {
                foreach (CompilerError error in results.Errors)
                    errorLog.AppendLine(error.ToString());
            }
            return null;
        }

        public static IEnumerable<IType> FindInterfaces<IType>(Assembly assembly)
        {
            foreach (Type t in assembly.GetTypes())
            {
                if (typeof(IType).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract)
                {
                    yield return (IType) Activator.CreateInstance(t);
                }
            }
        }

        public static Assembly LoadAssembly(string path)
        {
            return Assembly.LoadFile(path);
        }
    }
}
