using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsControl : MonoBehaviour
{
    //[SerializeField] Slider soundBar;
    //[SerializeField] static Slider musicBar;


    //GameObject settingMenu;
    GameObject mainMenu;

    private void Awake()
    {
        //settingMenu = GameObject.Find("SettingsMenu");
        mainMenu = GameObject.Find("MainCanvas");

        //settingMenu.SetActive(false);


    }
    void Update()
    {
        SetVolume();
    }

    void SetVolume()
    {
        

        //PlayerPrefs.SetFloat("soundValue", soundBar.value);
        //PlayerPrefs.SetFloat("musicValue", musicValue);
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        //settingMenu.SetActive(true);
    }

    public void CloseSettings()
    {
        mainMenu.SetActive(true);
        //settingMenu.SetActive(false);
    }
}
