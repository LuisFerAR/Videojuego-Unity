using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior: MonoBehaviour
{
    public float vMov;
    public float fSalto;

    private Rigidbody2D rbWarrior;
    private SpriteRenderer srWarrior;
    private Transform trWarrior;
    private GameManager gm;
    public static Animator anWarrior;
    

    // Start is called before the first frame update
    void Start(){
        //instanciar el cuerpo rigido del warrior con el objeto rbWarrior
        rbWarrior = GetComponent<Rigidbody2D>();
        srWarrior = GetComponent<SpriteRenderer>();
        anWarrior = GetComponent<Animator>();
        trWarrior = GetComponent<Transform>();
        anWarrior.SetBool("bPiso", false);
        anWarrior.SetBool("bVivo", true);

        gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anWarrior.SetFloat("fVelocidad", Mathf.Abs(rbWarrior.velocity.x));

        if (Input.GetKey(KeyCode.RightArrow)){
            srWarrior.flipX = false;
            rbWarrior.velocity = new Vector2(vMov, rbWarrior.velocity.y);
        }

        if (Input.GetKey(KeyCode.LeftArrow)){
            srWarrior.flipX = true;
            rbWarrior.velocity = new Vector2(-vMov, rbWarrior.velocity.y);
        }

        if(Input.GetAxis("Jump") > 0 && anWarrior.GetBool("bPiso"))
        {
            anWarrior.SetBool("bPiso", false);
            rbWarrior.velocity = new Vector2(rbWarrior.velocity.x, 0f);
            rbWarrior.AddForce(new Vector2(0, fSalto), ForceMode2D.Impulse);
        }

        if (trWarrior.position.y <= -5f)
        {
            StartCoroutine(muerte());
        }

    }

      IEnumerator muerte()
    {
        anWarrior.SetBool("bVivo", false);
        gm.setBotonReiniciar(true);
        yield return new WaitForSeconds(0.5f);
        Time.timeScale = 0;
    }

    public void reiniciarEscena()
    {

        trWarrior.position = new Vector2(-4, 2);
        anWarrior.SetBool("bVivo", true);
        Time.timeScale = 1;
        gm.setBotonReiniciar(false);

    }

    /*public void reiniciarEscena2()
    {

        trWarrior.position = new Vector2(-4, 2);
        anWarrior.SetBool("bVivo", true);
        Time.timeScale = 1;
        gm.setBotonReiniciar(false);

    }*/

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meta")
        {
            gm.irNivel02();
        }

        if (collision.gameObject.tag == "Meta2")
        {
            gm.irNivel03();
        }

         if (collision.gameObject.tag == "ORCO1")
          {
              StartCoroutine(muerte());
          }

        if (collision.gameObject.tag == "ORCO2")
        {
            StartCoroutine(muerte());
        }

        if (collision.gameObject.tag == "AGUILA")
        {
            StartCoroutine(muerte());
        }
    }


}


