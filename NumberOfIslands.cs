public static class Program 
    {
        public static void Main(string[] args)
        {
            var lands = new int[][]
            {
                new[] {1, 1, 0, 1},
                new[] {0, 1, 1, 0},
                new[] {1, 0, 0, 1},
                new[] {1, 1, 1, 1}
            };
            var num = NumberOfIslands(lands);
            Console.WriteLine(num);
        }

        private static int NumberOfIslands(int[][] lands)
        {
            if (lands.Length == 0)
            {
                return 0;
            }
            
            var visited = new bool[lands.Length][];
            for (int i = 0; i < lands.Length; i++)
            {
                visited[i] = new bool[lands[0].Length];
            }

            var islands = 0;

            for (int i = 0; i < lands.Length; i++)
            {
                for (int j = 0; j < lands[0].Length; j++)
                {
                    if (visited[i][j])
                    {
                        continue;
                    }

                    if (lands[i][j] == 1)
                    {
                        MarkIsland(lands, visited, i, j);
                        islands++;
                    }
                }
            }

            return islands;
        }

        private static void MarkIsland(int[][] lands,
            bool[][] visited,
            int i,
            int j)
        {
            if (visited[i][j])
                return;
            visited[i][j] = true;
            
            if (GetItemSafe(lands, i - 1, j) == 1)
                MarkIsland(lands, visited, i - 1, j);
            if (GetItemSafe(lands, i + 1, j) == 1)
                MarkIsland(lands, visited, i + 1, j);
            if (GetItemSafe(lands, i, j - 1) == 1)
                MarkIsland(lands, visited, i, j - 1);
            if (GetItemSafe(lands, i, j + 1) == 1)
                MarkIsland(lands, visited, i, j + 1);
        }

        private static int GetItemSafe(int[][] lands, int i, int j)
        {
            if (i < 0)
                return -1;
            if (j < 0)
                return -1;
            if (i > lands.Length - 1)
                return -1;
            if (j > lands[0].Length - 1)
                return -1;

            return lands[i][j];
        }
    }
