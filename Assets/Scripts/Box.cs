using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box
{
    public int score;

    public Box prev;
    public Box next;

    public bool IsStrike, IsSpare;

    // New default box with no other frames in circulation -- AKA first box
    public Box()
    {
        score = 0;

        prev = null;
        next = null;

        IsStrike = false;
        IsSpare = false;
    }

    // Define box with additional boxes before or after
    public Box(Box previousBox = null, Box nextBox = null)
    {
        score = 0;

        prev = previousBox;
        next = nextBox;

        IsStrike = false;
        IsSpare = false;
    }
}
