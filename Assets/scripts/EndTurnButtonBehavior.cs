using UnityEngine;
using System.Collections;

public class EndTurnButtonBehavior : MonoBehaviour {

	public GameObject Player1;
	public GameObject Player2;
	public GameObject line_up;
	public GameObject villian;
	public GameObject player1_Discard;
	public GameObject player2_Discard;


	public void switch_turns(){
		if (Player1.GetComponent<PlayerBehavior> ().active) {
			Player1.GetComponent<PlayerBehavior> ().active = false;
			Player2.GetComponent<PlayerBehavior> ().active = true;
			line_up.GetComponent<LineUpBehavior> ().player_discard = player2_Discard;
			villian.GetComponent<VillainDeckBehavior> ().player_discard = player2_Discard;
		} else {
			Player2.GetComponent<PlayerBehavior> ().active = false;
			Player1.GetComponent<PlayerBehavior> ().active = true;
			line_up.GetComponent<LineUpBehavior> ().player_discard = player1_Discard;
			villian.GetComponent<VillainDeckBehavior> ().player_discard = player1_Discard;

		}
	}
}
