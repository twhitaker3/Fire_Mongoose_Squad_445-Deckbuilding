using UnityEngine;
using System.Collections.Generic;

public class VillainDeckBehavior : MonoBehaviour {
	public List<GameObject> cards;
	public int length;
	//Variables for other game entries
	public GameObject player_discard;
	// Use this for initialization
	void Start () {
		Shuffle ();
		for (int i = 0; i < length; i++) {
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			c.ShowBack();
			Transform t1 = c.GetComponent<Transform>();
			Vector2 vec = new Vector2(GetComponent<Transform>().position.x, GetComponent<Transform>().position.y);
			t1.position = vec;
		}
		NextVillain ();
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < length; i++) {
			//print ("Update");
			CardBehavior c = cards[i].GetComponent<CardBehavior>();
			switch(c.state){
			case 6: 	//Villian Deck State
				break;
			case 3:		//Discard State
				PlayerDiscardBehavior d = player_discard.GetComponent<PlayerDiscardBehavior>();
				d.AddCard(cards[i]);
				cards.RemoveAt(i);
				length--;
				i--;

				NextVillain();
				break;
			}
		}
	}
	public void Shuffle(){
		for (int i = 0; i < length-1; i++) {
			int r = i + (int)(Random.value * (length-1 - i));
			GameObject t = cards[r];
			cards[r] = cards[i];
			cards[i] = t;
		}
	}
	public void NextVillain(){
		if (length == 0)
			return;
		Transform t = cards [length - 1].GetComponent<Transform> ();
		Vector2 vec = new Vector2(GetComponent<Transform>().position.x-3, GetComponent<Transform>().position.y);
		t.position = vec;
		cards [length - 1].GetComponent<CardBehavior> ().ShowFront ();
		cards [length - 1].GetComponent<CardBehavior> ().state = 7;
	}
}
