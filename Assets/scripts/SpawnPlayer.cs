using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField]
    private float posY = -2f;
    private Vector3 spawnTransform;
    private void Start()
    {
        spawnTransform = new Vector3(0, posY, 0);
    }
    void FixedUpdate()
    {
        if (this.gameObject.transform.position == spawnTransform) 
        {
            this.gameObject.transform.position = spawnTransform;        
        }
    }
}
