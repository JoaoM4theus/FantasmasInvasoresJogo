using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoTiroControle : MonoBehaviour
{
    //Variavel bala do tipo Transform
    private Transform bullet;
    public float speed;


    void Start()
    {
        bullet = GetComponent<Transform>();//Pegando componenets do tipo Transform para a variavel.
    }

    void FixedUpdate() {
        //Setando da onde a bala verticalmente e também que seja um disparo para baixo.
        bullet.position += Vector3.up * -speed;

        //Caso a bala passe do -10 na tela, será destruida.
        if (bullet.position.y <= -10) {
            Destroy(bullet.gameObject);
        }
    }

    //Criando os metodos de colisão. Caso a bala entre em colisão com o Player, tanto ele como a bala serão destruída e dando o GameOver = true(script de GameOver);
    //Se a bala atingir a base: perderá 1 de vida(Base possuem 2 vidas) e destruindo a bala logo após.
    // Criando uma instanciacao de Vidabase para variavel vidaBase.
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag.Equals("Player")) {
            Destroy(col.gameObject);
            Destroy(bullet.gameObject);
            GameOver.playerMorto = true;
        }
        else if(col.gameObject.tag.Equals("Base")) {
            GameObject playerBase = col.gameObject;
            VidaBase vidaBase = playerBase.GetComponent<VidaBase>();
            vidaBase.vida -= 1;
            Destroy(bullet.gameObject);
        }
    }
}
