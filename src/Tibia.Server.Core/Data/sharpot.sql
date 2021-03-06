DROP TABLE IF EXISTS "Account";
CREATE TABLE [Account] (
    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [Name] text NOT NULL COLLATE NOCASE UNIQUE,
    [Password] text NOT NULL
);
DROP TABLE IF EXISTS "Player";
CREATE TABLE [Player] (
    [Id] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [AccountId] integer NOT NULL,
    [Name] text NOT NULL COLLATE NOCASE UNIQUE,
    [Gender] integer NOT NULL,
    [Vocation] integer NOT NULL DEFAULT 0,
    [Level] integer NOT NULL DEFAULT 1,
    [MagicLevel] integer NOT NULL DEFAULT 0,
    [Experience] integer NOT NULL DEFAULT 0,
    [MaxHealth] integer NOT NULL DEFAULT 100,
    [MaxMana] integer NOT NULL DEFAULT 100,
    [Capacity] integer NOT NULL DEFAULT 0,
    [OutfitLookType] integer NOT NULL DEFAULT 128,
    [OutfitHead] integer NOT NULL DEFAULT 0,
    [OutfitBody] integer NOT NULL DEFAULT 0,
    [OutfitLegs] integer NOT NULL DEFAULT 0,
    [OutfitFeet] integer NOT NULL DEFAULT 0,
    [OutfitAddons] integer NOT NULL DEFAULT 0,
    [LocationX] integer,
    [LocationY] integer,
    [LocationZ] integer,
    [Direction] integer,
    [LastLogin] integer NOT NULL DEFAULT 0,
    CONSTRAINT [FK_Player_0] FOREIGN KEY ([AccountId]) REFERENCES [Account] ([Id])
);
DROP TABLE IF EXISTS "PlayerInventory";
CREATE TABLE [PlayerInventory] (
    [PlayerId] integer NOT NULL,
    [Slot] integer NOT NULL,
    [ItemUniqueId] integer NOT NULL,
    CONSTRAINT [PK_PlayerInventory] PRIMARY KEY ([PlayerId], [Slot]),
    CONSTRAINT [FK_PlayerInventory_0] FOREIGN KEY ([PlayerId]) REFERENCES [Player] ([Id]),
    CONSTRAINT [FK_PlayerInventory_1] FOREIGN KEY ([ItemUniqueId]) REFERENCES [Item] ([UniqueId])
);
CREATE TRIGGER Cascade_PlayerInventory_Delete DELETE ON PlayerInventory BEGIN
    DELETE FROM Item WHERE UniqueId = old.ItemUniqueId;
END;
DROP TABLE IF EXISTS "Item";
CREATE TABLE [Item] (
    [UniqueId] integer PRIMARY KEY AUTOINCREMENT NOT NULL,
    [ItemId] integer NOT NULL,
    [Extra] integer NOT NULL,
    [ParentUniqueId] integer,
    CONSTRAINT [FK_Item_1] FOREIGN KEY ([ParentUniqueId]) REFERENCES [Item] ([UniqueId])
);
CREATE TRIGGER Cascade_Item_Delete DELETE ON Item BEGIN
    DELETE FROM Item WHERE ParentUniqueId = old.UniqueId;
END;
PRAGMA recursive_triggers = true;