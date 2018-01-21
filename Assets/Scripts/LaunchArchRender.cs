using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LaunchArchRender : MonoBehaviour {

	public LineRenderer lr;
	public Projectile pr;
	public GameObject ball;

	public float velocity; //velocity of shot
	public float angle; //angle of shot
	public int resolution = 10; //how jagid the line is

	float g; //force of gravity on y
	float radianAngle; //angle in radians

	void Awake(){
		lr = GetComponent<LineRenderer> (); //get the line renderer comonent
		g = Mathf.Abs (Physics2D.gravity.y); //gravity is gravity in game
	}

	void OnValidate(){
		//check lr is not null and game is in play
		if (lr != null && Application.isPlaying && pr.isPressed){
			RenderArc ();
		}
	}

	void Start () {
		lr.enabled = false;
		if (pr.isPressed) {
			RenderArc ();
		}
	}

	void Update(){
		RenderArc ();
	}

	//giving line renderer the right settings
	void RenderArc(){
		if(pr.isPressed){
			lr.SetVertexCount (resolution/2 + 1);
			lr.SetPositions (calcArcArray()); //set vector3 of arc to method
		}
	}

	//create an array of vector 3 pos for arc
	Vector3[] calcArcArray(){
		Vector3[] arcArray = new Vector3[(resolution/2)+1]; //array of half of the path points, so it only shows half the path
		radianAngle = Mathf.Deg2Rad * angle; //change degrees to radians
		float maxDistance = (velocity * velocity * Mathf.Sin (2 * radianAngle)) / g; //d=(v^2*sin(2θ))/g

		for (int i = 0; i <= resolution/2; i++){ //for every int i, calculate the point at that part of the path (every tenth of the path)
			float t = (float)i / (float)resolution;
			arcArray [i] = calcArcPoint (t, maxDistance);
		}

		return arcArray;
	}

	//calc height and dist of each vertex
	Vector3 calcArcPoint (float t, float maxDistance){
		float x = (t * maxDistance);
		float y = (x * Mathf.Tan (radianAngle) - ((g * x * x) / (2 * (velocity * velocity * Mathf.Cos (radianAngle) * Mathf.Cos (radianAngle)))));
		return new Vector3 (x, y);
	}
}
