using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CabezaW : MonoBehaviour
{
    public GameObject sMoneda;

    private Bloque bloque;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        bloque = FindObjectOfType<Bloque>();
        gm = FindObjectOfType<GameManager>();
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bloque" && bloque.getEstado())
        {
            Debug.Log(bloque.getNroMonedas());
            gm.sumarMonedas();
            bloque.restarMonedas();
            Instantiate(sMoneda);
            if (bloque.getNroMonedas() <= 0)
            {
                bloque.desactivarBloque();
            }
                
        }
    }
}
