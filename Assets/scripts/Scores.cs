using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private Rigidbody rb;

    public float points = 70;
    [SerializeField] private float destroyTime = 3f;
    [SerializeField] private float multiplierSingleShotAndSpeedOne = 0.5f;
    [SerializeField] private float multiplierFiveShotAndSpeedOne = 0.1f;
    [SerializeField] private float multiplierFiveShotAndSpeedSecond = 0.2f;

    private bool singleCheck;

    [SerializeField, HideInInspector] GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody>(); 
        rb.isKinematic = true;
        rb.mass = 10.0f;
    }

    protected virtual void GetPoint()
    {
        //вроде как то можно закинуть findobject в массив, но у меня не получилось
        singleCheck = gameManager.GetCheck();
        if (!singleCheck)
        {
            gameManager.GetScore(this, multiplierSingleShotAndSpeedOne);
        }
        gameManager.GetScore(this, multiplierFiveShotAndSpeedOne);
        //gameManager.GetScore(this);//multi second speed = 1
        rb.isKinematic = false;  
    }

    private void OnCollisionEnter(Collision point)
    {
        if (point.gameObject.layer ==LayerMask.NameToLayer("Bullet"))
        {
            GetPoint();
            Destroy(gameObject,destroyTime);
        }
    }
}
