using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour, IPlayerCollisionable {

    public void PlayerCollision(Collider2D collider) {
		PlayerCollision playerCollision = collider.GetComponent<PlayerCollision>();

		playerCollision.isGrounded = true;
    }

}
