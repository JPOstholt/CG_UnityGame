using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roadSpawn : MonoBehaviour {



	public GameObject nextSpawn;
	int randomRoadNumber;
	public List<GameObject> roadTiles;
	public GameObject roadManager;
	public GameObject bombPrefab;
	Vector3 newPosition;
	int bombCount;
	public int bombMax;
	public Vector3 bombPos;
	public GameObject currentRoad;
	public GameObject lastRoad;
	// Use this for initialization
	void Start () {



		roadManager = GameObject.FindGameObjectWithTag ("roadManager");

		roadTiles = roadManager.GetComponent<roadManager> ().roadTiles;


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other) {





		if (other.gameObject.name == "Player") {



			Debug.Log ("bepis");

			randomRoadNumber = Random.Range (0, roadTiles.Count);


			newPosition = new Vector3 (transform.position.x, transform.position.y, transform.position.z + 200);

			currentRoad = Instantiate (roadTiles [randomRoadNumber], newPosition, Quaternion.identity);
			currentRoad.GetComponent<roadSpawn> ().lastRoad = this.gameObject;

			bombCount = Random.Range (0, bombMax);

			for (int i = 0; i < bombCount; i++) {


				bombPos = new Vector3 (transform.position.x + Random.Range(-560,50), transform.position.y +  Random.Range(80,150), transform.position.z + Random.Range(-100,100));

				GameObject currentBomb = Instantiate (bombPrefab, bombPos, Quaternion.Euler(Random.Range(0,360), Random.Range(0,360), Random.Range(0,360)));
				currentBomb.GetComponent<Rigidbody> ().AddForce (Vector3.down * 2000);
				currentBomb.transform.SetParent (transform);
			}

			GetComponent<BoxCollider> ().enabled = false;

			Destroy (lastRoad.gameObject);

		}

	}
}
