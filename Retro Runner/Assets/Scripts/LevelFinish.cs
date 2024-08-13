 using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelFinish : MonoBehaviour
{
    private AudioSource finishsound;
    private bool levelCompleted = false;
    // Start is called before the first frame update

    private void Start()
    {
        finishsound = GetComponent<AudioSource>();
    }
private void OnTriggerEnter2D(Collider2D collision)
{   
    if(collision.gameObject.name == "Player" && !levelCompleted)
    {
    finishsound.Play();
    levelCompleted = true;
    Invoke("CompleteLevel", 2f);
    
    }

}
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}

