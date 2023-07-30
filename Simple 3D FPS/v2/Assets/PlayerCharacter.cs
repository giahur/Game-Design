using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
	public TMP_Text health;
	public TMP_Text gameOver;

	private float xcord= 100f;
	private float ycord= 100f;
	private float xspeed= 100f;
	private float yspeed= -100f;

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
			
			gameOver.GetComponent<RectTransform>().anchoredPosition = new Vector2 (xcord, ycord);
			xcord = xcord + xspeed * Time.deltaTime;
			ycord = ycord + yspeed * Time.deltaTime;
			if(xcord >= Screen.width || xcord <= 0) {
				xspeed = -xspeed;
			}
			if(ycord >= Screen.height || ycord <= 0) {
				yspeed = -yspeed;
			}
		}
	}
}
