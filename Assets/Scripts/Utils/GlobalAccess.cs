using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalAccess
{
    static float speedupMultiplier = 1;
    static int boxCount = 0;
    static float score = 0;

    public static float SpeedupMultiplier 
    {
        get { return speedupMultiplier; }
        set { speedupMultiplier = value; }
    }

    public static int BoxCount 
    {
        get { return boxCount; }
        set { boxCount = value; }
    }

    public static float Score 
    {
        get { return score; }
        set { score = value; }
    }
    public static int WeightedRandom(float[] weights) 
    {
        int running = 0;
        List<int> ranges = new List<int>();
        foreach (float weight in weights)
        {
            running += (int)weight;
            ranges.Add(running);
        }

        running = Random.Range(0, ranges[ranges.Count - 1]);

        int choice = 0;
        foreach (int range in ranges)
        {
            if (running < range) break;
            else choice += 1;
        }
        return choice;
    }
}
