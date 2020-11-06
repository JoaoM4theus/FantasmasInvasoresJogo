using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaBase : MonoBehaviour {

    public float vida = 2;//Numero de vidas que a base ira conter.

    void Update() {
        //Se o tiro do inimigo atingir a base ela ira perder 1 de vida.
        //Se chegar em 0 destrói a base.
        //Cada base possui sua propria vida.
        if (vida <= 0) {
            Destroy(gameObject);
        }

    }
}