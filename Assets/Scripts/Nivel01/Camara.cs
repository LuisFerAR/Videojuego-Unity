using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public GameObject warrior;

    private Vector3 posicion;
    // Start is called before the first frame update
    void Start()
    {
        posicion = transform.position - warrior.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position =  new Vector3(warrior.transform.position.x + posicion.x, 0f, transform.position.z);
    }
}
