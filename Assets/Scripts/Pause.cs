using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&&Time.timeScale!=0)
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
        }
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
    }
    public void Again()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("DUTparkour");
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
