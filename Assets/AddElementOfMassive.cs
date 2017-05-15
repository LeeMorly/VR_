using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddElementOfMassive : MonoBehaviour {
	
	public string[] masMy;


	void Start () {
		AddStr (masMy, "Привет");
	}
	public void AddStr(string[]mas, string word)
	{
		string[] newMas = new string[mas.Length+1];
		for (int i = 0; i < mas.Length; i++) {
			newMas [1] = mas [i];
		}

		newMas [newMas.Length - 1] = word;
		mas = new string[newMas.Length];
		for (int i = 0; i < mas.Length; i++) {
			mas [i] = newMas [i];
			foreach (var item in word) {
				//masMy[i];
			}
		}
		}

	}
	