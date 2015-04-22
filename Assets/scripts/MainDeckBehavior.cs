using UnityEngine;
using System.Collections;

public class MainDeckBehavior : MonoBehaviour {

	public GameObject[] cards;
	public int length;
	//Variables for other game entries
	public GameObject line_up;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 4:		//Main Deck State
				break;
			case 0:		//Hand State
				break;
			case 1:		//Deck State
				break;
			case 2:		//Played State
				break;
			case 3:		//Discard State
				break;
			case 5: 	//Line Up State
				c.ShowFront();
				LineUpBehavior z = line_up.GetComponent<LineUpBehavior>();
				z.AddCard(cards[i]);
				for(int j = i+1; j < length; j++){
					cards[j-1] = cards[j];
				}
				length--;
				cards[length] = null;
				i--;
				
				Transform t2 = c.GetComponent<Transform>();
				Vector2 vec= z.GetComponent<Transform>().position;
				vec.x = vec.x + (z.length-1)*3;
				t2.position = vec;
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
