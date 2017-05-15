using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _Spider : MonoBehaviour {
	public int Life=2;
	public Transform Player;
	public Animator anim;
	public EnemyManager EnemManger;


	void Start ()
	{

		Player = GameObject.Find ("Pers").transform;
		GetComponent<UnityEngine.AI.NavMeshAgent> ().destination= Player.position;

		anim = GetComponent<Animator> ();

	}

	void Update(){
		GetComponent<UnityEngine.AI.NavMeshAgent> ().destination = Player.position;
		//Debug.Log (Vector3.Distance (transform.position, Player.position));
		if (Vector3.Distance (transform.position, Player.position) <= 2) {
			anim.SetBool ("Attack", true);
			Debug.Log ("Attack-true");
			//Canvas.GetDefaultCanvasMaterial().SetColor("Canvas", Color red);
			GameObject.Find("Canvas").GetComponent<UnityEngine.MeshRenderer>().material.color =new Color(255f,214f,214f,255f);
		} else {
			anim.SetBool ("Attack", false);
		}

	}

	public void takeDamage(int Damage){
		Life = Life - Damage;

		CheckHealth();
		//Debug.Log (Damage);

	}

	void CheckHealth(){

		if (Life <= 0) {
			EnemManger.Enemies--;
			anim.SetBool ("Die", true); 
			Destroy (gameObject, 1.0f);


		};


	}



	    public void PersTakeDamage(int countdamage){
		
		Player.GetComponent<HerHealth> ().TakeDamage (countdamage);

}

//	void viewhealth(){
//	//	GetComponentInChildren<TextMesh> ().text=Life.ToString();
//	}

}