using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private Rigidbody rb;
     //public SpawnBullet Bullet; //�������� �������� ����� �������

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
    /// ������� ����� �����������, ��� ��������� ������ ��� ����� ����� ����������� ������
    /// </summary>

    protected virtual void GetPoint()
    {
        //����� ��� �� ����� �������� findobject � ������, �� � ���� �� ����������
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
