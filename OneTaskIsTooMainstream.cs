using System;
using System.Collections.Generic;

class OneTaskIsTooMainstream
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        bool[] lamps = new bool[number];
        int counter=0;
        int time = 1;
        int lastPosition = 0;
        while (counter != number)
        {
            int position=0;
            while (lamps[position] != false)
            {
                position++;
            }
            lamps[position] = true;
            lastPosition = position+1;
            counter++;
            int teqOffLamps = 0;
            for (int i = position; i < lamps.Length; i++)
            {
                if (lamps[i] == false)
                {
                    teqOffLamps++;
                    if (teqOffLamps == time + 1)
                    {
                        lamps[i] = true;
                        counter++;
                        teqOffLamps = 0;
                        lastPosition = i + 1;
                    }
                }
            }
            time++;
        }
        Console.WriteLine(lastPosition);

        for (int i = 0; i < 2; i++)
        {
            BoundedOrNot(Console.ReadLine());
        }
    }

    static void BoundedOrNot(string line)
    {
        int[] movesX = { 1, 0, -1, 0 };
        int[] movesY = { 0, 1, 0, -1 };

        int direction = 0;
        int x=0, y = 0;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < line.Length; j++)
            {
                switch (line[j])
                {

                    case 'S':
                        x+= movesX[direction];
                        y+= movesY[direction];
                        break;
                    case 'L':
                        direction = (direction + 3) % 4; // +270 degrees, turns left
                        break;
                    case 'R':
                        direction = (direction + 1) % 4; // +90 degrees, turns right
                        break;
                }
            }
        }

        if (x == 0 && y == 0)
        {
            Console.WriteLine("bounded");
        }
        else
        {
            Console.WriteLine("unbounded");
        }
    }
}
