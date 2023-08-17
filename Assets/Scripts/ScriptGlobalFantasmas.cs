using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptGlobalFantasmas : MonoBehaviour
{


    public void ComenzarHuida(){
        for (int i = 0; i < this.gameObject.transform.childCount; i++){
            FantasmaNPC referenciaFantasma = this.gameObject.transform.GetChild(i).gameObject.GetComponent<FantasmaNPC>();
            referenciaFantasma.ComenzarHuida();
        }
    }

    public void PararHuida(){
        for (int i = 0; i < this.gameObject.transform.childCount; i++){
            FantasmaNPC referenciaFantasma = this.gameObject.transform.GetChild(i).gameObject.GetComponent<FantasmaNPC>();
            referenciaFantasma.Revivir();
        }
    }
}
