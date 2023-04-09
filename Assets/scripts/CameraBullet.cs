using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraBullet : MonoBehaviour
{
    [SerializeField] private Transform bulletTransform;
    [SerializeField] private Camera bulletCamera;
    [SerializeField] private Vector3 offset;
    [SerializeField] private bool cameraOnOff=false;

    private void Awake()
    {
        bulletTransform=this.transform;
        bulletCamera.gameObject.SetActive(cameraOnOff);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) 
        {
            cameraOnOff = !cameraOnOff;
            bulletCamera.gameObject.SetActive(cameraOnOff);
            transform.position = bulletTransform.position + offset;
            //--------------------------------------------------
            //slowmotion вообще так делать нельзя, и надо подправить, чтобы время возвращалось
            //но это "костыль" на время для красоты
            //Time.timeScale = 0.1f;
            //Time.fixedDeltaTime = Time.timeScale * 0.02f;
        }
        
    }
}
