using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque : MonoBehaviour
{
    private Animator aBloque;
    private int nroMonedas;


    // Start is called before the first frame update
   /* void Start()
    {
      // aBloque = GetComponent<Animator>();
      // aBloque.SetBool("bActivo", true);
       
    }*/
    
   void Update()
    {
        
        aBloque = GetComponent<Animator>();
        aBloque.SetBool("bActivo", true);
        nroMonedas = 1;

    }

    // Update is called once per frame
    public void desactivarBloque()
    {
        aBloque.SetBool("bActivo", false);
    }

    public bool getEstado()
    {
        return aBloque.GetBool("bActivo");
    }

    public void restarMonedas()
    {
        nroMonedas--;
    }
    
    public int getNroMonedas()
    {
        return nroMonedas;
        
    }
}
