using UnityEngine;
using System.Collections;

public class PlayerDiscardBehavior : MonoBehaviour {

	public GameObject[] cards;
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
