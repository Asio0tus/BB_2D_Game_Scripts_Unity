using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndGame : MonoBehaviour
{
    [SerializeField] private GameObject passedLevelPanel;
    [SerializeField] private GameObject defeatLevelPanel;
    [SerializeField] private LevelState levelState;
    [SerializeField] private UIMainMenu mainMenu;


    private void Awake()
    {
        passedLevelPanel.SetActive(false);
        defeatLevelPanel.SetActive(false);
        levelState.Passed.AddListener(PassedLevel);
        levelState.Defeat.AddListener(DefeatLevel);
    }
    private void OnDestroy()
    {
        levelState.Passed.RemoveListener(PassedLevel);
        levelState.Defeat.RemoveListener(DefeatLevel);
    }

    private void PassedLevel()
    {
        passedLevelPanel.SetActive(true);
        
    }

    private void DefeatLevel()
    {
        defeatLevelPanel.SetActive(true);
        
    }

    public void RestartLevel()
    {      
               
    }


}
