using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class Sudoku : MonoBehaviour
{

    public Sprite[] arrayOfSprites;
    public TextMeshProUGUI infoText;
    public GameObject nextButton;
    public GameObject previewImage;

    private int counter = 1;

    // Use this for initialization
    void Start()
    {
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { OnNextButtonClicked(1); });
        counter++;
    }

    public void OnNextButtonClicked(int nextImage)
    {
        previewImage.GetComponent<Image>().sprite = arrayOfSprites[nextImage - 1];
                
        int tmpCounter = counter;
        counter++;
        nextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { OnNextButtonClicked(tmpCounter); });

        switch (nextImage)
        {
            case 1:
                infoText.text = "Korak1";
                break;
            case 2:
                infoText.text = "Korak2";
                break;
                ///....
        }
        
    }
}
