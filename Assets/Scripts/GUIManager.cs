using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    private int currentAlgorithm = -1;

	bool red=false, blue=false ,green=false;

	[Header("Maps Sprites")]
	public Image imageMap;
	public Sprite red_sprite;
	public Sprite blue_sprite;
	public Sprite green_sprite;
	public Sprite blue_red_sprite;
	public Sprite blue_green_sprite;
	public Sprite green_red_sprite;
	public Sprite red_green_blue_sprite;
	public Sprite default_sprite;

	[Header("Buttons Colors")]
	public Button red_button;
	public Button green_button;
	public Button blue_button;

	public Sprite red_button_sprite;
	public Sprite green_button_sprite;
	public Sprite blue_button_sprite;
	public Sprite gray_button_sprite;

    [Header("Graph Elements")]
    public Toggle toggle6;
    public Toggle toggle7;
    public Toggle toggle9;

    [Header("Canvas Panels")]
    public GameObject mainMenuPanel;                        // Main panel holding common buttons
    public GameObject chooseAlgorithmPanel;                 // Choose algorithm to show 
    public GameObject infoPanel;                            // Information about project and team
    public GameObject exitPanel;                            // Exit confirmation panel

	[Header("Algorithm Panels")]
	public GameObject algorithmPanel1; 						// Algorithm 1
	public GameObject algorithmPanel2; 						// Algorithm 2
	public GameObject algorithmPanel3; 						// Algorithm 3
	public GameObject algorithmPanel4; 						// Algorithm 4

	[Header("Algorithm 1 steps")]
	public GameObject algorithm1_Step1; 						// Algorithm 1 step 1
	public GameObject algorithm1_Step2; 						// Algorithm 1 step 2
	public GameObject algorithm1_Step3; 						// Algorithm 1 step 3
	public GameObject algorithm1_Step4;                         // Algorithm 1 step 4
	public GameObject algorithm1_Step5;                         // Algorithm 1 step 5
	public GameObject algorithm1_Step6;                         // Algorithm 1 step 6
	public GameObject algorithm1_Step7;                         // Algorithm 1 step 7

    [Header("Algorithm 2 steps")]
    public GameObject algorithm2_Step1;                         // Algorithm 2 step 1
    public GameObject algorithm2_Step2;                         // Algorithm 2 step 2
    public GameObject algorithm2_Step3;                         // Algorithm 2 step 3

    [Header("Algorithm 3 steps")]
    public GameObject algorithm3_Step1;
    public GameObject algorithm3_Step2;
    public GameObject algorithm3_Step3;
    public GameObject algorithm3_Step4;

    [Header("Algorithm 4 steps")]
    public GameObject algorithm4_Step1;
    public GameObject algorithm4_Step2;

    [Header("Other objects")]
    public GameObject slider;

    // Use this for initialization
    void Start ()
    {
        SoundManager.instance.PlayMusic(SoundManager.instance.bgMusic);
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (chooseAlgorithmPanel.activeSelf || infoPanel.activeSelf || exitPanel.activeSelf)
                ActivatePanel(true, false, false, false);
            else
                ActivatePanel(false, false, false, true);
        }
	}

    #region COMMON_BUTTONS

    /// <summary>
    /// Activates choose algorithm panel
    /// </summary>
    public void OnChooseAlgorithmButtonClicked()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        ActivatePanel(false, true, false, false);
    }

    /// <summary>
    /// Activates info panel
    /// </summary>
    public void OnInfoButtonClicked()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        ActivatePanel(false, false, true, false);
    }

    /// <summary>
    /// Activates exit panel
    /// </summary>
    public void OnExitButtonClicked()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        ActivatePanel(false, false, false, true);
    }

    /// <summary>
    /// Opens Maze scene
    /// </summary>
    public void OnOpenMazeClicked()
    {
        Maze.Size.x = Maze.Size.z = (int)slider.GetComponent<Slider>().value;
        
        SceneManager.LoadScene("maze");
    }

    public void OnChooseGraphClicked()
    {
        algorithm3_Step4.SetActive(true);

        if (toggle6.isOn)
            GraphManager.instance.StartGraph(6);
        else if (toggle7.isOn)
            GraphManager.instance.StartGraph(7);
        else
            GraphManager.instance.StartGraph(9);
    }

    /// <summary>
    /// Confirm exit from app
    /// </summary>
    public void OnExitYesButtonClicked()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        Application.Quit();
    }

    /// <summary>
    /// Decline exit from app
    /// </summary>
    public void ReturnToMainPanel()
    {
        SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        ActivatePanel(true, false, false, false);
    }
    #endregion

    #region CHOOSE_BUTTONS

    /// <summary>
    /// Proceed to the choosen algorithm visualization
    /// </summary>
    /// <param name="algorithmID"></param>
    public void ChooseAlgorithm(int algorithmID)
    {
        SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + algorithmID);
    }

