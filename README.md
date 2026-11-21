# GridDungeon

A small text-based maze game for the console, written in C# (.NET).
Find your way through the maze, collect all the coins and avoid the traps.

## Gameplay

- Collect all **3 coins** to win.
- You start with **2 HP**. Every trap costs you 1 HP. If your HP reaches 0, you lose.
- Coins and traps disappear once you step on them.
- After a win or a loss you can start a new game or quit.

| Symbol | Meaning |
|--------|---------|
| `@`    | Player  |
| `#`    | Wall    |
| `.`    | Floor   |
| `M`    | Coin    |
| `T`    | Trap    |

## Controls

| Key | Action |
|-----|--------|
| `W` / `↑` | Move up |
| `S` / `↓` | Move down |
| `A` / `←` | Move left |
| `D` / `→` | Move right |
| `Esc` | Quit |

## How to run

Requirements: [.NET 10 SDK](https://dotnet.microsoft.com/download) or newer.

```
git clone https://github.com/ethernalblade/GridDungeon.git
cd GridDungeon
dotnet run --project GridDungeon
```

## Roadmap

Planned ideas, the order may change:

- [x] v1: playable maze with coins, traps and HP
- [ ] v2: rewrite with classes (player, map, ...)
- [ ] v3: hidden traps, fog of war, bigger maps
- [ ] v4: maps and item data loaded from files
- [ ] v5: chests, inventory and items
- [ ] v6: enemies and turn-based combat
- [ ] v7: high score table (SQLite)

## About

Learning project. I am learning C# and building this game step by step.
