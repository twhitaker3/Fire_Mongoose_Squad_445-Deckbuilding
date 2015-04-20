using UnityEngine;
using System.Collections;

public class CardBehavior : MonoBehaviour {

	public int state; 			//State 0- Player Hand, State 1- Deck, State 2- PlayedZone, 
	public bool face_down; 		//0 for face up card, 1 for face down card
	public int index; 			//Index in the faces array
	public Sprite back_face;	//Backside image
	public Sprite[] faces;		//Array of all frontside images for a card

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
		spriteRenderer.sprite = faces [index];
	}
	//Change the state of the card based on clicks
	public void OnMouseDown(){
		print ("Clicked");
		switch (state) {
		case 0:		//Hand State
			state = 1;
			break;
		case 1:		//Deck State
			state = 2;
			break;
		case 2:		//Played State
			break;
		}
	}
	public void onMouseDrag(){
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f)); //nonfunctional currently
			//should be able to drag/drop
	}
}
