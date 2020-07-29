namespace Tibia.Server.Core.Scripting
{
    public interface IScript
    {
        bool Start(Game game);
        bool Stop();
    }
}
