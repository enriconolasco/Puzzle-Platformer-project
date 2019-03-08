using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(Rigidbody2D))]
//base class for every character in the game
public class CharacterController : MonoBehaviour {

    public float moveSpeed;

    public float jumpHeight;
    private bool isGrounded;

    public Rigidbody2D rb;
    public float characterMass;

    public GameManager gm;
    public int thisCharacterIndexNumber;

    public Camera mainCam;

    public SpriteRenderer spriteRenderer;
    public bool facingForward;

    public bool playerIsInRange = false;
    public bool isCarryingPlayer = false;
    public Transform carriedPlayer;

    public bool isCarryingCard = false;
    //characterStrength define se é possivel carregar o animal ou não. Se ela é maior que a de outro animal, o player consegue carregá-lo.
    //Exemplo: Pato characterStrenght 1, tartaruga = 2, e pug = 3. Tartaruga carrega pato, mas não carrega pug. Pug carrega ambos. Pato carrega ninguem.
    public int characterStrength;

    public virtual void Start () {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb.mass = characterMass / 100;
    }

    public virtual void Update()
    {
        Walk();
        Jump();
        CollectPlayer();
        ReleasePlayer();
    }
	
    public virtual void Walk()
    {
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.Translate(moveSpeed/1000, 0, 0);
            spriteRenderer.flipX = false;
            facingForward = true;
        }
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.Translate(-moveSpeed/1000, 0, 0);
            spriteRenderer.flipX = true;
            facingForward = false;
        }
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            isGrounded = false;
            rb.AddForce(Vector3.up*10*jumpHeight);
        }
    }

    public virtual void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public virtual void CollectPlayer()
    {
        if(isCarryingPlayer == false && Input.GetKeyDown(KeyCode.Q) && playerIsInRange == true)
        {
            carriedPlayer.gameObject.SetActive(false);
            isCarryingPlayer = true;
        }
    }

    public virtual void ReleasePlayer()
    {
        if(isCarryingPlayer == true && Input.GetKeyDown(KeyCode.E))
        {
            carriedPlayer.transform.position = new Vector3(transform.position.x + 1.0f, transform.position.y, transform.position.z);
            carriedPlayer.gameObject.SetActive(true);
            isCarryingPlayer = false;
        }
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && gm.selectedCharacterIndex == thisCharacterIndexNumber)
        {
            Physics2D.IgnoreCollision(col.collider, gameObject.GetComponent<Collider2D>());
        }
        if(col.gameObject.tag == "missile")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public virtual void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    public virtual void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && characterStrength > other.GetComponent<CharacterController>().characterStrength)
        {
            playerIsInRange = true;
            carriedPlayer = other.transform;
        }
        if (other.CompareTag("Collectable"))
        {
            Destroy(other.gameObject);
            isCarryingCard = true;
        }
    }

    public virtual void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsInRange = false;
        }
    }
}
