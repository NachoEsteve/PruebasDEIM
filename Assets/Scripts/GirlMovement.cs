using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlMovement : MonoBehaviour
{
    // VARIABLE DE MOVIMIENTO:
    // └    Esta variable la utilizarás para ajustar la fuerza
    //      del movimiento físico.
    
    public float fuerzaLineal = 150,
                 fuerzaGiro = 30;
    
    // VARIABLES DE LA CLASE INPUT:
    // └    LAS VARIABLES "horizontal" y "vertical" TIENES que
    //      utilizarlas para el valor float que
    //      devuelve la clase INPUT con las teclas W, A, S, D,
    //      o las flechas del cursor.
    private float horizontal,
                  vertical;
    
    // VARIABLES EMPLEADAS PARA LA ANIMACIÓN:
    // └    No tienes que hacer nada.
    //      Variable booleana configurada para ser "true" cuando hay movimiento
    //      y "false" cuando no hay movimiento.
    public bool isMoving;
    public Animator anim;
    // MÉTODO EMPLEADO PARA LA ANIMACIÓN:
    // └    No tienes que hacer nada.
    //      Hace que la variable booleana IsMoving sea "true" si hay movimiento
    //      y "false" cuando no hay movimiento.

    private Vector3 direccion;  //Creamos un vector3
    private Rigidbody rb;       //Creamos un rigidbody del personaje
    private void Animating()
    {
        if (vertical != 0)
            anim.SetBool("IsMoving", true);
        else
            anim.SetBool("IsMoving", false);
    }
    private void Update()
    {
        Animating();
        GiroJugador();
    }

    private void FixedUpdate()
    {
        MoviminetoJugador();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //Definimos el rigidbody del jugador
    }

    public void MoviminetoJugador()
    {
        rb.AddRelativeForce(Vector3.forward * Input.GetAxis("Vertical") * fuerzaLineal, ForceMode.Force); //Le damos una fuerza al jugador para que se mueva hacia delante
        vertical = Input.GetAxis("Vertical");
    }

    public void GiroJugador()
    {
        rb.AddTorque(transform.up * fuerzaGiro * Input.GetAxis("Horizontal")); //Le damos fuerza al giro
        horizontal = Input.GetAxis("Horizontal");
    }

}
