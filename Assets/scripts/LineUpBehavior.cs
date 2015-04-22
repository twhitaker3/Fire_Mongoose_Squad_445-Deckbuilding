using UnityEngine;
using System.Collections;

public class LineUpBehavior : MonoBehaviour {

	public GameObject[] cards;
	public int length;
	//Variables for other game entries
	public GameObject main_deck;
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
			case 5: 	//Line Up State
				break;
			case 3:		//Discard State
				PlayerDiscardBehavior d = player_discard.GetComponent<PlayerDiscardBehavior>();
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
