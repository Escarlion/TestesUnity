using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    [SerializeField] Animator animator;
    [SerializeField] public SpriteRenderer sprite;

    public float MoveSpeed = 5f; //velocidade do player
    bool facingRight = true;
    Vector2 movement;
    public DialogueUI DialogueUI => dialogueUI;

    public IInteractable Interactable { get; set; }

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); //cria a colisão
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
      
        if (Input.GetKeyDown(KeyCode.E)) //interação
        {
            Interactable?.Interact(this);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MoveSpeed = 10f;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MoveSpeed = 5f;
        }
        if (Input.GetKeyUp(KeyCode.Q))
        {
            sprite.sortingOrder = 1;
        }
    }

    private void FixedUpdate()
    {
        if (dialogueUI.IsOpen) return; //impede que o player se mova caso o dialogo esteja aberto
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }
        rb.MovePosition(rb.position + movement.normalized * (MoveSpeed * Time.fixedDeltaTime)); //faz o player se mexer
        if (movement.x > 0 && !facingRight)
        {
            Flip();
        }
        if (movement.x < 0 && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;
        gameObject.transform.localScale = currentScale;

        facingRight = !facingRight;
    }
}
