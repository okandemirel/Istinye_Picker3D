using System;
using Command;
using Data.UnityObjects;
using Data.ValueObjects;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private Transform levelHolder;
        [SerializeField] private int levelID;
        [SerializeField] private int totalLevelCount;

        #endregion

        #region Private Variables

        private LevelData _data;

        private OnLevelLoaderCommand _levelLoader;
        private OnLevelDestroyerCommand _levelDestroyer;

        #endregion

        #endregion

        private void Awake()
        {
            _data = GetLevelData();
            levelID = GetLevelID();

            Init();
        }

        private void Init()
        {
            _levelDestroyer = new OnLevelDestroyerCommand(levelHolder);
            _levelLoader = new OnLevelLoaderCommand(levelHolder);
        }

        private void OnEnable() => SubscribeEvents();

        private void SubscribeEvents()
        {
        }

        private void UnsubscribeEvents()
        {
        }

        private void OnDisable() => UnsubscribeEvents();

        private void Start()
        {
            OnInitializeLevel(levelID);
        }

        private LevelData GetLevelData() => Resources.Load<CD_Level>("Data/CD_Level").LevelList[levelID];

        private int GetLevelID()
        {
            if (!ES3.FileExists()) return 0;
            return ES3.KeyExists("Level") ? ES3.Load<int>("Level") : 0;
        }

        private void OnInitializeLevel(int ID)
        {
            _levelLoader.Execute(ID);
        }

        private void OnClearActiveLevel()
        {
            _levelDestroyer.Execute();
        }
    }
}