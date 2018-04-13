using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct HeroStruct                                                                                                                        //Creo la estructura para almacenar las variables del héroe.
{
    public float speedHero;                                                                                                                     //Creo una variable de tipo "float" que será la velocidad del héroe.
    public Vector3 positionHero;                                                                                                                //Creo una variable de tipo "Vector3" para guardar la posición del personaje.
    public GameObject cam;                                                                                                                      //Creo una variable de tipo "GameObejct" para próximamente guardar la cámara principal de la escena.
    public Rigidbody rb;                                                                                                                        //Creo una variable de tipo "RigidBody".
}

public class Hero : MonoBehaviour                                                                                                               //La clase del héroe.
{

    HeroStruct heroStruct;                                                                                                                      //Creo una variable de tipo "HeroStruct" que es la estructura del héroe.
    ZombieStruct zombieStruct_H;                                                                                                                //Creo una variable de tipo "ZombieStruct" que es la estructura del zombie.
    CitizenStruct citizenStruct_H;                                                                                                              //Creo una variable de tipo "CitizenStruct" que es la estructura del ciudadano.

    /******************************************************************************************************************Funcion "OnCollisionEnter"******************************************************************************************************************/
    void OnCollisionEnter(Collision collision)                                                                                                  //Utilizo la función "OnCollisionEnter" para detectar cuando hay una colisión.
    {
        if (collision.gameObject.GetComponent<Zombie>())                                                                                        //Verifico con el condicional si el objeto que tiene este script esta chocando con algún otro que tenga el componente de "Zombie".
        {
            zombieStruct_H = collision.gameObject.GetComponent<Zombie>().ZombieMessage();                                                       //En resumen, "ZombieStruct_H" es igual a la función "ZombieMessage()" ubicada en la clase "Zombie" y, esta función retorna la estructura local de dicha clase, por lo tanto, "ZombieStruct_H" será igual a "ZombieStruct_Z".
            print("Waaaarrrr i want to eat " + zombieStruct_H.bodyPart);                                                                        //Ahora imprimo lo que aparece entre comillas más "zombieStruct_H.bodyPart", es decir, "zombieStruct_H" se acabó de sobrescribir por "zombieStruct_Z" y luego accedimos a la variable "bodyPart" de la estructura.
        }
        if (collision.gameObject.GetComponent<Citizen>())                                                                                       //Verifico con el condicional si el objeto que tiene este script esta chocando con algún otro que tenga el componente de "Citizen".
        {
            citizenStruct_H = collision.gameObject.GetComponent<Citizen>().CitizenMessage();                                                    //En resumen, "citizenStruct_H" es igual a la función "CitizenMessage()" ubicada en la clase "Citizen" y, esta función retorna la estructura local de dicha clase, por lo tanto, "CitizenStruct_H" será igual a "CitizenStruct_C".
            print("Hello, i am " + citizenStruct_H.randomName + " and i am " + citizenStruct_H.age + " years old");                             //Ahora imprimo lo que aparece entre comillas más "CitizenStruct_H.bodyPart", es decir, "CitizenStruct_H" se acabó de sobrescribir por "CitizenStruct_Z" y luego accedimos a la variable "randomName" de la estructura, y lo mismo con "citizenStruct.age"
        }
    }

    /************************************************************************************************************************Funcion "Start"************************************************************************************************************************/
    void Start()
    {
        heroStruct.positionHero = gameObject.transform.position;                                                                                //Accedo a la estructura "heroStruct" y luego a la variable "positionHero" y digo que será igual a la posicion del "gameObject" que contiene este script.

        gameObject.name = "Hero";                                                                                                               //Al objeto que contiene este script le doy el nombre de "Hero" para que aparezca en la jerarquía con ese nombre.
        gameObject.tag = "Player";                                                                                                              //Al objeto que contiene este script le doy el tag de "Hero".

        heroStruct.rb = GetComponent<Rigidbody>();                                                                                              //A la variable "rb" de la estructura le doy el componente "RigidBoy".
        gameObject.GetComponent<Renderer>().material.color = Color.black;                                                                       //Le doy un color al personaje, un simple cambio visual.
        heroStruct.rb.constraints = RigidbodyConstraints.FreezeRotation;                                                                        //A la variable "rb" de la estructura le digo que acceda a los "Constraints" y ponga verdadero todo el "FreezeRotation" en el inspector.
        heroStruct.speedHero = Random.Range(0.05f, 0.2f);                                                                                       //A la variable "speedHero" de la estructura la inicializo como un valor aleatorio entre 0.05 y 0.2.
        heroStruct.cam = GameObject.FindGameObjectWithTag("MainCamera");                                                                        //A la variable "cam" de la estructura almaceno el "gameObject" que tenga el tag de "MainCamera", es decir que se guardará la cámara principal de la escena.
        heroStruct.cam.transform.position = new Vector3(heroStruct.positionHero.x, heroStruct.positionHero.y + 1, heroStruct.positionHero.z);   //Ahora a la variable "cam" le doy una posición en la escena, la cual va a ser igual que a la del personaje o "Hero" pero se le suma 1 a "y" para que este un poco más alta y simule la cabeza.
        heroStruct.cam.transform.SetParent(gameObject.transform);                                                                               //Ahora a la variable "cam" la emparento al objeto que tenga este script, es decir al "Hero", para que a donde se mueva el objeto, también se mueva la cámara.
        gameObject.AddComponent<FPSMove>().speed = heroStruct.speedHero;                                                                        //Al personaje le agrego el componente "FPSMove" y le digo que la variable "speed" de dicha clase será igual a "speedHero" que esta en esta clase.
        heroStruct.cam.AddComponent<FPSAim>();                                                                                                  //A la cámara le añado el componente "FPSAim".
    }
}