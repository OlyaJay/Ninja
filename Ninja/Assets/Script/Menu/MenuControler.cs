using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuControler : MonoBehaviour
{
    [SerializeField]
    private GameObject difficultyWindow;
    public void StartGame()
    {
        difficultyWindow.SetActive(true);
        gameObject.SetActive(false);
    }
    public void Credits()
    {
        Debug.Log("Now it`s only me. In future add one Empty Object with return to menu");
    }

    public void doExitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
