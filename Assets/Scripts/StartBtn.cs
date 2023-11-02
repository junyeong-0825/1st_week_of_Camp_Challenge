using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartBtn : MonoBehaviour
{
    public AudioClip clicksound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame()
    {
        audioSource.PlayOneShot(clicksound);
        SceneManager.LoadScene("MainScene");
    }
}
