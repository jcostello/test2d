using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour, IPlayerCollisionable {
		
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private Animator animator;

    private Rigidbody2D rigidbody;

    private void Start() {
        rigidbody = GetComponent<Rigidbody2D>();

        StartCoroutine("Move");
    }

    private void Update() {
        animator.SetFloat("verticalSpeed", rigidbody.velocity.y);
    }

    private void Die() {
        gameObject.SetActive(false);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    public void PlayerCollision(Collider2D collider) {
        PlayerMovement playerMovement = collider.GetComponent<PlayerMovement>();

        Die();

        playerMovement.Bounce();
    }

    private IEnumerator Move() {
        while(true) {
            yield return new WaitForSeconds(3f);

            rigidbody.AddForce(new Vector2(-1f, 1.5f) * 400);
        }
    }
}
