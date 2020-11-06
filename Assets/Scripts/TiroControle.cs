using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiroControle : MonoBehaviour
{

    public Transform bullet;//Tiro do tipo transform
    public float speed;//Velocidade do tiro

    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();//Pegando o componente Transforms.
    }
    
    void FixedUpdate() {
        bullet.position += (Vector3.up * speed);//Setando a bala verticalmente e sua velocidade.

        if (bullet.position.y >= 10) //Se o tiro passar do quadro sera destruido em seguida
            Destroy(gameObject);
    }

    //Metodo colisao: Se o tiro atingir o inimigo, destroi tanto a bala como o inimgo e acrescenta +10 de scores.
    //Se atingir a base ela apenas será destruida(Não ira tira a vida da base).
    void OnCollisionEnter2D(Collision2D col) {
        if(col.gameObject.tag.Equals("Inimigo")) {
            Destroy(col.gameObject);
            Destroy(gameObject);
            PlayerScore.playerScore += 10;
        } else if(col.gameObject.tag.Equals("Base")) { 
            Destroy(gameObject);
        }
    }
}
