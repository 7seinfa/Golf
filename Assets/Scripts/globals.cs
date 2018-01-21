using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class globals : MonoBehaviour {

	public Score sc;
	public bool win;
	// Use this for initialization
	void Start () {
		win = false;
		sc = GameObject.FindGameObjectWithTag ("sc").GetComponent<Score> ();

		if (!PlayerPrefs.HasKey (SceneManager.GetActiveScene().buildIndex.ToString())) {
			PlayerPrefs.SetInt (SceneManager.GetActiveScene ().buildIndex.ToString (), 0);
		}
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (win.ToString());
		if (win) {
			if (sc.sc < PlayerPrefs.GetInt (SceneManager.GetActiveScene ().buildIndex.ToString ()) || PlayerPrefs.GetInt (SceneManager.GetActiveScene ().buildIndex.ToString ()) == 0) {
				PlayerPrefs.SetInt (SceneManager.GetActiveScene ().buildIndex.ToString (), sc.sc);
			}
			Debug.Log ("win");
			if (SceneManager.GetActiveScene ().buildIndex == 10) {
				SceneManager.LoadScene (0);
			} else {
				SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
			}
		}

	}
}
