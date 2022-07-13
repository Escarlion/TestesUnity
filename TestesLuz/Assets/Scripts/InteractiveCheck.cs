using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractiveCheck : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] private DialogueUI dialogueUI;

    public DialogueUI DialogueUI => dialogueUI;

    private bool hasDialogue;
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent interactAction;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.interactIconActivator();
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.interactIconActivator();
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
        if (dialogueUI.IsOpen)
        {
            hasDialogue = true;
        }
        else
        {
            hasDialogue = false;
        }
    }
}
