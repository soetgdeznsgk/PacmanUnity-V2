using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fantasma : Entidad
{
    Jugador _objetoJugador;
    // Start is called before the first frame update
    void Start()
    {
        _objetoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        if (_objetoJugador == null) {
            Debug.Log("q");
        }
    }

    // Update is called once per frame
    public override void Update()
    {
        if (_vivo) {
            base.Update();
            if (Input.GetKeyDown(KeyCode.W)){
                IrArriba();
            }

            else if (Input.GetKeyDown(KeyCode.S)){
                IrAbajo();
            }

            else if (Input.GetKeyDown(KeyCode.A)){
                IrIzq();
            }
            else if (Input.GetKeyDown(KeyCode.D)){
                IrDer();
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D colision){

        if (colision.gameObject.CompareTag("Player")){
            _objetoJugador.Morir();
        }
    }
}
