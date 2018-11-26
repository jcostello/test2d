using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float runSpeed = 40f;

    private PlayerMovement playerMovement;
    private PlayerHealth playerHealth;
    private Animator animator;
    private Rigidbody2D rigidbody;
    private CircleCollider2D collider;

    private int enemyLayer; 
    private float horizontalMove = 0f;
    private float raycastOffset = .1f;
    private bool jump = false;


    private void Start() {
        enemyLayer = LayerMask.NameToLayer("Enemy");
        collider = GetComponent<CircleCollider2D>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update() {
        if (!playerHealth.isDamaged) {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

            if (Input.GetButtonDown("Jump")) {
                jump = true;
            }

            animator.SetFloat("horizontalSpeed", Mathf.Abs(horizontalMove));
            animator.SetFloat("verticalSpeed", rigidbody.velocity.y);
        }
    }

    private void FixedUpdate() {
        if (!playerHealth.isDamaged) {
            playerMovement.Move(horizontalMove * Time.fixedDeltaTime, jump);
        }

        jump = false;
    }

    public void Bounce() {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        rigidbody.AddForce(Vector2.up.normalized * 500);
    }
}
