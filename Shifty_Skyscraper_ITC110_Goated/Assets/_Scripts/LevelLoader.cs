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
    int sceneCount = 0;
    int randomLevel = 0;
    
    void FixedUpdate()
    {  
        if (opened)
        {
            randomLevel = Random.Range(minInclusive, maxExclusive);
            currentScene = SceneManager.GetActiveScene().buildIndex;

            StaticData.Levels[StaticData.visited++] = currentScene;
            
            
            for (int i = 0; i < StaticData.visited; i++)
            {
                if (randomLevel == StaticData.Levels[i])
                {
                    i = -1;
                    randomLevel = Random.Range(minInclusive, maxExclusive);
                }
            }
            LoadNextLevel();
            opened = false;
            
            /*
            if (randomLevel != currentScene)
            {
                LoadNextLevel();
            }
            else
            {
                while (randomLevel == currentScene)
                {
                    randomLevel = Random.Range(minInclusive, maxExclusive);

                    if (randomLevel != currentScene)
                        LoadNextLevel();
                }
            }*/
        }
    }


    public void LoadNextLevel()
    {
        sceneCount++;
        StartCoroutine(LoadLevel(randomLevel));
        
    }

    IEnumerator LoadLevel (int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        if (StaticData.visited >= 4)
        {
            SceneManager.LoadScene(6);
        }
        else
        {
            SceneManager.LoadScene(levelIndex);
        }
        
    }
}
