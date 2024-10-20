using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinNiveau : MonoBehaviour
{
    public GameObject key;
    public string levelToLoad;

    public static FinNiveau instance;

    public AudioClip nextSound;
    private void Awake()
    {
        instance = this;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.instance.PlayClipAt(nextSound, transform.position);
        if (collision.transform.CompareTag("Player") && Clé.instance.keyfalse == false)
        {
            SceneManager.LoadScene(levelToLoad);
        }
    }
    public IEnumerator LoadNextScene() 
    {
        LoadAndSaveData.instance.SaveData();
        yield return new WaitForSeconds(1f);

    }
}
