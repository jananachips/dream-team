using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings_WinUI_Manager : MonoBehaviour {
    public string settingsUI_Text = "Settings";


    public AllWindowsUI_Manager allWindowsUI_Manager;
    public GameObject volume_Bar;
    public GameObject pauseWindowUI_Manager;

    private void OnEnable()
    {
        allWindowsUI_Manager = FindObjectOfType<AllWindowsUI_Manager>();

        //allWindowsUI_Manager.CleanCanvas();
        allWindowsUI_Manager.DisableAllUI_Except(name);

        allWindowsUI_Manager.SetUITextAs(settingsUI_Text);

        allWindowsUI_Manager.EnableUIText();
        //1f means the value of alpha
        allWindowsUI_Manager.EnableUIBackground(0.5f);

        volume_Bar.SetActive(true);
    }

    private void OnDisable()
    {
        Debug.Log("on disable");
        //allWindowsUI_Manager.CleanCanvas();
        allWindowsUI_Manager.DisableAllUI_Except(name);

        pauseWindowUI_Manager.SetActive(true);
    }
}
