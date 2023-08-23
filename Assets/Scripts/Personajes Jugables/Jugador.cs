using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : Entidad
{
    public bool powerUp = false;
    public ScriptGlobalFantasmas Fantasmas;
    public float _temporizador = 5f;
    public SpriteRenderer _sprite;

    [SerializeField] private AudioSource _muerteSFX;
    [SerializeField] private AudioSource _sirenaSFX;

    //public float _diferencial = 0.0003f;
    //public int i = 9;
    //public float comparacion;

    void Start()
    {
        Time.timeScale = 0;
        Application.targetFrameRate = 30;
        Fantasmas = GameObject.FindWithTag("GameController").GetComponent<ScriptGlobalFantasmas>();

        StartCoroutine(ConteoInicial());
    }

    public override void Update()
    {
        if (powerUp){
            _temporizador -= 1 * Time.deltaTime;        
        }

        if (_temporizador <= 0f){
            Fantasmas.PararHuida();
            powerUp = false;
        }

        #region Controles de Movimiento
        if (_vivo){
            base.Update(); // ésto por qué está aquí?, testear
            if (Input.GetKeyDown(KeyCode.UpArrow)){
                IrArriba();
            }

            else if (Input.GetKeyDown(KeyCode.DownArrow)){
                IrAbajo();
            }

            else if (Input.GetKeyDown(KeyCode.LeftArrow)){
                IrIzq();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow)){
                IrDer();
            }
        }
        #endregion
    }

    public void OnCollisionEnter2D(Collision2D colision){
        //base.OnCollisionEnter2D(colision);

        if (colision.gameObject.transform.parent.gameObject.CompareTag("GameController")) 
        {
            if (!powerUp){ // el otro caso ya está contemplado dentro del script de los fantasmas
                this.Morir();
                }
        }
        
        
    }

    public void OnTriggerEnter2D(Collider2D collider){
        if (collider.gameObject.transform.parent.gameObject.CompareTag("PowerUp")){
            if (!powerUp){
                Fantasmas.ComenzarHuida();
                powerUp = true;}

            _temporizador = 5f;
            // reiniciar contador de tiempo
        }
    }

    [ContextMenu("Matar a Pacman")]
    public void Morir(){
        this._rb.drag = 10;
        this._anim.speed = 1;
        this._anim.Play("jMuerte");
        _muerteSFX.Play();
        this._vivo = false;
        
        Invoke("selfDestruct", 1.6f);
    }

    private void selfDestruct(){
        _sprite.enabled = false;
    }
    
    IEnumerator ConteoInicial(){
        yield return new WaitForSecondsRealtime(5f);
        Time.timeScale = 1;
        _sirenaSFX.Play();

    }
}
