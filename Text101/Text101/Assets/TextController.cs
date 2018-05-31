using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	private enum States {opening, cell, mirror, sheet_0, lock_0, cell_mirror, lock_1, sheets_1, freedom};
	private States myState;
	public Text text;

	// Use this for initialization
	void Start () {
		myState = States.opening;
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == States.opening) {
			state_opening();
		}

		if (myState == States.cell) {
			state_cell();
		}
	}

	void state_opening () {
		text.text = "To Begin, press Enter.";

		if (Input.GetKeyDown(KeyCode.Return)) {
			myState = States.cell;
		}
	}

	void state_cell () {
		text.text = "John Wayne was a simple man who found himself in an unfortunate situation. After being found guilty in court for a crime he did not commit, he was sentenced to death in 24 hours. With no alternative, John Wayne knew he must escape from jail or he would meet his end. \n\n" + 

		"Help John by guiding him through his escape!\n\n" +

		"Press 'S' to view Sheets, press 'M' to view Mirror' and press 'L' to view Lock";

		if (Input.GetKeyDown(KeyCode.S)) {

		}
	}
}
