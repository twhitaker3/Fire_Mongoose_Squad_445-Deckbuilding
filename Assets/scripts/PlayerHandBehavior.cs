using UnityEngine;
using System.Collections;

public class PlayerHandBehavior : MonoBehaviour {

	public GameObject[] cards; 	//cards in the hand
	public int length;		//size of the hand
	//Variables for other game entities
	public GameObject player_deck;
	public GameObject played_zone;
	public GameObject player_discard;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	// Will always check the state of all cards it controls for changes
	// A changed state means the card needs to be removed from this entities' list, added to the new entity, and the sprite must be moved
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 0:		//Hand State
				c.ShowFront();
				break;
			case 1:		//Deck State
				c.ShowBack();
				PlayerDeckBehavior d = player_deck.GetComponent<PlayerDeckBehavior>();
				d.AddCard(cards[i]);
				for(int j = i+1; j < length; j++){
					cards[j-1] = cards[j];
				}
				length--;
				cards[length] = null;
				i--;

				Transform t1 = c.GetComponent<Transform>();
				t1.position = d.GetComponent<Transform>().position;
				break;
			case 2:		//Played State
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

	public void addCard(GameObject card){

	}
}
