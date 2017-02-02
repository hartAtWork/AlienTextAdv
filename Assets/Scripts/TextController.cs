using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {
	public Text text; //need UI
	private enum States { 
		room, stand, man_t, man_t2, man_t3, man_s, man_s2, man_s3, autopsy, ship, door, freedom 
		};
	private States myState;
	// Use this for initialization
	void Start () {
		myState = States.room;
	}
	
	// Update is called once per frame
	void Update () {
		print (myState);
		if 		(myState == States.room)	{room ();}
		else if (myState == States.stand)	{stand ();}
		else if (myState == States.man_t)	{man_t ();}
		else if (myState == States.man_t2)	{man_t2 ();}
		else if (myState == States.man_t3)	{man_t3();}
		else if (myState == States.man_s) 	{man_s ();}
		else if (myState == States.man_s2)	{man_s2 ();}
		else if (myState == States.man_s3)	{man_s3 ();}
		else if (myState == States.ship)	{ship ();}
		else if (myState == States.autopsy)	{autopsy();}
		else if (myState == States.freedom) {freedom ();}
	}
	#region gameStates
	void room (){
		text.text = "You are in a room. There's a light overhead. It feels "+
					"dry and smells like someones armpit. There's a large mirror on the wall and a metal table. "+
					"You are currently sitting in a metal chair. Its the kind of chair that "+ 
					"wants you to sit up but will punish you anyways.\nYou are in an interrigation room. There is a large man standing silently in the corner.\n\n"+
					"Press S to stand up\n"+
					"Press T to talk to the man\n"+
					"Press D to do nothing.";
		if (Input.GetKeyDown(KeyCode.S))										{myState = States.stand;}
		else if (Input.GetKeyDown(KeyCode.T) ||Input.GetKeyDown(KeyCode.D) )	{myState = States.man_t;} 
	}
	void stand () {
		text.text = "You stand up from the chair in a panic. The man in the corner gives you a wierd look. You notice the door.\n\n"+ 
					"Press S to sit back down.\n"+
					"Press R to run for the door.";
		if (Input.GetKeyDown(KeyCode.S))				{myState = States.man_t;} 
		else if (Input.GetKeyDown(KeyCode.R))			{myState = States.man_s;}
	}
	void man_t () {
		text.text = "The man immerges from the corner and approaches you. As he steps into the light you can make out his face. He looks like a brick. He leans on the the desk in front of you "+
					"and says ‘I’m only going to ask you this once. Are you an alien?’\n\n"+
					"Press N to say 'No, I've always been a fellow earthling.'\n"+
					"Press M to say 'Maybe, i haven't checked in awhile...'\n"+
					"Press Y to say 'Yes, i love probes!'";
		if (Input.GetKeyDown(KeyCode.N) || Input.GetKeyDown(KeyCode.M))	{myState = States.man_t2;} 
		else if (Input.GetKeyDown(KeyCode.Y))							{myState = States.man_s;}		
	}
	void man_t2 () {
		text.text = "The man leans in closer almost as if trying to stair directly into your perfectly normal, average sized human brain. 'You think "+
					"this is a joke? Do you know what i do to jokers? ARE YOU AN ALIEN?!?!\n\n"+
					"Press N to say 'No, I am perfectly normal bipedal tax avoiding rebuplican'\n"+
					"Press Y to say 'Yes, and so is Bierber. I'm sorry... Is it too late?'";
		if (Input.GetKeyDown(KeyCode.N))		{myState = States.man_t3;
		} else if (Input.GetKeyDown(KeyCode.Y))	{myState = States.man_s;}			
	}
	void man_t3 () {
		text.text = "The man slams his hand down on the table with a crash. You think you almost hear the table cry. The man exhales and begins to walk around to "+
					"the other side of the table. He looks at you solidy without blinking. You wonder how his eyes aren't welling up from not blinking. His eyes must getting dry. With a shark like "+
					"calm the man speaks again. 'Are...you...an...alien?'\n\n"+
					"Press N to say 'Nope, I'm just a perfectly normal hooman!'\n"+
					"Press R to run for the door and say 'Shit, i ain't going down like this!'\n"+
					"Press Y to say 'Yes, I immigrated last fall. The weather is so nice here'";
		if (Input.GetKeyDown(KeyCode.N))		{myState = States.freedom;} 
		else if (Input.GetKeyDown(KeyCode.R))	{myState = States.man_s2;} 
		else if (Input.GetKeyDown(KeyCode.Y))	{myState = States.autopsy;}
	}
	void man_s2(){
		text.text = "You make a break for the door. On your haste you knock over your chair. The man chases after you but trips over the chair. You try door but its locked.\n\n"+
					"Press B to call your mothership and beam up\n"+
					"Press K to try to knock out the agent on the ground\n";
		if(Input.GetKeyDown(KeyCode.B)) 		{myState = States.ship;}
		else if (Input.GetKeyDown(KeyCode.K)) 	{myState = States.man_s3;}
	}
	#endregion
	#region endStates 
	void man_s3(){
		text.text = "The man laughs at your puny attempts to knock him out. The man stands up and bears down on you. He seems even taller"+
					"'I know how to deal with jokers like you...' He pulls out the phone book...\n\n"+
					"Press ENTER to try again.";
		if (Input.GetKeyDown(KeyCode.Return))	{myState = States.room;}
	}
	void ship(){
		text.text = "Your body is surrounded by light and you feel a tinlkling sensation. You are now on the mothership. 'Good job Bob.' says one of your coworkers.  "+
					"'HR wants to see you right away!' You have feeling you wont be getting that holiday bonus...\n\n"+
					"Press ENTER to try again.";
		if (Input.GetKeyDown(KeyCode.Return))	{myState = States.room;}
	}
	void autopsy () {
		text.text = "The man smilles and put on his sunglasses. Its indoors. As he puts his glasses he says 'Time to put an X on your file.' "+
					"The man walks out of the room. Thats the last thing you remember. You wake up and youa are on an operating table. Something tells you "+
					"you are not just your appendix getting removed.\n\n"+
					"Press ENTER to try again.";
		if (Input.GetKeyDown(KeyCode.Return))	{myState = States.room;}
	}
	//end state
	void man_s () {
		text.text = "The man seems to smile. With what seems like eternity the man draws his gun from his holster and shoots you."+
					"You are dead. Your green blood spills over the table. The man says, 'Aw damn Shawty, you got iced.'\n\n"+
					"Press ENTER to try again.";
		if (Input.GetKeyDown(KeyCode.Return))	{myState = States.room;}
	}
	void freedom() {
		text.text = "The man stares at you silently. He straightens up and says 'Well. I got nothing. You are free to go!' He leads you out of the room and your are free.";
	}
	#endregion
}
