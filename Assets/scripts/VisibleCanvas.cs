using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VisibleCanvas : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2)) 
        {
            canvas.enabled=!canvas.enabled;
        }
    }
}
