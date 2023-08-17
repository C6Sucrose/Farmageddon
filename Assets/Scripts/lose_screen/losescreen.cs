using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class losescreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void GotoScene(string scenename)
    {// Update is called once per frame
        SceneManager.LoadScene(scenename);
      //  Debug.Log(SceneManager.sceneCount);
    }
    void Update()
    {
        
    }
     public void Reload()
    {
        Debug.Log(farm.index);
        SceneManager.LoadScene(farm.index);
    }
    //testing
    //public void OnEnable() { SceneManager.sceneUnloaded += SceneUnloadedMethod; }
    //void OnDisable()Sce { SceneManager.sceneUnloaded -= SceneUnloadedMethod; }

    //int lastSceneIndex = -1;

    //// looks a bit funky but the method signature must match the scenemanager delegate signature
    //void SceneUnloadedMethod(Scene sceneNumber)
    //{
    //    int sceneIndex = sceneNumber.buildIndex;
    //    // only want to update last scene unloaded if were not just reloading the current scene
    //    if (lastSceneIndex != sceneIndex)
    //    {
    //        lastSceneIndex = sceneIndex;
    //        Debug.Log("unloaded scene is : " + lastSceneIndex);
    //    }
    //    GetLastSceneNumber();
    //}
    // void GetLastSceneNumber()
    //{
    //    SceneManager.GetSceneAt( lastSceneIndex);
    //}
}
