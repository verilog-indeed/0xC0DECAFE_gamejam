using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManagerScript : MonoBehaviour
{
    [SerializeField] GameObject PressAnyKeyGO; //UI First Menu
    [SerializeField] GameObject MainMenuGO;
    [SerializeField] GameObject OptionMenu;


    // Start is called before the first frame update
    void Start()
    {
        MainMenuGO.SetActive(false);
        OptionMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey && PressAnyKeyGO.activeInHierarchy)
        {
            PressAnyKeyGO.SetActive(false);
            MainMenuGO.SetActive(true);
        }
    }
    void MenuHandler()
    {

    }
    public void Continue()
    {
        Time.timeScale = 1;
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }
    public void Options()
    {
        MainMenuGO.SetActive(false);
        OptionMenu.SetActive(true);
    }
    public void Quit()
    {
        Quit();
    } public void AnyKey()
    {
        
    }
    public void Return()
    {
        OptionMenu.SetActive(false);
        MainMenuGO.SetActive(true);
    }
}
