﻿using NPC.Ally;
using NPC.Enemy;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/******************************************************************************************************************************NameSpace NPC***********************************************************************************************************************************/
namespace NPC                                                                                                   //Creo el "nameSpace" para almacenar las dos clases.
{
    /****************************************************************************************************************************Clase "Npc"*************************************************************************************************************************************/
    public class Npc : MonoBehaviour                                                                            //Creamos la clase "Npc" que contiene todo lo que van a tener en común el zombie y el aldeano, como por ejemplo el movimineto.
    {
        public ZombieStruct zombieStruct_N;                                                                     //Creo una variable del tipo de la estructura "ZombieStruct" y la llamo igual, simplemente que en minúsculas y luego del guión bajo, la letra de la clase a la que corresponde.
        public CitizenStruct citizenStruct_N;                                                                   //Creo una variable de tipo de la estructura "CitizenStruct" para poder acceder a una copia de estructura.
        public NpcStruct npcStruct_N;                                                                           //Creo una variable de tipo de la estructura "NpcStruct" para poder acceder a una copia de ella.
        WaitForSeconds timeBehaviourChange = new WaitForSeconds(3);                                             //Inicializo la variable "timeBehaviourChage" y va a ser igual a un tiempo de espera de 3 segundos.
        /**********************************************************************************************************************Función "_Start"*********************************************************************************************************************************/
        public void Awake()                                                                                     //Creo una función que se encarga de hacer lo que se debe hacer en la funcion "Start" de Unity, para luego llamar esta función en las otras clases desde su propio "Start" para no se sobrescriba la una a la otra.
        {
            npcStruct_N.age = Random.Range(15, 101);                                                            //Inicializo la variable "age" con un número aleatorio entre 15 y 101.
            npcStruct_N.rotationVelocity = Random.Range(15, 100);                                               //Inicializo la variable "rotationVelocity" que está dentro de la estructura "npcStruct_N" y va a ser igual a un número entre 15 y 99 realmente.

            if (npcStruct_N.age <= 15)                                                                          //Con este condicional verifico la edad para darle una velocidad, si es menor a 15...                                           
            {
                npcStruct_N.runSpeed = 10.0f;                                                                   //Su velocidad será 10.
            }
            else if (npcStruct_N.age <= 30 && npcStruct_N.age > 15)                                             //Si es mayor de 15 pero menor de 30...
            {
                npcStruct_N.runSpeed = 8.0f;                                                                    //Su velocidad será 8.
            }
            else if (npcStruct_N.age <= 50 && npcStruct_N.age > 30)                                             //Si es mayor de 30 pero menor de 50...
            {
                npcStruct_N.runSpeed = 7.0f;                                                                    //Su velocidad será 7.
            }
            else if (npcStruct_N.age <= 75 && npcStruct_N.age > 50)                                             //Si es mayor de 50 pero menor de 75...
            {
                npcStruct_N.runSpeed = 6.0f;                                                                    //Su velocidad será 6.
            }
            else if (npcStruct_N.age <= 100 && npcStruct_N.age > 75)                                            //Si es mayor de 75 pero menor de 100...
            {
                npcStruct_N.runSpeed = 5.0f;                                                                    //Su velocidad será 5.
            }

            StartCoroutine("ChangeBehaviour");                                                                  //Iniciamos la corrutina "ChangeBehaviour".
        }

