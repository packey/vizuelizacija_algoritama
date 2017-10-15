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
    public float frameDurationInMS = 150f;

    private int counter = 0;
    private float frameDurationInS;

    // Use this for initialization
    void Start()
    {
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { OnNextButtonClicked(0); });
        frameDurationInS = frameDurationInMS * 0.001f;
    }

    public void OnNextButtonClicked(int nextImage)
    {
        previewImage.GetComponent<Image>().sprite = arrayOfSprites[nextImage];
                
        counter++;
        nextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { OnNextButtonClicked(counter); });

        switch (nextImage)
        {
            case 0:
                counter--;
                infoText.text = "Algoritam pokusava da dodje do resenja.";
                StartCoroutine(chageImagePartI());
                break;
            case 9:
                infoText.text = "Algoritam se zbog greske vratio na pocetak i sada krece iz pocetka sa novom predpostavkom.";
                break;
            case 10:
                counter--;
                infoText.text = "Algoritam pokusava da dodje do resenja. Tako da uvek kada nema moguce resenje vrace se unazad i pokusava sa novom predpostavkom.";
                StartCoroutine(chageImagePartII());
                break;
                ///....
        }
        
    }

    public IEnumerator chageImagePartI()
    {

        nextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        while (true)
        {
            
            if (counter == 0)
            {
                counter++;
                yield return new WaitForSeconds(frameDurationInS);
            }
            else if (counter <  8)
            {
                previewImage.GetComponent<Image>().sprite = arrayOfSprites[counter];
                counter++;
                yield return new WaitForSeconds(frameDurationInS);
            }
            else
            {
                previewImage.GetComponent<Image>().sprite = arrayOfSprites[counter];
                infoText.text = "Kod ovog koraka algoritam dolazi u situaciju da nema moguce resenje za sledece polje, pa se vraca unazad.";
                counter++;
                nextButton.GetComponent<Button>().onClick.AddListener(delegate { OnNextButtonClicked(counter); });
                break;
            }
        }
    }

    public IEnumerator chageImagePartII()
    {

        nextButton.GetComponent<Button>().onClick.RemoveAllListeners();
        while (true)
        {

            if (counter == 10)
            {
                counter++;
                yield return new WaitForSeconds(frameDurationInS);
            }
            else if (counter < 125)
            {
                previewImage.GetComponent<Image>().sprite = arrayOfSprites[counter];
                counter++;
                yield return new WaitForSeconds(frameDurationInS);
            }
            else
            {
                previewImage.GetComponent<Image>().sprite = arrayOfSprites[counter];
                infoText.text = "Algoritam je dosao do resenja.";
                break;
            }
        }
    }
}
