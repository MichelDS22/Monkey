using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneracionNivel : MonoBehaviour
{
    public Transform[] PosicionInicialNivel;
    public GameObject[] Habitaciones;
    public GameObject[] HabitacionesExtra;

    public GameObject[] SalaInicial;
    public GameObject[] SalaFinal;
    public GameObject[] Sala_Izq_Der;
    public GameObject[] Sala_Izq_Der_Abajo;
    public GameObject[] Sala_Izq_Der_Arriba;
    public GameObject[] Sala_Izq_Der_Abajo_Arriba;

    private int SalasRandomID;
    private int SalasRandomIDA;
    private int SalasRandomIDA2;
    private int SalasRandomIDAA;

    //Variables Modificadas
    public GameObject[] Tienda_Juego;
    public GameObject[] Tienda_Juego_Izq;
    public GameObject[] Tienda_Juego_Der;
    //Variables Modificadas

    private int Direccion;
    private int HabitacionesRandom;
    public float CantidadDeMovimientos;
    public bool PararGeneracionNivel = false;

    public float PerimetroMinimo_X;
    public float PerimetroMaximo_X;
    public float PerimetroMinimo_Y;

    public LayerMask HabitacionMascara;

    private int ContadorHabitacionesHaciaAbajo;
    //Varialbles para testeo
    private float TiempoDeEspera;
    public float EsperaIncial = 0.25f;

    private void Start()
    {
        //Codigo Modificado 
        int PosicionInicialRandomNivel = Random.Range(0, PosicionInicialNivel.Length);
        transform.position = PosicionInicialNivel[PosicionInicialRandomNivel].position;

        HabitacionesRandom = Random.Range(0, SalaInicial.Length);
        Instantiate(SalaInicial[HabitacionesRandom], transform.position, Quaternion.identity);

        Direccion = Random.Range(1, 4);

        int RandomTienda = Random.Range(0, 3);

        if (RandomTienda == 0)
        {

            if (Direccion == 1 || Direccion == 2)
            {
                if (transform.position.x > PerimetroMinimo_X)
                {

                    Collider2D DetectorHabitacion = Physics2D.OverlapCircle(transform.position, 1, HabitacionMascara);
                    DetectorHabitacion.GetComponent<DestruirSalas>().DestruirSala();

                    HabitacionesRandom = Random.Range(0, Tienda_Juego_Izq.Length);
                    Instantiate(Tienda_Juego_Izq[HabitacionesRandom], transform.position, Quaternion.identity);

                    Transform transformComponent = GetComponent<Transform>();
                    Vector2 posicionActual = transformComponent.position;
                    Vector2 nuevaPosicion = new Vector2(posicionActual.x - 10, posicionActual.y);

                    Instantiate(Tienda_Juego[0], nuevaPosicion, Quaternion.identity);
                }
            }

            if (Direccion == 3 || Direccion == 4)
            {
                if (transform.position.x < PerimetroMaximo_X)
                {

                    Collider2D DetectorHabitacion = Physics2D.OverlapCircle(transform.position, 1, HabitacionMascara);
                    DetectorHabitacion.GetComponent<DestruirSalas>().DestruirSala();

                    HabitacionesRandom = Random.Range(0, Tienda_Juego_Der.Length);
                    Instantiate(Tienda_Juego_Der[HabitacionesRandom], transform.position, Quaternion.identity);


                    Transform transformComponent = GetComponent<Transform>();
                    Vector2 posicionActual = transformComponent.position;
                    Vector2 nuevaPosicion = new Vector2(posicionActual.x + 10, posicionActual.y);

                    Instantiate(Tienda_Juego[1], nuevaPosicion, Quaternion.identity);
                }
            }

        }

        //Codigo Modificado

    }

    private void Update()
    {
        if (TiempoDeEspera <= 0 && !PararGeneracionNivel)
        {
            Movimiento();
            TiempoDeEspera = EsperaIncial;
        }
        else
        {
            TiempoDeEspera -=Time.deltaTime;
        }
    }

    private void SelectorDeSalas(int HabitacionesRandom_)
    {
        switch (HabitacionesRandom_)
        {
            case 0:
                int SalasRandomID = Random.Range(0, Sala_Izq_Der.Length);
                Instantiate(Sala_Izq_Der[SalasRandomID], transform.position, Quaternion.identity);
                break;
            case 1:
                int SalasRandomIDA = Random.Range(0, Sala_Izq_Der_Abajo.Length);
                Instantiate(Sala_Izq_Der_Abajo[SalasRandomIDA], transform.position, Quaternion.identity);
                break;
            case 2:
                int SalasRandomIDA2 = Random.Range(0, Sala_Izq_Der_Arriba.Length);
                Instantiate(Sala_Izq_Der_Arriba[SalasRandomIDA2], transform.position, Quaternion.identity);
                break;
            case 3:
                int SalasRandomIDAA = Random.Range(0, Sala_Izq_Der_Abajo_Arriba.Length);
                Instantiate(Sala_Izq_Der_Abajo_Arriba[SalasRandomIDAA], transform.position, Quaternion.identity);
                break;
        }
    }
    private void Movimiento()
    {
        if (Direccion == 1 || Direccion == 2)
        {
            //Mover Derecha

            if (transform.position.x < PerimetroMaximo_X)

            {

                ContadorHabitacionesHaciaAbajo = 0;
                Vector2 NuevaPosicionNivel = new Vector2(transform.position.x + CantidadDeMovimientos, transform.position.y);
                transform.position = NuevaPosicionNivel;
                HabitacionesRandom = Random.Range(0, Habitaciones.Length);
                SelectorDeSalas(HabitacionesRandom);

                Direccion = Random.Range(1, 3);
                if (Direccion == 3)
                {
                    Direccion = 2;
                }
                else if (Direccion == 4)
                {
                    Direccion = 5;
                }
            }
            else
            {
                Direccion = 5;
            }
        }

        if (Direccion == 3 || Direccion == 4)
        {
            //Mover izquierda
            if (transform.position.x > PerimetroMinimo_X)
            {
                ContadorHabitacionesHaciaAbajo = 0;
                Vector2 NuevaPosicionNivel = new Vector2(transform.position.x - CantidadDeMovimientos, transform.position.y);
                transform.position = NuevaPosicionNivel;

                HabitacionesRandom = Random.Range(0, Habitaciones.Length);
                SelectorDeSalas(HabitacionesRandom);
                //Instantiate(Habitaciones[HabitacionesRandom], transform.position, Quaternion.identity);

                Direccion = Random.Range(3, 6);
            }
            else
            {
                Direccion = 5;
            }
        }
        else if (Direccion == 5)
        {
            //Mover Abajo
            ContadorHabitacionesHaciaAbajo++;
            if (transform.position.y > PerimetroMinimo_Y)
            {
                Collider2D DetectorHabitacion = Physics2D.OverlapCircle(transform.position, 1, HabitacionMascara);
                print((DetectorHabitacion.GetComponent<DestruirSalas>().TipoDeSala != 1 && DetectorHabitacion.GetComponent<DestruirSalas>().TipoDeSala != 3));
                print((ContadorHabitacionesHaciaAbajo >= 2));

                if (DetectorHabitacion.GetComponent<DestruirSalas>().TipoDeSala != 1 && DetectorHabitacion.GetComponent<DestruirSalas>().TipoDeSala != 3)
                {
                    if (ContadorHabitacionesHaciaAbajo >= 2)
                    {
                        DetectorHabitacion.GetComponent<DestruirSalas>().DestruirSala();
                        SelectorDeSalas(3);
                    }
                    else
                    {
                        DetectorHabitacion.GetComponent<DestruirSalas>().DestruirSala();

                        int RandomHabitacionAbajo = Random.Range(1, 3);
                        if (RandomHabitacionAbajo == 2)
                        {
                            RandomHabitacionAbajo = 1;
                        }
                        SelectorDeSalas(RandomHabitacionAbajo);
                    }
                }

                Vector2 NuevaPosicionNivel = new Vector2(transform.position.x, transform.position.y - CantidadDeMovimientos);
                transform.position = NuevaPosicionNivel;
                HabitacionesRandom = Random.Range(2, 3);

                SelectorDeSalas(HabitacionesRandom);
                //Instantiate(Habitaciones[HabitacionesRandom], transform.position, Quaternion.identity);
                Direccion = Random.Range(1, 6);
            }
            else
            {
                Collider2D DetectorHabitacion = Physics2D.OverlapCircle(transform.position, 1, HabitacionMascara);
                DetectorHabitacion.GetComponent<DestruirSalas>().DestruirSala();
                HabitacionesRandom = Random.Range(0, SalaFinal.Length);
                Instantiate(SalaFinal[HabitacionesRandom], transform.position, Quaternion.identity);
                PararGeneracionNivel = true;

            }
        }
    }
}
