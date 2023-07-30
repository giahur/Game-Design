using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class MemoryCard : MonoBehaviour {
	[SerializeField] private GameObject cardBack;
	[SerializeField] private SceneController controller;
	[SerializeField] GameObject smokePrefab;
	GameObject _smoke;

	private int _id;
	public int id {
		get {return _id;}
	}

	public void SetCard(int id, Sprite image) {
		_id = id;
		GetComponent<SpriteRenderer>().sprite = image;
	}

	public void OnMouseDown() {
		if (!EventSystem.current.IsPointerOverGameObject() 
      	&& cardBack.activeSelf && controller.canReveal) {
    		if (cardBack.activeSelf && controller.canReveal) {
				cardBack.SetActive(false);
				controller.CardRevealed(this);
			}
		}
		if (cardBack.activeSelf && controller.canReveal) {
			cardBack.SetActive(false);
			controller.CardRevealed(this);
		}
	}

	public void Unreveal() {
		cardBack.SetActive(true);
	}

	public void Shake() {
		float sinWave = (Mathf.Sin(Time.time * 2.0f * Mathf.PI * 2.0f) + 1.0f) / 2.0f;
		transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 5), new Vector3(0, 0, -10), sinWave);
		transform.eulerAngles = Vector3.Lerp(new Vector3(0, 0, 5), new Vector3(0, 0, -10), sinWave);
			//StartCoroutine(Stop());
	}

	public void Kill() {
		Destroy(this.gameObject);
	}

	public void Smoke() {
		_smoke = Instantiate(smokePrefab) as GameObject;
		_smoke.transform.position = transform.position;
		_smoke.GetComponent<ParticleSystem>().Play();
	}
}
