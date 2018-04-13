using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct CitizenStruct                                                                                     //Creo la estructura para almacenar las variables del ciudadano.
{
    public string randomName;                                                                                   //Dentro de la estructura creo una variable de tipo "string" para manejar los nombres aleatorios dentro de la matríz.
    public int age;                                                                                             //Dentro de la estructura creo una variable de tipo "age" para manejar la edad.
}

public class Citizen : MonoBehaviour                                                                            //Esto es una clase que tiene algunas variables y un constructor.
{
    CitizenStruct citizenStruct_C;                                                                              //Creo una variable de tipo de la estructura "CitizenStruct_C" para poder acceder a la estructura.

    string[] names = new string[]                                                                               //Creo una matriz donde guardo en las próximas dos líneas 20 nombres para después acceder a ellos.
    {
        "Stubbs", "Rob", "Rodolfo", "Arnulfo", "Jesús", "Cristian", "Santiago", "Alonso", "Dios", "Samuel",     //En esta línea y la siguiente esta la lista de nombres que se utilizarón
        "Ricardo", "José", "Armando", "Luna", "María", "Mónica", "Manuela", "Cristobal", "Furgo", "Andrés"      //para darle nombres a los ciudadanos.
    };

    /*****************************************************************************************************************************Funcion "Start"****************************************************************************************************************************/
    void Start()
    {
        citizenStruct_C.randomName = names[Random.Range(0,20)];                                                 //Inicializo la variable "randomName" con uno de los nombres en la matríz, que como vemos, es aleatorio entre 0 y 20.
        citizenStruct_C.age = Random.Range(15, 101);                                                            //Inicializo la variable "age" con un número aleatorio entre 15 y 101.
        gameObject.tag = "Citizen";                                                                             //Al "gameObject" que contenga este script se le dará el tag de "Citizen".
    }

    /************************************************************************************************************************Funcion "CitizenMessage"************************************************************************************************************************/
    public CitizenStruct CitizenMessage()                                                                       //Creo una función de tipo de la estructura "CitizenMessage" para retornar esta y que sea utilizada en otro script.
    {
        return citizenStruct_C;                                                                                 //Retorno la variable local de la estructura, es decir, la variable llamada "citizenStruct_C".
    }
}
