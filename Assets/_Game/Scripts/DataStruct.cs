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
        Wall,
        Brick,
        UnBrick
    }
}