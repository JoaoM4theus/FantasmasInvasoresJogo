using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{

    public static float playerScore = 0;//Contagem de score
    private Text scoreText;//Texto score

    void Start()
    {
        scoreText = GetComponent<Text>();//Pegando o componente transform.
    }

    void Update()
    {
        float score = playerScore;//Atribuindo o valor
        scoreText.text = "Score: " + score;//Escrevendo a pontuação na tela junto com a tela de score.
    }
}
