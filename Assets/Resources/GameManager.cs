using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class GameManager : MonoBehaviour {

	public TextAsset wordFile;

	List<string> words;
	int totalWords;
	int remainWords;

	bool endGame;

	int score;
	public Text scoreText;

	bool canPass;
	float lastPassTime;
	public float passTime;
	public Image passTimerImage;

	float currentTime;
	public float maxTime;
	public Image timerImage;
	public Text timeText;

	public Text answerText;

	public GameObject resultPanel;
	public Text resultText;
	public Text remainWordsText;

	void PrintNextRandomWord() {
		int randIndexOfWord = Random.Range(0, words.Count);
		string randWord = words[randIndexOfWord];

		answerText.text = randWord;

		words.RemoveAt(randIndexOfWord);

		lastPassTime = 0;
		passTimerImage.color = Color.gray;
		canPass = false;
	}

	void PrintResult() {
		resultPanel.SetActive(true);
		resultText.text = "제한시간 종료!" + '\n' + "점수 : " + score;
		remainWordsText.text = "남은 단어 " + words.Count + " / " + totalWords;
	}

	void UpdateScore() {
		scoreText.text = "점수 : " + score;
	}

	void UpdateTime() {
		int remainTime = (int)(maxTime - currentTime);
		timeText.text = remainTime / 60 + " : " + remainTime % 60;
		timerImage.fillAmount = currentTime / maxTime;
	}

	void StartNewGame() {
		score = 0;
		UpdateScore();
		currentTime = 0;
		UpdateTime();
		lastPassTime = 0;
		passTimerImage.color = Color.gray;
		canPass = false;

		PrintNextRandomWord();

		resultPanel.SetActive(false);

		endGame = false;
	}

	// Use this for initialization
	void Start () {
		words = wordFile.text.Split('\n').ToList();
		totalWords = words.Count;

		endGame = true;
		score = 0;
		currentTime = 0;
		lastPassTime = 0;
		passTimerImage.color = Color.gray;
		canPass = false;

		PrintResult();
	}
	
	// Update is called once per frame
	void Update () {
		if (!endGame) {
			currentTime += Time.deltaTime;
			UpdateTime();

			if (currentTime > maxTime) {
				endGame = true;

				PrintResult();
				return;
			}
			
			if (lastPassTime < passTime) {
				lastPassTime += Time.deltaTime;
				passTimerImage.fillAmount = lastPassTime / passTime;
			}
			else {
				passTimerImage.color = Color.green;
				canPass = true;
			}

			if (Input.GetKeyDown(KeyCode.O)) {
				score += 10;
				UpdateScore();
				PrintNextRandomWord();
			}
			else if (Input.GetKeyDown(KeyCode.P) && canPass) {
				PrintNextRandomWord();
			}
		}
		else {
			if (Input.GetKeyDown(KeyCode.Return)) {
				StartNewGame();
			}
		}
	}
}
