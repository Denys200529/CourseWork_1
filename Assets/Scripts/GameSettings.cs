using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class GameSettings : MonoBehaviour
{


    private readonly Dictionary<EpuzzleCategories,string> _puzzleCatDirectory = new Dictionary<EpuzzleCategories,string>();
    private int _settings;
    private const int SettingsNumber = 2;
    private bool _muteFxPermanently = false;

    public enum EpairNumber
    {
        NotSet=0,
        E10Pairs=10,
        E15Pairs=15,
        E20Pairs=20,
    }
    public enum EpuzzleCategories
    {
        NotSet,
        Fruits,
        Animals
    }
    public struct Settings
    {
        public EpairNumber PairsNumber;
        public EpuzzleCategories PuzzleCategory;
    }
    private Settings _gameSettings;

    public static GameSettings Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            DontDestroyOnLoad(target:this);
            Instance = this;
        }
        else
        {
            Destroy(obj:this);
        }
    }

    void Start()
    {
        SetPuzzleCatDirectory();
        _gameSettings = new Settings();
        ResetGameSettings();
    }

    private void SetPuzzleCatDirectory()
    {
        _puzzleCatDirectory.Add(EpuzzleCategories.Fruits, "Fruits");
        _puzzleCatDirectory.Add(EpuzzleCategories.Animals, "Animals");
    }

    public void SetPairNumber(EpairNumber Number)
    {
        if(_gameSettings.PairsNumber== EpairNumber.NotSet)
            _settings++;  
            
        _gameSettings.PairsNumber = Number;
            
    }
    
    public void SetPuzzleCategories(EpuzzleCategories cat)
    {
        if (_gameSettings.PuzzleCategory == EpuzzleCategories.NotSet)
        {
            _settings++;
        }   
        _gameSettings.PuzzleCategory = cat;
    }
    public EpairNumber GetPairNumber() 
    {
        return _gameSettings.PairsNumber; 
    }
    public EpuzzleCategories GetPuzzleCategory()
    {
        return _gameSettings.PuzzleCategory;
    }
    public void ResetGameSettings()
    {
        _settings = 0;
        _gameSettings.PuzzleCategory = EpuzzleCategories.NotSet;
        _gameSettings.PairsNumber=EpairNumber.NotSet;
    }
    public bool AllSettingsReady()
    {
        return _settings == SettingsNumber;
    }

    public string GetMaterialDirectoryName()
    {
        return "Materials/";
    }

    public string GetPuzzleCatugoryTextureDirectoryName()
    {
        if (_puzzleCatDirectory.ContainsKey(_gameSettings.PuzzleCategory)) 
        {
            return "Graphics/PuzzleCat/" + _puzzleCatDirectory[_gameSettings.PuzzleCategory] + "/";
        }
        else
        {
            Debug.LogError("Error:Canno get directory name");
            return "";
        }
    }

    public void MuteSoundEffectPermanently(bool muted)
    {
        _muteFxPermanently = muted;
    }

    public bool IsSoundEffectMutedPermanently()
    {
        return _muteFxPermanently;
    }

}
