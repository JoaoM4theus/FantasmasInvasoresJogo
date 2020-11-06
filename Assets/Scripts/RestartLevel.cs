using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    void Update()
    {
            //Toda vez que o jogador apertar R, reseta o jogo para o começo.
            if (Input.GetKeyDown(KeyCode.R)) {
            PlayerScore.playerScore = 0;
            GameOver.playerMorto = false;
            Time.timeScale = 1;

            SceneManager.LoadScene("Scene_001");
            }        
    }
}
