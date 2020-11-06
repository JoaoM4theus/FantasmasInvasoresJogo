using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoControle : MonoBehaviour
{
    public Transform inimigo;
    public float speed;

    public GameObject shot;
    public Text winText;
    public Text restartText;
    public float fireRate = 0.997f;

    // Start is called before the first frame update
    void Start()
    {
        /*
         * Atribuindo falso para os texto de Win e Restart
         * Implementando uma função InvokerRepeating(), essa que deixar a função passada por parametro em um loop.
         * inimigo => Pegando componentes do tipo Transforms.
         */
        winText.enabled = false;
        restartText.enabled = false;
        InvokeRepeating("MoverInimigo", 0.1f, 0.3f);
        inimigo = GetComponent<Transform>();
    }

    void MoverInimigo() 
    {
        
        //Setando um movimento padrão do inimigo.
        inimigo.position += Vector3.right * speed;

        //Percorrendo todos os inimigos
        foreach(Transform enemy in inimigo) {
            //Setando um limite para se mover na tela(quadro) e invertendo a velocidade.
            if (enemy.position.x < -10.2 || enemy.position.x > 10.5) {
                speed = -speed;
                inimigo.position += Vector3.down * 0.5f;
                return;
            }

            //Se o valor randomico for maior q o firerate, o inimigo vai efetuar um disparo. Instanciando shot, a posição e mantendo a sua rotação
            if(Random.value > fireRate) {
                Instantiate(shot, enemy.position, enemy.rotation);
            }
            
            //Se os inimigos chegar na barreira. A tela de GameOver vai aparecer e tambem parar o jogo
            if (enemy.position.y <= -2) {
                GameOver.playerMorto = true;
                Time.timeScale = 0; 
            }
        }

        //Se sobra somente um inimigo. Vou cancelar o InvokerRepeating padrão e acrescentar um diferente. Inimigo vai passar a se mover mais rápido na tela.
        if(inimigo.childCount == 1) {
            CancelInvoke();
            InvokeRepeating("MoverInimigo", 0.1f, 0.25f);
        }

        //Quando derrotar todos os inimigos, habilita win e restart para true. (childCount conta o numero de objetos presente no jogo)
        if(inimigo.childCount == 0) {
            winText.enabled = true;
            restartText.enabled = true;
            Time.timeScale = 0;
        }
    }
}
