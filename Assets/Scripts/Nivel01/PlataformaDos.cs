using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformaDos : MonoBehaviour
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
        direccion = new Vector2(iDir, 0 );
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
        //restriccion de limite superior
        if(transform.position.x > GameManager.supDer.x - 8.5 && direccion.x > 0)
        {
            direccion.x = -direccion.x;
        }
        //restriccion de limite inferior
        if(transform.position.x < GameManager.infIzq.x + 10 && direccion.x < 0)
        {
            direccion.x = -direccion.x;
        }
    }
}