#endregion

    #region PRIVATE_METHODS
    /// <summary>
    /// Activates proper panel
    /// </summary>
    /// <param name="main"></param>
    /// <param name="choose"></param>
    /// <param name="info"></param>
    /// <param name="exit"></param>
    private void ActivatePanel(bool main, bool choose, bool info, bool exit)
    {
        mainMenuPanel.SetActive(main);
        chooseAlgorithmPanel.SetActive(choose);
        infoPanel.SetActive(info);
        exitPanel.SetActive(exit);
    }

#endregion

	#region ALGORITHM_CONTROL

	public void ActiveAlorithm(int idAlgorithm)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);		
        currentAlgorithm = idAlgorithm;
        GetGameObject("algorithmPanel" + currentAlgorithm).SetActive(true);
    }

	public void ReturnToChoosePanel()
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
        GetGameObject("algorithmPanel" + currentAlgorithm).SetActive (false);
		ActivatePanel(false, true, false, false);
	}

	public void ActiveAlorithmStep(int idStep)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		switch (idStep) 
		{
		    case 1:
                GetGameObject("algorithm" + currentAlgorithm + "_Step1").SetActive(true);
                break;
		    case 2:
                GetGameObject("algorithm" + currentAlgorithm + "_Step2").SetActive(true);
			    break;
		    case 3:
                GetGameObject("algorithm" + currentAlgorithm + "_Step3").SetActive(true);
			    break;
		    case 4:
                GetGameObject("algorithm" + currentAlgorithm + "_Step4").SetActive(true);
			    break;
		}
	}

	public void ReturnToPrevStep(int idStep)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		switch (idStep) 
		{
		    case 1:
                GetGameObject("algorithm" + currentAlgorithm + "_Step1").SetActive(false);
                GetGameObject("algorithmPanel" + currentAlgorithm).SetActive(true);
                break;
		    case 2:
                GetGameObject("algorithm" + currentAlgorithm + "_Step2").SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step1").SetActive(true);
			    break;
		    case 3:
                GetGameObject("algorithm" + currentAlgorithm + "_Step3").SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step2").SetActive(true);
			    break;
		    case 4:
                GetGameObject("algorithm" + currentAlgorithm + "_Step4").SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step3").SetActive(true);
			    break;
			case 5:
				GetGameObject("algorithm" + currentAlgorithm + "_Step5").SetActive(false);
				GetGameObject("algorithm" + currentAlgorithm + "_Step4").SetActive(true);
				break;
			case 6:
				GetGameObject("algorithm" + currentAlgorithm + "_Step6").SetActive(false);
				GetGameObject("algorithm" + currentAlgorithm + "_Step5").SetActive(true);
				break;
			case 7:
				GetGameObject("algorithm" + currentAlgorithm + "_Step7").SetActive(false);
				GetGameObject("algorithm" + currentAlgorithm + "_Step6").SetActive(true);
				break;
		}
	}
	public void NextStep(int idStep)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		switch (idStep) 
		{
		    case 1:
                GetGameObject("algorithmPanel" + currentAlgorithm).SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step1").SetActive(true);
			    break;
		    case 2:
                GetGameObject("algorithm" + currentAlgorithm + "_Step1").SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step2").SetActive(true);
			    break;
		    case 3:
                GetGameObject("algorithm" + currentAlgorithm + "_Step2").SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step3").SetActive(true);
			    break;
		    case 4:
                GetGameObject("algorithm" + currentAlgorithm + "_Step3").SetActive(false);
                GetGameObject("algorithm" + currentAlgorithm + "_Step4").SetActive(true);
			    break;
			case 5:
				GetGameObject("algorithm" + currentAlgorithm + "_Step4").SetActive(false);
				GetGameObject("algorithm" + currentAlgorithm + "_Step5").SetActive(true);
				break;
			case 6:
				GetGameObject("algorithm" + currentAlgorithm + "_Step5").SetActive(false);
				GetGameObject("algorithm" + currentAlgorithm + "_Step6").SetActive(true);
				break;
			case 7:
				GetGameObject("algorithm" + currentAlgorithm + "_Step6").SetActive(false);
				GetGameObject("algorithm" + currentAlgorithm + "_Step7").SetActive(true);
				break;

		}
	}

	#endregion

	public void redSet()
	{
		red = !red;
		if (red) 
		{
			red_button.GetComponent<Image>().sprite = red_button_sprite;
			if (blue && green) 
			{
				imageMap.GetComponent<Image> ().sprite = red_green_blue_sprite;
			} 
			else 
			{
				if (blue) 
				{
					imageMap.GetComponent<Image> ().sprite = blue_red_sprite;
				} 
				else 
				{
					if (green)
					{
						imageMap.GetComponent<Image> ().sprite = green_red_sprite;
					} 
					else 
					{
						imageMap.GetComponent<Image> ().sprite = red_sprite;
					}
				}
			}
		}
		else 
		{
			red_button.GetComponent<Image>().sprite = gray_button_sprite;
			if (!green && !blue) 
			{
				imageMap.GetComponent<Image> ().sprite = default_sprite;
			} 
			else
			{
				if (blue && green)
				{
					imageMap.GetComponent<Image> ().sprite = blue_green_sprite;
				}
				else
				{
					if (blue) 
					{
						imageMap.GetComponent<Image> ().sprite = blue_sprite;
					}
					else
					{
						imageMap.GetComponent<Image> ().sprite = green_sprite;
					}
				}
			}
		}
	}
	public void blueSet()
	{
		blue = !blue;
		if (blue) 
		{
			blue_button.GetComponent<Image>().sprite = blue_button_sprite;
			if (red && green) 
			{
				imageMap.GetComponent<Image> ().sprite = red_green_blue_sprite;
			} 
			else 
			{
				if (red) 
				{
					imageMap.GetComponent<Image> ().sprite = blue_red_sprite;
				} 
				else 
				{
					if (green)
					{
						imageMap.GetComponent<Image> ().sprite = blue_green_sprite;
					} 
					else 
					{
						imageMap.GetComponent<Image> ().sprite = blue_sprite;
					}
				}
			}
		}
		else 
		{
			blue_button.GetComponent<Image>().sprite = gray_button_sprite;
			if (!red && !green) 
			{
				imageMap.GetComponent<Image> ().sprite = default_sprite;
			} 
			else
			{
				if (red && green)
				{
					imageMap.GetComponent<Image> ().sprite = green_red_sprite;
				}
				else
				{
					if (red) 
					{
						imageMap.GetComponent<Image> ().sprite = red_sprite;
					}
					else
					{
						imageMap.GetComponent<Image> ().sprite = green_sprite;
					}
				}
			}
		}

	}
	public void greenSet()
	{
		green = !green;
		if (green) 
		{
			green_button.GetComponent<Image>().sprite = green_button_sprite;
			if (blue && red) 
			{
				imageMap.GetComponent<Image> ().sprite = red_green_blue_sprite;
			} 
			else 
			{
				if (blue) 
				{
					imageMap.GetComponent<Image> ().sprite = blue_green_sprite;
				} 
				else 
				{
					if (red)
					{
						imageMap.GetComponent<Image> ().sprite = green_red_sprite;
					} 
					else 
					{
						imageMap.GetComponent<Image> ().sprite = green_sprite;
					}
				}
			}
		}
		else 
		{
			green_button.GetComponent<Image>().sprite = gray_button_sprite;
			if (!red && !blue) 
			{
				imageMap.GetComponent<Image> ().sprite = default_sprite;
			} 
			else
			{
				if (blue && red)
				{
					imageMap.GetComponent<Image> ().sprite = blue_red_sprite;
				}
				else
				{
					if (blue) 
					{
						imageMap.GetComponent<Image> ().sprite = blue_sprite;
					}
					else
					{
						imageMap.GetComponent<Image> ().sprite = red_sprite;
					}
				}
			}
		}

	}

    GameObject GetGameObject(string name)
    {
        var field = GetType().GetField(name);
        if (field == null)
            return null;
        return field.GetValue(this) as GameObject;
    }
		
}
