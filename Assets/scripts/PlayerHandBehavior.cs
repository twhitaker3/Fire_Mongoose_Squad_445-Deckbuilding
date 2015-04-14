using UnityEngine;
using System.Collections;

public class PlayerHandBehavior : MonoBehaviour {

	public GameObject[] cards; 	//cards in the hand
	public int hand_size;		//size of the hand
	//Variables for other game entities
	public GameObject player_deck;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	// Will always check the state of all cards it controls for changes
	// A changed state means the card needs to be removed from this entities' list, added to the new entity, and the sprite must be moved
	void Update () {
		for (int i = 0; i < hand_size; i++) {
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
				for(int j = i+1; j < hand_size; j++){
					cards[j-1] = cards[j];
				}
				hand_size--;
				cards[hand_size] = null;
				i--;
				
				Vector3 translate = new Vector3(2,4,0);
				Transform t = c.GetComponent<Transform>();
				t.position = translate;
				break;
			}
		}
	}

	public void addCard(GameObject card){

	}
}
