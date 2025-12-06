using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1;
    public bool opened = false;
    
    public int minInclusive = 0, maxExclusive = 0;
    int currentScene = 0;
    int randomLevel = 0;

    // Update is called once per frame
    void Update()
    {
        if (opened)
        {
            randomLevel = Random.Range(minInclusive, maxExclusive);
            currentScene = SceneManager.GetActiveScene().buildIndex;
            
            if (randomLevel != currentScene)
            {
                LoadNextLevel();
            }

            while (randomLevel == currentScene)
            {
                randomLevel = Random.Range(minInclusive, maxExclusive);

                if (randomLevel != currentScene)
                    LoadNextLevel();
            }
        }
    }


    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(randomLevel));
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
