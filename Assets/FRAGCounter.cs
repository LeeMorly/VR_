using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FRAGCounter : MonoBehaviour {
	public int MyFrags;
	public string Frags;




	// Use this for initialization
	void Start () {
		//Frags = GameObject.Find ("spider(Clone");
		viewFrags(MyFrags.ToString());

	
	}

	
	// Update is called once per frame
	void Update () {
		if (GetComponent<_Spider>().Life==0) {
			MyFrags++;
			viewFrags(MyFrags.ToString());
			Frags = MyFrags.ToString ();
			Debug.Log ("MyFrags");

		}
		}
	void viewFrags(string Frags){
		GameObject.Find ("FragCounter").GetComponent<TextMesh> ().text = Frags;
	}
	}


