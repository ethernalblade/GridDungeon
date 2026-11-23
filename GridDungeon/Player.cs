    namespace GridDungeon
{
    class Player
    {
        public int coins = 0;
        public int hp = 14;
        public int row = 20;
        public int col = 0;
        
        public void Move(string direction)
        {
            switch (direction)
            {
                case "up":
                    if (Map.MovementValidation(row, col, direction))
                    {
                        row--;
                    }
                    break;
                case "down":
                    if (Map.MovementValidation(row, col, direction))
                    {
                        row++;
                    }
                    break;
                case "left":
                    if (Map.MovementValidation(row, col, direction))
                    {
                        col -= 1;
                    }
                    break;
                case "right":
                    if (Map.MovementValidation(row, col, direction))
                    {
                        col += 1;
                    }
                    break;
            }
            
        }
        public void AddCoin()
        {
            coins++;
        }
        public void ReduceHp()
        {
            hp--;
        }

    }
}
