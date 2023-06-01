using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Plataforma plataforma;
    public Text lblMonedas;
    public Text lblVidas;
    public Button btnReiniciar;

    public PlataformaDos plataformaDos;
   

    private int iMonedas;
    private int iVidas;
    //Desierto
    public PlataformaTres plataformaTres;
    public PlataformaCuatro plataformaCuatro; 
    public PlataformaCinco plataformaCinco;
  
    //INVIERNO
    public PlataformaSiete plataformaSiete;
    public PlataformaOcho plataformaOcho;
    public PlataformaNueve plataformaNueve;
    



    public static Vector2 infIzq;
    public static Vector2 supDer;


    private Warrior warrior;
    // Start is called before the first frame update
    void Start()
    {
        iVidas = PlayerPrefs.GetInt("vidas");
        lblVidas.text = "x" + (iVidas < 10 ? "0" + iVidas.ToString() : iVidas.ToString());
        iMonedas = PlayerPrefs.GetInt("monedas");
        lblMonedas.text = "x" + (iMonedas < 10 ? "0" + iMonedas.ToString() : iMonedas.ToString());

        infIzq = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        supDer = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        if (SceneManager.GetActiveScene().name == "Nivel01")
        {
            Plataforma p1 = Instantiate(plataforma) as Plataforma;
            p1.crear(-0.2f, -2.1f, 1f, true);
            PlataformaDos p2 = Instantiate(plataformaDos) as PlataformaDos;
            p2.crear(1.7f, -0.1f, 1f, true);


            //desierto
            PlataformaTres p3 = Instantiate(plataformaTres) as PlataformaTres;
            p3.crear(39.0f, 1f, 1f, true);
            PlataformaCuatro p4 = Instantiate(plataformaCuatro) as PlataformaCuatro;
            p4.crear(42.0f, 2f, 1f, true); 
            PlataformaCinco p5 = Instantiate(plataformaCinco) as PlataformaCinco;
            p5.crear(45.0f, 0f, 1f, true);
        
        
            //INVIERNO
            PlataformaSiete p7 = Instantiate(plataformaSiete) as PlataformaSiete;
            p7.crear(62.8f, -3.701152f, 2f, true);

            PlataformaOcho p8 = Instantiate(plataformaOcho) as PlataformaOcho;
            p8.crear(72.60806f, -3.460432f, 2f, true);

            PlataformaNueve p9 = Instantiate(plataformaNueve) as PlataformaNueve;//PLAT_9
            p9.crear(76.62661f, -3.34f, 2f, true);

            PlataformaOcho p10 = Instantiate(plataformaOcho) as PlataformaOcho;//PLAT_10
            p10.crear(78.43f, 1.69f, 2f, true);

            PlataformaNueve p11 = Instantiate(plataformaNueve) as PlataformaNueve;//PLAT_11
            p11.crear(80.48785f, -3.34f, 2f, true);

            PlataformaOcho p12 = Instantiate(plataformaOcho) as PlataformaOcho;//PLAT_12
            p12.crear(82.61458f, 1.69f, 2f, true);

            PlataformaNueve p13 = Instantiate(plataformaNueve) as PlataformaNueve;//PLAT_13
            p13.crear(84.95164f, -3.34f, 2f, true);

        }
        if (SceneManager.GetActiveScene().name == "Nivel03")
        {
            PlataformaTres p33 = Instantiate(plataformaTres) as PlataformaTres;
            p33.crear(-1.2f, -4.12f, 1f, true);
            ///////////////////////////////
            PlataformaTres p53 = Instantiate(plataformaTres) as PlataformaTres;
            p53.crear(4.7f, -4.121965f, 1f, true);
            ///////////////////////////////
            PlataformaCuatro p43 = Instantiate(plataformaCuatro) as PlataformaCuatro;
            p43.crear(1.1f, -0.7755589f, 1f, true);
            ///////////////////////////////
            PlataformaCuatro p63 = Instantiate(plataformaCuatro) as PlataformaCuatro;
            p63.crear(7f, -0.7755589f, 1f, true); 

        }

      Instantiate(lblMonedas);
      Instantiate(lblVidas);
      Instantiate(btnReiniciar);

      btnReiniciar.gameObject.SetActive(false);

      warrior = FindObjectOfType<Warrior>();
    }

    public void setBotonReiniciar(bool estado)
    {
        btnReiniciar.gameObject.SetActive(estado);
    }

    public void irNivel02()
    {
        PlayerPrefs.SetInt("vidas", iVidas);
        PlayerPrefs.SetInt("monedas", iMonedas);
        SceneManager.LoadScene("Nivel02");
    }

    public void irNivel03()
    {
        PlayerPrefs.SetInt("vidas", iVidas);
        PlayerPrefs.SetInt("monedas", iMonedas);
        SceneManager.LoadScene("Nivel03");
    }

    public void onClicReiniciar()
    {
        iVidas--;
        lblVidas.text = "x" + (iVidas < 10 ? "0" + iVidas.ToString() : iVidas.ToString());
        warrior.reiniciarEscena();
        PlayerPrefs.SetInt("vidas", iVidas);
        PlayerPrefs.SetInt("monedas", iMonedas);
        if (iVidas <= 0)
            SceneManager.LoadScene("Menu");
        else
            SceneManager.LoadScene("Nivel01");
    }

    public void onClicReiniciar2()
    {
        iVidas--;
        lblVidas.text = "x" + (iVidas < 10 ? "0" + iVidas.ToString() : iVidas.ToString());
        warrior.reiniciarEscena();
        PlayerPrefs.SetInt("vidas", iVidas);
        PlayerPrefs.SetInt("monedas", iMonedas);
        if (iVidas <= 0)
            SceneManager.LoadScene("Menu");
        else
            SceneManager.LoadScene("Nivel02");
    }

    public void sumarMonedas()
    {
        iMonedas++;
        lblMonedas.text = "x" + (iMonedas < 10 ? "0" + iMonedas.ToString() : iMonedas.ToString());
    }

    public void restarVidas()
    {
        iVidas--;
        lblVidas.text = "x" + (iVidas < 10 ? "0" + iVidas.ToString() : iVidas.ToString());
    }

    void FixedUpdate()
    {
        if (iVidas <= 1)
            btnReiniciar.GetComponentInChildren<Text>().text = "Ir a Men�";
    }
}
