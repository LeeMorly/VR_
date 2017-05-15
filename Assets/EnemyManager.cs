using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public GameObject prefabEnemy;
	public GameObject CurEnemy;
	public int Enemies;
	public int MaxEnemies;

	void Start() {
		
        InvokeRepeating ("Respawn", 5f, 5f);

	}
	void Respawn(){

		if (Enemies<=MaxEnemies) {
			CurEnemy = Instantiate(prefabEnemy, new Vector3( Random.Range(1.24f,47f),0f, Random.Range(1.62f,47f)),transform.rotation) as GameObject;
			Enemies++;
			CurEnemy.GetComponent<_Spider> ().EnemManger = this;
		}

	}

//	void Update () {
//		Respawn ();
//
//	}
}

