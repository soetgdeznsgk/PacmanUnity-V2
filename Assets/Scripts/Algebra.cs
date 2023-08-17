using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Algebra : MonoBehaviour
{
    public IDictionary<Vector3, string> VectorAString = new Dictionary<Vector3, string>(); // Entidad también debería heredar de algebra para poder utilizar estos métodos

    static private float floatMayor() { // funciona perfectamente
        float[] direccion = {4, 1, 5, 3};
        float numMayor = direccion[0];

        for(int i = 0; i < direccion.Length - 1; i++){
            if (numMayor < direccion[i]){
                numMayor = direccion[i];
                }
        }
        return numMayor;
    }

    static public Vector2 AproximarAPuntoCardinal(Vector3 vect){ // funciona perfectamente
        Vector3[] puntosCardinales = {(Vector3)Vector2.up, (Vector3)Vector2.down, (Vector3)Vector2.left, (Vector3)Vector2.right};
        int indicePuntoCardinalMasCercano = 0;
        //float temp;
        
        for (int i = 0; i < puntosCardinales.Length; i++){

            if (Vector3.Dot(puntosCardinales[indicePuntoCardinalMasCercano], vect) < Vector3.Dot(vect, puntosCardinales[i])){
                indicePuntoCardinalMasCercano = i;
            }
        }
        return puntosCardinales[indicePuntoCardinalMasCercano];
    }

}
