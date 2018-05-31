using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	private enum States {opening, cell, mirror, cell_mirror, running, freedom, sheet, lock0, sheet_start, sheet_in_hand};
	private States myState;
	public Text text;
	private bool sheetsInHand = false;
	private bool mirrorInHand = false;

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
		if (myState == States.mirror) {
			state_mirror();
		}
		if (myState == States.sheet_start) {
			state_sheet_start();
		}
		if (myState == States.sheet_in_hand) {
			state_sheet_in_hand();
		}
		if (myState == States.lock0) {
			state_lock0();
		}

	}

	void state_opening () {
		text.text = "John Wayne was a simple man who found himself in an unfortunate situation. After being found guilty in court for a crime he did not commit, he was sentenced to death in 24 hours. With no alternative, John Wayne knew he must escape from jail or he would meet his end. \n\n Help John by guiding him through his escape!\n\n To Begin, press Enter.";

		if (Input.GetKeyDown(KeyCode.Return)) {
			myState = States.cell;
		}
	}

	void state_cell () {
		if (!sheetsInHand) {
			text.text = "John stands in the middle of the room. Not much around. A mirror, a stone with some sheets on top and the door with a giant lock on top. \n\n What is John to do?" + 

			"Press 'S' to view Sheets, press 'M' to view Mirror' and press 'L' to view Lock";

			if (Input.GetKeyDown(KeyCode.S)) {
				myState = States.sheet_start;
			}

			if (Input.GetKeyDown(KeyCode.M)) {
				myState = States.mirror;
			}

			if (Input.GetKeyDown(KeyCode.L)) {
				myState = States.lock0;
			}

		} else if (sheetsInHand) {
			text.text = "John, with sheet in hand, had two options: check out the Mirror or go for the Lock \n\n" +
			"press 'M' or press 'L' to decide";

			if (Input.GetKeyDown(KeyCode.M)) {
				myState = States.mirror;
			}
		}
	}

	void state_mirror () {
		text.text = "All John saw was his ugly mug staring back at him. He needed to figure out how he could escape. Maybe he could use a piece of the mirror, but the last thing he needed to do was cause a scene with a hand full of glass. \n\n" + 
		"What is John to do? \n\n" +
		"Press 'S' to check out the sheets, 'C' to return to the middle of the cell, or 'L' to check out the lock";

			if (Input.GetKeyDown(KeyCode.S)) {
				myState = States.sheet;
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				myState = States.cell;
			}

			if (Input.GetKeyDown(KeyCode.L)) {
				myState = States.lock0;
			}
	}

	void state_sheet_start () {
		text.text = "John went over to the sheets. He grabbed the sheets and wrapped them around his hand.\n\n Press 'C' to return to the center of the room, press 'M' to go to the Mirror or press 'L' to go check out the lock.";
		sheetsInHand = true;

		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.cell;
		}

		if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
	}

	void state_sheet_in_hand() {
		text.text = "John already had the sheets in hand. \n\n What should John do next? \n\n Press 'C' to return to the center of the cell, 'M' to head to the mirror, 'L' to check out the lock";
		sheetsInHand = true;

		if (Input.GetKeyDown(KeyCode.C)) {
			myState = States.cell;
		}

		if (Input.GetKeyDown(KeyCode.M)) {
			myState = States.mirror;
		}
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock0;
		}
	}

	void state_cell_sheets() {
		text.text = "John now has his right hand wrapped in a sheet. What should he do next?";
	}

	void state_lock0() {
		if (sheetsInHand && mirrorInHand) {
			text.text = "John had the tools he needed to open the lock. After fiddling around with the lock, it finally cracked open!\n\n" + 
			"press 'R' to make a run for it!";

			if (Input.GetKeyDown(KeyCode.R)) {
				myState = States.running;
			}

		} else if (sheetsInHand && !mirrorInHand) {
			text.text = "John looked at his hand and looked at the lock. Not even the hardest swing of his fist was going to break through that lock. He was going to have to find a way to pick the lock\n\n What should John do next? \n\n Press 'M' to check out the mirror, or 'C' to head back to the middle of the room.";

			if (Input.GetKeyDown(KeyCode.M)) {
				myState = States.mirror;
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				myState = States.cell;
			}
		}
	}
}
