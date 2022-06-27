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
    public GameObject obst;

    //botones
    public GameObject botonEmpezar;
    public GameObject Instrucciones;
    public GameObject textoInicial;
    public GameObject botonSeguir;
    public GameObject pantalla;
    public GameObject reiniciar;
    public GameObject confetti;
    public bool seVeSig = true;
    public bool seVeEmp = false;

    //Reiniciar
    public bool volverPrincipio = false;
    public Text ganarTxt;
    public bool cubitoVer = true;

    //tiempo
    /*int segundosContar;
    public float tiempoCambiar;
    public float tiempoEspera;
    public GameObject obstacle;
    GameObject clon;*/

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
                rb.AddForce(new Vector3(0, 6, 0), ForceMode.Impulse);
                cubeEnElPiso = false;
                fuenteSonidoSaltar.clip = sonidoSalto;
                fuenteSonidoSaltar.Play();

            }
        
    }
    public int b = 15;
    private void OnCollisionEnter(Collision col)
    {
        //saltar
        if (col.gameObject.name == "Piso")
        {
            cubeEnElPiso = true;
        }
        //morir
        if (col.gameObject.name == "PlanoCaida" || col.gameObject.name == "obstaculo(Clone)" || col.gameObject.name == "obstaculo2(Clone)" || col.gameObject.name == "obstaculo3")
        {
                ganarTxt.text = "¡Perdiste!";
            if (cubitoVer == true){
                cubitoVer = false;
            }
        }
        //ganar
        if (col.gameObject.name == "Llegada")
        {
            ganarTxt.text = "¡Ganaste!";
            if (cubitoVer == true)
            {
                cubitoVer = false;
            }
                confetti.SetActive(true);
                float a = 0.5f;
                while (b > 0)
                {
                    confetti.transform.localScale = new Vector3(a, a, a);
                    a -= 0.1f;
                    b--;
                    Instantiate(confetti);
                }
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
            pantalla.SetActive(!pantalla.activeInHierarchy);
            reiniciar.SetActive(!reiniciar.activeInHierarchy);
            seVeEmp = true;
            /*while (tiempoCambiar < Time.time && segundosContar > 0)
            {
                segundosContar--;
                clon = Instantiate(obstacle);
                Destroy(clon, 1);
                tiempoCambiar += tiempoEspera;
            }*/

        }
    }
    public void Reiniciar()
    {
        if (ganarTxt.text == "¡Ganaste!" || ganarTxt.text == "¡Perdiste!" || ganarTxt.text == "")
        {
            if (cubitoVer == false)
            {
                cubitoVer = true;
            }
            transform.position = posicionInicio;
            ganarTxt.text = "";
        }
    }
    /*
    public void Confetti (GameObject confetti)
    {
        if (ganarTxt.text == "¡Ganaste!")
        {
            confetti.SetActive(!confetti.activeInHierarchy);
            float a = 0.5f;
            while (i > 0)
            {
                confetti.transform.localScale = new Vector3(a, a, a);
                a -= 0.1f;
                i--;
                Instantiate(confetti);
            }
        }
    }*/

}

