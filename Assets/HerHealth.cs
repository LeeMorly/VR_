using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerHealth : MonoBehaviour {
	public int Health=100;
	public int Ammo;
//	public AudioClip WhoWantsSome;



	public void TakeDamage(int damage){
		Health-= damage;//Health=Health-damage;
		CheckGameOver(Health);

	}
	void CheckGameOver(int Health){
		if (Health<=0) {
			Destroy (gameObject);
		}
		if (Health==50) {
			gameObject.GetComponent<AudioClip>();

		}
	}
	void viewhealth(){
		GetComponentInChildren<TextMesh> ().text=Health.ToString();
	}

	void Start () {
		viewhealth ();
	}



	void Update () {
//		Health.ToString=GetComponent<TextMesh> ().ToString();
		viewhealth ();

	}
//	public void takePersDamage(int damage){
//		Health = Health - damage;
//
//		CheckPersHealth();
//
//	}
//
//	void CheckPersHealth(){
//
//		if (Health<=0) {
//			Destroy (gameObject);
//		}
//	}
//	void OnCollisionEnter(Collision col){
//		
//		if (col.gameObject.name == "Spider(Clone)") {
//
//			TakeDamage(1);
//
//		}
//	}
}


