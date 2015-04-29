using UnityEngine;
using System.Collections.Generic;

public class PlayerHandBehavior : MonoBehaviour {

	public List<GameObject>cards; 	//cards in the hand
	public int length;		//size of the hand
	//Variables for other game entities
	public GameObject player_deck;
	public GameObject played_zone;
	public GameObject player_discard;
	// Use this for initialization
	void Start () {
		for (int i = 0; i < length; i++) {
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			Transform t1 = c.GetComponent<Transform>();
			Vector2 vec = GetComponent<Transform>().position;
			vec.x = vec.x + i*3;
			t1.position = vec;
		}
	}
	
	// Update is called once per frame
	// Will always check the state of all cards it controls for changes
	// A changed state means the card needs to be removed from this entities' list, added to the new entity, and the sprite must be moved
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("i = " + i);
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 0:		//Hand State
				break;
			case 1:		//Deck State
				c.ShowBack();
				PlayerDeckBehavior d = player_deck.GetComponent<PlayerDeckBehavior>();
				d.AddCard(cards[i]);
				cards.RemoveAt(i);
				length--;
				i--;

				Transform t1 = c.GetComponent<Transform>();
				t1.position = d.GetComponent<Transform>().position;
				break;
			case 2:		//Played State
				c.ShowFront();
				PlayedZoneBehavior z = played_zone.GetComponent<PlayedZoneBehavior>();
				z.AddCard(cards[i]);
				cards.RemoveAt(i);
				length--;
				i--;
				
				Transform t2 = c.GetComponent<Transform>();
				Vector2 vec= z.GetComponent<Transform>().position;
				vec.x = vec.x + (z.length-1)*3;
				t2.position = vec;
				break;
			case 3:
				break;
			}
		}
	}
	public void AddCard(GameObject card){
		cards.Add(card);
		length++;
	}
}
