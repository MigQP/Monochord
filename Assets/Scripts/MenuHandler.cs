using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    public void LoadScene(string sceneToLoad)
    {
        //SceneManager.LoadScene(sceneToLoad);
        StartCoroutine(Fade(sceneToLoad));
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame()
    {
        Debug.Log("Salió");
        Application.Quit();
        
    }

    IEnumerator Fade(string scene)
    {
      
            yield return new WaitForSeconds(3);
            SceneManager.LoadScene(scene);

    }
}
