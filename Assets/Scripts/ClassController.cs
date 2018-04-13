using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassController : MonoBehaviour          
{  
    int numberOfCubes;                                                                              //Creo una variable de tipo "int" que se encargará del número de cubos que se creen.                                                                
    int randomComponent;                                                                            //Creo una variable de tipo "int" que se encargará luego de, según el número, agregar un componente.

    /************************************************************************************************************************Funcion "Start"************************************************************************************************************************/
    void Start()
    {
        numberOfCubes = Random.Range(10, 21);                                                       //Inicializo "numberOfCubes" a un valor aleatorio entre 10 y 21, esto definirá la cantidad de cubos que se creen, lo mínimo será 10 y el máximo 20.
        randomComponent = 0;                                                                        //La variable "randomComponent" se inicializa a cero.

        for (int i = 0; i <= numberOfCubes; i++)                                                    //Se hace el bucle con la siguiente condición: "i" = 0, hasta que sea menor a "numberOfCubes" vaya aumentando en uno.
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);                         //Creo una variable de tipo "GameObject" llamada "go" para almacenar el cubo que se crea después del "=".
            go.transform.position = new Vector3(Random.Range(0, 30), 0, Random.Range(0, 30)); ;     //Luego decimos que la posición de "go" será igual a una nueva posición con el "Vector3" y entre paréntesis le damos un valor a X, Y, Z. De los cuales y será cero, y los demás serán valores aleatorios entre 0 y 30.

            if (randomComponent == 0)                                                               //En un principio "randomComponent" es igual a 0, así que en la primera vuelta de bucle entrará a este condicional.
            {
                go.AddComponent<Hero>();                                                            //Al cubo "go" que se acabó de crear se le agrega el componente llamado "Hero" que es una clase.
                go.gameObject.AddComponent<Rigidbody>();                                            //Al cubo "go" que se acabó de crear se le agrega el componente llamado "RigidBody".
            }
            else if (randomComponent == 1)                                                          //Cuando el valor almacenado en "randomComponent" sea igual a 1, entrará en este condicional.
            {
                go.AddComponent<Zombie>();                                                          //Al cubo "go" que se acabó de crear se le agrega el componente llamado "Zombie" que es una clase.
            }
            else if (randomComponent == 2)                                                          //Cuando el valor almacenado en "randomComponent" sea igual a 2, entrará en este condicional.
            {
                go.AddComponent<Citizen>();                                                         //Al cubo "go" que se acabó de crear se le agrega el componente llamado "Citizen" que es una clase.
            }
            randomComponent = Random.Range(1, 3);                                                   //Por último, después de verificar todos los condicionales "if" anteriores, se cambia el valor de "randomComponent" para la próxima vuelta del bucle.
        }
    }
}