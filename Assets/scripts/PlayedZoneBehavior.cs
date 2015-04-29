using UnityEngine;
using System.Collections.Generic;

public class PlayedZoneBehavior : MonoBehaviour {

	public List<GameObject> cards;
	public int length;
	//Variables for other game entities
	public GameObject player_deck;
	public GameObject player_hand;
	public GameObject player_discard;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
				
			case 2:		//Played State
				break;
			case 1:		//Deck State
				break;
			case 0:		//Hand State
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
	}

	public void AddCard(GameObject card){
		cards.Add(card);
		length++;
	}
}
