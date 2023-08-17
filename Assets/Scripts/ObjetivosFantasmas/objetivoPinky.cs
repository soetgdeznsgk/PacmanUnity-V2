using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivoPinky : objetivosMadre
{
    public Transform _objetivo;
    private Vector2 temp;
    private Vector2 _alteracionX, _alteracionY, _aberracionY;
    private Vector2 posicionJugador;
    private Jugador jugadorReferencia;
    //private objetivosMadre madreReferencia;
    
    void Start()
    {
        jugadorReferencia = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        _alteracionX = new Vector2(4f, 0f);
        _alteracionY = new Vector2(0f, 4f);
        _aberracionY = new Vector2(-3f, 0f);
        esquinaPreferida = new Vector2(limiteI, limiteAr);
    }

    // Update is called once per frame
    void Update()
    {
        if (!objetivosMadre._scatter) {
            posicionJugador = jugadorReferencia.gameObject.transform.position;
            switch (jugadorReferencia._orientacion)
            {
                case "ar":
                    temp = posicionJugador + _alteracionY + _aberracionY;  
                    break;
                case "ab":
                    temp = posicionJugador - _alteracionY;
                    break;
                case "i":
                    temp = posicionJugador - _alteracionX;
                    break;
                case "d":
                    temp = posicionJugador + _alteracionX;
                    break;
                
            }

            if (!PuntoDentroDeMapa(temp)) {
                _objetivo.position = posicionJugador;
            }

            else {
                _objetivo.position = temp;
            }
        }

        else {
            _objetivo.position = esquinaPreferida;
        }
        
    }

}
