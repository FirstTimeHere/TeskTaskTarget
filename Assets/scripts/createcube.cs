using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class createcube : MonoBehaviour
{
    [SerializeField]
    private GameObject[] cube;
    public int X;
    public int Y;
    [SerializeField]
    private float Duration;
    
    void Start()
    {
        for (int i = 0; i < cube.Length; i++)
        {
           Draw(X, Y, i,Duration);
        }
    }
    /// <summary>
    /// ������ �������� �� ������� ���������� ������ (���� ������ 7 ����, �� ������ ������������)
    /// </summary>
    /// <param �����������="x"></param>
    /// <param ���������="y"></param>
    /// <param ���� ������="color">(������� �� �������)</param>
    private void Draw(int x, int y,int color,float duration=0)
    {
        for (int i = color ; i < x - color; i++) //X 
        {            
            Instantiate(cube[color]);
            cube[color].transform.position = new Vector3(i , color,duration);
            Instantiate(cube[color]);
            cube[color].transform.position = new Vector3(i + 1, y - color, duration);
        }

        for (int i = color; i < y-color; i++) //Y 
        {            
            Instantiate(cube[color]);
            cube[color].transform.position = new Vector3(color, i + 1, duration);
            
            Instantiate(cube[color]);
            cube[color].transform.position = new Vector3(x - color, i, duration);
        }
    }
}
