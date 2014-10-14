using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinSpawnScript : MonoBehaviour {
	
	public GameObject coin;

	public float minX, maxX, minY, maxY;

	public int pooledAmount = 5;
	List<GameObject> coins;

	int TotalScore;
	GUIText t;

	// Use this for initialization
	void Start () {
		coins = new List<GameObject>();
		GameObject obj;

		for(int i = 0; i < pooledAmount; ++i) {
			obj = (GameObject) Instantiate(coin);
			obj.SetActive(false);
			coins.Add(obj);
			coins[i].transform.parent = this.transform;
		}

		t = GameObject.FindGameObjectWithTag("Score").GetComponent("GUIText") as GUIText;
		t.text = coins.Count.ToString();

		InvokeRepeating("CountScore",0.1f,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		float x,y;

		for(int i = 0; i < coins.Count; ++i) {
			if(!coins[i].activeInHierarchy) {
				coins[i].SetActive(true);
				x = Random.Range(minX,maxX);
				y = Random.Range(minY,maxY);
				coins[i].transform.position = new Vector3(x,y,0);
			}
		}
	}

	void CountScore() {
		CoinScript cs;
		//int Score = 0;

		for(int i = 0; i < coins.Count; ++i) {
			cs = (CoinScript) coins[i].GetComponent("CoinScript");
			TotalScore += cs.score;
			cs.score = 0;
		}

		//TotalScore += Score;
		t.text = "Score: " + TotalScore;
	}
}
