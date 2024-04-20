using System.Numerics;
using Raylib_cs;

public class Program
{
    public static void Main()
    {
        Raylib.InitWindow(500, 500, "Black is Coming");
        Random rd = new Random();
        // 生成A
        int gridCount = 250000;
        bool[] arr = new bool[gridCount];
        int index;
        for (int i = 0; i < 200000; i++)
        {
            do
            {
                int x = rd.Next(1, 500);
                int y = rd.Next(1, 500);
                index = GetIndex(x, y);
            } while (arr[index]);
            // 生成的red设为true；
            arr[index] = true;

        }
        int[] blacksIndex = new int[200000];
        int blackCount = 0;
        int blackCountTemp;
        // 生成第一个黑点
        Vector2 firstBlack = new Vector2(250, 250);
        int blackIndex = 249 * 500 + 249;
        blacksIndex[blackCount] = blackIndex;
        blackCount++;
        blackCountTemp = blackCount;
        // System.Console.WriteLine(GetIndex(250, 249) + " " + BackVector(GetIndex(250, 249))+" "+arr[GetIndex(250, 249)]);
        // System.Console.WriteLine(GetIndex(250, 251) + " " + BackVector(GetIndex(250, 251))+" "+arr[GetIndex(250, 241)]);
        // System.Console.WriteLine(GetIndex(251, 250) + " " + BackVector(GetIndex(251, 250))+" "+arr[GetIndex(251, 250)]);
        // System.Console.WriteLine(GetIndex(249, 250) + " " + BackVector(GetIndex(249, 250))+" "+arr[GetIndex(249, 250)]);

        while (!Raylib.WindowShouldClose())
        {
            float dt = Raylib.GetFrameTime();
            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.White);

            int upIndex;
            int downIndex;
            int rightIndex;
            int leftIndex;
            // draw
            for (int i = 0; i < blackCountTemp; i++)
            {
                var bl = blacksIndex[i];
                Vector2 blPos = BackVector(bl);
                upIndex = GetIndex((int)blPos.X, (int)blPos.Y - 1);
                downIndex = GetIndex((int)blPos.X, (int)blPos.Y + 1);
                rightIndex = GetIndex((int)blPos.X + 1, (int)blPos.Y);
                leftIndex = GetIndex((int)blPos.X - 1, (int)blPos.Y);
                // 有点
                if (arr[upIndex])
                {
                    arr[upIndex] = false;
                    blacksIndex[blackCount] = upIndex;
                    blackCount++;
                }
                if (arr[downIndex])
                {
                    arr[downIndex] = false;
                    blacksIndex[blackCount] = downIndex;
                    blackCount++;
                }
                if (arr[rightIndex])
                {
                    arr[rightIndex] = false;
                    blacksIndex[blackCount] = rightIndex;
                    blackCount++;
                }
                if (arr[leftIndex])
                {
                    arr[leftIndex] = false;
                    blacksIndex[blackCount] = leftIndex;
                    blackCount++;
                }
            }
            blackCountTemp = blackCount;

            // for (int i = 0; i < arr.Length; i++)
            // {
            //     if (arr[i])
            //     {
            //         Raylib.DrawPixelV(BackVector(i), Color.Red);
            //     }
            // }
            System.Console.WriteLine(blackCount);
            for (int i = 0; i < blackCount; i++)
            {
                var bl = blacksIndex[i];
                Vector2 blPos = BackVector(bl);
                upIndex = GetIndex((int)blPos.X, (int)blPos.Y - 1);
                downIndex = GetIndex((int)blPos.X, (int)blPos.Y + 1);
                rightIndex = GetIndex((int)blPos.X + 1, (int)blPos.Y);
                leftIndex = GetIndex((int)blPos.X - 1, (int)blPos.Y);
                Raylib.DrawPixelV(BackVector(upIndex), Color.Black);
                Raylib.DrawPixelV(BackVector(downIndex), Color.Black);
                Raylib.DrawPixelV(BackVector(rightIndex), Color.Black);
                Raylib.DrawPixelV(BackVector(leftIndex), Color.Black);
            }

            Raylib.EndDrawing();
        }
        Raylib.CloseWindow();

    }

    static int GetIndex(int x, int y)
    {
        // if (x <= 1)
        // {
        //     x = 1;
        // }
        // if (y <= 1)
        // {
        //     y = 1;
        // }
        // if (x >= 500)
        // {
        //     x = 500;
        // }
        // if (y >= 500)
        // {
        //     y = 500;
        // }
        x = Math.Clamp(x, 1, 500);
        y = Math.Clamp(y, 1, 500);
        return (y - 1) * 500 + x - 1;
    }

    static Vector2 BackVector(int index)
    {
        Vector2 v1 = new Vector2();
        v1.X = index % 500 + 1;
        v1.Y = (int)index / 500 + 1;
        return v1;
    }

    static void TryAddInex(bool[] arr, int index, int[] blacksIndex, ref int blackCount)
    {
        if (arr[index])
        {
            arr[index] = false;
            blacksIndex[blackCount] = index;
            blackCount++;
        }
    }

}
