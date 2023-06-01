using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ORCO1 : MonoBehaviour
{

    public float speed;
    public bool esDerecha;
    public float contadorT;
    public float tiempoParaCambiar;
    // Start is called before the first frame update
    void Start()
    {
        contadorT = tiempoParaCambiar;  
    }

    // Update is called once per frame
    void Update()
    {
        if(esDerecha == true)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.localScale = new Vector3(1, 1, 0);
        }

        if (esDerecha == false)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.localScale = new Vector3(-1, 1, 0);

        }

        contadorT -= Time.deltaTime;

        if (contadorT <= 0)
        {
            contadorT = tiempoParaCambiar;
            esDerecha = !esDerecha;
        }
    }
}
