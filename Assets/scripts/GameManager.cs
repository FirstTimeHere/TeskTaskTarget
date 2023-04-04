using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score { get; private set; }

    public void GetScore(Scores scores)
    {
        SetScore(this.score + scores.points);
    }
    private void SetScore(int score)
    {
        this.score = score;
    }
}
