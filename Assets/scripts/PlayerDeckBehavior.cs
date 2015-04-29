using UnityEngine;
using System.Collections.Generic;

public class PlayerDeckBehavior : MonoBehaviour {

	public List<GameObject> cards;
	public int length;
	
	//Variables for other game entities
	public GameObject player_hand;
	public GameObject played_zone;
	public GameObject player_discard;
	// Use this for initialization
	void Start () {
		Shuffle ();
		for (int i = 0; i < length; i++) {
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			Transform t1 = c.GetComponent<Transform>();
			Vector2 vec = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
			t1.position = vec;
		}
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
				c.ShowFront();
				PlayerHandBehavior z = player_hand.GetComponent<PlayerHandBehavior>();
				z.AddCard(cards[i]);
				cards.RemoveAt(i);
				length--;
				i--;
				
				Transform t2 = c.GetComponent<Transform>();
				Vector2 vec= z.GetComponent<Transform>().position;
				vec.x = vec.x + (z.length-1)*3;
				t2.position = vec;
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
	public void Shuffle(){
		for (int i = 0; i < length; i++) {
			int r = i + (int)(Random.value * (length - i));
			GameObject t = cards[r];
			cards[r] = cards[i];
			cards[i] = t;
		}
	}
}
