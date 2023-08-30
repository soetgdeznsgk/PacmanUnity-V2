using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogicaUX
{
    public static int cuenta = 0;

    [SerializeField]
    private static AudioSource munch1;
    [SerializeField]
    private static AudioSource munch2;
    private static int alternadorMunch = 0;

    [ContextMenu("AumentarPuntoChiquito")]
    public static void ptsPuntoChiquito(){
        cuenta += 100;
        
        if (alternadorMunch++ % 2 == 0){
            munch1.Play();
        }
        else {
            munch2.Play();
        }
    }
}
