using System.Numerics;
using Raylib_cs;

public static class Function
{

    public static bool IsInRange(Vector2 pos1, Vector2 pos2, float searchRange)
    {
        return Vector2.DistanceSquared(pos1, pos2) <= searchRange * searchRange;
    }
}