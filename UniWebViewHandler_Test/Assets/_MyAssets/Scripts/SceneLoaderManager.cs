using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderManager : Singleton<SceneLoaderManager>
{
    //the build index of the scene which the game realy start with.
    //scenes like: Main Menu, level1, ...
    const int firstBuildSceneIndex = 0;

    const int firstGameSceneIndex = 0;

    [SerializeField] float defaultWaitingTime = 3.5f;

    int LastBuildSceneIndex
    {
        get
        {
            return SceneManager.sceneCountInBuildSettings - 1;
        }
    }

    Scene CurrentScene
    {
        get
        {
            return SceneManager.GetActiveScene();
        }
    }

    Scene firstSceneThisGameObjectWasLoaded;

    // Start is called before the first frame update
    void Start()
    {
        firstSceneThisGameObjectWasLoaded = CurrentScene;
    }

    // Update is called once per frame
    void Update()
    {

    }

    #region Basic Functionality

    public void FirstScene()
    {
        SceneManager.LoadScene(firstBuildSceneIndex);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(firstGameSceneIndex);
    }

    public void NextScene()
    {
        int nextScenebuildIndex = CurrentScene.buildIndex + 1;
        if (nextScenebuildIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextScenebuildIndex);
        }
        else
        {
            //TODO: decision what the game loop is, or fined another resolution!!
        }
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(CurrentScene.buildIndex);
    }

    public void PreviousScene()
    {
        SceneManager.LoadScene(CurrentScene.buildIndex - 1);
    }

    public void LastScene()
    {
        SceneManager.LoadScene(LastBuildSceneIndex);
    }

    #endregion

    #region Advance Functionality

    //ToDo: Write more overloads to this methods 
    public void WaitAndLoadScene(string sceneToLoad, float timeToWait = 0)
    {
        StartCoroutine(WaitAndLoadSceneRoutine(sceneToLoad, timeToWait));
    }

    private IEnumerator WaitAndLoadSceneRoutine(string sceneToLoad, float givenWaitingTime = 0)
    {
        //Wait
        if (givenWaitingTime > 0)
        {
            yield return new WaitForSeconds(givenWaitingTime);
        }
        else
        {
            yield return new WaitForSeconds(defaultWaitingTime);
        }

        //Load Scene
        LoadByKey(sceneToLoad);

    }

    #endregion

    #region Spesifice Functionality

    public void LoadByIndex(int sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadByName(string sceneToLoad)
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    public void LoadByKey(string sceneToLoad)
    {
        switch (sceneToLoad)
        {
            case "First":
                FirstScene();
                break;
            case "RestartGame":
                RestartGame();
                break;
            case "Next":
                NextScene();
                break;
            case "Reset":
                ResetScene();
                break;
            case "Previous":
                PreviousScene();
                break;
            case "Last":
                LastScene();
                break;
            default:
                Debug.LogError("Wrong Load Action Key / Scene Name To Load!!!!!");
                break;
        }
    }

    #endregion


}
