using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {
	
	public float rotationX = 0;
	public bool startUpdate = false;

	[SerializeField] private GameObject enemyPrefab1;
	[SerializeField] private GameObject enemyPrefab2;
	[SerializeField] private GameObject tombstone;
	

	public void ReactToHit() {
		WanderingAI behavior = GetComponent<WanderingAI>();
		if (behavior != null) {
			behavior.SetAlive(false);
		}
		startUpdate = true;
	}

	void Update() {
		if(startUpdate) {
			if(rotationX >= 90) {
				StartCoroutine(Destroy());
				startUpdate = false;
				rotationX = 0;
			} else {
				this.transform.Rotate(1.0f,0,0);
				rotationX = rotationX + 1.0f;
			}
		}
		else
			;
	}

	private IEnumerator Destroy() {
		StartCoroutine(Hydra());
		StartCoroutine(CreateTomb());
		yield return new WaitForSeconds(1.0f);
		
		Destroy(this.gameObject);
	}

	private IEnumerator Hydra() {
		yield return new WaitForSeconds(1.0f);

		GameObject enemy1 = Instantiate(enemyPrefab1) as GameObject;
		enemy1.transform.rotation = Quaternion.identity;
		enemy1.transform.position = new Vector3(5, 0, 0);
		float angle1 = Random.Range(0, 360);
		enemy1.transform.Rotate(0, angle1, 0);

		GameObject enemy2 = Instantiate(enemyPrefab2) as GameObject;
		enemy2.transform.rotation = Quaternion.identity;
		enemy2.transform.position = new Vector3(0, 0, 0);
		float angle2 = Random.Range(0, 360);
		enemy2.transform.Rotate(0, angle2, 0);
	}

	private IEnumerator CreateTomb() {
		yield return new WaitForSeconds(1.0f);

		GameObject tomb = Instantiate(tombstone) as GameObject;
 		tomb.transform.position = new Vector3(gameObject.transform.position.x, 0.5f, gameObject.transform.position.z);
	}
}
