using System;
using System.Collections.Generic;

class Slides
{
    static int W, H, D;
    static void Main()
    {
        string[] WHD = Console.ReadLine().Split(' ');
        W = int.Parse(WHD[0]);
        H = int.Parse(WHD[1]);
        D = int.Parse(WHD[2]);

        string[, ,] cube = new string[W, H, D];

        for (int heigth = 0; heigth < H; heigth++)
        {
            string[] platform = Console.ReadLine().Split('|');
            for (int depth = 0; depth < D; depth++)
            {
                string[] line = platform[depth].Trim().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries);
                for (int width = 0; width < W; width++)
                {
                    cube[width, heigth, depth] = line[width];
                }
            }
        }

        string[] WD = Console.ReadLine().Split(' ');
        int ballW = int.Parse(WD[0]);
        int ballD = int.Parse(WD[1]);
        int ballH = 0;

        bool stuck = false;
        bool escape = false;

        while (!stuck && !escape)
        {
            WhatToDo(cube, ref ballW, ref ballH, ref ballD, ref stuck, ref escape);
        }

        if (stuck)
        {
            Console.WriteLine("No");
            Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
        }
        else
        {
            Console.WriteLine("Yes");
            Console.WriteLine("{0} {1} {2}", ballW, ballH, ballD);
        }
    }

    static void WhatToDo(string[, ,] cube, ref int ballW, ref int ballH, ref int ballD, ref bool stuck, ref bool escape)
    {
        switch (cube[ballW, ballH, ballD][0])
        {
            case 'S':
                {
                    MoveMe(cube, ref ballW, ref ballH, ref ballD, ref stuck,ref escape);
                    return;
                }
            case 'T':
                {
                    string[] WD = cube[ballW, ballH, ballD].Substring(1).Split(new char[]{' '}, StringSplitOptions.RemoveEmptyEntries);
                    ballW = int.Parse(WD[0]);
                    ballD = int.Parse(WD[1]);
                    WhatToDo(cube, ref ballW, ref ballH, ref ballD, ref stuck, ref escape);
                }
                break;
            case 'B':
                {
                    stuck = true;
                    return;
                }
            case 'E':
                {
                    ballH++;
                    if (ballH == H-1)
                    {
                        escape = true;
                    }
                    return;
                }
        }
    }

    static void MoveMe(string[, ,] cube, ref int ballW, ref int ballH, ref int ballD, ref bool stuck,ref bool escape)
    {
        switch (cube[ballW, ballH, ballD].Substring(1).Trim())
        {
            case "L":
                {
                    if (ballW - 1 < 0 && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballW--;
                        ballH++;
                    }
                }
                break;
            case "R":
                {
                    if (ballW + 1 == W && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballW++;
                        ballH++;
                    }
                }
                break;
            case "F":
                {
                    if (ballD - 1 < 0 && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballD--;
                        ballH++;
                    }
                }
                break;
            case "B":
                {
                    if (ballD + 1 ==D && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballD++;
                        ballH++;
                    }
                }
                break;
            case "FL":
                {
                    if ((ballD - 1 < 0||ballW-1<0) && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballW--;
                        ballD--;
                        ballH++;
                    }
                }
                break;
            case "FR":
                {
                    if ((ballD - 1 < 0 || ballW +1==W) && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballW++;
                        ballD--;
                        ballH++;
                    }
                }
                break;
            case "BL":
                {
                    if ((ballD + 1 == D||ballW-1<0 )&& ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballW--;
                        ballD++;
                        ballH++;
                    }
                }
                break;
            case "BR":
                {
                    if ((ballD + 1 == D || ballW+1==W) && ballH != H - 1)
                    {
                        stuck = true;
                        return;
                    }
                    else
                    {
                        if (ballH == H-1)
                        {
                            escape = true;
                            return;
                        }
                        ballW++;
                        ballD++;
                        ballH++;
                    }
                }
                break;
        }
    }
}
