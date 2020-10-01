//Librerias de Unity creadas predeterminadas al hacer un script
                                                                                                                                                                                                                  //Codigo Alejandro Aceves Rocha

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//Codigo Alejandro Aceves Rocha
//Clase publica donde se da de  alta el personaje
public class core_adventurer : MonoBehaviour
{
    // Mas claes una flotante y otra bool, una expresa el movvimiento y sus unidades y la otra es del piso donde solo sera true y false
    public float movVel = 5f;
    public bool enelPiso = false;
    
    // Da de alta la variable Animator anima
    private Animator anima;
    // Start is called before the first frame update....  LOo que saldra al principio
    void Start()
    {
        //LLama al componente de unity Animator
        anima = GetComponent<Animator>();
    }

    // Update is called once per frame.. lo que estara en cada frame
    void Update()
    {
        //Condicion donde piso es falso y el bool sera falso
        if(enelPiso == false)
        {
            anima.SetBool("Piso", false);
        }
        //Condicion donde piso es true y el bool sera true

        if (enelPiso == true)
        {
            anima.SetBool("Piso", true);
        }
        //Si se presiona left ctrl esta hara la anim de atacar
  
        if(Input.GetKeyDown("left ctrl"))
        {
            anima.SetTrigger("Ataque");
        }


        //Vector3 es la direccion en la que se va a mover por lo que se da de alta como movimiento en la parte Horrizontal
        Vector3 movimiento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f); 
        //Es para el movimiento que se va a sumar la posicion con el mov y este se va a mult por el tiempo
        transform.position += movimiento * Time.deltaTime * movVel;

        //Se da de alta salto
        Salto();

        //Girar cuerpo con flechas
        Vector3 characterScale = transform.localScale;
        //Cuando horizontal es mayor a 0 no se rotara
        if (Input.GetAxis("Horizontal") < 0)
        {
            characterScale.x = -1f;
            //Si se cumple la condicion se activara la anim de correr

            anima.SetFloat("Velocidad", 1f);
        }
        //Cuando horizontal es menor a 0  se rotara

        if (Input.GetAxis("Horizontal") > 0)
        {
            characterScale.x = 1f;
            //Si se cumple la condicion se activara la anim de correr
            anima.SetFloat("Velocidad", 1f);
        }
        //Condicion de cuando Horizontal es 0 
        if (Input.GetAxis("Horizontal") == 0)
        {
            //Se quitara la anim de Correr y se pondra la de idle
            anima.SetFloat("Velocidad", 0f);
        }
        //El personaje estara en escala local
        transform.localScale = characterScale;
    }
    // Programacion de salto
    void Salto()
    {
        //Cuando se presione la tecla de salto esta se activara si y solo si esta tocando el piso
        if (Input.GetButtonDown("Jump") && enelPiso == true)
        {
            //La programacion para que se de el salto
            gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
                                                                                                                                                                                                                  //Codigo Alejandro Aceves Rocha
        }
    }
    //Se declara variable Player_Damaged
    public void Player_Damaged() {
        //Si esta se cumple se pondra la anim de Adventure_Hit
        anima.Play("Adventure_Hit");

        
    }
    //Se declara la variable Player_Insta
    public void Player_Insta()
    {
        //Si se cumple la funcion se hara la anim Die y se hara respawn 
        anima.Play("Adventure_Die");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    //Se declara la variable Player_Insta

    public void Player_Die_Object()
    {
        //Si se cumple la funcion se hara la anim Die y se hara respawn 
        anima.Play("Adventure_Die");
       
    }
}
