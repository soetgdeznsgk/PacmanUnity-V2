using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objetivosMadre : MonoBehaviour
{
    public static readonly float limiteI = -18.48f;
    public static readonly float limiteD = -0.3f;
    public static readonly float limiteAr = 18.76f;
    public static readonly float limiteAb = -5.4f;

    public static bool _scatter = true;
    public float _scatterTimer = 5f;
    [HideInInspector]
    public Vector2 esquinaPreferida;

    public bool PuntoDentroDeMapa(Vector2 pos){
        //Debug.Log(limiteD + " > " + pos.x + " = " + (limiteD > pos.x));
        return (limiteD >= pos.x && limiteI <= pos.x && (limiteAb - 0.5f) <= pos.y && limiteAr >= pos.y);
    }

    void Update(){
        _scatterTimer -= 1 * Time.deltaTime;
        if (_scatterTimer < 0f){
            _scatterTimer = (_scatter ? 20f : 7f);
            _scatter = !_scatter;
        }


    }
}
