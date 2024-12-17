using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed; //Velocidad de la plataforma
    [SerializeField] int startingPoints; //Número para determinar el index del punto del inicio del movimiento
    [SerializeField] Transform[] points; //Array de puntos de posiciíon a los que la plataforma "Perseguirá"
    int i; //Index que determina que número de plataforma se persigue actualmente 


    // Start is called before the first frame update
    void Start()
    {
        //Setear la posición inicial de la plataforma en uno de los puntos 
        transform.position = points[startingPoints].position;
    }

    // Update is called once per frame
    void Update()
    {
        platformMove();
    }

    void platformMove()
    {
        //Detector de si la plataforma ha llegado al destino, cambiando el destino
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f) 
        {
            i++; //Aumenta en uno el index, cambia de objetivo
            if (i == points.Length) i = 0;
            

           
         }
        //Movimiento: siempre despues de la detección
        //Mueve la plataforma al punto del array que coincide con el valor de i
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

}
