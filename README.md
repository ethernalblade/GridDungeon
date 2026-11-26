# GridDungeon

A small text-based maze game for the console, written in C# (.NET).
Explore a foggy maze, collect all the coins, avoid the hidden traps and find the door.

## Gameplay

- Collect **all coins**. When you pick up the last one, the door opens.
- Walk into the open door to win.
- You start with **10 HP**. Every trap costs you 1 HP. If your HP reaches 0, you lose.
- Traps are **hidden**. When you step on one, it is marked with `*` and does not hurt again.
- **Fog of war:** you only see a small area around you. Cells you have already explored stay visible.
- After a win or a loss you can start a new game or quit.

| Symbol | Meaning |
|--------|---------|
| `@`    | Player  |
| `#`    | Wall    |
| `.`    | Floor   |
| `M`    | Coin    |
| `D`    | Closed door (blocks your way) |
| `O`    | Open door (walk in to win) |
| `*`    | Triggered trap |
| `?`    | Not explored yet |

Hidden traps look like normal floor until you step on them.

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
    ├── Player.cs
    └── maps/
        └── level1.txt
```

| File | Responsibility |
|------|----------------|
| `Program.cs` | Game loop, keyboard input, win/lose check, "play again" question |
| `Map.cs` | Loads the map from a file, draws it, checks walls and the door, handles coins, hidden traps and the fog of war |
| `Player.cs` | Player state (position, HP, coins) and movement |
| `maps/level1.txt` | The level data |

## Roadmap

Planned ideas, the order may change:

- [x] v1: playable maze with coins, traps and HP
- [x] v2: split the code into classes (`Map`, `Player`)
- [x] v3: hidden traps, fog of war, bigger map
- [x] v4: load maps from text files

Maybe later:

- [ ] v5: chests, inventory and items (item data loaded from files)
- [ ] v6: enemies and turn-based combat
- [ ] v7: several levels (one map file each)

## Known limitations

Things I plan to clean up as I learn more C#:

- Directions and tile results are plain strings and characters; an `enum` would be safer.
- Player fields are public; properties would protect them.
- `Map` is static, so only one map can be loaded at a time.
- The player start position (row 20, column 0) is fixed in `Player.cs`, so the map file must have 21 rows.
- There is no error handling yet: if the map file is missing or broken, the game crashes at startup.

## About

Learning project. I am learning C# and building this game step by step.
