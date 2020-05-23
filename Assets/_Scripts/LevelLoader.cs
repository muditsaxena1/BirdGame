using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);
            yield return null;
        }
        Debug.Log("################################");
    }
    private int upd = 0, fupd = 0;

    private void Awake()
    {
        Debug.Log("LevelLoader - Awake");
    }

    private void OnEnable()
    {
        Debug.Log("LevelLoader - OnEnable");
    }

    void Start()
    {
        Debug.Log("LevelLoader - Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (upd != 3)
        {
            upd++;
            Debug.Log("LevelLoader - Update" + upd);
        }

    }

    private void FixedUpdate()
    {
        if (fupd != 3)
        {
            fupd++;
            Debug.Log("LevelLoader - FixedUpdate" + fupd);
        }
    }
}
