using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Lobby : MonoBehaviour
{

    public Button TutorialBtn;
    public Button GameStartBtn;
    private void Start()
    {
        TutorialBtn.onClick.AddListener(ChangeSceneTutorial);
        GameStartBtn.onClick.AddListener(ChangeSceneGameStart);
    }

    void ChangeSceneTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    void ChangeSceneGameStart()
    {
        SceneManager.LoadScene("GameScene");
    }
}
