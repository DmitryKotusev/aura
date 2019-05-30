using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileDataController : MonoBehaviour
{
    public static string keysScoreKey = "keysStorage";

    private static List<LevelStorageData> storageList;

    private static void Init()
    {
        string keysJsonString = PlayerPrefs.GetString(keysScoreKey, "{\"levelStorageDatas\":[]}");
        StorageDataArrayWrapper arrayWrapper = JsonUtility.FromJson<StorageDataArrayWrapper>(keysJsonString);
        storageList = new List<LevelStorageData>(arrayWrapper.levelStorageDatas);
    }

    public static int GetLevelHighestScore(string levelName)
    {
        if (storageList == null)
        {
            Init();
        }
        LevelStorageData levelData = storageList.Find((element) =>
        {
            return element.levelName == levelName;
        });
        if (levelData == null)
        {
            return 0;
        }
        return levelData.levelsHighestScore;
    }

    public static void SetLevelHighestScore(string levelName, int newScore)
    {
        if (storageList == null)
        {
            Init();
        }
        LevelStorageData levelData = storageList.Find((element) =>
        {
            return element.levelName == levelName;
        });
        if (levelData == null)
        {
            levelData = new LevelStorageData();
            levelData.levelName = levelName;
            levelData.levelsHighestScore = newScore;
            storageList.Add(levelData);
            return;
        }
        levelData.levelsHighestScore = newScore;
    }

    public static void ResetController()
    {
        Init();
    }

    public static void SynchronizeDataWithStorage()
    {
        if (storageList == null)
        {
            Init();
        }
        StorageDataArrayWrapper arrayWrapper = new StorageDataArrayWrapper();
        arrayWrapper.levelStorageDatas = storageList.ToArray();
        string keysJsonString = JsonUtility.ToJson(arrayWrapper);
        PlayerPrefs.SetString(keysScoreKey, keysJsonString);
    }
}
