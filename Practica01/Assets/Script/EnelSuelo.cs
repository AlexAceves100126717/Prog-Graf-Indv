//Librerias de Unity predeterminadas
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Codigo Alejandro Aceves Rocha
// Clase publica dada de alta en el suelo
public class EnelSuelo : MonoBehaviour
{
    //Llama al personaje al codigo
                                                                                                                                                                                                                  //Codigo Alejandro Aceves Rocha
    GameObject adventurer;
    // Start is called before the first frame update.. lo que estara al principio
    void Start()
    {
        //Se da a entender que el personaje es el padre del objeto
        adventurer = gameObject.transform.parent.gameObject;

    }

    // Update is called once per frame.. lo que se estara ejecutando cada frame
    void Update()
    {
        
    }
    //Cambiar bool, da de alta la entrada de la collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Si collision en el tag es igual a piso este sera true
        if (collision.collider.tag == "Piso")
        {
            //Si el personaje = DecPiso esta pisando el tag piso estara en true
            adventurer.GetComponent<core_adventurer>().enelPiso = true;
        }

    }
    //Se da de alta la salida de la collision
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Si  la collision esta en activa en el tag piso..
        if (collision.collider.tag == "Piso")
        {
            //Si el personaje = el box collider DecPiso no esta tocando piso esta sera falso
            adventurer.GetComponent<core_adventurer>().enelPiso = false;
        }
    }
}
