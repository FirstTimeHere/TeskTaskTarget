using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private Rigidbody rb;
     //public SpawnBullet Bullet; //передать значение через делегат

    public float points = 70;
    [SerializeField] private float destroyTime = 3f;
    private float multiplier = 0.1f;
    private bool someBool;

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
    /// <summary>
    /// сделать здесь коэффициент, или откзаться писать его здесь через виртуальные методы
    /// </summary>

    protected virtual void GetPoint()
    {
        //вроде как то можно закинуть findobject в массив, но у меня не получилось
        someBool = gameManager.GetCheck();
        if (!someBool)
        {
            gameManager.GetScore(this, multiplier);
        }
        FindObjectOfType<GameManager>().GetScore(this);
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
