using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockHandler : MonoBehaviour {
	public GameObject[] cubes;
	public List<GameObject> cubesAt;
	public float count = 0;
	// Use this for initialization
	void Start () {
		
	}
	void Update()
	{
		CheckLines ();
	}
	// Update is called once per frame
	void CheckLines () {
		{
			cubes = GameObject.FindGameObjectsWithTag ("Cube");
			for (int i = 6; i >= -6; i--) {
				foreach (GameObject cube in cubes) {
					if (cube != null) {
						Movement a = cube.GetComponentInParent<Movement> ();
						if (cube.transform.position.y > i - 0.001f && cube.transform.position.y < i + 0.001f && !a.move) {
							count += 1;
							cubesAt.Add (cube);
						}
					}
				}
				if (count > 9) {
					Debug.Log ("Enough to destroy");
					foreach (GameObject cube in cubesAt) {
						Destroy (cube);
					}
				}
				count = 0;
				cubesAt.Clear ();
			}
		}
	}
}
