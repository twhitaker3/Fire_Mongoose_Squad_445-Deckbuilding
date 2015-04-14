using UnityEngine;
using System.Collections;

public class PlayerDeckBehavior : MonoBehaviour {

	public GameObject[] cards;
	public GameObject player_hand;
	public int length;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){

			case 1:		//Deck State
				break;
			case 0:		//Hand State
				break;
			}
		}
	}

	public void AddCard(GameObject card){
		if (length >= cards.Length) {
			print ("Deck is full");
			return;
		}
		else {
			cards[length] = card;
			length++;

		}
	}
}
