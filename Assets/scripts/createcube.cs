using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

public class createcube : MonoBehaviour
{
    /// <summary>
    /// Здесь создается мишень, и в начале создание проекта хотелось брать отсюда расстояние
    /// </summary>
    [SerializeField] private GameObject[] cube;
    [SerializeField] private Transform parent;
    [SerializeField] private Camera m_Camera;

    public int X;
    public int Y;
    private float camPos = 5f;
    [SerializeField] private float camRotX = 41f;
    [SerializeField] private float camRotY = -65f;
    public float Duration { get; private set; } = 20;
    private bool camerOnOff = false;


    void Start()
    {
        m_Camera.gameObject.SetActive(camerOnOff);
        m_Camera.transform.position = new Vector3(X + camPos, Y + camPos, Duration - camPos);
        m_Camera.transform.rotation = Quaternion.Euler(camRotX, camRotY, 0);

        for (int i = 0; i < cube.Length; i++)
        {
           Draw(X, Y, i,Duration);
        }
    }
    private void Update()
    {
        //режим камеры сверху
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            camerOnOff=!camerOnOff;
            m_Camera.gameObject.SetActive(camerOnOff);
        }
    }
    /// <summary>
    /// метод рисовки
    /// </summary>
    /// <param горизонталь="x"></param>
    /// <param вертикаль="y"></param>
    /// <param цвет кубика="color">(берется из массива)</param>
    private void Draw(int x, int y,int color,float duration=0)
    {
        for (int i = color ; i < x - color; i++) //X 
        {            
            Instantiate(cube[color],parent);
            cube[color].transform.position = new Vector3(i, color, duration);

            Instantiate(cube[color], parent);
            cube[color].transform.position = new Vector3(i + 1, y - color, duration);
        }

        for (int i = color; i < y-color; i++) //Y 
        {            
            Instantiate(cube[color], parent);
            cube[color].transform.position = new Vector3(color, i + 1, duration);
            
            Instantiate(cube[color], parent);
            cube[color].transform.position = new Vector3(x - color, i, duration);
        }
    }
}
