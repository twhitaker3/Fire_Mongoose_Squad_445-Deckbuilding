using UnityEngine;
using System.Collections;

public class CardBehavior : MonoBehaviour {

	public int state; 			//State 0- Player Hand, State 1- Deck, State 2- PlayedZone, State 3- Discard, State 4- Main Deck, State 5-Line Up, State 6- VillianDeck, State 7- Active Villian
	public bool face_down; 		//0 for face up card, 1 for face down card
	public Sprite back_face;	//Backside image
	public Sprite front_face;		//Array of all frontside images for a card

	SpriteRenderer spriteRenderer; //For drawing the card
	float x; //used for drag/drop
	float y; //used for drag/drop

	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;	//used for drag/drop
		y = Input.mousePosition.y;	//used for drag/drop
	
	}
	//Change the side of the card showing
	public void ShowBack(){
		face_down = true;
		spriteRenderer.sprite = back_face;
	}
	public void ShowFront(){
		face_down = false;
		spriteRenderer.sprite = front_face;
	}
	//Change the state of the card based on clicks
	public void OnMouseDown(){
		print ("Clicked");
		switch (state) {
		case 0:		//Hand State
			state = 2;
			break;
		case 1:		//Deck State
			state = 0;
			break;
		case 2:		//Played State
			state = 3;
			break;
		case 3:		//Discard State
			state = 1;
			break;
		case 4:		//Main Deck State
			state = 5;
			break;
		case 5:		//Line Up State
			state = 3;
			break;
		case 6:		//Villian Deck State
			break;
		case 7:		//Active Villian State
			state = 3;
			break;
		}
	}
	public void onMouseDrag(){
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f)); //nonfunctional currently
			//should be able to drag/drop
	}
}
