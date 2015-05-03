using UnityEngine;
using System.Collections.Generic;

public class DestroyedStackBehavior : MonoBehaviour {

	public List<GameObject> cards;
	public int length;
	//Variables for other game entities

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void AddCard(GameObject card){
		cards.Add(card);
		length++;
		Transform t = card.GetComponent<Transform>();
		Vector2 vec= GetComponent<Transform>().position;
		t.position = vec;
	}
}
