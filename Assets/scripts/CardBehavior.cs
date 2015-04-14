using UnityEngine;
using System.Collections;

public class CardBehavior : MonoBehaviour {

	public int state;
	public int index;
	public Sprite back_face;
	public Sprite[] faces;

	float x; //used for drag/drop
	float y; //used for drag/drop

	SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		x = Input.mousePosition.x;	//used for drag/drop
		y = Input.mousePosition.y;	//used for drag/drop
	
	}
	public void ShowBack(){
		spriteRenderer.sprite = back_face;
	}
	public void ShowFront(){
		spriteRenderer.sprite = faces [index];
	}
	public void OnMouseDown(){
		switch (state) {
		case 0:
			ShowFront();
			print("Front");
			state = 1;
			break;
		case 1:
			ShowBack();
			print ("Back");
			state = 0;
			break;
		}
	}
	public void onMouseDrag(){
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(x,y,10.0f)); //nonfunctional currently
			//should be able to drag/drop
	}
}
