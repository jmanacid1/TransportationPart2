using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
public Airplane airplane;
public GameObject cubePrefab;
static int numCubes = 16;
static int numRows = 9;
private GameObject[,] allCubes = new GameObject[numCubes, numRows];

	// Use this for initialization
	void Start () {
		airplane = new Airplane ();
		for (int h = 0; h < numRows; h++) {
			for (int i = 0; i < numCubes; i++) {
				allCubes [i,h] = (GameObject)Instantiate (cubePrefab, new Vector3 (i * 2 - 14, h * 2, 10), Quaternion.identity);
				// these lines turn the location of the spanwed cubes into the x and y values used in CubeBehavior
				allCubes [i,h].GetComponent<CubeBehavior>().x = i;
				allCubes [i,h].GetComponent<CubeBehavior>().y = h;
			}
		}
		// tells the airplane to spawn in the upper left
		airplane.x = 0;
		airplane.y = 8;
		allCubes [0,8].GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ProcessClickedCube (GameObject clickedCube, int x, int y) {

		// this says "if you click a cube that isn't the airplane while the airplane is active, turn the clicked cube yellow"
		if (airplane.active == true &&(x != airplane.x || y != airplane.y)){
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			clickedCube.GetComponent<Renderer>().material.color = Color.yellow;
			airplane.x = x;
			airplane.y = y;
		}
		// this says "if you click on an inactive airplane, that airplane becomes active"
		else if (airplane.active == false && x == airplane.x && y ==  airplane.y){
			allCubes[airplane.x, airplane.y].GetComponent<Renderer>().material.color = Color.white;
			clickedCube.GetComponent<Renderer>().material.color = Color.yellow;
			airplane.active = true;
			airplane.x = x;
			airplane.y = y;
		}
		// this says "if you click the active cube, deactivate it"
		else if (airplane.active == true && x == airplane.x && y ==  airplane.y){
			clickedCube.GetComponent<Renderer>().material.color = Color.red;
			airplane.active = false;
			airplane.x = x;
			airplane.y = y;
		}
	}

}
