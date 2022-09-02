using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    [SerializeField] GameObject PauseMenuGO;
    [SerializeField] GameObject OptionsMenu;
    [SerializeField] GameObject ControlsPanelGO;



    // Start is called before the first frame update
    void Start()
    {
        PauseMenuGO.SetActive(false);
        OptionsMenu.SetActive(false);
        ControlsPanelGO.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.Escape)|| Input.GetKeyDown(KeyCode.P))&& !PauseMenuGO.activeInHierarchy)
        {
            Pause();
        }
        else if((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && PauseMenuGO.activeInHierarchy)
        {
            UnPause();
        }
    }
    public void Pause()
    {
        PauseMenuGO.SetActive(true);
        OptionsMenu.SetActive(false);
        ControlsPanelGO.SetActive(false);
        Time.timeScale = 0;
    }
    public void UnPause()
    {
        PauseMenuGO.SetActive(false);
        OptionsMenu.SetActive(false);
        ControlsPanelGO.SetActive(false);
        Time.timeScale = 1;
    }
    public void OptionMenu()
    {
        PauseMenuGO.SetActive(false);
        OptionsMenu.SetActive(true);
    }
    public void Return()
    {
        PauseMenuGO.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void MainMunu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void Controls()
    {
        ControlsPanelGO.SetActive(true);
        OptionsMenu.SetActive(false);
    }
    public void ControlsReturn()
    {
        ControlsPanelGO.SetActive(false);
        OptionsMenu.SetActive(true);
    }
}
