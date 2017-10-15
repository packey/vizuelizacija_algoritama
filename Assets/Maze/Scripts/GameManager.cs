using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Maze mazePrefab;
    public GameObject mainCamera;
    public GameObject slider;
    public GameObject startPanel;
    public GameObject infoPanel;
    public ToggleGroup nextObjectGroup;
    public ToggleGroup backtrackModeGroup;

    private Maze mazeInstance;
    private bool isSlow = false;

    void Start () {
        

        //BeginGame();
	}
	
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && mazeInstance != null){
            RestartGame();
        }

        if (Maze.isPaused)
        {
            infoPanel.SetActive(true);
            infoPanel.transform.Find("InfoMessage").GetComponent<TextMeshProUGUI>().text = Maze.displayMessage;
        }

        //if(Input.GetKeyDown(KeyCode.Return) && mazeInstance == null)
        //{
        //    BeginGame();
        //}
	}

    public void StartMaze()
    {
        Maze.Size.x = Maze.Size.z = (int)slider.GetComponent<Slider>().value;
        startPanel.SetActive(false);
        mainCamera.transform.position = new Vector3(0, 8.4f + (Maze.Size.x - 10) * 0.73f, -5.9f - (Maze.Size.x - 10) * 0.52f);

        BeginGame();
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

    public void GoHome()
    {
        SceneManager.LoadScene("start_menu");
    }

    public void NextObjectToggle(bool toggled)
    {
        if(toggled)
        {
            var activeToggle = nextObjectGroup.ActiveToggles().FirstOrDefault();
            if (activeToggle.name == "None")
                Maze.showNextObject = false;
            else
            {
                if (Maze.showNextObject == false)
                    Maze.nextObjectMessagesCount = 0;
                Maze.showNextObject = true;
            }
            Maze.showNextObjectFirstTime = activeToggle.name == "First";
        }
    }

    public void BacktrackToggle(bool toggled)
    {
        if (toggled)
        {
            var activeToggle = backtrackModeGroup.ActiveToggles().FirstOrDefault();
            if (activeToggle.name == "None")
                Maze.showBacktrack = false;
            else
            {
                if (Maze.showBacktrack == false)
                    Maze.backtrackMessagesCount = 0;
                Maze.showBacktrack = true;
            }
            Maze.showBacktrackFirstTime = activeToggle.name == "First";
        }
    }

    public void OkPressed()
    {
        Maze.isPaused = false;
        infoPanel.SetActive(false);
    }
}
