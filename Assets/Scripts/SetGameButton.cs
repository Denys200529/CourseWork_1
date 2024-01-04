using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetGameButton : MonoBehaviour
{
   
    public enum EButtonType
    {
        NotSet,
        PairNumberBtn,
        PuzzleCategoryBtn,
        
    }
    [SerializeField] public EButtonType ButtonType = EButtonType.NotSet;

    [HideInInspector] public GameSettings.EpairNumber PairNumber = GameSettings.EpairNumber.NotSet;

    [HideInInspector] public GameSettings.EpuzzleCategories PuzzleCategories = GameSettings.EpuzzleCategories.NotSet;

    void Start()
    {
        
    }

    public void SetGameOption(string GameSceneName)
    {
        var comp = gameObject.GetComponent<SetGameButton>();

        switch (comp.ButtonType) 
        {
            case SetGameButton.EButtonType.PairNumberBtn:
                GameSettings.Instance.SetPairNumber(comp.PairNumber);
                break;
            case EButtonType.PuzzleCategoryBtn:
                GameSettings.Instance.SetPuzzleCategories(comp.PuzzleCategories);
                break;

        }
        if (GameSettings.Instance.AllSettingsReady())
        {
           SceneManager.LoadScene(GameSceneName);
        }
    }
 
}
