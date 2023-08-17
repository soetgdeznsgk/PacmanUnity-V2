using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entidad : MonoBehaviour
{
    public string[] animaciones; // 0. arriba, 1. abajo, 2. izq, 3. der
    public float _multiplicadorDeVelocidad;
    public Rigidbody2D _rb;
    public Animator _anim;
    public Collider2D _cuerpo;
    public bool _vivo = true;
    public string _orientacion;

    // Start is called before the first frame update
    void Start()
    {
        _anim.speed = 1;
    }

    // Update is called once per frame
    public virtual void Update(){
        if (_rb.velocity != Vector2.zero && _vivo) {
            _anim.speed = 1;
        }

        else {
            _anim.speed = 0;
        }
    }

    /*public virtual void OnCollisionEnter2D(Collision2D colision){
        if (colision.gameObject.CompareTag("Environment")){
            _anim.speed = 0;
        }
    }

    public virtual void OnCollisionExit2D(Collision2D colision){
        if (colision.gameObject.CompareTag("Environment")){
            _anim.speed = 1;
        }
    }*/

    public virtual void IrArriba(){
        _rb.velocity = Vector2.up * _multiplicadorDeVelocidad;
        _anim.Play(animaciones[0]);
        _orientacion = "ar";
    }

    public virtual void IrAbajo(){
        _rb.velocity = Vector2.down * _multiplicadorDeVelocidad;
        _anim.Play(animaciones[1]);
        _orientacion = "ab";
    }

    public virtual void IrIzq(){
        _rb.velocity = Vector2.left * _multiplicadorDeVelocidad;
        _anim.Play(animaciones[2]);
        _orientacion = "i";
    }

    public virtual void IrDer(){
        _rb.velocity = Vector2.right * _multiplicadorDeVelocidad;
        _anim.Play(animaciones[3]);
        _orientacion = "d";
    }
}
