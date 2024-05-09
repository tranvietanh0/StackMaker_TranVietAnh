using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.StackMaker
{
    public enum Direction
    {
        None,
        Left,
        Right,
        Forward,
        Backward
    }

    public enum GameLayer
    {
        None,
        Wall
    }

    public enum GameTag
    {
        None,
        Player,
        Wall,
        Brick,
        UnBrick,
        Finish,
        Destination,
        Slow
    }

    public enum GamePref
    {
        CurLevelId,
        Score,
        LevelUnlocked
    }
}