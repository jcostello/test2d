using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerHealth : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private Animator animator;

    public bool isDamaged = false;

	void Start () {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
	}
	
    public void TakeDamage() {
        isDamaged = true;

        rigidbody.velocity = Vector2.zero;
        rigidbody.AddForce(new Vector2(-transform.localScale.x, 1.5f) * 300);

        animator.SetBool("isDamaged", isDamaged);

        Physics2D.IgnoreLayerCollision(8, 9);
    }

}
