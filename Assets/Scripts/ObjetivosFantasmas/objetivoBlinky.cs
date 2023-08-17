using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivoBlinky : objetivosMadre
{
    public Transform _objetivo;
    public Transform Jugador;

    // Start is called before the first frame update
    void Start()
    {
        esquinaPreferida = new Vector2(limiteD, limiteAr);
        Jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!objetivosMadre._scatter){
            _objetivo.position = Jugador.position;
        }

        else {
            _objetivo.position = esquinaPreferida;
        }
    }
}
