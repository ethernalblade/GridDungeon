# GridDungeon

A small text-based maze game for the console, written in C# (.NET).
Explore a foggy maze, collect all the coins and avoid the hidden traps.

## Gameplay

- Collect all coins to win.
- Every trap costs you 1 HP. If your HP reaches 0, you lose.
- Traps are **hidden**. When you step on one, it is marked with `*` and does not hurt again.
- **Fog of war:** you only see a small area around you. Cells you have already explored stay visible.
- After a win or a loss you can start a new game or quit.

| Symbol | Meaning |
|--------|---------|
| `@`    | Player  |
| `#`    | Wall    |
| `.`    | Floor   |
| `M`    | Coin    |
| `*`    | Triggered trap |
| `?` | Not explored yet |

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

## Project structure

```
GridDungeon/
├── GridDungeon.slnx
├── README.md
└── GridDungeon/
    ├── GridDungeon.csproj
    ├── Program.cs
    ├── Map.cs
    └── Player.cs
```

| File | Responsibility |
|------|----------------|
| `Program.cs` | Game loop, keyboard input, win/lose check, "play again" question |
| `Map.cs` | The maze: builds it from text, draws it, checks walls, hidden traps, coins and the fog of war |
| `Player.cs` | Player state (position, HP, coins) and movement |

The maze is defined as an array of text lines in `Map.cs`, so changing the level only means editing those lines.

## Roadmap

Planned ideas, the order may change:

- [x] v1: playable maze with coins, traps and HP
- [x] v2: split the code into classes (`Map`, `Player`)
- [x] v3: hidden traps, fog of war, bigger map
- [ ] v4: load maps from text files
- [ ] v5: chests, inventory and items (item data loaded from files)
- [ ] v6: enemies and turn-based combat

## Known limitations

Things I plan to clean up as I learn more C#:

- Directions are plain strings; an `enum` would be safer.
- Player fields are public; properties would protect them.
- `Map` is static, so only one map can exist at a time (needed to change for loading maps from files).
- The number of coins to win and the start position are fixed values in the code, not read from the map.

## About

Learning project. I am learning C# and building this game step by step.
