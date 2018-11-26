using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private float jumpForce = 400f;
	[Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
	[SerializeField] private bool allowAirControl = false;
	[SerializeField] private PlayerCollision playerCollision;

	private Rigidbody2D rigidbody;
	private Vector3 velocity = Vector3.zero;

	private void Awake() {
		rigidbody = GetComponent<Rigidbody2D>();
	}

	public void Move(float move, bool jump) {
		if (playerCollision.isGrounded || allowAirControl) {
			Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
			rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref velocity, movementSmoothing);

			if (targetVelocity.x > 0) {
				FlipRight();
			}
			else if (targetVelocity.x < 0) {
				FlipLeft();
			}

			if (jump) {
				Jump();
			}
		}
	}

	public void Jump() {
		if (playerCollision.isGrounded) {
			rigidbody.AddForce(new Vector2(0f, jumpForce));
		}
	}

	private void FlipRight() {
		Vector3 theScale = transform.localScale;
		theScale.x = Mathf.Abs(theScale.x);
		transform.localScale = theScale;
	}

	private void FlipLeft() {
		Vector3 theScale = transform.localScale;
		theScale.x = Mathf.Abs(theScale.x) * -1;
		transform.localScale = theScale;
	}

    public void Bounce() {
        rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
        rigidbody.AddForce(Vector2.up.normalized * 500);
    }

}
