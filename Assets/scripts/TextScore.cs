using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text scoreText;
    [SerializeField] private StringBuilder builder; // для "оптимизации"
    private int lenghtBuilder = 10;

    private void Start()
    {
        scoreText = this.gameObject.GetComponent<Text>();
        builder = new StringBuilder(lenghtBuilder);
        
    }
    void Update()
    {
        builder.Length = 0;
        builder.Append("Ваш счет ");
        builder.Append(gameManager.score.ToString());
        scoreText.color = Color.white;
        scoreText.text = builder.ToString();
    }
}
