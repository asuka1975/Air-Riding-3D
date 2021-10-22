using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitioner
{
    public static IEnumerator Transition<T>(string scene, T param)
    {
        var sharedParams = GameObject.FindWithTag("SharedParams");
        sharedParams.GetComponent<SharedParams>().Set(param);
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

        // Wait until the last operation fully loads to return anything
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        SceneManager.MoveGameObjectToScene(sharedParams, SceneManager.GetSceneByName(scene));
        SceneManager.UnloadSceneAsync(SceneManager.GetActiveScene());
    }
}
