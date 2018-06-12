using System.Collections;                                               //UpWork / HackerRank
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.Ally;                                                                                                                                         //Para utilizar la clase "Citizen" utilizo la directiva donde se encuentra esta.                         
using NPC.Enemy;                                                                                                                                        //Para utilizar la clase "Zombie" utilizo la directiva donde se encuentra esta.
using NPC;                                                                                                                                              //Para utilizar la clase "Npc" utilizo la directiva donde se encuentra esta.

/****************************************************************************************************************************Clase Hero*****************************************************************************************************************************/
public class Hero : MonoBehaviour                                                                                                                       //La clase del héroe.
{
    HeroStruct heroStruct_H;                                                                                                                            //Creo una variable de tipo "HeroStruct" que es la estructura del héroe.
    ZombieStruct zombieStruct_H;                                                                                                                        //Creo una variable de tipo "ZombieStruct" que es la estructura del zombie.
    CitizenStruct citizenStruct_H;                                                                                                                      //Creo una variable de tipo "CitizenStruct" que es la estructura del ciudadano.
    NpcStruct npcStruct_H;                                                                                                                              //Creo una variable de tipo "NpcStruct" que es la estructura del npc.

    WaitForSeconds textEnabled = new WaitForSeconds(2);                                                                                                 //Creo una variable de tipo "waitForSeconds" para utilizarla en la corrutina.

    /******************************************************************************************************************Funcion "OnCollisionEnter"******************************************************************************************************************/
    void OnCollisionEnter(Collision collision)                                                                                                          //Utilizo la función "OnCollisionEnter" para detectar cuando hay una colisión.
    {
        if (collision.gameObject.GetComponent<Zombie>())                                                                                                //Verifico con el condicional si el objeto que tiene este script esta chocando con algún otro que tenga el componente de "Zombie".
        {
            zombieStruct_H = collision.gameObject.GetComponent<Zombie>().ZombieMessage();                                                               //En resumen, "ZombieStruct_H" es igual a la función "ZombieMessage()" ubicada en la clase "Zombie" y, esta función retorna la estructura local de dicha clase, por lo tanto, "ZombieStruct_H" será igual a "ZombieStruct_Z".
            StopCoroutine("RemoveDialogue");                                                                                                            //Detengo la corrutina, esto es para que siempre que colisione se asegure de, en caso de que este activada, la detenga para que no se acumule.
            heroStruct_H.dialogue.enabled = true;                                                                                                       //Activo el texto para que se pueda hacer la siguiente línea.
            heroStruct_H.dialogue.text = "ZOMBIE: Waaaarrrr i want to eat " + zombieStruct_H.bodyPart;                                                  //Ahora el texto de la variable "dialogue" de la estructura cambiará a lo que aparece entre comillas más "zombieStruct_H.bodyPart", es decir, "zombieStruct_H" se acabó de sobrescribir por "zombieStruct_Z" y luego accedimos a la variable "bodyPart" de la estructura.
            StartCoroutine("RemoveDialogue");                                                                                                           //Llamo la corrutina que desactivará el texto.
        }
        if (collision.gameObject.GetComponent<Citizen>())                                                                                               //Verifico con el condicional si el objeto que tiene este script esta chocando con algún otro que tenga el componente de "Citizen".
        {
            citizenStruct_H = collision.gameObject.GetComponent<Citizen>().CitizenMessage();                                                            //En resumen, "citizenStruct_H" es igual a la función "CitizenMessage()" ubicada en la clase "Citizen" y, esta función retorna la estructura local de dicha clase, por lo tanto, "CitizenStruct_H" será igual a "CitizenStruct_C".
            npcStruct_H = collision.gameObject.GetComponent<Npc>().NpcMessage();
            StopCoroutine("RemoveDialogue");                                                                                                            //Detengo la corrutina, esto es para que siempre que colisione se asegure de, en caso de que este activada, la detenga para que no se acumule.
            heroStruct_H.dialogue.enabled = true;                                                                                                       //Activo el texto para que se pueda hacer la siguiente línea.
            heroStruct_H.dialogue.text = "CITIZEN: Hello, i am " + citizenStruct_H.names + " and i am " + npcStruct_H.age + " years old";               //Ahora el texto de la variable "dialogue" de la estructura cambiará a lo que aparece entre comillas más "CitizenStruct_H.bodyPart", es decir, "CitizenStruct_H" se acabó de sobrescribir por "CitizenStruct_Z" y luego accedimos a la variable "randomName" de la estructura, y lo mismo con "citizenStruct.age"
            StartCoroutine("RemoveDialogue");                                                                                                           //Llamo la corrutina que desactivará el texto.
        }
    }

