using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct ZombieStruct                                                                              //Creo la estructura para almacenar las variables del Zombie.
{
    public WaitForSeconds timeBehaviourChange;                                                          //Creo una variable de tipo "WaitForSeconds" para utilizarlo en la corrutina como el tiempo de espera.
    public int randomColor;                                                                             //Creo una variable de tipo "int" para determinar según el número, que color será asignado.
    public int randomDirection;                                                                         //Creo una variable de tipo "int" para determinar según el número que dirección tendrá el zombie.
    public ZombieBehaviour zombieBehaviour;                                                             //Creo una variable del tipo de la enumeración "ZombieBehaviour" para poder interáctuar los comportamientos que irá teniendo.
    public BodyPart bodyPart;                                                                           //Creo una variable del tipo de la enumeración "BodyPart" para poder interactuar con las partes que se irán eligiendo.
}

public enum ZombieBehaviour                                                                             //Creo la enumeración "ZombieBehaviour" y almaceno los comportamientos que tendrá.
{
    Idle, Moving                                                                                        //Creo los dos nombres para los comportamientos. Idle (Quieto) y Moving (Moviendo).
}

public enum BodyPart                                                                                    //Creo la enumeración "BodyPart" y almaceno las partes posibles para luego escoger.
{
    Brain, Eyes, Legs, Fingers, neck                                                                    //Creo los nombres de las partes que necesito.
}

public class Zombie : MonoBehaviour                                                                     //Ahora entramos a la clase "Zombie".
{
    public ZombieStruct zombieStruct_Z;                                                                 //Creo una variable del tipo de la estructura "ZombieStruct" y la llamo igual, simplemente que en minúsculas y luego del guión bajo, la letra de la clase a la que corresponde.

    /********************************************************************************************************************************Funcion "Start"********************************************************************************************************************************/
    void Start()
    {
        gameObject.name = "Zombie";                                                                     //Al objeto que tenga este script se le dará el nombre de "Zombie".
        gameObject.tag = "Zombie";                                                                      //Al objeto que tenga este script se le dará el tag de "Zombie".

        zombieStruct_Z.timeBehaviourChange = new WaitForSeconds(5f);                                    //Inicializo la variable "timeBehaviourChage" que está dentro de la estructura y va a ser igual a un tiempo de espera de 5 segundos.
        zombieStruct_Z.randomColor = Random.Range(0, 3);                                                //Inicializo la variable "randomColor" que está dentro de la estructura y va a ser igual a un número aleatorio entre 0 y 2 realmente.
        zombieStruct_Z.bodyPart = (BodyPart)Random.Range(0, 5);                                         //Inicializo la variable "bodyPart" que esta dentro de la estructura y va a ser igual a una parte aleatoria de la enumeración "BodyPart", es decir, primero se obtiene un número aleatorio entre 0 y 4 realmente, y como la variable no es de un tipo de número, es decir, no puede almacenar números, por lo tanto ese número que obtengamos se transfoma en una posición de la enumeración con los paréntesis (BodyPart).
        ChangeColor();                                                                                  //Llamamos la función "ChangeColor".
        StartCoroutine("ChangeBehaviour");                                                              //Iniciamos la corrutina "ChangeBehaviour".
    }

