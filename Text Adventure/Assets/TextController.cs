using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

	public Text text;
	private string[][] commands;
	private enum States {cell, mirror, lock_0, sheets_0, sheets_1, cell_mirror, lock_1, corridor_0};
	private States myState;
	
	// Use this for initialization
	void Start () {
		myState = States.cell;
	}
	
	// Update is called once per frame
	void Update () {
		if(myState == States.cell) 				{ cell();} 
		else if(myState == States.mirror) 		{ mirror();}
		else if(myState == States.lock_0) 		{ lock_0();}
		else if(myState == States.sheets_0) 	{ sheets_0();}
		else if(myState == States.sheets_1) 	{ sheets_1();}
		else if(myState == States.cell_mirror) 	{ cell_mirror();}
		else if(myState == States.lock_1) 		{ lock_1();}
		else if(myState == States.corridor_0) 	{ corridor_0();}
	}
	
	void corridor_0() {
		commands = new string[3][];
		commands[0] = new string[2] {"S", "approach the stairs"};
		commands[1] = new string[2] {"G", "examine the ground"};
		commands[2] = new string[2] {"C", "approach the closet"};
		
		text.text = "Sliding the mirror through the bars, you have just enough of an angle to be able to see faint fingerprint smudged on the keypad.  After a few tries, you find the right combination. Yes!\n\n" +
					"The door opens into a long corridor.  At one end, stairs head upwards.  You can hear faint voices. At the other end is a closet.  Looking down, you catch the glint of something on " + 
					"the ground.\n\n" + formatCommands(commands);
	}
	
	void lock_1() {
		commands = new string[2][];
		commands[0] = new string[2] {"M", "use the mirror with the lock"};
		commands[1] = new string[2] {"R", "return to roaming your cell"};
		
		text.text = "You stand in front of the lock with your mirror.  Will this work?\n\n" + formatCommands(commands);
		
		if(Input.GetKeyDown(KeyCode.M)) 		{ myState = States.corridor_0;}
		else if(Input.GetKeyDown(KeyCode.R)) 	{ myState = States.cell_mirror;}
	}
	
	void cell_mirror() {
		commands = new string[2][];
		commands[0] = new string[2] {"S", "view the sheets"};
		commands[1] = new string[2] {"L", "view the lock"};
		
		text.text = "You have the mirror in your hand now. But you are still stuck in this blasted prison with your dirty sheets and a locked door.\n\n" + formatCommands(commands);
		
		if(Input.GetKeyDown(KeyCode.S)) 		{ myState = States.sheets_1;}
		else if(Input.GetKeyDown(KeyCode.L)) 	{ myState = States.lock_1;}
	}
	
	void cell() {
		commands = new string[3][];
		commands[0] = new string[2] {"S", "view the sheets"};
		commands[1] = new string[2] {"M", "view the mirror"};
		commands[2] = new string[2] {"L", "view the lock"};
		
		
		text.text = "You wake up. In this room. Again. Always again. You have been in this prison for...days?  Months? No one will answer your calls for help or even tell you why you are being held. " +
			"You can't take it anymore. It is time to leave. Time to escape!\n\n" +
				"There are some sheets on the bed, a mirror on the wall, and a locked door.\n\n" + formatCommands(commands);
				
		if(Input.GetKeyDown(KeyCode.S)) { myState = States.sheets_0;}
		else if(Input.GetKeyDown(KeyCode.M)) { myState = States.mirror;}
		else if(Input.GetKeyDown(KeyCode.L)) { myState = States.lock_0;}
	}
	
	void sheets_1() {
		commands = new string[1][];
		commands[0] = new string[2] {"R", "return to roaming your cell"};
		
		text.text = "The sheets look just are dirty and pitiful in the mirror as they do without it.\n\n" + formatCommands(commands);
		
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell_mirror;}
	}
	
	void mirror() {
		commands = new string[2][];
		commands[0] = new string[2] {"T", "take the mirror"};
		commands[1] = new string[2] {"R", "return to roaming your cell"};
		
		text.text = "Looking at your gaunt face and sunken eyes, you finally understand why they gave you a mirror, even such a small one as this. They want you to see your decline. To know better your fate. " +
					"You want to destroy it, but perhaps there is a better use.\n\n" + formatCommands(commands);
		
		if(Input.GetKeyDown(KeyCode.T)) 		{ myState = States.cell_mirror;}
		else if(Input.GetKeyDown(KeyCode.R)) 	{ myState = States.cell;}
	}
	
	void lock_0() {
		commands = new string[1][];
		commands[0] = new string[2] {"R", "return to roaming your cell"};
		
		text.text = "Through the bars, you can see it is a button lock.  If you had a better angle, perhaps you could see the greasy fingerprints left by your silent jailer.\n\n" + formatCommands(commands);
		
		if(Input.GetKeyDown(KeyCode.R)) {myState = States.cell;}
	}
	
	void sheets_0() {
		commands = new string[1][];
		commands[0] = new string[2] {"R", "return to roaming your cell"};
		
		
		text.text = "You see your sheets. Though calling them sheets might be a bit of a stretch.  These are more like dirty rags that barely cover your torso at night. You don't need them.\n\n" + 
					formatCommands(commands);
		
		if(Input.GetKeyDown(KeyCode.R)) { myState = States.cell;}
	}
	
	private string formatCommands(string[][] commands) {
		string formattedCommands = "Press \n";
		
		for (int i = 0; i < commands.GetLength(0); i++) {
			formattedCommands += "\t<b>" + commands[i][0] + "</b> to " + commands[i][1] + "\n";
			
		}
		
		return formattedCommands;
	}
}
