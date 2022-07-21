using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    //Objetos 
    GameObject player;

    //Variaveis
    [SerializeField] string sceneToLoad;
    [SerializeField] Vector2 playerPosition; //variavel que determina a onde o player vai aparecer

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); //Como o player não esta em todas as fases, é necessario encontra-lo via script
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !other.isTrigger)
        {
            SceneManager.LoadScene(sceneToLoad);
            player.transform.position = playerPosition;
            
        }
    }


}
