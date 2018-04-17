using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NPC.Ally;                                                                                                                                         //Para utilizar la clase "Citizen" utilizo la directiva donde se encuentra esta.                         
using NPC.Enemy;                                                                                                                                        //Para utilizar la clase "Zombie" utilizo la directiva donde se encuentra esta.

public class Hero : MonoBehaviour                                                                                                                       //La clase del héroe.
{
    HeroStruct heroStruct_H;                                                                                                                            //Creo una variable de tipo "HeroStruct" que es la estructura del héroe.
    ZombieStruct zombieStruct_H;                                                                                                                        //Creo una variable de tipo "ZombieStruct" que es la estructura del zombie.
    CitizenStruct citizenStruct_H;                                                                                                                      //Creo una variable de tipo "CitizenStruct" que es la estructura del ciudadano.

    /******************************************************************************************************************Funcion "OnCollisionEnter"******************************************************************************************************************/
    void OnCollisionEnter(Collision collision)                                                                                                          //Utilizo la función "OnCollisionEnter" para detectar cuando hay una colisión.
    {
        if (collision.gameObject.GetComponent<Zombie>())                                                                                                //Verifico con el condicional si el objeto que tiene este script esta chocando con algún otro que tenga el componente de "Zombie".
        {
            zombieStruct_H = collision.gameObject.GetComponent<Zombie>().ZombieMessage();                                                               //En resumen, "ZombieStruct_H" es igual a la función "ZombieMessage()" ubicada en la clase "Zombie" y, esta función retorna la estructura local de dicha clase, por lo tanto, "ZombieStruct_H" será igual a "ZombieStruct_Z".
            print("Waaaarrrr i want to eat " + zombieStruct_H.bodyPart);                                                                                //Ahora imprimo lo que aparece entre comillas más "zombieStruct_H.bodyPart", es decir, "zombieStruct_H" se acabó de sobrescribir por "zombieStruct_Z" y luego accedimos a la variable "bodyPart" de la estructura.
        }
        if (collision.gameObject.GetComponent<Citizen>())                                                                                               //Verifico con el condicional si el objeto que tiene este script esta chocando con algún otro que tenga el componente de "Citizen".
        {
            citizenStruct_H = collision.gameObject.GetComponent<Citizen>().CitizenMessage();                                                            //En resumen, "citizenStruct_H" es igual a la función "CitizenMessage()" ubicada en la clase "Citizen" y, esta función retorna la estructura local de dicha clase, por lo tanto, "CitizenStruct_H" será igual a "CitizenStruct_C".
            print("Hello, i am " + citizenStruct_H.names + " and i am " + citizenStruct_H.age + " years old");                                          //Ahora imprimo lo que aparece entre comillas más "CitizenStruct_H.bodyPart", es decir, "CitizenStruct_H" se acabó de sobrescribir por "CitizenStruct_Z" y luego accedimos a la variable "randomName" de la estructura, y lo mismo con "citizenStruct.age"
        }
    }

    /************************************************************************************************************************Funcion "Start"************************************************************************************************************************/
    void Start()
    {
        S_Hero speedHero = new S_Hero();                                                                                                                //Instancio la clase "S_Hero".

        heroStruct_H.positionHero = gameObject.transform.position;                                                                                      //Accedo a la estructura "heroStruct" y luego a la variable "positionHero" y digo que será igual a la posicion del "gameObject" que contiene este script.

        gameObject.name = "Hero";                                                                                                                       //Al objeto que contiene este script le doy el nombre de "Hero" para que aparezca en la jerarquía con ese nombre.
        gameObject.tag = "Player";                                                                                                                      //Al objeto que contiene este script le doy el tag de "Hero".

        heroStruct_H.rb = GetComponent<Rigidbody>();                                                                                                    //A la variable "rb" de la estructura le doy el componente "RigidBoy".
        gameObject.GetComponent<Renderer>().material.color = Color.black;                                                                               //Le doy un color al personaje, un simple cambio visual.
        heroStruct_H.rb.constraints = RigidbodyConstraints.FreezeRotation;                                                                              //A la variable "rb" de la estructura le digo que acceda a los "Constraints" y ponga verdadero todo el "FreezeRotation" en el inspector.
        heroStruct_H.cam = GameObject.FindGameObjectWithTag("MainCamera");                                                                              //A la variable "cam" de la estructura almaceno el "gameObject" que tenga el tag de "MainCamera", es decir que se guardará la cámara principal de la escena.
        heroStruct_H.cam.transform.position = new Vector3(heroStruct_H.positionHero.x, heroStruct_H.positionHero.y + 1, heroStruct_H.positionHero.z);   //Ahora a la variable "cam" le doy una posición en la escena, la cual va a ser igual que a la del personaje o "Hero" pero se le suma 1 a "y" para que este un poco más alta y simule la cabeza.
        heroStruct_H.cam.transform.SetParent(gameObject.transform);                                                                                     //Ahora a la variable "cam" la emparento al objeto que tenga este script, es decir al "Hero", para que a donde se mueva el objeto, también se mueva la cámara.
        gameObject.AddComponent<FPSMove>().speed = speedHero.speed_Hero;                                                                                //Al personaje le agrego el componente "FPSMove" y le digo que la variable "speed" de dicha clase será igual a "speed_Hero" que esta en la clase "S_Hero".
        heroStruct_H.cam.AddComponent<FPSAim>();                                                                                                        //A la cámara le añado el componente "FPSAim".
        print(speedHero.speed_Hero);
    }
}

/******************************************************************************************************************************Clase "S_Hero"************************************************************************************************************************/
public class S_Hero                                                                                                                                     //Creo una clase que no hereda de "Monobehaviour" para utilizar "Random.Range", porque si se hereda nos saldrá error.                                                                                                                             
{
    public readonly float speed_Hero;                                                                                                                   //Creo una variable de tipo "float" y "readOnly".

    public S_Hero()                                                                                                                                     //Creo un constructor para poder cambiar la variable "speed_Hero".
    {
        speed_Hero = Random.Range(0.1f, 0.5f);                                                                                                          //Dentro del constructor cambio la variable "speed_Hero".
    }
}