using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    [Header("General Panel")]
    [SerializeField] GameObject GeneralPanel;



    [Header("Settings Panel")]
    [SerializeField] GameObject SettingsPanel;

    [Header("Pause Panel")]
    public GameObject PausePanel;

    [Header("Fail Panel")]
    [SerializeField] GameObject FailPanel;
    [SerializeField] TMP_Text ScoreFail;

   
    [Header("Home Panel")]
    public GameObject HomePanel;
    public GameObject Button;
    public GameObject Play;
    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }

    private void Start() {

        PlayerController.instance.moveSpeed= 0;
        HomePanel.SetActive(true);
        Button.transform.DOScale(1.25f, 1).SetLoops(-1, LoopType.Yoyo);
        Play.transform.DORotate(new Vector3(0, 0, -1.5f), 1).SetLoops(-1, LoopType.Yoyo);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            // OpenSettingsPanel();
            OpenFailPanel();
        }
      
        if (Input.GetKeyDown(KeyCode.A)) {
            CloseFailPanel();
        }
       
    }

    public void OpenGeneralPanel() {
        GeneralPanel.SetActive(true);
    }

    public void CloseGeneralPanel() {
        GeneralPanel.SetActive(false);
    }


    public void OpenPausePanel()
    {
        PausePanel.SetActive(true);
        PausePanel.transform.localScale = Vector3.zero;
        PausePanel.transform.DOScale(1f, 0.2f).OnComplete(() =>
        {
            PlayerController.instance.moveSpeed = 0;
            PlayerController.instance.anim.SetBool("Idle",true);
        });
    }

    public void ClosePausePanel()
    {
        PausePanel.transform.DOScale(0f, 0.2f).OnComplete(() => {
            PausePanel.SetActive(false);
            PlayerController.instance.moveSpeed = 11;
            PlayerController.instance.anim.SetBool("Idle",false);


        });
    }
    public void OpenHomePanel() {

    }

   

    public void OpenSettingsPanel() {
        SettingsPanel.SetActive(true);
        SettingsPanel.transform.localScale = Vector3.zero;
        SettingsPanel.transform.DOScale(0.5f, 0.2f);
    }

    public void CloseSettingsPanel() {
        SettingsPanel.transform.DOScale(0f, 0.2f).OnComplete(() => {
            SettingsPanel.SetActive(false);
            
        });
    }


    public void OpenFailPanel() {
        FailPanel.SetActive(true);
        FailPanel.transform.localScale = Vector3.zero;
        FailPanel.transform.DOScale(1f, 0.2f).OnComplete(() =>
        {
            ScoreFail.text = PlayerController.instance.scoreCount.ToString();
            Time.timeScale = 0f;
        });
    }

    public void CloseFailPanel() {
        FailPanel.transform.DOScale(0f,0.2f).OnComplete(()=>{
            FailPanel.SetActive(false);
        });
    }

    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Resume()
    {

    }
    public void CloseHomePanel()
    {
        HomePanel.SetActive(false); 
        PlayerController.instance.moveSpeed = 11f;

    }
}
