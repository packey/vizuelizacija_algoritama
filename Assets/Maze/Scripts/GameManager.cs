using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;
    public GameObject mainCamera;

    private Maze mazeInstance;

	void Start () {
        mainCamera.transform.position = new Vector3(0, 8.8f+(Maze.Size.x-10)*0.75f, -5.1f - (Maze.Size.x - 10) * 0.48f);

        BeginGame();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space)){
            RestartGame();
        }
	}

    private void BeginGame()
    {
        mazeInstance = Instantiate(mazePrefab) as Maze;
        mazeInstance.Generate();
    }

    private void RestartGame()
    {
        StopAllCoroutines();
        Destroy(mazeInstance.gameObject);
        BeginGame();
    }
}
