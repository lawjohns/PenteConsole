using System;
using System.Diagnostics;

namespace PenteConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            gameBoard[0] = 1;
            gameBoard[1] = 1;
            gameBoard[13] = 1;
            gameBoard[15] = 1;
            gameBoard[20] = 1;

            Player = 2;
            gameBoard[2] = 2;
            gameBoard[3] = 2;
            gameBoard[4] = 2;
            gameBoard[5] = 2;
            gameBoard[6] = 2;

            CheckForWin(4);

            PrintBoard();

            Player = 1;
            gameBoard[61] = 1;
            gameBoard[62] = 2;
            gameBoard[63] = 2;
            gameBoard[64] = 1;

            PrintBoard();

            CheckForCapture(64);

            PrintBoard();

            Console.ReadLine();
        }
            // Game veriables
        private static int[] gameBoard = {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0,
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        private static readonly int[][] winningMoves = new int[20][] {
        // Hrizontal Win
            new int[4] { -4, -3, -2, -1 },
            new int[4] { -3, -2, -1, 1 },
            new int[4] { -2, -1, 1, 2 },
            new int[4] { -1, 1, 2, 3 },
            new int[4] { 1, 2, 3, 4 },
            // Virtical Win
            new int[4] { -40, -30, -20, -10 },
            new int[4] { -30, -20, -10, 10 },
            new int[4] { -20, -10, 10, 20 },
            new int[4] { -10, 10, 20, 30 },
            new int[4] { 10, 20, 30, 40 },
            // Left Top Diagnal win
            new int[4] { -44, -33, -22, -11 },
            new int[4] { -33, -22, -11, 11 },
            new int[4] { -22, -11, 11, 22 },
            new int[4] { -11, 11, 22, 33 },
            new int[4] { 11, 22, 33, 44 },
            // Right Top Diagnal Win
            new int[4] { -36, -27, -18, -9 },
            new int[4] { -27, -18, -9, 9 },
            new int[4] { -18, -9, 9, 18 },
            new int[4] { -9, 9, 18, 27 },
            new int[4] { 9, 18, 27, 36 }
        };

        private static int[][] capMoves = new int[8][] {
            // Horizontal Capture
            new int[3] { 1, 2, 3 },
            new int[3] { -1, -2, -3 },
            // Virtical Capture 
            new int[3] { 10, 20, 30 },
            new int[3] { -10, -20, -30 },
            // Left Top Diagnal Capture
            new int[3] { 11, 22, 33 },
            new int[3] { -11, -22, -33 },
            // Left Top Diagnal Capture
            new int[3] { 9, 18, 27 },
            new int[3] { -9, -18, -27 }
        };

        // Player Access
        private static int Player { get; set; }

        // Game Status Access
        private static bool GameStatus { get; set; }

        // P1 Score Access
        private static int PlayerOneScore { get; set; }

        // P2 Score Access
        private static int PlayerTwoScore { get; set; }

        private static void PlayGame()
        {

        }

        private static void PrintBoard()
        {
            Console.WriteLine("_____________________________________________________________");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[0], gameBoard[1], gameBoard[2], gameBoard[3], gameBoard[4], gameBoard[5], gameBoard[6], gameBoard[7], gameBoard[8], gameBoard[9]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[10], gameBoard[11], gameBoard[12], gameBoard[13], gameBoard[14], gameBoard[15], gameBoard[16], gameBoard[17], gameBoard[18], gameBoard[19]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[20], gameBoard[21], gameBoard[22], gameBoard[23], gameBoard[24], gameBoard[25], gameBoard[26], gameBoard[27], gameBoard[28], gameBoard[29]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[30], gameBoard[31], gameBoard[32], gameBoard[33], gameBoard[34], gameBoard[35], gameBoard[36], gameBoard[37], gameBoard[38], gameBoard[39]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[40], gameBoard[41], gameBoard[42], gameBoard[43], gameBoard[44], gameBoard[45], gameBoard[46], gameBoard[47], gameBoard[48], gameBoard[49]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[50], gameBoard[51], gameBoard[52], gameBoard[53], gameBoard[54], gameBoard[55], gameBoard[56], gameBoard[57], gameBoard[58], gameBoard[59]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[60], gameBoard[61], gameBoard[62], gameBoard[63], gameBoard[64], gameBoard[65], gameBoard[66], gameBoard[67], gameBoard[68], gameBoard[69]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[70], gameBoard[71], gameBoard[72], gameBoard[73], gameBoard[74], gameBoard[75], gameBoard[76], gameBoard[77], gameBoard[78], gameBoard[79]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[80], gameBoard[81], gameBoard[82], gameBoard[83], gameBoard[84], gameBoard[85], gameBoard[86], gameBoard[87], gameBoard[88], gameBoard[89]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
            Console.WriteLine("|     |     |     |     |     |     |     |     |     |     |");
            Console.WriteLine("|  {0}  |  {1}  |  {2}  |  {3}  |  {4}  |  {5}  |  {6}  |  {7}  |  {8}  |  {9}  |", gameBoard[90], gameBoard[91], gameBoard[92], gameBoard[93], gameBoard[94], gameBoard[95], gameBoard[96], gameBoard[97], gameBoard[98], gameBoard[99]);
            Console.WriteLine("|_____|_____|_____|_____|_____|_____|_____|_____|_____|_____|");
        }

        private static void MakeMove(int place)
        {
            int boardSpot = place - 1;

            if (GameStatus == true)
            {
                if (gameBoard[boardSpot] == 0)
                {
                    gameBoard[boardSpot] = Player;
                    CheckForWin(boardSpot);
                    CheckForCapture(boardSpot);
                    Player = Player == 1 ? 2 : 1;
                }
            }
        }

        private static void ResetBoard()
        {
            foreach (int spot in gameBoard) { gameBoard[spot] = 0; }
            Player = 1;
            GameStatus = true;
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
        }

        private static bool CheckForCapture(int piece)
        {
            foreach (int[] check in capMoves)
            {
                int p1 = piece + check[0],
                    p2 = piece + check[1],
                    p3 = piece + check[2];

                // Check for valid move
                if ((p1 > -1 && p1 <= 99) &&
                    (p3 > -1 && p3 <= 99))
                {
                    Debug.WriteLine("Check is valid {0} = {1}, {2} = {3}, {4} = {5}", p1, gameBoard[p1], p2, gameBoard[p2], p3, gameBoard[p3]);
                    // Capture opponents pieces
                    if ((gameBoard[p1] != 0) && (gameBoard[p1] != Player) && (gameBoard[p1] == gameBoard[p2]) && (gameBoard[p3] == Player))
                    {
                        Debug.WriteLine("Capture!");
                        if (Player == 1) PlayerOneScore += 1;
                        else PlayerTwoScore += 1;

                        gameBoard[p1] = 0;
                        gameBoard[p2] = 0;

                        Debug.WriteLine("Capture Move done");
                    }
                }
            }

            if (PlayerOneScore == 5 || PlayerTwoScore == 5)
            {
                GameStatus = false;

                return true;
            }

            return false;
        }

        private static bool CheckForWin(int piece)
        {
            foreach (int[] check in winningMoves)
            {
                if ((piece + check[0]) > -1 && (piece + check[3]) < 100)
                {
                    int p1 = GetOnesPlace(piece + check[0]),
                        p2 = GetOnesPlace(piece + check[1]),
                        p3 = GetOnesPlace(piece + check[2]),
                        p4 = GetOnesPlace(piece + check[3]);

                    // Check if win case is valid
                    if ((p1 < p2 && p2 < p3 && (p3 < p4 || p4 == 0)) ||
                        p4 == 0 ||
                        ((p1 == 0 || p1 > p2) && p2 > p3 && p3 > p4) ||
                        p1 == p4)
                    {
                        int match = 0;

                        // Check for matches in win case
                        foreach (int item in check)
                        {
                            if (gameBoard[piece + item] == Player) { match++; }
                            else break;
                        }

                        // If all 4 match, win case successful
                        if (match == 4)
                        {
                            Debug.WriteLine("Winner Player {0}", Player);

                            GameStatus = false;

                            return true;
                        }
                    }

                }

            }

            // Check for draw
            foreach (int place in gameBoard)
            {
                if (place != 0)
                {
                    if (place == 99)
                    {
                        GameStatus = false;

                        return true;
                    }
                }
                else break;
            }

            return false;
        }

        private static int GetOnesPlace(int place)
        {
            int returnPlace = place;

            while (place > 9) { returnPlace -= 10; }

            return returnPlace;
        }
    }
}