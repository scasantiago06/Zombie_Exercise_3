﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC                                                                                                   //Creo el "nameSpace" para almacenar las dos clases.
{
    public class Npc : MonoBehaviour                                                                            //Creamos la clase "Npc" que contiene todo lo que van a tener en común el zombie y el aldeano, como por ejemplo el movimineto.
    {
        public ZombieStruct zombieStruct_N;                                                                     //Creo una variable del tipo de la estructura "ZombieStruct" y la llamo igual, simplemente que en minúsculas y luego del guión bajo, la letra de la clase a la que corresponde.
        public CitizenStruct citizenStruct_N;                                                                   //Creo una variable de tipo de la estructura "CitizenStruct_C" para poder acceder a la estructura.
        public NpcStruct npcStruct_N;
        WaitForSeconds timeBehaviourChange = new WaitForSeconds(3);                                             //Inicializo la variable "timeBehaviourChage" y va a ser igual a un tiempo de espera de 3 segundos.

        public void _Start()                                                                                    //Creo una función que se encarga de hacer lo que se debe hacer en la funcion "Start" de Unity, para luego llamar esta función en las otras clases desde su propio "Start" para no se sobrescriba el uno al otro.
        {
            npcStruct_N.age = Random.Range(15, 101);                                                            //Inicializo la variable "age" con un número aleatorio entre 15 y 101.
            zombieStruct_N.rotationVelocity = Random.Range(15, 100);                                            //Inicializo la variable "rotationVelocity" que está dentro de la estructura y va a ser igual a un número entre 15 y 99 realmente.
            StartCoroutine("ChangeBehaviour");                                                                  //Iniciamos la corrutina "ChangeBehaviour".
        }

        public void _Update()
        {
            //direction = Vector3.Normalize(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);

            switch (npcStruct_N.npcBehaviour)                                                                   //Creamos un "switch" para comparar la variable "zombieBehaviour" que está dentro de la estructura.
            {
                case NpcBehaviour.Idle:                                                                         //En caso que el comportamiento sea "Idle":
                    transform.position = transform.position;                                                    //La posición del este objeto será igual a la posición de este objeto, es decir, si se estaba moviendo ya no lo hará porque la posición de este será la misma en la que se encuentra.
                    break;                                                                                      //Rompemos el "switch" porque no necesitamos que siga.

                case NpcBehaviour.Moving:                                                                       //En caso que el comportamiento sea "Moving":
                    transform.position += (transform.forward * 1f) * Time.deltaTime;                            //La posición será igual a un movimiento hacia "forward" positivo, es decir, hacia el frente.
                    break;                                                                                      //Rompemos el "switch" externo.

                case NpcBehaviour.Rotating:                                                                     //En caso que el comportamiento sea "Rotating".
                    switch (zombieStruct_N.randomRotation)                                                      //Creamos otro "switch" para comparar la variabke "randomRotation" que está dentro de la estructura.
                    {
                        case 0:                                                                                 //En caso que la variable sea igual a cero:
                            transform.Rotate(0, zombieStruct_N.rotationVelocity * Time.deltaTime, 0, 0);        //La rotación será igual a un movimiento positivo en "Y", es decir, hacia la derecha.
                            break;                                                                              //Rompemos el "switch".
                        case 1:                                                                                 //En caso que la variable sea igual a uno:
                            transform.Rotate(0, -zombieStruct_N.rotationVelocity * Time.deltaTime, 0, 0);       //La rotación será igual a un movimiento negativo en "Y", es decir, hacia la izquierda.
                            break;                                                                              //Rompemos el "switch".
                    }
                    break;                                                                                      //Rompemos el "switch" externo.
            }
        }
        
        /************************************************************************************************************************Corrutina "ChangeBehaviour"************************************************************************************************************************/
        IEnumerator ChangeBehaviour()
        {
            ChooseBehaviour();                                                                                  //Llamamos la función "ChooseBehaviour".
            yield return timeBehaviourChange;                                                                   //Utilizamos la variable "timeBehaviourChange" para esperar cinco segundos.
            StartCoroutine("ChangeBehaviour");                                                                  //Por último volvemos a iniciar la corrutina.
        }
        
        /*************************************************************************************************************************Funcion "ChooseBehaviour"*************************************************************************************************************************/
        void ChooseBehaviour()
        {
            zombieStruct_N.randomDirection = Random.Range(0, 4);                                                //Inicializamos la variable "randomDirection" y va a ser igual a un número aleatorio entre 0 y 3 realmente.
            zombieStruct_N.randomRotation = Random.Range(0, 2);                                                 //Inicializamos la variable "randomRotation" y va a ser igual a un número aleatorio entre 0 y 1 realmente.
            npcStruct_N.npcBehaviour = (NpcBehaviour)Random.Range(0, 3);                                        //Inicializamos la variable "zombieBehaciour" y va a ser igual a un comportamiento aleatorio. Mismo caso que cuando inicializamos la variable "bodyPart".
        }

        public NpcStruct NpcMessage()
        {
            return npcStruct_N;
        }
    }

    /****************************************************************************************************************************************NameSpace Enemy***********************************************************************************************************************************/
    namespace Enemy                                                                                             //Creo otro "nameSpace" para almacenar la clase "Zombie".
    {
        public class Zombie : Npc                                                                               //Ahora entramos a la clase "Zombie".
        {
            
            //void OnDrawGizmos()
            //{
            //    Gizmos.DrawLine(transform.position, transform.position + direction);
            //}
            
            /********************************************************************************************************************************Funcion "Start"********************************************************************************************************************************/
            void Start()
            {
                _Start();
                gameObject.name = "Zombie";                                                                     //Al objeto que tenga este script se le dará el nombre de "Zombie".
                gameObject.tag = "Zombie";                                                                      //Al objeto que tenga este script se le dará el tag de "Zombie".
                zombieStruct_N.randomColor = Random.Range(0, 3);                                                //Inicializo la variable "randomColor" que está dentro de la estructura y va a ser igual a un número aleatorio entre 0 y 2 realmente.
                zombieStruct_N.bodyPart = (BodyPart)Random.Range(0, 5);                                         //Inicializo la variable "bodyPart" que esta dentro de la estructura y va a ser igual a una parte aleatoria de la enumeración "BodyPart", es decir, primero se obtiene un número aleatorio entre 0 y 4 realmente, y como la variable no es de un tipo de número, es decir, no puede almacenar números, por lo tanto ese número que obtengamos se transfoma en una posición de la enumeración con los paréntesis (BodyPart).
                ChangeColor();                                                                                  //Llamamos la función "ChangeColor".
            }

            /*******************************************************************************************************************************Funcion "Update"*******************************************************************************************************************************/
            void Update()
            {
                //direction = Vector3.Normalize(GameObject.FindGameObjectWithTag("Player").transform.position - transform.position);
                _Update();
            }

            /****************************************************************************************************************************Funcion "ChageColor"****************************************************************************************************************************/
            void ChangeColor()
            {
                switch (zombieStruct_N.randomColor)                                                             //Creo un "switch" para comparar la variable "randomColor" que esta dentro de la estructura.
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


            /******************************************************************************************************************************ZombieMessage********************************************************************************************************************************/
            public ZombieStruct ZombieMessage()
            {
                return zombieStruct_N;                                                                          //Retornamos la variable de la estructura.                                       
            }
        }
    }

    /*************************************************************************************************************************************NameSpace Ally********************************************************************************************************************************/

    namespace Ally                                                                                              //Creo otro "nameSpace" para almacenar la clase "Citizen".
    {
        public class Citizen : Npc                                                                              //Esto es una clase que tiene algunas variables y un constructor.
        {

            /*****************************************************************************************************************************Funcion "Start"*******************************************************************************************************************************/
            void Start()
            {
                _Start();
                citizenStruct_N.names = (Names)Random.Range(0, 20);                                             //Inicializo la variable "names" con uno de los nombres en la enumeración, que como vemos, es aleatorio entre 0 y 20.
                gameObject.name = citizenStruct_N.names.ToString();                                             //El objeto que contenga este componente "Citizen" tendrá como nombre el elegido del enumerador de nombres.
                gameObject.tag = "Citizen";                                                                     //Al "gameObject" que contenga este script se le dará el tag de "Citizen".
            }

            void Update()
            {
                _Update();
            }

            /************************************************************************************************************************Funcion "CitizenMessage"************************************************************************************************************************/
            public CitizenStruct CitizenMessage()                                                               //Creo una función de tipo de la estructura "CitizenMessage" para retornar esta y que sea utilizada en otro script.
            {
                return citizenStruct_N;                                                                         //Retorno la variable local de la estructura, es decir, la variable llamada "citizenStruct_C".
            }
        }
    }
}