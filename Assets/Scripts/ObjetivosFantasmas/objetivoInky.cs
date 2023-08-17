using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivoInky : objetivosMadre
{
    public Transform _objetivo;
    private Vector2 temp;
    private Vector2 _alteracionX, _alteracionY;
    private Vector2 posicionJugador;
    private Jugador jugadorReferencia;
    private Transform posicionBlinky;
    private Vector2 _vectorEntreBlinkyYTemp;
    
    // Start is called before the first frame update
    void Start()
    {
        jugadorReferencia = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        posicionBlinky = GameObject.Find("Blinky").GetComponent<Transform>();

        esquinaPreferida = new Vector2(limiteD, limiteAb);

        _alteracionX = new Vector2(2f, 0f);
        _alteracionY = new Vector2(0f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (!objetivosMadre._scatter) {
            posicionJugador = jugadorReferencia.transform.position;
            switch(jugadorReferencia._orientacion)
            {
                case "ar":
                    temp = posicionJugador + _alteracionY;  
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
            _vectorEntreBlinkyYTemp = temp - (Vector2) posicionBlinky.position;

            temp = _vectorEntreBlinkyYTemp + temp;
            
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
