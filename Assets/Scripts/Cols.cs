using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cols : MonoBehaviour {

	public Rigidbody2D rb;
	public bool win;
	public globals g;

	void Start(){
		win = false;
		g = GameObject.FindGameObjectWithTag ("globals").GetComponent<globals> ();
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Goal") {
			win = true;
			g.win = true;
			Destroy (this.gameObject);
		}else if(coll.gameObject.tag == "Ground"){
			rb.angularDrag = 0.8F;
		}
	}

	void OnCollisionExit2D(Collision2D coll){
		if(coll.gameObject.tag == "Ground"){
			rb.angularDrag = 0;
		}
	}
}
