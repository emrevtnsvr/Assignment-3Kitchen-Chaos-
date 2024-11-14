using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MediumButton : MonoBehaviour
{
    public void OnClickMediumButton()

    {
        SceneManager.LoadScene("MediumScene", LoadSceneMode.Single);
    }

}