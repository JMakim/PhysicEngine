using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour {

    public void startGame()
    {
        SceneManager.LoadScene("_Scene/main");
    }

    public void endGame()
    {
        Application.Quit();
    }
}
