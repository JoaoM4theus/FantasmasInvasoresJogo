using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControle : MonoBehaviour {
    private Transform player;//Variavel player do tipo Transform
    public float speed;//Velocidade que vai ser o player
    public float maxBound, minBound;//"Paredes invisiveis" para que o jogador não passe da tela
    public GameObject shot;//Tiro
    public Transform shotSpawn;//Spawn da bala
    public float fireRate;//Intervalo de tempo de cada tiro
    private float nextFire;//Efetuar outro tiro

    void Start() {
        player = GetComponent<Transform>();//Pegando o componente do tipo Transform.
    }

    void FixedUpdate() {
        //A variavel h receber um metodo GetAxis, que serve para verificar se o jogador esta se movendo> Se estiver movendo pra direita, retorna 1 e para esquerdar -1, parado 0.
        float h = Input.GetAxis("Horizontal");

        //Se o jogador passar da minBound e estiver andando o jogador vai passar a receber o getAxis 0, assim deixando-o parado na posição atual. Assim vale para o max bound.
        if (player.position.x < minBound && h < 0) 
            h = 0;
        else if (player.position.x > maxBound && h > 0) 
            h = 0;
   
        player.position += Vector3.right * h * speed;
    }

    void Update() {
        //Se apertar a tecla espaço e estiver no time acima da permissão de efetuar o proximo disparo ele vai instanciar ou criar um tiro.
        if(Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire) {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
    }

    
}