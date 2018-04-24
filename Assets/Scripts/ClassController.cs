using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NPC.Enemy;                                                                                    //Para utilizar la clase "Zombie" utilizo la directiva donde se encuentra esta.
using NPC.Ally;                                                                                     //Para utilizar la clase "Citizen" utilizo la directiva donde se encuentra esta.

public class ClassController : MonoBehaviour          
{  
    int numberOfCubes;                                                                              //Creo una variable de tipo "int" que se encargará del número de cubos que se creen.                                                                
    int randomComponent;                                                                            //Creo una variable de tipo "int" que se encargará luego de, según el número, agregar un componente.
    const int MAXCUBES = 25;                                                                        //Creo una variable constante de tipo "int" que será el valor máximo de cubos que se podrán crear y no se puede editar una vez comience el juego.
    List<GameObject> zombies_citizens = new List<GameObject>();                                     //Creo una lista para almacenar todos los zombies y ciudadanos.
    int numberZombies;                                                                              //Creo una variable de tipo "int" que será el contador de zombies.
    int numberCitizens;                                                                             //Creo una variable de tipo "int" que será el contador de ciudadanos.
    public Text zo;                                                                                 //Creo una variable a la cual añadir el texto del zombie.
    public Text ci;                                                                                 //Creo una variable a la cual añadir el texto del ciudadano.

    /************************************************************************************************************************Funcion "Start"************************************************************************************************************************/
    void Start()
    {
        _ClassController cl = new _ClassController();                                               //Llamo la clase que contiene el contructor necesario para cambiar la variable "ReadOnly".
        numberOfCubes = Random.Range(cl.minCubes, MAXCUBES);                                        //Inicializo "numberOfCubes" a un valor aleatorio entre 10 y 21, esto definirá la cantidad de cubos que se creen, lo mínimo será 10 y el máximo 20.
        randomComponent = 0;                                                                        //La variable "randomComponent" se inicializa a cero.

        for (int i = 0; i <= numberOfCubes; i++)                                                    //Se hace el bucle con la siguiente condición: "i" = 0, hasta que sea menor a "numberOfCubes" vaya aumentando en uno.
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);                         //Creo una variable de tipo "GameObject" llamada "go" para almacenar el cubo que se crea después del "=".
            go.transform.position = new Vector3(Random.Range(-20, 20), 0, Random.Range(-20, 20)); ; //Luego decimos que la posición de "go" será igual a una nueva posición con el "Vector3" y entre paréntesis le damos un valor a X, Y, Z. De los cuales y será cero, y los demás serán valores aleatorios entre -20 y 20.

            if (randomComponent == 0)                                                               //En un principio "randomComponent" es igual a 0, así que en la primera vuelta de bucle entrará a este condicional.
            {
                go.AddComponent<Hero>();                                                            //Al cubo "go" que se acabó de crear se le agrega el componente llamado "Hero" que es una clase.
                go.gameObject.AddComponent<Rigidbody>();                                            //Al cubo "go" que se acabó de crear se le agrega el componente llamado "RigidBody".
            }
            else if (randomComponent == 1)                                                          //Cuando el valor almacenado en "randomComponent" sea igual a 1, entrará en este condicional.
            {
                go.AddComponent<Zombie>();                                                          //Al cubo "go" que se acabó de crear se le agrega el componente llamado "Zombie" que es una clase dentro de la directiva "NPC.Enemy".
                zombies_citizens.Add(go);                                                           //En esta línea estoy diciendo que añada a la lista "zombies_citizens" el objeto "go" que se acabó de crear.
            }
            else if (randomComponent == 2)                                                          //Cuando el valor almacenado en "randomComponent" sea igual a 2, entrará en este condicional.
            {
                go.AddComponent<Citizen>();                                                         //Al cubo "go" que se acabó de crear se le agrega el componente llamado "Citizen" que es una clase dentro de la directiva "NPC.Ally".
                zombies_citizens.Add(go);                                                           //En esta línea estoy diciendo que añada a la lista "zombies_citizens" el objeto "go" que se acabó de crear.
            }
            randomComponent = Random.Range(1, 3);                                                   //Por último, después de verificar todos los condicionales "if" anteriores, se cambia el valor de "randomComponent" para la próxima vuelta del bucle.
        }

        foreach (GameObject gos in zombies_citizens)                                                //Creo un "foreach" y entre paréntesis digo: para cada objeto "gos" (Nombre que le dí a dichos objetos) en la lista hacer:
        {
            if (gos.GetComponent<Zombie>())                                                         //El condicional verifica si el objeto "gos" tiene el componente <Zombie>.
            {
                zo.text = "Number of zombies: " + (numberZombies += 1) ;                            //El texto de "zo" cambia por lo que esta después del igual.
            }
            if (gos.GetComponent<Citizen>())                                                        //El condicional verifica si el objeto "gos" tiene el componente <Citizen>.
            {
                ci.text = "Number of citizens: " + (numberCitizens += 1);                           //El texto de "ci" cambia por lo que esta después del igual. 
            }
        }
    }
}

public class _ClassController                                                                       //Creo una clase que no hereda de "Monobehaviour".
{
    public readonly int minCubes;                                                                   //Creo una variable "ReadOnly" de tipo "int" que será el valor mínimo de cubos que se podrán crear y no se puede editar a menos que sea desde un constructor.

    public _ClassController()                                                                       //Creo un constructor de la clase "_ClassController".
    {
        minCubes = Random.Range(5, 15);                                                             //Modifico la variable minCubes y la igualo a 5, recordando que las variables "ReadOnly" solo se pueden modificar al momento de crearse o en un constructor.
    }
}