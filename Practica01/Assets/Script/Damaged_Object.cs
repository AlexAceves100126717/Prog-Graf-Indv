//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damaged_Object : MonoBehaviour
{
    // un void privado donde se importa la collision
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si la colision choca con el tag player esta hara lo que dice Player_Damaged
        if(collision.transform.CompareTag("Player"))
        { 
            collision.transform.GetComponent<core_adventurer>().Player_Damaged();
        }
    }
}
