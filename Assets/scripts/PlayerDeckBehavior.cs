using UnityEngine;
using System.Collections;

public class PlayerDeckBehavior : MonoBehaviour {

	public GameObject[] cards;
	public int length;
	//Variables for other game entities
	public GameObject player_hand;
	public GameObject played_zone;
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

			case 1:		//Deck State
				break;
			case 0:		//Hand State
				break;
			case 2:		//Played State
				c.ShowFront();
				PlayedZoneBehavior z = played_zone.GetComponent<PlayedZoneBehavior>();
				z.AddCard(cards[i]);
				for(int j = i+1; j < length; j++){
					cards[j-1] = cards[j];
				}
				length--;
				cards[length] = null;
				i--;
				
				Transform t2 = c.GetComponent<Transform>();
				t2.position = z.GetComponent<Transform>().position;
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
