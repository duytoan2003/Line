using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelButton : MonoBehaviour
{
    public void OpenLevel(int levelId){
        string levelName = "Level " + levelId;
        SceneManager.LoadScene(levelName);
    }
}
