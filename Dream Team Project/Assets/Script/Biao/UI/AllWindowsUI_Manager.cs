using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllWindowsUI_Manager : MonoBehaviour {

    //public float defaultAlphaVal_color = 0.5f;
    public string UIText_Name = "Windows_Text";
    public string UIBackground_Name = "Windows_Background";

    public GameObject UI_Text;
    public GameObject UI_Background;

    //public GameObject[] AllUis_List;

    //public UIManagerList_Format[] UiManagersList;

    public int numUis = 15;
    public GameObject[] allUis_List_Auto;

	void Awake () {
        //UI_Text = this.transform.Find(UIText_Name).gameObject;
        //UI_Background = this.transform.Find(UIBackground_Name).gameObject;

        allUis_List_Auto = new GameObject[numUis];

        int tempI = 0;
        int skipFirst_Two = 0;
        //get all the child to the list
        foreach(Transform child in transform)
        {

            //I don't want to disable text and background for some reason
            if(skipFirst_Two < 2)
            {
                skipFirst_Two++;
                continue;
            }
            allUis_List_Auto[tempI] = child.gameObject;
            tempI++;
        }
	}


    public void DisableUIText()
    {
        //UI_Text.SetActive(false);
        UI_Text.GetComponent<Text>().text = "";
    }

    public void EnableUIText()
    {
        UI_Text.SetActive(true);
    }

    public void DisableUIBackground()
    {
        //UI_Background.SetActive(false);
        Color oldColor = UI_Background.GetComponent<Image>().color;
        UI_Background.GetComponent<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, 0);
    }

    public void EnableUIBackground(float alphaVal=0.5f)
    {
        //UI_Background.SetActive(true);
        Color oldColor = UI_Background.GetComponent<Image>().color;
        UI_Background.GetComponent<Image>().color = new Color(oldColor.r, oldColor.g, oldColor.b, alphaVal);
    }

    public void SetUITextAs(string textTemp)
    {
        UI_Text.GetComponent<Text>().text = textTemp;
        //Debug.Log("heard that ");
    }


    public void CleanCanvas()
    {
        DisableAllUI_Except("");
    }

    public void DisableAllUI_Except(string nameTemp)
    {
        DisableUIText();
        DisableUIBackground();

        for(int i = 0; i < allUis_List_Auto.Length; i++)
        {

            if(allUis_List_Auto[i] == null)
            {
                break;
            }

            //I will keep the timer for now
            if(allUis_List_Auto[i].name == "TimeWindow_Text")
            {
                continue;
            }
            if(allUis_List_Auto[i].name == nameTemp)
            {
                Debug.Log("skipped " + nameTemp);
                continue;
            }
            if (allUis_List_Auto[i].activeSelf)
            {
                allUis_List_Auto[i].SetActive(false);
            }

        }
    }










}
