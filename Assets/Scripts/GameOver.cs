using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    //Criando uma variavel do tipo bool pra verificar se o player morreu ou nãp
    public static bool playerMorto = false;
    private Text gameOver; //Texto de gameover

    void Start()
    {
        gameOver = GetComponent<Text>();//Pegando o componente texto.
        gameOver.enabled = false;//Atribuindo falso para ficar desabilitado
    }

    // Update is called once per frame
    void Update()
    {
        //Caso playerMorto venha a ser True entrara no IF, assim habilitando a tela de gameover e pausando o jogo.
        if (playerMorto) {
            Time.timeScale = 0;
            gameOver.enabled = true;
        }  
    }
}
