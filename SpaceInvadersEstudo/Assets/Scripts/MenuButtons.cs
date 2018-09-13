using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
public class MenuButtons : MonoBehaviour {
    
    public Text record;
    public Button btnStart;
    public Button btnRestart;
    public Button btnQuit;
    public GameObject dirGO;
    public GameObject fireGO;
    Image dirJS;
    Image fireBTN;
    

    void Start()
    {
        
        Time.timeScale = 0;
        dirJS = dirGO.GetComponent<Image>();
        fireBTN = fireGO.GetComponent<Image>();
    }

    public void onDeath()
    {
        Time.timeScale = 0;
        SceneManager.LoadScene("GameScene");
    }

    
   
    
    public void startButton()
    {
        btnStart.gameObject.SetActive(false);
        btnQuit.gameObject.SetActive(false);
        btnRestart.gameObject.SetActive(false);
        dirJS.enabled = true;
        fireBTN.enabled = true;
        record.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }

    public void quitButton()
    {
        Application.Quit();
    }

    
}
