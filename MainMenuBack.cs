using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenuBack : MonoBehaviour
{
   


    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Main");
        
    }
    

}
