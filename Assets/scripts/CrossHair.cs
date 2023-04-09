using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    [SerializeField] private RectTransform Crosshair;
    [SerializeField] private float sizeState;
    [SerializeField] private float scoreState;
    [SerializeField] private float sizeCurrent;
    [SerializeField] private float speed=10f;

    /// <summary>
    /// берем высоту и ширину
    /// каждый раз когда нажимаем кнопку прицеливания он должен уменьшаться
    /// </summary>
    private void Update()
    {
        if (isScored) 
        {
            sizeCurrent = Mathf.Lerp(sizeCurrent, scoreState, Time.deltaTime * speed);
        }
        else
        {
            sizeCurrent = Mathf.Lerp(sizeCurrent, sizeState, Time.deltaTime * speed);
        }

        Crosshair.sizeDelta=new Vector2(sizeCurrent, sizeCurrent);
    }
   private bool isScored
    {
        get
        { 
            if(Input.GetAxis("Fire2") != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
