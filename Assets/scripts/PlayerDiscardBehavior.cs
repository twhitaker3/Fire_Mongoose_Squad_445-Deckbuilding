using UnityEngine;
using System.Collections.Generic;

public class PlayerDiscardBehavior : MonoBehaviour {

	public List<GameObject> cards;
	public int length;
	//Variables for other game entities
	public GameObject player_deck;
	public GameObject player_hand;
	public GameObject played_zone;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 3:		//Discard State
				break;
			case 0:		//Hand State
				break;
			case 1:		//Deck State
				break;
			case 2:		//Played State
				break;
			}
		}
	}
	public void AddCard(GameObject card){
		cards.Add(card);
		length++;
	}
}
