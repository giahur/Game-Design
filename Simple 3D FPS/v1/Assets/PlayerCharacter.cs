using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	public TMP_Text health;
	public TMP_Text gameOver;

	public int xcord= 100;
	public int ycord= 100;
	public int xspeed= 1;
	public int yspeed= -1;

	void Start() {
		_health = 2;
	}

	public void Hurt(int damage) {
		_health -= 1;
		Debug.Log("Health: " + _health);

		if(_health <= 0) {
			gameOver.text = ("game over :(");
		}
	}

	void Update() {
		health.text = ("Health: " + _health);
		if(_health <= 0) {
			gameOver.text = ("game over :(");
			
			/*gameOver.transform.position = new Vector2 (xcord, ycord);
			xcord = xcord + xspeed * (int)Time.deltaTime;
			ycord = ycord + yspeed * (int)Time.deltaTime;
			if(xcord >= Screen.width || xcord <= 0) {
				xspeed = -xspeed;
			}
			if(ycord >= Screen.height || ycord <= 0) {
				yspeed = -yspeed;
			}*/
		}
	}
}
