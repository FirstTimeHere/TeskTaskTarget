using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLifeTime : MonoBehaviour
{
    [SerializeField] private float bulletLife = 3f;

    private void Awake()
    {
        Destroy(gameObject, bulletLife);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Target")
        {
            Destroy(this.gameObject);
        }
    }
}
