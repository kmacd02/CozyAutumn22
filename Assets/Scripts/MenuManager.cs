using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private bool AutoProgress = false;
    [SerializeField] private int Seconds = 0;
    [SerializeField] private string Scene = "";
    
    private void OnEnable()
    {
        if(AutoProgress) StartCoroutine(AutoLoadScene(Scene));
    }
    
    

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadScene(string s)
    {
        SceneManager.LoadScene(s);
    }
    
    public IEnumerator AutoLoadScene(string s)
    {
        yield return new WaitForSeconds(Seconds);
        SceneManager.LoadScene(s);
    }
}
