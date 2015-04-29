using UnityEngine;
using System.Collections.Generic;

public class LineUpBehavior : MonoBehaviour {

	public List<GameObject> cards;
	public int length;
	public List<GameObject> kicks;
	public List<GameObject>weaknesses;
	//Variables for other game entries
	public GameObject main_deck;
	public GameObject player_discard;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < kicks.Count; i++) {
			CardBehavior k = kicks[i].GetComponent<CardBehavior>();
			Transform t1 = k.GetComponent<Transform>();
			Vector2 vec = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y+4);
			t1.position = vec;
		}
		for (int i = 0; i < weaknesses.Count; i++) {
			CardBehavior w = kicks[i].GetComponent<CardBehavior>();
			Transform t1 = w.GetComponent<Transform>();
			Vector2 vec = new Vector2(GetComponent<Transform>().position.x-3, GetComponent<Transform>().position.y+4);
			t1.position = vec;
		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 5: 	//Line Up State
				break;
			case 3:		//Discard State
				PlayerDiscardBehavior d = player_discard.GetComponent<PlayerDiscardBehavior>();
				d.AddCard(cards[i]);
				cards.RemoveAt(i);
				length--;
				i--;
				
				Transform t1 = c.GetComponent<Transform>();
				t1.position = d.GetComponent<Transform>().position;
				break;
			}
		}
		for (int i = 0; i < kicks.Count; i++) {
			//print ("Update");
			CardBehavior c = kicks[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 5: 	//Line Up State
				break;
			case 3:		//Discard State
				PlayerDiscardBehavior d = player_discard.GetComponent<PlayerDiscardBehavior>();
				d.AddCard(cards[i]);
				kicks.RemoveAt(i);
				i--;
				
				Transform t1 = c.GetComponent<Transform>();
				t1.position = d.GetComponent<Transform>().position;
				break;
			}
		}
		for (int i = 0; i < weaknesses.Count; i++) {
			//print ("Update");
			CardBehavior c = weaknesses[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 5: 	//Line Up State
				break;
			case 3:		//Discard State
				PlayerDiscardBehavior d = player_discard.GetComponent<PlayerDiscardBehavior>();
				d.AddCard(cards[i]);
				weaknesses.RemoveAt(i);
				i--;
				
				Transform t1 = c.GetComponent<Transform>();
				t1.position = d.GetComponent<Transform>().position;
				break;
			}
		}
	}
	public void AddCard(GameObject card){
		cards.Add(card);
		length++;
	}
}
