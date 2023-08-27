using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuntoChiquito : MonoBehaviour
{
    Jugador jugadorReferencia;
    public Collider2D colision;
    public SpriteRenderer Sprite;
    // Start is called before the first frame update
    void Start()
    {
        //jugadorReferencia = GameObject.FindGameObjectWithTag("Player").GetComponent<Jugador>();
        //Sprite = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnTriggerEnter2D(Collider2D Collider){

        if (Collider.gameObject.CompareTag("Player")) {
            Sprite.enabled = false;
            colision.enabled = false;
            }
    }
}
