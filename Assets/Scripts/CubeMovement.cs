using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    private Vector3 direccion;
    private Rigidbody rb;
    public float velocidad;
    public Transform targetIzq;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(MoverCubo());//empieza la corutina
    }

    IEnumerator MoverCubo()//Creamos una corrutina para que se mueva hacia un game object vacio
    {        
        while (true)
        {
            direccion = targetIzq.position - transform.position;
            direccion.Normalize();
            rb.velocity = direccion * velocidad;
            yield return new WaitForSeconds(1f);
        }
    }
    //Añadimos la etiqueta al personaje con Player
    private void OnCollisionEnter(Collision collision) //Si el cubo entra en contacto con la etiqueta player se para la corutina
    {
        if(collision.gameObject.tag == "Player")
        {
            StopAllCoroutines();
        }
    }
}