    /*******************************************************************************************************************************Funcion "Update"*******************************************************************************************************************************/
    void Update()
    {
        switch (zombieStruct_Z.zombieBehaviour)                                                         //Creamos un "switch" para comparar la variable "zombieBehaviour" que está dentro de la estructura.
        {
            case ZombieBehaviour.Idle:                                                                  //En caso que el comportamiento sea "Idle":
                transform.position = transform.position;                                                //La posición del este objeto será igual a la posición de este objeto, es decir, si se estaba moviendo ya no lo hará porque la posición de este será la misma en la que se encuentra.
                break;                                                                                  //Rompemos el "switch" porque no necesitamos que siga.

            case ZombieBehaviour.Moving:                                                                //En caso que el comportamiento sea "Moving":
                switch (zombieStruct_Z.randomDirection)                                                 //Creamos otro "switch" para comparar la variabke "randomDirection" que está dentro de la estructura.
                {
                    case 0:                                                                             //En caso que la variable sea igual a cero:
                        transform.position += (transform.forward * 1f) * Time.deltaTime;                //La posición será igual a un movimiento hacia "forward" positivo, es decir, hacia el frente.
                        break;                                                                          //Rompemos el "switch".
                    case 1:                                                                             //En caso que la variable sea igual a uno:
                        transform.position -= (transform.forward * 1f) * Time.deltaTime;                //La posición será igual a un movimiento hacia "forward" negativo, es decir, hacia atras.
                        break;                                                                          //Rompemos el "switch".
                    case 2:                                                                             //En caso que la variable sea igual a dos:
                        transform.position += (transform.right * 1f) * Time.deltaTime;                  //La posición será igual a un movimiento hacia "right" positivo, es decir, hacia la derecha.
                        break;                                                                          //Rompemos el "switch".
                    case 3:                                                                             //En caso que la variable sea igual a tres:
                        transform.position -= (transform.right * 1f) * Time.deltaTime;                  //La posición será igual a un movimiento hacia "right" negativo, es decir, hacia la izquierda.
                        break;                                                                          //Rompemos el "switch".
                }
                break;                                                                                  //Rompemos el "switch".
        }    
    }

    /****************************************************************************************************************************Funcion "ChageColor"****************************************************************************************************************************/
    void ChangeColor()
    {
        switch (zombieStruct_Z.randomColor)                                                             //Creo un "switch" para comparar la variable "randomColor" que esta dentro de la estructura.
        {
            case 0:                                                                                     //En caso que la variable sea igual a cero:
                gameObject.GetComponent<Renderer>().material.color = Color.cyan;                        //El objeto con este script tomará el color a "cyan".
                break;                                                                                  //Rompemos el "switch".
            case 1:                                                                                     //En caso que la variable sea igual a uno:
                gameObject.GetComponent<Renderer>().material.color = Color.green;                       //El objeto con este script tomará el color a "green".
                break;                                                                                  //Rompemos el "switch".
            case 2:                                                                                     //En caso que la variable sea igual a dos:
                gameObject.GetComponent<Renderer>().material.color = Color.magenta;                     //El objeto con este script tomará el color a "magenta".
                break;                                                                                  //Rompemos el "switch".
        }
    }

    /*************************************************************************************************************************Funcion "ChooseBehaviour"*************************************************************************************************************************/
    void ChooseBehaviour()
    {
        zombieStruct_Z.randomDirection = Random.Range(0, 4);                                            //Inicializamos la variable "randomDirection" y va a ser igual a un número aleatorio entre 0 y 3 realmente.
        zombieStruct_Z.zombieBehaviour = (ZombieBehaviour)Random.Range(0, 2);                           //Inicializamos la variable "zombieBehaciour" y va a ser igual a un comportamiento aleatorio. Mismo caso que cuando inicializamos la variable "bodyPart".
    }

    /******************************************************************************************************************************ZombieMessage********************************************************************************************************************************/
    public ZombieStruct ZombieMessage()
    {
        return zombieStruct_Z;                                                                          //Retornamos la variable de la estructura.                                       
    }

    /************************************************************************************************************************Corrutina "ChangeBehaviour"************************************************************************************************************************/
    IEnumerator ChangeBehaviour()
    {
        ChooseBehaviour();                                                                              //Llamamos la función "ChooseBehaviour".
        yield return zombieStruct_Z.timeBehaviourChange;                                                //Utilizamos la variable "timeBehaviourChange" para esperar cinco segundos.
        StartCoroutine("ChangeBehaviour");                                                              //Por último volvemos a iniciar la corrutina.
    }
}