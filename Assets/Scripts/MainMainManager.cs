using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MainMainManager : MonoBehaviour
{
    public static MainMainManager Instance;
    public string Name;

    public int BestScore;
    public string BestName;

    [SerializeField] private Text BestScoreMenuText;
    void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(Instance);
        LoadRecord();
        BestScoreMenuText.text = "Best Score - " + BestName + " - " + BestScore;
    }

    

    [System.Serializable]
    class SaveData
    {
        public int BestScore;
        public string BestName;
    }

    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.BestName = BestName;
        data.BestScore = BestScore;


        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadRecord()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestName = data.BestName;
            BestScore = data.BestScore;
        }
    }

}
