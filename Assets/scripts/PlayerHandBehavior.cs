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
				FixSprites();
				break;
			case 2:		//Played State
				c.ShowFront();
				PlayedZoneBehavior z = played_zone.GetComponent<PlayedZoneBehavior>();
				z.AddCard(cards[i]);
				cards.RemoveAt(i);
				length--;
				i--;
				FixSprites();
				break;
			case 3:
				break;
			}
		}
	}
	public void AddCard(GameObject card){
		cards.Add(card);
		length++;
		Transform t = card.GetComponent<Transform>();
		Vector2 vec= GetComponent<Transform>().position;
		vec.x = vec.x + (length-1)*3;
		t.position = vec;
	}
	public void FixSprites(){
		for (int i = 0; i < length; i++) {
			Transform t = cards[i].GetComponent<Transform>();
			Vector2 vec = GetComponent<Transform>().position;
			vec.x = vec.x + (i)*3;
			t.position = vec;
		}
	}
}
