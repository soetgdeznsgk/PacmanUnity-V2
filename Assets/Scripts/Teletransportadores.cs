using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teletransportadores : MonoBehaviour
{
    public Vector3 objetivo;
    public SpriteRenderer _sprite;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }   

    void OnTriggerEnter2D(Collider2D colision) {

        if (colision.gameObject.CompareTag("Player")){
            _sprite.enabled = false;}

        if (gameObject.CompareTag("TP1")){
            GameObject.FindGameObjectWithTag("TP2").GetComponent<SpriteRenderer>().enabled = false;
            objetivo = GameObject.FindGameObjectWithTag("TP2").transform.position + new Vector3(-1f, 0f, 0f);
        }

        else if (gameObject.CompareTag("TP2")){
            GameObject.FindGameObjectWithTag("TP1").GetComponent<SpriteRenderer>().enabled = false;
            objetivo = GameObject.FindGameObjectWithTag("TP1").transform.position + new Vector3(1f, 0f, 0f);
        }
    }

    void OnTriggerExit2D(Collider2D colision) {
        colision.gameObject.transform.position = objetivo;
    }
}
