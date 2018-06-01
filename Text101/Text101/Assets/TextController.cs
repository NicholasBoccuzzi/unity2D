using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	private enum States {opening, cell, mirror, running, outside, sheet, lock0, sheet_start, sheet_in_hand, right, left, death, alley, police_cars, wrong_car, right_car, wall, jump, jump2};
	private States myState;
	public Text text;
	private bool sheetsInHand = false;
	private bool mirrorInHand = false;
	private bool jumped = false;
	private bool jumped2 = false;

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
		}	else if (myState == States.outside) {
			state_death();
		}	else if (myState == States.police_cars) {
			state_police_cars();
		}	else if (myState == States.alley) {
			state_alley();
		}	else if (myState == States.wrong_car) {
			state_wrong_car();
		}	else if (myState == States.right_car) {
			state_right_car();
		}	else if (myState == States.jump) {
			state_jump();
		}	else if (myState == States.jump2) {
			state_jump2();
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
			myState = States.outside;
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
		text.text = "John burst into a sprint heading for the door. Heads turn, some get out of their chair, and one officer yells \"Freeze\" but it was too late. John wasn't going to stop now. He was so close to outside! *BANG* *BANG* *BANG* *Thud* \n\n Game Over \n\n Press 'P' to play again"; 

		if (Input.GetKeyDown(KeyCode.P)) {
			sheetsInHand = false;
			mirrorInHand = false;
			myState = States.cell;
		}
	}

	void state_outside() {
		text.text = "John exited the police station and started climbing down the fire escape. To his right was a group of empty parked police cars and to his left was another alley. \n\n Which direction should John head? \n\n Press 'L' to head toward the alley or 'R' to head for the cop car";


		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.police_cars;
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.alley;
		}
	}

	void state_alley() {
		text.text = "John turned the corner and was met with a large wall. He did track and field in high school but this wall was pretty high. Alas, this was the direction he chose to head. It wasn't too late for him to turn back though. \n\n Press 'b' to turn back and head to the police cars, or press 'w' to step up to the wall";

		if (Input.GetKeyDown(KeyCode.B)) {
				myState = States.police_cars;
		}

		if (Input.GetKeyDown(KeyCode.W)) {
				myState = States.wall;
		}
	}
	void state_wall() {
		if (jumped || jumped2) {
			text.text = "After attempting the jump he knew he wouldn't make it. He had to go back. Hopefully he hadn't wasted too much time. \n\n press 'b' to go back in the opposite direction";

			if (Input.GetKeyDown(KeyCode.B)) {
				myState = States.police_cars;
			}
		} else {
			text.text = "He stepped up to the wall. Boy was it high. 'Should I just go back' he thought to himself. \n\n press 'b' to go back to the police cars, or press 'j' to jump";

			if (Input.GetKeyDown(KeyCode.B)) {
				myState = States.police_cars;
			}

			if (Input.GetKeyDown(KeyCode.J)) {
				myState = States.jump;
			}
		}
	}
	void state_jump() {
		jumped = true;

		text.text = "He gave it a running start and smacked his body against the well. 'Was I close?' he thought. He couldn't tell. \n\n Press 'j' to try again";

		
		if (Input.GetKeyDown(KeyCode.J)) {
			myState = States.jump2;
		}
	}
	void state_jump2() {
		text.text = "He gave it another attempt with everything he had. Running and jumping as fast and high as he could. His body smashed against the wall. He didn't make it. \n\n Press 'W' to go back to the wall, or press 'B' to head back to the police cars.";

		if (Input.GetKeyDown(KeyCode.W)) {
			myState = States.wall;
		}

		
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.police_cars;
		}
	}

	void state_police_cars () {
		text.text = "This was the moment of truth. Hoping that one of the cars was unlocked, he would have just enough time to pick one car before someone noticed what he was doing. \n\n Which car should John pick? \n\n Press '1' for the first car, '2' for the second car, '3' for the third car.";
		if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Keypad1)) {
			myState = States.wrong_car;
		}

		
		if (Input.GetKeyDown(KeyCode.Keypad2)) {
			myState = States.right_car;
		}
	}

	void state_wrong_car () {
		text.text = "John ran up to the car as fast as he could. He would have to be quick. Get in the car, jump it, and get out of there. He attempted to open the door... Nothing. Locked. A police officer emerged from the station dropped his coffee and yelled 'FREEZE'. John had a moment to decide: \n\n press 'R' to make a run to the closest car, or 'g' to give in.";

		if (Input.GetKeyDown(KeyCode.Keypad2)) {
			myState = States.right_car;
		}

		if (Input.GetKeyDown(KeyCode.Keypad2)) {
			myState = States.right_car;
		}
	}

	void state_right_car() {
		text.text = "He ran as fast as he could to the car. Praying it was unlocked he pulled the door open and, with his last bit of luck, found the keys sitting on the dashboard. He grabbed them, turned the key and sped off with a yelling officer in his rear view mirror.\n\n John was never heard from again but he managed to avoid an unwarranted end to his life. \n\n Thanks for playing! Press 'P' to play again!";

		if (Input.GetKeyDown(KeyCode.P)) {
			sheetsInHand = false;
			mirrorInHand = false;
			myState = States.cell;
		}
	}
}

		// if (Input.GetKeyDown(KeyCode.P)) {
		// 	sheetsInHand = false;
		// 	mirrorInHand = false;
		// 	myState = States.cell;
		// }