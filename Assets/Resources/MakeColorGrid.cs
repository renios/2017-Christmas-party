using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class MakeColorGrid : MonoBehaviour {

	List<Image> images;

	public int blueCells;
	public int redCells;

	void MakeRandomGrid() {
		images = FindObjectsOfType<Image>().ToList();
		images.ForEach(image => image.color = Color.white);

		int randIndex;

		for (int i = 0; i < redCells; i++) {
			randIndex = Random.Range(0, images.Count);
			images[randIndex].color = Color.red;
			images.RemoveAt(randIndex);
		}

		for (int i = 0; i < blueCells; i++) {
			randIndex = Random.Range(0, images.Count);
			images[randIndex].color = Color.blue;
			images.RemoveAt(randIndex);
		}

		randIndex = Random.Range(0, images.Count);
		images[randIndex].color = Color.black;
		images.RemoveAt(randIndex);
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