    /************************************************************************************************************************Funcion "Start"************************************************************************************************************************/
    void Start()
    {
        S_Hero speedHero = new S_Hero();                                                                                                                    //Instancio la clase "S_Hero".

        heroStruct_H.positionHero = gameObject.transform.position;                                                                                          //Accedo a la estructura "heroStruct" y luego a la variable "positionHero" y digo que será igual a la posicion del "gameObject" que contiene este script.
        heroStruct_H.dialogue = GameObject.FindGameObjectWithTag("Dialogue").GetComponent<Text>();                                                          //A la variable de tipo texto "dialogue" que está dentro de la estructura le asigno el componente "text" del "GameObject" que tenga el tag "Dialogue".

        gameObject.name = "Hero";                                                                                                                           //Al objeto que contiene este script le doy el nombre de "Hero" para que aparezca en la jerarquía con ese nombre.
        gameObject.tag = "Player";                                                                                                                          //Al objeto que contiene este script le doy el tag de "Hero".

        heroStruct_H.rb = GetComponent<Rigidbody>();                                                                                                        //A la variable "rb" de la estructura le doy el componente "RigidBoy".
        gameObject.GetComponent<Renderer>().material.color = Color.black;                                                                                   //Le doy un color al personaje, un simple cambio visual.
        heroStruct_H.rb.constraints = RigidbodyConstraints.FreezeRotation;                                                                                  //A la variable "rb" de la estructura le digo que acceda a los "Constraints" y ponga verdadero todo el "FreezeRotation" en el inspector.
        heroStruct_H.cam = GameObject.FindGameObjectWithTag("MainCamera");                                                                                  //A la variable "cam" de la estructura almaceno el "gameObject" que tenga el tag de "MainCamera", es decir que se guardará la cámara principal de la escena.
        heroStruct_H.cam.transform.position = new Vector3(heroStruct_H.positionHero.x, heroStruct_H.positionHero.y + 1, heroStruct_H.positionHero.z - 2);   //Ahora a la variable "cam" le doy una posición en la escena, la cual va a ser igual que a la del personaje o "Hero" pero se le suma 1 a "y" para que este un poco más alta y simule la cabeza.
        heroStruct_H.cam.transform.SetParent(gameObject.transform);                                                                                         //Ahora a la variable "cam" la emparento al objeto que tenga este script, es decir al "Hero", para que a donde se mueva el objeto, también se mueva la cámara.
        gameObject.AddComponent<FPSMove>().speed = speedHero.speed_Hero;                                                                                    //Al personaje le agrego el componente "FPSMove" y le digo que la variable "speed" de dicha clase será igual a "speed_Hero" que esta en la clase "S_Hero".
        heroStruct_H.cam.AddComponent<FPSAim>();                                                                                                            //A la cámara le añado el componente "FPSAim".
    }

    /******************************************************************************************************************Corrutina "RemoveDialogue"**********************************************************************************************************************/
    IEnumerator RemoveDialogue()                                                                                                                        //Creo la corrutina que controla el texto del diálogo para desactivar.
    {
        yield return textEnabled;                                                                                                                       //Hago que la corrutina espere dos segundos.
        heroStruct_H.dialogue.enabled = false;                                                                                                          //Y luego que desactive el texto.
    }
}

/****************************************************************************************************************************Clase "S_Hero"****************************************************************************************************************************/
public class S_Hero                                                                                                                                     //Creo una clase que no hereda de "Monobehaviour".                                                                                                                             
{
    public readonly float speed_Hero;                                                                                                                   //Creo una variable de tipo "float" y "readOnly".

    /*********************************************************************************************************************Contructor "S_Hero"**************************************************************************************************************************/
    public S_Hero()                                                                                                                                     //Creo un constructor para poder cambiar la variable "speed_Hero".
    {
        speed_Hero = Random.Range(0.01f, 0.3f);                                                                                                         //Dentro del constructor cambio la variable "speed_Hero".
    }
}