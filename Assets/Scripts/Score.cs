using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

	public Text t;
	public string score;
	public int sc;

	void Start () {
		t = GetComponent<Text>();
		sc = 0;
	}
	
	// Update is called once per frame
	void Update () {
		score = sc.ToString () + "       " + PlayerPrefs.GetInt(SceneManager.GetActiveScene ().buildIndex.ToString ());
		t.text = score;
	}
}
