using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using TMPro;
using static System.Random;

public class SceneController : MonoBehaviour {
	[SerializeField] private int gridRows = 2;
	[SerializeField] private int gridCols = 4;

	public float offsetX = 1.75f;
	public float offsetY = 1.75f;

	[SerializeField] private MemoryCard originalCard;
	[SerializeField] private Sprite[] images;
	[SerializeField] private TMP_Text scoreLabel;
	[SerializeField] private GameObject WinScreen;
	//[SerializeField] GameObject smokePrefab;
	//GameObject _smoke;
	
	private MemoryCard _firstRevealed;
	private MemoryCard _secondRevealed;
	private int _score = 0;
	private bool updateRan = false;
	private int winScore;
	private bool matched = false;

	public bool canReveal {
		get {return _secondRevealed == null;}
	}

	// Use this for initialization
	void Start() {
		WinScreen.SetActive(false);
		winScore = gridRows * gridCols / 2;

		// create shuffled list of cards
		int[] numbers = new int[gridRows * gridCols];
		bool[] arr = new bool[52];

		System.Random rnd = new System.Random();
		for(int j = 0; j < gridRows * gridCols; j = j+2) {
			int a = rnd.Next(52);
			while(arr[a]) {
				a = rnd.Next(52);
			}
			arr[a] = true;
			numbers[j] = numbers[j+1] = a;
		}
		numbers = ShuffleArray(numbers);
		if(gridRows == 2 && gridCols == 4) {
			originalCard.transform.position = new Vector3(-3.5f,1.59f,-5f);
			originalCard.transform.localScale = new Vector3(2.5f,2.5f,2.5f);
			offsetX = 2.3f;
			offsetY = 3.3f;
		}
		if(gridRows == 2 && gridCols == 3) {
			originalCard.transform.position = new Vector3(-2.5f,1.59f,-5f);
			originalCard.transform.localScale = new Vector3(2.5f,2.5f,2.5f);
			offsetX = 2.5f;
			offsetY = 3.25f;
		}
		if(gridRows == 2 && gridCols == 5) {
			originalCard.transform.position = new Vector3(-4f,1.5f,-5f);
			originalCard.transform.localScale = new Vector3(2f,2f,2f);
			offsetX = 2f;
			offsetY = 3f;
		}
		if(gridRows == 3 && gridCols == 4) {
			originalCard.transform.position = new Vector3(-3f,2f,-5f);
			originalCard.transform.localScale = new Vector3(1.75f,1.75f,1.75f);
			offsetX = 2f;
			offsetY = 2.25f;
		}
		if(gridRows == 4 && gridCols == 4) {
			originalCard.transform.position = new Vector3(-2.5f,2.35f,-5f);
		}
		Vector3 startPos = originalCard.transform.position;

		// place cards in a grid
		for (int i = 0; i < gridCols; i++) {
			for (int j = 0; j < gridRows; j++) {
				MemoryCard card;

				// use the original for the first grid space
				if (i == 0 && j == 0) {
					card = originalCard;
				} else {
					card = Instantiate(originalCard) as MemoryCard;
				}

				// next card in the list for each grid space
				int index = j * gridCols + i;
				int id = numbers[index];
				card.SetCard(id, images[id]);

				float posX = (offsetX * i) + startPos.x;
				float posY = -(offsetY * j) + startPos.y;
				card.transform.position = new Vector3(posX, posY, startPos.z);
			}
		}
	}

	// Knuth shuffle algorithm
	private int[] ShuffleArray(int[] numbers) {
		int[] newArray = numbers.Clone() as int[];
		for (int i = 0; i < newArray.Length; i++ ) {
			int tmp = newArray[i];
			int r = Random.Range(i, newArray.Length);
			newArray[i] = newArray[r];
			newArray[r] = tmp;
		}
		return newArray;
	}

	public void CardRevealed(MemoryCard card) {
		if (_firstRevealed == null) {
			_firstRevealed = card;
		} else {
			_secondRevealed = card;
			StartCoroutine(CheckMatch());
		}
	}
	
	private IEnumerator CheckMatch() {

		// increment score if the cards match
		if (_firstRevealed.id == _secondRevealed.id) {
			matched = true;
			_score++;
			scoreLabel.text = "Score: " + _score;
		}

		// otherwise turn them back over after .5s pause
		else {
			yield return new WaitForSeconds(.5f);

			_firstRevealed.Unreveal();
			_secondRevealed.Unreveal();
			_firstRevealed = null;
			_secondRevealed = null;
		}
	}

	void Update() {
		if(!updateRan) {
			updateRan = true;
		}
		if(_score == winScore) {
			Invoke("Winner", 1f);
		}
		if(matched == true) {
			_firstRevealed.Shake();
			_secondRevealed.Shake();
			Invoke("Stop", 0.5f);
		}
	}

	private void Winner() {
		WinScreen.SetActive(true);
	}

	private void Stop() {
		matched = false;
		_firstRevealed.Smoke();
		_secondRevealed.Smoke();
		_firstRevealed.Kill();
		_secondRevealed.Kill();
		_firstRevealed = null;
		_secondRevealed = null;
	}

	public void Restart() {
		if(updateRan) {
			WinScreen.SetActive(false);
			SceneManager.LoadScene("SampleScene");
		}
	}

	public void SetSize(int row, int col) {
		gridRows = row;
		gridCols = col;
		Restart();
	}
}
