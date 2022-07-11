using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private static int currentLevel;

    public int CurrentLevel => currentLevel;

    private void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("currentLevel", 1);
    }

    public void NextLevel()
    {
        currentLevel++;
        PlayerPrefs.SetInt("currentLevel", currentLevel);
        SceneManager.LoadScene(0); 
    }
}
