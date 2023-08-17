using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivoClyde : objetivosMadre
{
    //public Transform _objetivo;
    //private Vector2 temp;
    private Vector2 vectorResta;
    private float distanciaCuadrada; // de ésta manera no se tiene que calcular ninguna raiz cuadrada
    private Jugador jugadorReferencia;
    private GameObject clydeReferencia;
    public bool haLlegadoASuEsquina = false;

    // Start is called before the first frame update
    void Start()
    {
        jugadorReferencia = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        clydeReferencia = GameObject.Find("Clyde");
        esquinaPreferida = new Vector2(limiteI, limiteAb);
    }

    // Update is called once per frame
    void Update()
    {
        vectorResta = jugadorReferencia.transform.position - clydeReferencia.transform.position;

        distanciaCuadrada = (vectorResta.x * vectorResta.x) + (vectorResta.y * vectorResta.y);

        if (distanciaCuadrada < 64f) { // 8 casillas de radio, 64 es la comparacion apropiada
            haLlegadoASuEsquina = false;
            gameObject.transform.position = esquinaPreferida;
        }

        else if (haLlegadoASuEsquina) {
            gameObject.transform.position = jugadorReferencia.gameObject.transform.position;
        }
    }

    public void OnTriggerStay2D(Collider2D otro){
        //Debug.Log("Esquina llegada");
        if (otro.name == "Clyde"){
            haLlegadoASuEsquina = true;
        }
    }
}
