using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaNueve : MonoBehaviour
{
    private float velocidad;
    private Vector2 direccion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void crear(float x, float y, float vel, bool dir)
    {
        int iDir;
        transform.position = new Vector2(x, y);
        velocidad = vel;
        iDir = (dir == true ? 1 : -1);
        direccion = new Vector2(0, iDir);
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
        //restriccion de limite superior
        if(transform.position.y > GameManager.supDer.y + 1 && direccion.y >0)//abajo
        {
            direccion.y = -direccion.y;
        }
        //restriccion de limite inferior
        if(transform.position.y < GameManager.infIzq.y - 1  && direccion.y < 0)//arriba
        {
            direccion.y = -direccion.y;
        }
    }
}
