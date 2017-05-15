using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _ShootScript : MonoBehaviour {
//	public GameObject Cube;
//	public GameObject Sphere;
	public int Ammo;


	public GameObject Spider;

void Start(){

		Ammo=GetComponentInChildren<_CurAmmo> ().Ammo;

////		ChangeColor (Cube.GetComponent<MeshRenderer> ().material);
////		ChangeColor (Sphere.GetComponent<MeshRenderer> ().material);
}

	void Update () {
		//Debug.DrawLine(transform.position, Vector3.forward, Color.red);
		Debug.DrawRay(transform.position, transform.forward*10, Color.red);
		Ray ray = new Ray (transform.position, transform.forward * 10);
	    RaycastHit hit = new RaycastHit();
		if (Physics.Raycast(ray, out hit)) {
			//Debug.Log(hit.transform.gameObject.name);
		}
//		Crosshair.transform.position = hit.point;
//		if (hit.transform.gameObject.name=="Cube") {
//			ChangeColor (hit.transform.GetComponent<MeshRenderer> ().material);
//		}
		if (hit.collider != null&Ammo>0) {
			
		
			if (hit.transform.gameObject.tag == "spider") {
				
//			ChangeColor (hit.transform.GetComponent<MeshRenderer> ().material);
				GetComponentInChildren<GunPlayer> ().getFire=true;
				hit.transform.GetComponent<_Spider> ().takeDamage (1);
				//CurAmmoCount--;
			} else {
				GetComponentInChildren<GunPlayer> ().getFire = false;
				//Destroy(Spider);
			}  

		} else {
			//Debug.Log (null);
		}
//		if (Ammo==0) {
//			Input.GetButtonDown ("Reload Weapon");
//			
//		}
	
	}


//	void ChangeColor(Material mat){
//		
//		mat.color = Color.red;
//	}
}
