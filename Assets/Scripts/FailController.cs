using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailController : MonoBehaviour
{
    public GameObject failPanel;
   public void OpenFailPanel()
    {
        failPanel.SetActive(true);
    }

    public void OnClickRetryButton() {
        if (GameManager.Instance.difficulty == GameManager.DIFFICULTY.easy)
        {
            SceneManager.LoadScene(0);
        }
        else if (GameManager.Instance.difficulty == GameManager.DIFFICULTY.medium)
        {
            SceneManager.LoadScene("MediumScene", LoadSceneMode.Single);
        }
        else {
            SceneManager.LoadScene("HardScene", LoadSceneMode.Single);
        }

    }

    public void OnClickMenuButton() {
        SceneManager.LoadScene(0);
    }
}
