using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaTres : MonoBehaviour
{
    private float velocidad;
    private Vector2 direccion;

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

    void FixedUpdate()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // Restricción de límite superior (se movió de y-6 a y-10)
        if (transform.position.y > GameManager.supDer.y - 6 && direccion.y > 0)
        {
            direccion.y = -direccion.y;
        }

        // Restricción de límite inferior
        if (transform.position.y < GameManager.infIzq.y + 2.5 && direccion.y < 0)
        {
            direccion.y = -direccion.y;
        }
    }
}
