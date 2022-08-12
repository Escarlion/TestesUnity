using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public IInteractable Interactable { get; set; }

    //Objetos
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] Animator animator;
    private PlayerManager playerManager;
    public DialogueUI DialogueUI => dialogueUI;
    private Rigidbody2D rb;
    
    //Variaveis
    private bool isInteractive = false; 
    [HideInInspector]
    public bool facingRight = true;
    public float MoveSpeed = 5f;
    Vector2 movement;


    private void Start()
    {
        playerManager = GetComponent<PlayerManager>();
        rb = GetComponent<Rigidbody2D>(); 
    }

    private void Update()
    {
        //Atualiza o a posição do personagem
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //Roda a animação de movimento
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        //interação
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            if (!dialogueUI.IsOpen)
            {
                Interactable?.Interact(this);
            }
            
        }
        //Corrida
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = 5f;
        }
        //Lanterna
        if (Input.GetKeyDown(KeyCode.Q))
        { 
            //verifica se ele esta ativo ou não
            if (gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(false);
            }
            else if (!gameObject.transform.GetChild(0).gameObject.activeSelf)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
            } 
        }
       
    }

    private void FixedUpdate()
    {
        PlayerMovement();
    }

    //Inverte o sprite do personagem
    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;
        
        facingRight = !facingRight;
    }
   //Move o personagem 
    void PlayerMovement()
    {
        if (dialogueUI.IsOpen) return; //impede que o player se mova caso o dialogo esteja aberto

        rb.MovePosition(rb.position + movement.normalized * (MoveSpeed * Time.fixedDeltaTime)); //faz o player se mexer
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        else if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }
    //Ativa o Icone quando esta em contato com algo interativo
    public void interactIconActivator()
    {
        isInteractive = !isInteractive;
        if (isInteractive == true)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (isInteractive == false)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(false);
        }
    }
}