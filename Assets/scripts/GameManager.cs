using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    /// <summary>
    /// В данном случае этот скрипт побольшей части связующий
    /// </summary>
    public float score { get; private set; }

    private SpawnBullet bullet;

    private void Awake()
    {
        bullet = FindObjectOfType<SpawnBullet>();
    }
    public bool GetCheck() 
    {
        return bullet.singleShoot;        
    }
    public void GetScore(Scores scores, float multiplier=1)
    {
        SetScore(this.score + (scores.points * multiplier));
    }
    private void SetScore(float score)
    {
        this.score = score;
    }
}
