using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	private enum States {opening, cell, mirror, running, freedom, sheet, lock0, sheet_start, sheet_in_hand, right, left, death};
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
		} 	else if (myState == States.cell) {
			state_cell();
		}	else if (myState == States.mirror) {
			state_mirror();
		}	else if (myState == States.sheet_start) {
			state_sheet_start();
		}	else if (myState == States.sheet_in_hand) {
			state_sheet_in_hand();
		} 	else if (myState == States.lock0) {
			state_lock0();
		} 	else if (myState == States.running) {
			state_running();
		} 	else if (myState == States.left) {
			state_left();
		}	else if (myState == States.right) {
			state_right();
		}	else if (myState == States.death) {
			state_death();
		}	else if (myState == States.freedom) {
			state_death();
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
			text.text = "John stands in the middle of the room. Not much around. A mirror, a stone with some sheets on top and the door with a biggest lock he'd ever seen. \n\n What is John's next move?\n\n" + 

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

			if (Input.GetKeyDown(KeyCode.L)) {
				myState = States.lock0;
			}
		}
	}

	void state_mirror () {
		if (!sheetsInHand) {
			text.text = "All John saw was his ugly mug staring back at him. He needed to figure out how he could escape. Maybe he could use a piece of the mirror, but the last thing he needed to do was cause a scene with a hand full of glass. \n\n" + 
			"What is John to do? \n\n" +
			"Press 'S' to check out the sheets, 'C' to return to the middle of the cell, or 'L' to check out the lock";

			if (Input.GetKeyDown(KeyCode.S)) {
				myState = States.sheet_start;
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				myState = States.cell;
			}

			if (Input.GetKeyDown(KeyCode.L)) {
				myState = States.lock0;
			}
		} else {
			text.text = "John looked at himself in the mirror. His time was running thin. A quick look at the door and it seemed like nobody was around. With a windup and a swing, he broke the mirror! \"Seven years bad luck\" John snickered. Carefully picking up a shard of the mirror and John turned towards the lock. \n\n Press 'L' to check out the lock";
			mirrorInHand = true;

			if (Input.GetKeyDown(KeyCode.L)) {
					myState = States.lock0;
			}
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
		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.lock0;
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

	void state_lock0() {
		if (sheetsInHand && mirrorInHand) {
			text.text = "John had the only tool he could scrap together while in isolation. He got to work and after fiddling around with the lock, it finally cracked open!\n\n" + 
			"press 'R' to make a run for it!";

			if (Input.GetKeyDown(KeyCode.R)) {
				myState = States.running;
			}

		} else {
			text.text = "John looked at his hand and looked at the lock. Not even the hardest swing of his fist was going to break through that lock. He was going to have to find a way to pick the lock\n\n What should John do next? \n\n Press 'M' to check out the mirror, or 'C' to head back to the middle of the room.";

			if (Input.GetKeyDown(KeyCode.M)) {
				myState = States.mirror;
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				myState = States.cell;
			}
		}
	}

	void state_running () {
		text.text = "John peaked his head out the cell and looked to his left and to his right, nobody around. Unsure of where he should go, he hesitates for a moment... \n\n Which direction should John head? \n\n 'L' for left, 'R' for right";

		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.left;
		}
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.right;
		}
	}

	void state_left() {
		text.text = "John heads down the hall and finds the back of the police station. A fire exit! John lifts the window open and steps out. This was his only chance. \n\n press 'B' to make a break for it.";

		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.freedom;
		}
	}

	void state_right() {
		text.text = "John heads down the hall and finds the front of the police station. Everyone seems to be head down in work. \"Should I just run for it?\" he thought. \n\n press 'B' to make a break for it, press 'T' to turn around.";

		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.death;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.left;
		}
	}

	void state_death() {
		text.text = "John burst into a sprint heading for the door. Heads turn, some get out of their chair, and one officer yells \"Freeze\" but it was too late. John wasn't going to stop now. He was so close to freedom! *BANG* *BANG* *BANG* *Thud* \n\n Game Over \n\n Press 'P' to play again"; 

		if (Input.GetKeyDown(KeyCode.P)) {
			sheetsInHand = false;
			mirrorInHand = false;
			myState = States.cell;
		}
	}

	void state_freedom() {
		text.text = "John exited the police station and started running as fast as he could. He was never seen from again but some say he's still running today. \n\n Game Over\n\n Press 'P' to play again";

		if (Input.GetKeyDown(KeyCode.P)) {
			sheetsInHand = false;
			mirrorInHand = false;
			myState = States.cell;
		}
	}
}
