using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]private TMP_Text mainText;
    
    [SerializeField]private GameObject dropdownGameObject;
    private TMP_Dropdown dropdown;

    [HideInInspector]public enum Chapters{Title,Content,C01,C02,C03,C04,Cepilogue};
    private Chapters chapters=Chapters.Title;

    private bool backToContent=true;
    private int chapterLog=0;

    private void Start()
    {
        dropdown=dropdownGameObject.GetComponent<TMP_Dropdown>();    
    }

    private void Update()
    {
        ChapterSwitch();
    }

    private void ChapterSwitch(){
        switch(chapters){
			case Chapters.Title:
				mainText.text = "Harmony";
				BackToContent();
				break;

			case Chapters.Content:
                mainText.text="Content";
                dropdownGameObject.SetActive(true);
                break;

            case Chapters.C01:
                mainText.text="I have a story to tell.\nThe Story of a Failure.\nThe Story of a Defector.\nIn other words, me.";
                BackToContent();
                break;

            case Chapters.C02:
                mainText.text="I'm sorry, Miach.";
                BackToContent();
                break;

            case Chapters.C03:
                mainText.text="It was cloudy in this city that day.\nThis city being the capital of Japan.\nThe clouds hung heavy, gray lumps in the sky over the city,waiting to crush the people who braved the streets.\nOr maybe I was seeing symbolism in everything due to shock.";
                BackToContent();
                break;

            case Chapters.C04:
                mainText.text="The three of us were sitting on a rooftop, each with our own lunch.";
                BackToContent();
                break;

            case Chapters.Cepilogue:
                mainText.text="This is the last day of human consciousness.\nThe day that several billion “me”s ceased to exist.\nThis text is a story written from the viewpoint of one of the Homo sapiens involved with these events.";
                BackToContent();
                break;

            default:
                break;
        }
    }

	private void BackToContent()
	{
		dropdownGameObject.SetActive(false);
		if (Input.GetKeyUp(KeyCode.Mouse0) && backToContent) {
			chapters = Chapters.Content;
			backToContent = false;
		}
	}

	private void BackToContentEqualsTrue(){
        backToContent=true;
    }

    //Triggered when the selection of chapters in the dropdown UI is changed
    public void ChapterSelection(int val){
        switch(val){
            case 1:
                chapters=Chapters.C01;
                if(chapterLog==0){
                    chapterLog=1;
                    dropdown.options.Add(new TMP_Dropdown.OptionData("A Warm Place",null));
                }
                Invoke("BackToContentEqualsTrue",1);
                break;

            case 2:
                chapters=Chapters.C02;
                if(chapterLog==1){
                    chapterLog=2;
                    dropdown.options.Add(new TMP_Dropdown.OptionData("Me, I'm Not",null));
                }
                Invoke("BackToContentEqualsTrue",1);
                break;

            case 3:
                chapters=Chapters.C03;
                if(chapterLog==2){
                    chapterLog=3;
                    dropdown.options.Add(new TMP_Dropdown.OptionData("The Day The World Went Away",null));
                }
                Invoke("BackToContentEqualsTrue",1);
                break;

            case 4:
                chapters=Chapters.C04;
                if(chapterLog==3){
                    chapterLog=4;
                    dropdown.options.Add(new TMP_Dropdown.OptionData("In This Twilight",null));
                }
                Invoke("BackToContentEqualsTrue",1);
                break;

            case 5:
                chapters=Chapters.Cepilogue;
                Invoke("BackToContentEqualsTrue",1);
                break;

            default:
                break;
        }
    }
}
