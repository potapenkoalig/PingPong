using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class GameData
{
    public int bestScoreTop, bestScoreDown;
    public float ball_color_r, ball_color_g, ball_color_b;

    public GameData(int scoreTop, int scoreDown, Color color)
    {
        bestScoreTop  = scoreTop;
        bestScoreDown = scoreDown;
        ball_color_r  = color.r;
        ball_color_g  = color.g;
        ball_color_b  = color.b;
    }
}
