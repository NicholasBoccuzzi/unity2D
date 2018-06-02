using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class TextController : MonoBehaviour {

	private enum States {
		opening, 
		cell, 
		mirror, 
		running, 
		outside, 
		sheet, 
		lock0, 
		sheet_start, 
		sheet_in_hand, 
		right, 
		left, 
		death, 
		alley, 
		police_cars, 
		wrong_car, 
		right_car, 
		wall, 
		jump, 
		jump2, 
		give_in
	};
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
			state_outside();
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
		}	else if (myState == States.wall) {
			state_wall();
		}	else if (myState == States.give_in) {
			state_wall();
		}
	}

	void state_opening () {
		text.text = "John Wayne is a simple man who has found himself in an unfortunate situation. After being found guilty" + 
		"in court for a crime he did not commit, he was sentenced to death in 24 hours. With no alternative, John knows " + 
		"he will have to escape from jail or he will meet his end.\n\nHelp John by guiding him through his escape!\n\n" +
		"To Begin, press Enter.";

		if (Input.GetKeyDown(KeyCode.Return)) {
			myState = States.cell;
		}
	}

	void state_cell () {
		if (!sheetsInHand) {
			text.text = "John stands in the middle of the cell. Not much around. A mirror, some sheets atop a stone slab they consider a " + 
			"bed, and a door with the biggest lock he has ever seen. \n\nWhat is John's next move?\n\n" + 
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
			text.text = "John, with sheet in hand, has two options: bust the Mirror or go for the Lock" +
			"\n\nWhat is John's next move? \n\nPress 'M' to go for the mirror or press 'L' to pull on the lock.";

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
			text.text = "All John sees is his ugly mug staring back at him. He needs to figure out how he can escape. " + 
			"Maybe he can use a piece of the mirror, but the last thing he needs to do is cause a scene with " + 
			"a hand full of glass. \n\nWhat is John's next move? \n\nPress 'S' to check out the sheets, " +
			"press 'C' to return to the middle of the cell, or press 'L' to check out the lock";

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
			text.text = "John looks at himself in the mirror. His time is running thin. A quick look at the door gives him " + 
			"the sense that nobody is around. With a windup and a swing, he breaks the mirror! \"Seven years bad luck\" " + 
			"John snickers. Carefully picking up a shard of the mirror, John turns towards the lock. \n\n" +
			"Press 'L' to check out the lock";

			mirrorInHand = true;			
			if (Input.GetKeyDown(KeyCode.L)) {
					myState = States.lock0;
			}
		}
	}

	void state_sheet_start () {
		text.text = "John heads over to the sheets. He grabbs the thickest layer and wraps them around his hand.\n\n" + 
		"Press 'C' to return to the center of the room, press 'M' to go to the Mirror or press 'L' to go check out the lock.";
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
		text.text = "John has the sheets wrapped around his hand. \n\nWhat should John do next? \n\nPress 'C' to " + 
		"return to the center of the cell, 'M' to head to the mirror, 'L' to check out the lock";
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
			text.text = "John has the only tool he could scrap together while stuck in the cell. He begins " + 
			"fiddling around with the lock, and, by some miracle, it cracks open!\n\n" + 
			"Press 'R' to make a run for it!";

			if (Input.GetKeyDown(KeyCode.R)) {
				myState = States.running;
			}

		} else {
			text.text = "John looks at his hand and looks at the lock. Not even the hardest swing of his fist will be " + 
			"enough to break through that lock. He is going to have to find a way to pick the lock\n\nWhat should John" +
			"do next? \n\nPress 'M' to check out the mirror, or 'C' to head back to the middle of the room.";

			if (Input.GetKeyDown(KeyCode.M)) {
				myState = States.mirror;
			}

			if (Input.GetKeyDown(KeyCode.C)) {
				myState = States.cell;
			}
		}
	}

	void state_running () {
		text.text = "John pokes his head out the cell and looks to his left and right. Luckily there is nobody around."+ 
		"Unsure of where he should go, he hesitates for a moment. \n\nIn which direction should John head?" +
		"\n\n'L' for left, 'R' for right";

		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.left;
		}
		
		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.right;
		}
	}

	void state_left() {
		text.text = "John heads down the hall and is met the back of the police station. A fire exit! John lifts " + 
		"the window open and steps out. This is his only chance. \n\nPress 'B' to make a break for it.";

		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.outside;
		}
	}

	void state_right() {
		text.text = "John heads down the hall and finds the front of the police station. Everyone seems to have their head down in work. " + 
		"\"Should I just run for it?\" he thinks to himself. \n\nPress 'B' to make a break for it, press 'T' to turn around.";

		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.death;
		} else if (Input.GetKeyDown(KeyCode.T)) {
			myState = States.left;
		}
	}

	void state_death() {
		text.text = "John bursts into a sprint heading for the door. Heads turn and some officers get out of their chairs." + 
		" One officer yells \"Freeze\" but it's too late. John can't stop now. He was so close to getting outside!" + 
		"*BANG* *BANG* *BANG* *Thud* \n\nGame Over \n\nPress 'P' to play again"; 

		if (Input.GetKeyDown(KeyCode.P)) {
			sheetsInHand = false;
			mirrorInHand = false;
			myState = States.cell;
		}
	}

	void state_outside() {
		text.text = "John exits the police station and start climbing down the fire escape. To his right is a group of empty parks " + 
		"police cars and to his left is another alley. \n\n Which direction should John head? \n\n" + 
		"Press 'L' to head toward the alley or 'R' to head for the cop car";


		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.police_cars;
		}

		if (Input.GetKeyDown(KeyCode.L)) {
			myState = States.alley;
		}
	}

	void state_alley() {
		text.text = "John turns the corner and is met with a large wall. He ran track and field in high school but this wall is pretty " + 
		"high. Alas, this is the direction he chose to head. It issn't too late for him to turn back though. \n\nPress 'B' " + 
		"to turn back and head to the police cars, or press 'W' to step up to the wall";

		if (Input.GetKeyDown(KeyCode.B)) {
				myState = States.police_cars;
		}

		if (Input.GetKeyDown(KeyCode.W)) {
				myState = States.wall;
		}
	}
	void state_wall() {
		if (jumped || jumped2) {
			text.text = "After attempting the jump he knows he can't make it. He has to go back. Hopefully" + 
			"he hasn't wasted too much time. \n\nPress 'b' to go back in the opposite direction";

			if (Input.GetKeyDown(KeyCode.B)) {
				myState = States.police_cars;
			}
		} else {
			text.text = "He steps up to the wall. Boy is it high. 'Should I just go back' he thinks to himself." + 
			"\n\nPress 'B' to go back to the police cars, or press 'J' to jump";

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

		text.text = "He gave it a running start and his body smacks against the well. 'Was I close?' he thought." +
		"He couldn't tell. \n\nPress 'j' to try again";

		
		if (Input.GetKeyDown(KeyCode.J)) {
			myState = States.jump2;
		}
	}
	void state_jump2() {
		text.text = "He gave it another attempt with everything he had. Running and jumping as fast and " + 
		"high as he could. His body smashes against the wall. He didn't make it. \n\nPress 'W' to go" +
		" back to the wall, or press 'B' to head back to the police cars.";

		if (Input.GetKeyDown(KeyCode.W)) {
			myState = States.wall;
		}

		
		if (Input.GetKeyDown(KeyCode.B)) {
			myState = States.police_cars;
		}
	}

	void state_police_cars () {
		text.text = "This was the moment of truth. Hoping that one of the cars is unlocked, he has " + 
		"just enough time to pick one car before someone notices what he is doing. \n\n Which car should John pick? \n\n" + 
		"Press '1' for the first car, '2' for the second car, '3' for the third car.";
		if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha1)) {
			myState = States.wrong_car;
		}

		
		if (Input.GetKeyDown(KeyCode.Alpha2)) {
			myState = States.right_car;
		}
	}

	void state_wrong_car () {
		text.text = "John runs up to the car as fast as he can. He would have to be quick. Get in the car, jump it, " + 
		"and get out of there. He attempts to open the door... Nothing. Locked. A police officer emerges from the station " + 
		"drops his coffee and yells 'FREEZE'. John has a moment to decide: \n\nPress 'R' to make a run to " +
		"the closest car, or 'G' to give in.";

		if (Input.GetKeyDown(KeyCode.R)) {
			myState = States.right_car;
		}

		if (Input.GetKeyDown(KeyCode.G)) {
			myState = States.give_in;
		}
	}

	void state_right_car() {
		text.text = "He runs as fast as he can to the car. Praying it is unlocked he pulls the door open and, with his last bit of luck, " + 
		"finds the keys sitting on the dashboard. He grabs them, turns the key and speeds off with a yelling officer in his rear view " + 
		"mirror.\n\n John is never heard from again as he manages to avoid an unwarranted end to his life. \n\nThanks for playing! Press " + 
		"'P' to play again!";

		if (Input.GetKeyDown(KeyCode.P)) {
			sheetsInHand = false;
			mirrorInHand = false;
			myState = States.cell;
		}
	}

	void state_give_in () {
		text.text = "John gives in. He knew he was out of options. \n\nGame Over \n\nThanks for playing! Press 'P' to play again!";
		
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