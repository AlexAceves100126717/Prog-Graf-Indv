//Librerias
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die_Object : MonoBehaviour
{
    // un void privado donde se importa la collision

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // Si la colision choca con el tag player esta hara lo que dice Player_Insta

            collision.transform.GetComponent<core_adventurer>().Player_Die_Object();

        }

    }
}
