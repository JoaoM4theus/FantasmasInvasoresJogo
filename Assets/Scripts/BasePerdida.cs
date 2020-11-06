using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePerdida : MonoBehaviour
{
    //Criando uma variavel do tipo Transform
    public Transform playerBase;

    void Start()
    {
        //Pegando todos os componentes do tipo transform.
        playerBase = GetComponent<Transform>();
    }

    void Update()
    {
        //Se o numero de base contida no jogo for 0 o playerMorto sera true assim sendo GameOver (childCount serve para conta o numero de objetos no jogo a cada instante).
        if (playerBase.childCount == 0) {
            GameOver.playerMorto = true;
        }
    }
}
