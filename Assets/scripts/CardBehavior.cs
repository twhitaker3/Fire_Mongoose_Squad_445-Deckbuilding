using UnityEngine;
using System.Collections;

public class CardBehavior : MonoBehaviour {

	public int state; 			//State 0- Player Hand, State 1- Deck
	public bool face_down; 		//0 for face up card, 1 for face down card
	public int index; 			//Index in the faces array
	public Sprite back_face;	//Backside image
	public Sprite[] faces;		//Array of all frontside images for a card

	SpriteRenderer spriteRenderer; //For drawing the card
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	//Change the side of the card showing
	public void ShowBack(){
		face_down = true;
		spriteRenderer.sprite = back_face;
	}
	public void ShowFront(){
		face_down = false;
		spriteRenderer.sprite = faces [index];
	}
	//Change the state of the card based on clicks
	public void OnMouseDown(){
		print ("Clicked");
		switch (state) {
		case 0:
			ShowFront();
			//print("Front");
			state = 1;
			break;
		case 1:
			break;
		}
	}
}
