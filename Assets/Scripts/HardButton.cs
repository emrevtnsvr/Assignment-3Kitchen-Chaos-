using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardButton : MonoBehaviour
{
    public void OnClickHardButton()

    {
        SceneManager.LoadScene("HardScene", LoadSceneMode.Single);
    }

}