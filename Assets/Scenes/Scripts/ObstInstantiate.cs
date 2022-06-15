using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstInstantiate : MonoBehaviour
{
    int segundosContar;

    public float tiempoCambiar;
    public float tiempoEspera;

    public GameObject obstacle;
    GameObject clon;

    void Start()
    {
        segundosContar = 1;
    }
    
    void Update()
    {
        while (tiempoCambiar < Time.time && segundosContar > 0)
        {
            segundosContar--;
            clon = Instantiate(obstacle);
            Destroy(clon, 1);
            tiempoCambiar += tiempoEspera;
        }
    }
    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Piso")
        {
            Destroy(clon);
        }
    }*/
}
