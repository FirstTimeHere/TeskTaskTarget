using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScore : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text scoreText;

    private void Start()
    {
        scoreText = this.gameObject.GetComponent<Text>();
        
    }
    void Update()
    {
        scoreText.color = Color.white;
        scoreText.text = "¬аш счет " + gameManager.score.ToString();
    }
}
