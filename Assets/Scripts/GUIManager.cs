using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GUIManager : MonoBehaviour {

    private int currentAlgorithm = -1;

	bool red=false, blue=false ,green=false;

	public static bool option1,option2;

	[Header("Maps Sprites")]
	public Image imageMap;
	public Image imageMapStep1;
	public Image imageMapStep2;
	public Image imageMapStep3;
	public Sprite red_sprite;
	public Sprite blue_sprite;
	public Sprite green_sprite;
	public Sprite blue_red_sprite;
	public Sprite blue_green_sprite;
	public Sprite green_red_sprite;
	public Sprite red_green_blue_sprite;
	public Sprite default_sprite;
	public Sprite WA_red;
	public Sprite WA_green;
	public Sprite WA_blue;

	[Header("Maps Sprites Full")]
	public Sprite maps1; 	//WA=crvena, NT=zelena, SA=plava, Q=crvena, NSW=zelena, V=crvena, T=zelena
	public Sprite maps2;	//WA=crvena, NT=plava, SA=zelena, Q=crvena, NSW=plava, V=crvena, T=plava
	public Sprite maps3;	//WA=zelena, NT=crvena, SA=plava, Q=zelena, NSW=crvena, V=zelena, T=crvena
	public Sprite maps4;	//WA=zelena, NT=plava, SA=crvena, Q=zelena, NSW=plava, V=zelena, T=plava
	public Sprite maps5;	//WA=plava, NT=zelena, SA=crvena, Q=plava, NSW=zelena, V=plava, T=zelena
	public Sprite maps6;	//WA=plava, NT=crvena, SA=zelena, Q=plava, NSW=crvena, V=plava, T=crvena

	[Header("WA")]
	public Sprite WA_red_NT_green_SA_blue;
	public Sprite WA_red_NT_blue_SA_green;
	public Sprite WA_green_NT_red_SA_blue;
	public Sprite WA_green_NT_blue_SA_red;
	public Sprite WA_blue_NT_green_SA_red;
	public Sprite WA_blue_NT_red_SA_green;

	public GameObject optionInfo;

	[Header("Maps Elements")]
	public Toggle redColor;
	public Toggle greenColor;
	public Toggle blueColor;

	public Button option1_button;
	public Button option2_button;

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
		if (algorithm1_Step5.activeSelf)
		{
			if (redColor.isOn) 
			{
				imageMapStep1.GetComponent<Image> ().sprite = WA_red;
			} 
			else if (greenColor.isOn) 
			{
				imageMapStep1.GetComponent<Image> ().sprite = WA_green;
			} 
			else 
			{
				imageMapStep1.GetComponent<Image> ().sprite = WA_blue;
			}
		}
		if (option1) 
		{
			option1_button.GetComponent<Image> ().sprite = blue_button_sprite;
			option2_button.GetComponent<Image> ().sprite = gray_button_sprite;
		}
		if (option2)
		{
			option1_button.GetComponent<Image> ().sprite = gray_button_sprite;
			option2_button.GetComponent<Image> ().sprite = blue_button_sprite;
		}
		if (!option1 && !option2)
		{
			option1_button.GetComponent<Image> ().sprite = gray_button_sprite;
			option2_button.GetComponent<Image> ().sprite = gray_button_sprite;
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
		
	public void coloringMapStep2()
	{
		
		GetGameObject("algorithm" + currentAlgorithm + "_Step5").SetActive(false);
		GetGameObject("algorithm" + currentAlgorithm + "_Step6").SetActive(true);

		if (redColor.isOn) 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_red;
		} 
		else if (greenColor.isOn) 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_green;
		} 
		else 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_blue;
		}
		option1 = false;
		option2 = false;
	}

	public void coloringMapStep3()
	{
		if (option1 || option2) 
		{
			GetGameObject("algorithm" + currentAlgorithm + "_Step6").SetActive(false);
			GetGameObject("algorithm" + currentAlgorithm + "_Step7").SetActive(true);
			if (redColor.isOn) 
			{
				if (option1) 
				{
					imageMapStep3.GetComponent<Image> ().sprite = WA_red_NT_green_SA_blue;
				} else 
				{
					imageMapStep3.GetComponent<Image> ().sprite = WA_red_NT_blue_SA_green;
				}
			}
			else if (greenColor.isOn)
			{
				if (option1) 
				{
					imageMapStep3.GetComponent<Image> ().sprite = WA_green_NT_red_SA_blue;
				} 
				else
				{
					imageMapStep3.GetComponent<Image> ().sprite = WA_green_NT_blue_SA_red;
				}
			}
			else
			{
				if (option1)
				{
					imageMapStep3.GetComponent<Image> ().sprite = WA_blue_NT_green_SA_red;
				}
				else
				{
					imageMapStep3.GetComponent<Image> ().sprite = WA_blue_NT_red_SA_green;
				}
			}
		}
		else
		{
			optionInfo.SetActive (true);
		}
	}

	public void coloringMapFull()
	{
		if (redColor.isOn) 
		{
			if (option1) 
			{
				imageMapStep3.GetComponent<Image> ().sprite = maps1; //1
			} else 
			{
				imageMapStep3.GetComponent<Image> ().sprite = maps2; //2
			}
		}
		else if (greenColor.isOn)
		{
			if (option1) 
			{
				imageMapStep3.GetComponent<Image> ().sprite = maps3; //3
			} 
			else
			{
				imageMapStep3.GetComponent<Image> ().sprite = maps4; //4
			}
		}
		else
		{
			if (option1)
			{
				imageMapStep3.GetComponent<Image> ().sprite = maps5; //5
			}
			else
			{
				imageMapStep3.GetComponent<Image> ().sprite = maps6; //6
			}
		}
	}

	public void backToHome()
	{
		SceneManager.LoadScene("start_menu");
	}

	public void closeOptionInfo()
	{
		optionInfo.SetActive (false);
	}


	public void option1MapStep2()
	{
		option1 = true;
		option2 = false;
		if (redColor.isOn) 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_red_NT_green_SA_blue;
		} 
		else if (greenColor.isOn) 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_green_NT_red_SA_blue;
		} 
		else 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_blue_NT_green_SA_red;
		}
	}
	public void option2MapStep2()
	{
		option1 = false;
		option2 = true;
		if (redColor.isOn) 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_red_NT_blue_SA_green;
		} 
		else if (greenColor.isOn) 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_green_NT_blue_SA_red;
		} 
		else 
		{
			imageMapStep2.GetComponent<Image> ().sprite = WA_blue_NT_red_SA_green;
		}
	}
		
}
