using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressPanel : MonoBehaviour
{
    [SerializeField] private StoneSpawner stoneSpawner;    
    [SerializeField] private LevelState levelState;
    [SerializeField] private Image fillImage;
    [SerializeField] private Text currentLevelText;
    [SerializeField] private Text nextLevelText;

    private float fillStep;
    
    
    
    private void Start()
    {
        currentLevelText.text = levelState.CurrentLevel.ToString();
        nextLevelText.text = (levelState.CurrentLevel + 1).ToString();

        fillImage.fillAmount = 0;
        
        fillStep = 1 / (float)(stoneSpawner.StoneAmount * 8);

    }

    
    public void OnFillProgressPanel()
    {        
        fillImage.fillAmount += fillStep;
        Debug.Log("fill");
    }

    public void FillStepMath()
    {      
        fillStep = 1 / (float)(((stoneSpawner.StoneAmount - stoneSpawner.AmountSpawned) * 8) + stoneSpawner.AllStoneHP);
    }


}
