using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _CurAmmo : MonoBehaviour {


	public int Ammo=30;//Текущее кол-во патронов;
	public int MaxAmmoCount = 30; // Макс патронов в обойме
	public int inventoryAmmoCount = 600; //Текущее число патронов инвентаре
	private int RaznicaAmmo; //Переменная разницы между максимальным и текущим кол-вом патронов в обойме
	// Use this for initialization
	public GameObject GunPlayer;
	void Start () {
		
		viewAmmo ();
	}
	void viewAmmo(){
		GetComponent<TextMesh> ().text=Ammo.ToString();
	}

		void Update () {
		if (GunPlayer.GetComponentInChildren<GunPlayer> ().getFire==true) {
			Ammo=Ammo-1;
		}
		Reload ();
		viewAmmo ();
	}

	void Reload(){
		if (Ammo <= 0) {
			GunPlayer.GetComponent<GunPlayer> ().reloadKey = true;
			Ammo = Ammo + MaxAmmoCount;
			inventoryAmmoCount = inventoryAmmoCount - MaxAmmoCount;
		} else {
			GunPlayer.GetComponent<GunPlayer> ().reloadKey = false;
		}

	}
}
