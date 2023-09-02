using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiSceneController : MonoBehaviour 
{
    //public string uiScene; 
    public string gameplayScene;

    public OVRInput.Touch Touch { get; } // novo
    public OVRInput.Button Button { get; }

    public void Update()
    {
        if (OVRInput.Get(OVRInput.Button.Two, OVRInput.Controller.RTouch))//(Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }


    public void LoadFirstLevel()
    {
        SceneManager.LoadSceneAsync("Level01");

        SceneManager.LoadSceneAsync(gameplayScene, LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync(uiScene, LoadSceneMode.Additive);
    }

    public void LoadNextLevel()
    {
        var activeName = SceneManager.GetActiveScene().name;

        int sceneId = (int.Parse(activeName.Split('0')[1]) + 1);

        

        var next = "Level0" + sceneId;

        if (sceneId > 2)
        {
            next = "TitleScreen";
        }

        Unload(activeName);

        LoadLevel(next);

    }

    private void Unload(string name)
    {
        SceneManager.UnloadSceneAsync(name);
        SceneManager.UnloadSceneAsync(gameplayScene);
        //SceneManager.UnloadSceneAsync(uiScene);
    }

    public void Reload()
    {
        var active = SceneManager.GetActiveScene();
        LoadLevel(active.name);

    }

    private void LoadLevel(string level)
    {

        SceneManager.LoadSceneAsync(level);

        if (level == "TitleScreen") return;

        SceneManager.LoadSceneAsync(gameplayScene, LoadSceneMode.Additive);
        //SceneManager.LoadSceneAsync(uiScene, LoadSceneMode.Additive);
    }

    public void LoadMenu()
    {
        SceneManager.LoadSceneAsync("TitleScene");
    }


}
