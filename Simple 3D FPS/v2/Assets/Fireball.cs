using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public float speed = 10.0f;
	public int damage = 1;
	[SerializeField] GameObject explosionPrefab;
	GameObject _explosion;

	void Update() {
		transform.Translate(0, 0, speed * Time.deltaTime);
	}


	//private void Start(){
	//	explosionPrefab = Resources.Load("particles/ExplosionParticle");
	//}

	void OnTriggerEnter(Collider other) {
		_explosion = Instantiate(explosionPrefab) as GameObject;
		_explosion.transform.position = this.transform.position;
		_explosion.GetComponent<ParticleSystem>().Play(); 

		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}
		Destroy(this.gameObject);
	}
}
