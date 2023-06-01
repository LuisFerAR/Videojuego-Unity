using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private int vidas;
    private int monedas;

    public void Start()
    {
        vidas = 3;
        monedas = 0;
    }

    public void setVidas()
    {
        vidas = GameObject.Find("cboVidas").GetComponent<Dropdown>().value + 3;
        Debug.Log(vidas);
        
    }


    public void Jugar()
    {
        //Debug.Log(vidas);
        //Debug.Log(monedas);
        PlayerPrefs.SetInt("vidas", vidas);
        PlayerPrefs.SetInt("monedas", monedas);
        SceneManager.LoadScene("Nivel01");
    }

    public void Salir()
    {
        Application.Quit();
        Debug.Log("Salir");
    }
}
