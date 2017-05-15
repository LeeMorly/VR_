using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryUse : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Dictionary<string, int>mas = new Dictionary<string, int>();
		mas = ColWords ("Привет Привет Пока");
		foreach (var item in mas) {
			Debug.Log (item);
		}
	}
	public Dictionary<string, int> ColWords(string words){//мы создаетм публичный метод который возвращает нам Dictionary  имеющий ключ стринг  а значения инт.Методо называетсы 	ColWords  и имеет входящий параметр стринг."Привет" "привет" "пока" 

		string[] myWords=words.Split(' ');//рубит по пробелу и складывает в массив стрингов Создаем временный массив MyWords  
													
		Dictionary<string,int>result= new Dictionary<string, int>();//и присваеваем в него порубленный words  по пробелам.

		foreach (var word in myWords) {//для каждого элемента массива

			if (result.ContainsKey(word))
				{
					result [word]++;
				}else{
					result.Add(word,1);
				}
				
				

		}
		return result;
	}
	// Update is called once per frame
	void Update () {
		
	}
}
