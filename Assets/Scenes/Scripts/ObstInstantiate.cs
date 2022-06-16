using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstInstantiate : MonoBehaviour
{
    public GameObject cubePrefab;
    public float tiempoCambiar;
    public float tiempoEspera;

    void Update()
    {
        while (tiempoCambiar < Time.time)
        {
            GameObject inst = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            Destroy(inst, 1);
            tiempoCambiar += tiempoEspera;
        }
    }
}
//(Input.GetButtonDown(buttonName:"Reiniciar"))
/*int segundosContar;

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
            Destroy(clon,1);
            tiempoCambiar += tiempoEspera;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Piso")
        {
            Destroy(clon);
        }
    }*/