        /**********************************************************************************************************************Función "Movement"*********************************************************************************************************************************/
        public void Movement()
        {
            switch (npcStruct_N.npcBehaviour)                                                                   //Creamos un "switch" para comparar la variable "zombieBehaviour" que está dentro de la estructura.
            {
                case NpcBehaviour.Idle:                                                                         //En caso que el comportamiento sea "Idle":
                    transform.position = transform.position;                                                    //La posición del este objeto será igual a la posición de este objeto, es decir, si se estaba moviendo ya no lo hará porque la posición de este será la misma en la que se encuentra.
                    goto case NpcBehaviour.Running;                                                             //Después de este caso, se mandará a verificar el caso "Running".                                   

                case NpcBehaviour.Moving:                                                                       //En caso que el comportamiento sea "Moving":
                    transform.position += (transform.forward * npcStruct_N.runSpeed) * Time.deltaTime;          //La posición será igual a un movimiento hacia "forward" positivo, es decir, hacia el frente.
                    goto case NpcBehaviour.Running;                                                             //Después de este caso, se mandará a verificar el caso "Running".                 

                case NpcBehaviour.Rotating:                                                                     //En caso que el comportamiento sea "Rotating".
                    switch (npcStruct_N.randomRotation)                                                         //Creamos otro "switch" para comparar la variabke "randomRotation" que está dentro de la estructura.
                    {
                        case 0:                                                                                 //En caso que la variable sea igual a cero:
                            transform.Rotate(0, npcStruct_N.rotationVelocity * Time.deltaTime, 0, 0);           //La rotación será igual a un movimiento positivo en "Y", es decir, hacia la derecha.
                            break;                                                                              //Rompemos el "switch".
                        case 1:                                                                                 //En caso que la variable sea igual a uno:
                            transform.Rotate(0, -npcStruct_N.rotationVelocity * Time.deltaTime, 0, 0);          //La rotación será igual a un movimiento negativo en "Y", es decir, hacia la izquierda.
                            break;                                                                              //Rompemos el "switch".
                    }
                    goto case NpcBehaviour.Running;                                                             //Después de este caso, se mandará a verificar el caso "Running".                                                            

                case NpcBehaviour.Running:                                                                      //Ya que este caso se debe estar verificando constantemente, es por eso que los anteriores siempre llegan a este.
                    DistanceFunction();                                                                         //Llamamos la función "DistanceFunction".
                    break;
            }
        }
        /**********************************************************************************************************************Función "DistanceFunction"*********************************************************************************************************************************/
        public virtual void DistanceFunction()                                                                                                                              //La función es "Virtual" porque luego se necesita sobreescribir.
        {
            foreach (GameObject cit in ClassController.citizenList)                                                                                                         //A esta función base accederá el zombie, por eso el foreach verifica la lista de ciudadanos, que es con la que trabajará cada zombie.
            {
                npcStruct_N.distances = Vector3.Distance(gameObject.transform.position, cit.transform.position);                                                            //A la variable "distance" ubicada en la estructura de "NPC" le asignamos la distancia entre el "gameObject" que entre a esta función, es decir el zombie, y el ciudadano que este en el momento de verificación del "foreach".

                if (npcStruct_N.distances < 5 && npcStruct_N.distances > 1.0f)
                {
                    if (cit.GetComponent<Citizen>() || cit.GetComponent<Hero>())
                    {
                        gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, cit.transform.position, npcStruct_N.runSpeed * Time.deltaTime);
                        npcStruct_N.npcBehaviour = NpcBehaviour.Running;
                    }
                }
            }
        }

        /*************************************************************************************************************************Corrutina "ChangeBehaviour"***********************************************************************************************************************/
        IEnumerator ChangeBehaviour()
        {
            ChooseBehaviour();                                                                                  //Llamamos la función "ChooseBehaviour".
            yield return timeBehaviourChange;                                                                   //Utilizamos la variable "timeBehaviourChange" para esperar cinco segundos.
            StartCoroutine("ChangeBehaviour");                                                                  //Por último volvemos a iniciar la corrutina.
        }

