using UnityEngine;
using System.Collections;

public class NumberWizard : MonoBehaviour {
  int min;
  int max;
  int guess = 500;
  
	// Use this for initialization
	void Start() {
		min = 1;
		max = 1000;
    print ("Welcome to Number Wizard");
		print ("Pick a number in your head between " + min + " and " + max);
		
		max += 1;
		askQuestion();
		
	}
	
	// Update is called once per frame
	void Update() {
		
		if(Input.GetKeyDown(KeyCode.UpArrow)) {
			//print "Up was pressed");	
      min = guess;	
      askQuestion();
		} else if (Input.GetKeyDown(KeyCode.DownArrow)) {
			//print ("Down was pressed");
      max = guess;
      askQuestion();
		} else if (Input.GetKeyDown(KeyCode.Return)) {
			print ("I won!");
      print("========================================");
      Start();
		}
    
	}
  
  void askQuestion() {
    guess = (min + max) / 2;
    print ("Is the number higher or lower than " + guess + "?");
    print ("Up for higher, down for lower, and return for equals");  
  }
}
