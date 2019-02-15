///<summary>
/// Written by: Charley Bein, Ben Tipton
/// File Summary: Class to be instantiated into the array, hold the token's color, and check for a win state
/// (General info in Program.cs)
/// </summary>

using System;
using System.Collections.Generic;


namespace ConnectTetris
{
    class Token
    {
        private int color;
        private int[,] neighbors = new int[3, 3];
        public LinkedListNode<Token[]> row;
        public int position;

        public Token() { color = 0; }
        public Token(int inColor) { color = inColor; }

        // Check each neighboring token for the same color
        public void CheckNeighbors()
        {
            for (int i = position - 1; i <= position + 1; i++)
            {
                int column = i - position + 1;
                if (row.Next.Value[i].color == this.color)
                {
                    neighbors[0, column] += 1;
                }
                if (row.Value[i].color == this.color && column != 1)
                {
                    neighbors[1, column] += 1;
                }
                if (row.Previous.Value[i].color == this.color)
                {
                    neighbors[2, column] += 1;
                }
            }

            int j = 1;
            int x = 0;
            int y = 0;

            // Loop through each direction (represented by the following values), and if there is the same color in one of the directions, recursively check that direction for more

            // 1 | 2 | 3
            // 4 |   | 6
            // 7 | 8 | 9
            while (j < 10)
            {
                if (neighbors[x, y] != 0)
                {
                    neighbors[x, y] = CheckLine(j);
                }
                j++;
                if (y < 2)
                {
                    y++;
                } else
                {
                    y = 0;
                    x++;
                }
            }



        }

        // Depending on which direction was passed, call the appropriate recursive function to get the total color count in that direction
        public int CheckLine(int dir)
        {
            switch (dir)
            {
                case 1:
                    return line1(0, this);
                case 2:
                    return line2(0, this);
                case 3:
                    return line3(0, this);
                case 4:
                    return line4(0, this);
                case 6:
                    return line6(0, this);
                case 7:
                    return line7(0, this);
                case 8:
                    return line8(0, this);
                case 9:
                    return line9(0, this);
                default:
                    return 0;

            }
        }

        // Add up the counts on opposite sides of the token, and return whether any of them are over 4, meaning a win state
        public bool CheckTot()
        {
            int v = neighbors[0, 1] + neighbors[2, 1] + 1;
            int h = neighbors[1, 0] + neighbors[1, 2] + 1;
            int d1 = neighbors[0, 0] + neighbors[2, 2] + 1;
            int d2 = neighbors[2, 0] + neighbors[0, 2] + 1;

            if (v >= 4 || h >= 4 || d1 >= 4 || d2 >= 4)
            {
                return true;
            } else { return false; }
        }

        // Store the node and index of the token for future use
        public void SetPos(LinkedListNode<Token[]> r, int p)
        {
            row = r;
            position = p;
        }

        // Set the color of the token
        public void SetColor(int c)
        {
            color = c;
        }

        // Return the color of the token
        public int GetColor()
        {
            return color;
        }

        // Recursively check the token in the given direction until a different color value is found, and return the total
        // (Each of these are identical, but in different directions)
        private int line1(int count, Token active)
        {
            Token next = active.row.Next.Value[active.position - 1];
            if (next.color == active.color)
            {
                return line1(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line2(int count, Token active)
        {
            Token next = active.row.Next.Value[active.position];
            if(next.color == active.color)
            {
                return line2(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line3(int count, Token active)
        {
            Token next = active.row.Next.Value[active.position + 1];
            if(next.color == active.color)
            {
                return line3(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line4(int count, Token active)
        {
            Token next = active.row.Value[active.position - 1];
            if(next.color == active.color)
            {
                return line4(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line6(int count, Token active)
        {
            Token next = active.row.Value[active.position + 1];
            if(next.color == active.color)
            {
                return line6(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line7(int count, Token active)
        {
            Token next = active.row.Previous.Value[active.position - 1];
            if(next.color == active.color)
            {
                return line7(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line8(int count, Token active)
        {
            Token next = active.row.Previous.Value[active.position];
            if(next.color == active.color)
            {
                return line8(count + 1, next);
            } else
            {
                return count;
            }
        }

        private int line9(int count, Token active)
        {
            Token next = active.row.Previous.Value[active.position + 1];
            if(next.color == active.color)
            {
                return line9(count + 1, next);
            } else
            {
                return count;
            }
        }

    }
}