        /*************************************************************************************************************************Funcion "ChooseBehaviour"*************************************************************************************************************************/
        void ChooseBehaviour()
        {
            npcStruct_N.randomRotation = Random.Range(0, 2);                                                    //Inicializamos la variable "randomRotation" y va a ser igual a un número aleatorio entre 0 y 1 realmente.
            npcStruct_N.npcBehaviour = (NpcBehaviour)Random.Range(0, 3);                                        //Inicializamos la variable "zombieBehaviour" y va a ser igual a un comportamiento aleatorio. Mismo caso que cuando inicializamos la variable "bodyPart".
        }
        /***************************************************************************************************************************Función "NpcMessage"****************************************************************************************************************************/
        public NpcStruct NpcMessage()
        {
            return npcStruct_N;
        }
    }

    /*********************************************************************************************************************************NameSpace Enemy***********************************************************************************************************************************/
    namespace Enemy                                                                                             //Creo otro "nameSpace" para almacenar la clase "Zombie".
    {
        /*****************************************************************************************************************************Clase "Zombie"*******************************************************************************************************************************/
        public class Zombie : Npc                                                                               //Ahora entramos a la clase "Zombie" que hereda de la clase "Npc".
        {
            /***********************************************************************************************************************Funcion "Start"********************************************************************************************************************************/
            void Start()
            {
                gameObject.name = "Zombie";                                                                     //Al objeto que tenga este script se le dará el nombre de "Zombie".
                gameObject.tag = "Zombie";                                                                      //Al objeto que tenga este script se le dará el tag de "Zombie".
                zombieStruct_N.randomColor = Random.Range(0, 3);                                                //Inicializo la variable "randomColor" que está dentro de la estructura y va a ser igual a un número aleatorio entre 0 y 2 realmente.
                zombieStruct_N.bodyPart = (BodyPart)Random.Range(0, 5);                                         //Inicializo la variable "bodyPart" que esta dentro de la estructura y va a ser igual a una parte aleatoria de la enumeración "BodyPart", es decir, primero se obtiene un número aleatorio entre 0 y 4 realmente, y como la variable no es de un tipo de número, es decir, no puede almacenar números, por lo tanto ese número que obtengamos se transfoma en una posición de la enumeración con los paréntesis (BodyPart).
                ChangeColor();                                                                                  //Llamamos la función "ChangeColor".
            }

            /***********************************************************************************************************************Funcion "Update"*******************************************************************************************************************************/
            void Update()
            {
                Movement();
            }

            /********************************************************************************************************************Funcion "ChangeColor"****************************************************************************************************************************/
            public void ChangeColor()
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

            private void OnCollisionEnter(Collision collision)
            {
                if (collision.gameObject.GetComponent<Citizen>())
                {
                    Citizen c = collision.gameObject.GetComponent<Citizen>();
                    Zombie z = c;
                }
            }


            /*********************************************************************************************************************Función "ZombieMessage"***************************************************************************************************************************/
            public ZombieStruct ZombieMessage()
            {
                return zombieStruct_N;                                                                          //Retornamos la variable de la estructura.                                       
            }
        }
    }

    /*********************************************************************************************************************************NameSpace Ally********************************************************************************************************************************/
    namespace Ally                                                                                              //Creo otro "nameSpace" para almacenar la clase "Citizen".
    {
        /****************************************************************************************************************************Clase "Citizen"********************************************************************************************************************************/
        public class Citizen : Npc                                                                              //Esto es una clase que hereda de "Npc".
        {
            float distanceC_Z;
            /*************************************************************************************************************************Funcion "Start"*******************************************************************************************************************************/
            void Start()
            {                                                                                   
                citizenStruct_N.names = (Names)Random.Range(0, 20);                                             //Inicializo la variable "names" con uno de los nombres en la enumeración, que como vemos, es aleatorio entre 0 y 20.
                gameObject.name = citizenStruct_N.names.ToString();                                             //El objeto que contenga este componente "Citizen" tendrá como nombre el elegido del enumerador de nombres.
                gameObject.tag = "Citizen";                                                                     //Al "gameObject" que contenga este script se le dará el tag de "Citizen".
            }

            /*************************************************************************************************************************Función "Update"*******************************************************************************************************************************/
            void Update()
            {
                Movement();                                                                                     //Llamo la función "Movement" que se encuentra en la clase "Npc".
            }

            /***********************************************************************************************************************Funcion "CitizenMessage"**************************************************************************************************************************/
            public CitizenStruct CitizenMessage()                                                               //Creo una función de tipo de la estructura "CitizenMessage" para retornar esta y que sea utilizada en otro script.
            {
                return citizenStruct_N;                                                                         //Retorno la variable local de la estructura, es decir, la variable llamada "citizenStruct_C".
            }

            public override void DistanceFunction()
            {
                foreach (GameObject zom in ClassController.zombieList)
                {
                    npcStruct_N.distances = Vector3.Distance(gameObject.transform.position, zom.transform.position);

                    if (npcStruct_N.distances < 5)
                    {
                        if (gameObject.GetComponent<Citizen>() && zom.GetComponent<Zombie>())
                        {
                            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, zom.transform.position, -npcStruct_N.runSpeed * Time.deltaTime);
                            npcStruct_N.npcBehaviour = NpcBehaviour.Running;
                        }
                    }
                }
            }

            /*****************************************************************************************************************Implicit Operator************************************************************************************************************************/
            public static implicit operator Zombie(Citizen c)
            {
                Zombie z = c.gameObject.AddComponent<Zombie>();
                z.npcStruct_N.age = c.npcStruct_N.age;
                Destroy(c);
                return z;
            }
        }
    }
}