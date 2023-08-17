using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using System;

public class FantasmaNPC : Algebra
{
    public Animator _anim;
    public AILerp _pathFinding;
    public Collider2D _cuerpo;
    public AIDestinationSetter AIDS;

    public Jugador jugadorReferencia;

    public string[] _animacionesVivo; // 0. arriba, 1. abajo, 2. izq, 3. der
 
    #region Asignacion de las animaciones para cada estado
    public readonly string[] _animacionesMuerto = {"fMuertoArriba", "fMuertoAbajo", "fMuertoIzq", "fMuertoDer"};
    public readonly string[] _animacionesHuida = {"fHuida", "fParpadeo"};
    public readonly string[] _orientacionAnimaciones = {"Arriba", "Abajo", "Izq", "Der"}; // 
    public string animacionEnCurso = "frDer";
    #endregion

    public bool _vivo = true;
    public bool _huyendo = false;
   
    public Transform spawnPoint;
    public float _inicioTimer;

    public Transform _objetivo;
    List<Vector3> buffer = new List<Vector3>(); 
    private Vector2 orientacion;


    void Start(){
        //_anim = gameObject.GetComponent<Animator>();
        jugadorReferencia = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        _pathFinding = gameObject.GetComponent<AILerp>();

        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").GetComponent<Transform>();

        #region Asignacion de terminos al diccionario
        VectorAString.Add((Vector3)Vector2.up, _orientacionAnimaciones[0]); 
        VectorAString.Add((Vector3)Vector2.down, _orientacionAnimaciones[1]);
        VectorAString.Add((Vector3)Vector2.left, _orientacionAnimaciones[2]);
        VectorAString.Add((Vector3)Vector2.right, _orientacionAnimaciones[3]);
        #endregion
        StartCoroutine(ConteoInicioMovimiento());
    }

    void Update(){
        #region Encontrar Animaciones de cada fantasma
        _pathFinding.GetRemainingPath(buffer, out bool stale);

        

        

        try {
            orientacion = (Vector2) AproximarAPuntoCardinal(buffer[2] - buffer[1]);

            if (animacionEnCurso != VectorAString[AproximarAPuntoCardinal(orientacion)]){
                animacionEnCurso = EncontrarAnimacion(VectorAString[AproximarAPuntoCardinal(orientacion)]); 
                _anim.Play(animacionEnCurso);
            }
        }

        catch (ArgumentOutOfRangeException e) {
            e = null; // para que no muestre advertencia 
        } 

        #endregion
    }

    public void OnCollisionEnter2D(Collision2D colision){
        if (colision.gameObject.CompareTag("Player")){
            if (jugadorReferencia.powerUp) {
                this.Morir();
            }
            else {
                // en el script del jugadorReferencia, ésta colisión lo mata
                _pathFinding.canMove = false;
            }
        }

        // toca implementar un caso en el que 2 fantasmas que se choquen para que cambien de direccion a fuerzas
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.CompareTag("Respawn")){
            this.Revivir();
        }
    }

    private string EncontrarAnimacion(string direccion){

        if (_huyendo){
            return _animacionesHuida[0]; // implementar parpadeo
        }

        for(int i = 0; i < 4; i++){
            if (_vivo){
                if (_animacionesVivo[i].Contains(direccion)){
                    return _animacionesVivo[i];
                }
            }

            else {
                if (_animacionesMuerto[i].Contains(direccion)){
                    return _animacionesMuerto[i];
                }
            }
        }

        return null;
    }

    IEnumerator ConteoInicioMovimiento(){
        yield return new WaitForSeconds(_inicioTimer);
        _pathFinding.canMove = true;
    }


    /*private string ParpadeoFantasma(){
        // definir el parpadeo
    }*/

    #region Cambio de estados
    [ContextMenu("Morir")]
    public void Morir() {
        _huyendo = false;
        _vivo = false;
        _cuerpo.isTrigger = true;
        AIDS.target = spawnPoint;
        // cambiar velocidad de movimiento
    }

    [ContextMenu("Revivir")]
    public void Revivir() {
        _vivo = true;
        _huyendo = false;
        _cuerpo.isTrigger = false;
        AIDS.target = _objetivo;
        // cambiar velocidad de movimiento
    }

    [ContextMenu("Comenzar Huida")]
    public void ComenzarHuida() {
        _huyendo = true; 
        // huir de pacman
    }
    #endregion
}
