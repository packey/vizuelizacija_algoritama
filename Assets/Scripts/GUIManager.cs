using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GUIManager : MonoBehaviour {

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
	public GameObject algorithm1_Step4; 						// Algorithm 1 step 4



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
		switch (idAlgorithm) 
		{
			case 1:
				algorithmPanel1.SetActive (true);
				break;
			case 2:
				algorithmPanel2.SetActive (true);
				break;
			case 3:
				algorithmPanel3.SetActive (true);
				break;
			case 4:
				algorithmPanel4.SetActive (true);
				break;
		}
	}

	public void ReturnToChoosePanel()
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		algorithmPanel1.SetActive (false);
		ActivatePanel(false, true, false, false);
	}

	public void ActiveAlorithmStep(int idStep)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		switch (idStep) 
		{
		case 1:
			algorithm1_Step1.SetActive (true);
			break;
		case 2:
			algorithm1_Step2.SetActive (true);
			break;
		case 3:
			algorithm1_Step3.SetActive (true);
			break;
		case 4:
			algorithm1_Step4.SetActive (true);
			break;
		}
	}

	public void ReturnToPrevStep(int idStep)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		switch (idStep) 
		{
		case 1:
			algorithm1_Step1.SetActive (false);
			algorithmPanel1.SetActive (true);
			break;
		case 2:
			algorithm1_Step2.SetActive (false);
			algorithm1_Step1.SetActive (true);
			break;
		case 3:
			algorithm1_Step3.SetActive (false);
			algorithm1_Step2.SetActive (true);
			break;
		case 4:
			algorithm1_Step4.SetActive (false);
			algorithm1_Step3.SetActive (true);
			break;
		}
	}
	public void NextStep(int idStep)
	{
		SoundManager.instance.PlaySound(SoundManager.instance.clickSound);
		switch (idStep) 
		{
		case 1:
			algorithmPanel1.SetActive (false);
			algorithm1_Step1.SetActive (true);
			break;
		case 2:
			algorithm1_Step1.SetActive (false);
			algorithm1_Step2.SetActive (true);
			break;
		case 3:
			algorithm1_Step2.SetActive (false);
			algorithm1_Step3.SetActive (true);
			break;
		case 4:
			algorithm1_Step3.SetActive (false);
			algorithm1_Step4.SetActive (true);
			break;
		}
	}

	#endregion
}
