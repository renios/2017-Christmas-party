using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MakeWordGrid : MonoBehaviour {

	public TextAsset wordFile;

	List<string> words;
	List<Text> texts;

	void MakeRandomGrid() {
		texts = FindObjectsOfType<Text>().ToList();
		words = wordFile.text.Split('\n').ToList();

		texts.ForEach(textUI => {
			int randIndexOfWord = Random.Range(0, words.Count);
			string randWord = words[randIndexOfWord];

			textUI.text = randWord;

			words.RemoveAt(randIndexOfWord);
		});
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return)) {
			MakeRandomGrid();
		}
	}
}
