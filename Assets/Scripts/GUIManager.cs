using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    private int currentAlgorithm = -1;

	bool red=false, blue=false ,green=false;

	public Image imageMap;
	public Sprite red_sprite;
	public Sprite blue_sprite;
	public Sprite green_sprite;
	public Sprite blue_red_sprite;
	public Sprite blue_green_sprite;
	public Sprite green_red_sprite;
	public Sprite red_green_blue_sprite;
	public Sprite default_sprite;



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

    [Header("Algorithm 2 steps")]
    public GameObject algorithm2_Step1;                         // Algorithm 2 step 1
    public GameObject algorithm2_Step2;                         // Algorithm 2 step 2
    public GameObject algorithm2_Step3;                         // Algorithm 2 step 3
    public GameObject algorithm2_Step4;                         // Algorithm 2 step 4

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
		//switch (idAlgorithm) 
		//{
		//	case 1:
		//		algorithmPanel1.SetActive (true);
		//		break;
		//	case 2:
		//		algorithmPanel2.SetActive (true);
		//		break;
		//	case 3:
		//		algorithmPanel3.SetActive (true);
		//		break;
		//	case 4:
		//		algorithmPanel4.SetActive (true);
		//		break;
		//}
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
		}
	}

	#endregion

	public void redSet()
	{
		red = !red;
		if (red) 
		{
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
