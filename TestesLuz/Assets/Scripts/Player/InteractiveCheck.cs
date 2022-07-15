using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveCheck : MonoBehaviour
{
    private GameObject player;
    private GameObject dialogueUI;

    //public DialogueUI DialogueUI => dialogueUI;

    private bool hasDialogue;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dialogueUI = GameObject.FindGameObjectWithTag("UI");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().interactIconActivator();
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Player>().interactIconActivator();
            isInRange = false;
        }
    }

    private void Update()
    {
        if (isInRange && !hasDialogue)
        {
            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }
    void checkDialogue()
    {
        if (dialogueUI.GetComponent<DialogueUI>().IsOpen)
        {
            hasDialogue = true;
        }
        else
        {
            hasDialogue = false;
        }
    }
}
