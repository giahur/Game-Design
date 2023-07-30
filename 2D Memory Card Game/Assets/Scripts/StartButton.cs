using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {
	[SerializeField] private GameObject targetObject;
	[SerializeField] private string targetMessage;
	public Color highlightColor;

	public void OnMouseEnter() {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			sprite.color = highlightColor;
		}
	}
	public void OnMouseExit() {
		SpriteRenderer sprite = GetComponent<SpriteRenderer>();
		if (sprite != null) {
			sprite.color = Color.blue;
		}
	}

	public void OnMouseDown() {
		transform.localScale = new Vector3(1.3f, 1.69f, 1.3f);
	}
	public void OnMouseUp() {
		transform.localScale = new Vector3(1f, 1.3f, 1f);
		if (targetObject != null) {
			targetObject.SendMessage(targetMessage);
		}
	}
}
