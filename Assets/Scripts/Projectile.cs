using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Projectile : MonoBehaviour {

	public Rigidbody2D rb;
	public LaunchArchRender line;
	public GameObject ball;
	public Score score;

	public float power;
	public float maxV;

	public bool isPressed = false;
	public bool inPlay;
	float angle;
	float radianAngle;
	float v;
	float xDist;
	float yDist;
	Vector3 mousePos;
	float xV;
	float yV;
	float t;

	void Start(){
		rb.isKinematic = true;
		inPlay = false;
		score = GameObject.Find ("Score").GetComponent<Score> ();
	}

	void Update(){
		if (rb.velocity.y > maxV) {
			rb.velocity = new Vector2 (rb.velocity.x, maxV);
		}
		if (rb.velocity.y < -maxV) {
			rb.velocity = new Vector2 (rb.velocity.x, -maxV);
		}
		if (rb.velocity.x > maxV) {
			rb.velocity = new Vector2 (maxV, rb.velocity.y);
		}
		if (rb.velocity.x < -maxV) {
			rb.velocity = new Vector2 (-maxV, rb.velocity.y);
		}
		if (isPressed) {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			Vector3 dir = rb.transform.position - mousePos;
			dir = rb.transform.InverseTransformDirection(dir);
			angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
			radianAngle = Mathf.Deg2Rad * angle;

			xDist = (rb.transform.position.x - mousePos.x) * power;
			yDist = (rb.transform.position.y - mousePos.y) * power;

			//xV = Mathf.Abs(xDist) * Mathf.Cos(radianAngle);
			//yV = Mathf.Abs(yDist) * Mathf.Sin(radianAngle);
			xV = xDist * Mathf.Cos(radianAngle);
			yV = yDist * Mathf.Sin (radianAngle);
			v = xV + yV;

			if (mousePos.y < rb.transform.position.y) {
				line.lr.enabled = true;
				line.angle = angle;
				line.velocity = v;
			} else {
				line.lr.enabled = false;
			}

		}

		if (rb.velocity.x <= 0.1F && rb.velocity.y == 0.0F && inPlay) {
			Instantiate (ball, rb.position, Quaternion.identity);
			Destroy (this.transform.parent.gameObject);
		}
	}

	void OnMouseDown(){
		isPressed = true;
	}

	void OnMouseUp(){
		isPressed = false;

		score.sc++;
		rb.velocity = new Vector2 (xDist, yDist);
		rb.isKinematic = false;
		inPlay = true;
	}
}
