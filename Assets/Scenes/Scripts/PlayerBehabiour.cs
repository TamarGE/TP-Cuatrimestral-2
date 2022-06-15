using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehabiour : MonoBehaviour
{
    //Movimiento:
    public float movementSpeed;// la preferida es = 0.2
    public float speed = 10f;
    Rigidbody rb;
    public bool cubeEnElPiso = true;

    //sonido:
    public AudioClip sonidoSalto;
    public AudioClip sonidoSlide;
    AudioSource fuenteSonidoSaltar;
    AudioSource fuenteSonidoSlide;

    //Muerte
    Vector3 posicionInicio;

    //botones
    public GameObject botonEmpezar;
    public GameObject Instrucciones;
    public GameObject cubito;
    public GameObject textoInicial;
    public GameObject botonSeguir;
    public GameObject reiniciar;
    public bool seVeSig = true;
    public bool seVeEmp = false;

    //Reiniciar
    public bool volverPrincipio = false;

    //tiempo
    int segundosContar;
    public float tiempoCambiar;
    public float tiempoEspera;
    public GameObject obstacle;
    GameObject clon;

    void Start()
    {
        //salto
        rb = GetComponent<Rigidbody>();
        //sonido    
        fuenteSonidoSaltar = GetComponent<AudioSource>();
        fuenteSonidoSlide = GetComponent<AudioSource>();
        //muerte
        posicionInicio = transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        //Movimiento:
    if (Input.GetKey(KeyCode.D))
    {
        transform.Translate(0, 0, -movementSpeed);
        if (cubeEnElPiso)
        {
            fuenteSonidoSlide.clip = sonidoSlide;
            fuenteSonidoSlide.Play();
        }
    }
    if (Input.GetKey(KeyCode.A))
    {
        transform.Translate(0, 0, movementSpeed);
        if (cubeEnElPiso)
        {
            fuenteSonidoSlide.clip = sonidoSlide;
            fuenteSonidoSlide.Play();
        }
    }
    if (Input.GetKey(KeyCode.S))
    {
        transform.Translate(-movementSpeed, 0, 0);
        if (cubeEnElPiso)
        {
            fuenteSonidoSlide.clip = sonidoSlide;
            fuenteSonidoSlide.Play();
        }
    }
    if (Input.GetKey(KeyCode.W))
    {
        transform.Translate(movementSpeed, 0, 0);
        if (cubeEnElPiso)
        {
            fuenteSonidoSlide.clip = sonidoSlide;
            fuenteSonidoSlide.Play();
        }
    }
        //Saltar:
        if (Input.GetKey(KeyCode.Space) && cubeEnElPiso)
        {
            rb.AddForce(new Vector3(0, 7, 0), ForceMode.Impulse);
            cubeEnElPiso = false;
            fuenteSonidoSaltar.clip = sonidoSalto;
            fuenteSonidoSaltar.Play();

        }
    }
    private void OnCollisionEnter(Collision col)
    {
        //saltar
        if (col.gameObject.name == "Piso" || col.gameObject.name == "Plataforma")
        {
            cubeEnElPiso = true;
        }
        //morir
        if (col.gameObject.name == "PlanoCaida" || col.gameObject.name == "obstaculo")
        {
                transform.position = posicionInicio;
        }
    }
    public void VerSig()
    {
        if (seVeSig)
        {
            textoInicial.SetActive(!textoInicial.activeInHierarchy);
            Instrucciones.SetActive(!Instrucciones.activeInHierarchy);
            botonEmpezar.SetActive(!botonEmpezar.activeInHierarchy);
            botonSeguir.SetActive(!botonSeguir.activeInHierarchy);
            seVeSig = false;
        }
    }
    public void VerEmp()
    {
        if (seVeEmp == false)
        {
            Instrucciones.SetActive(!Instrucciones.activeInHierarchy);
            botonEmpezar.SetActive(!botonEmpezar.activeInHierarchy);
            cubito.SetActive(!cubito.activeInHierarchy);
            reiniciar.SetActive(!reiniciar.activeInHierarchy);
            seVeEmp = true;
            while (tiempoCambiar < Time.time && segundosContar > 0)
            {
                segundosContar--;
                clon = Instantiate(obstacle);
                Destroy(clon, 1);
                tiempoCambiar += tiempoEspera;
            }

        }
    }
    /*public void Reiniciar()
    {
        if ()
        transform.position = posicionInicio;

    }*/

}

