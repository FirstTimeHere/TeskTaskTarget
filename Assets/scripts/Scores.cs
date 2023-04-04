using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Scores : MonoBehaviour
{
    private Rigidbody rb;
    public int points = 70;
    [SerializeField] private float destroyTime = 3f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.mass = 100.0f;
    }
    /// <summary>
    /// сделать здесь коэффициент, или откзаться писать его здесь через виртуальные методы
    /// </summary>
    protected virtual void GetPoint()
    {
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
