using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public int Counter;
    public TextMeshProUGUI Text;
    public AudioClip Second, End;
    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        StartCoroutine(DisplayTimer());
    }

    IEnumerator DisplayTimer()
    {
        while (Counter > 0)
        {
            yield return null;
            Text.text = Counter.ToString();
            _audioSource.PlayOneShot(Second);
            yield return new WaitForSeconds(1f);
            Counter--;
        }

        Text.text = "You Won!!";
        _audioSource.PlayOneShot(End);
        yield return new WaitForSeconds(2f);
        Text.gameObject.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
