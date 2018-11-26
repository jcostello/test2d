using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public bool isGrounded = false;

    [SerializeField] private Collider2D bottomCollider;
    [SerializeField] private LayerMask bottomCollisionMask;

    private PlayerHealth playerHealth;

    private void Start() {
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update() {
        isGrounded = false; 

		Collider2D collider = Physics2D.OverlapCircle(bottomCollider.bounds.center - new Vector3(0, bottomCollider.bounds.size.y / 3, 0), bottomCollider.bounds.size.x / 2.5f, bottomCollisionMask);

		if (collider) {
            IPlayerCollisionable playerCollisionable = collider.GetComponent<IPlayerCollisionable>();
            playerCollisionable.PlayerCollision(bottomCollider);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.name == "Frog") {
            playerHealth.TakeDamage();
        }

    }

	private void OnDrawGizmos() {
		Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(bottomCollider.bounds.center - new Vector3(0, bottomCollider.bounds.size.y / 3, 0), bottomCollider.bounds.size.x / 2.5f);
	}
}
