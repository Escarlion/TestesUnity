using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    [HideInInspector]
    public string objectID;

    //Cria um ID para evitar que objetos sejam duplicados
    private void Awake()
    {
        objectID = name + transform.position.ToString(); //Usa a posição para evitar problemas com objetos com o mesmo nome
    }

    void Start()
    {
        //Destroi objetos com Id's iguais
        for (int i = 0; i < Object.FindObjectsOfType<DontDestroy>().Length; i++)
        {
            if(Object.FindObjectsOfType<DontDestroy>()[i] != this)
            {
                if(Object.FindObjectsOfType<DontDestroy>()[i].objectID == objectID)
                {
                    Destroy(gameObject);
                }
            }
        }
        
        DontDestroyOnLoad(gameObject);
    }

}
