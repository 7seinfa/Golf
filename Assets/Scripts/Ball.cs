using System.Collections;
using System.Collections.Generic;
//using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start () {
		//PrefabUtility.DisconnectPrefabInstance (this.gameObject);
		this.transform.GetChild (0).transform.localPosition = Vector3.zero;
		this.transform.GetChild (1).transform.localPosition = Vector3.zero;
		this.transform.GetChild (0).transform.localRotation = Quaternion.identity;
		this.transform.GetChild (1).transform.localRotation = Quaternion.identity;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
