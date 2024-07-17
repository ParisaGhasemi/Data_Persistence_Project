using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static MenuManager Instance;

    public TMP_InputField nameText;

    public string bestRecordName;
    public int bestRecordScore;

    public string playerName;

    private void Awake()
    {
    // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadRecord(); 
    } 

    [System.Serializable] class SaveData
    {
        public string playerName;
        public int playerScore;
    }


    public void SaveRecord()
    {
        SaveData data = new SaveData();
        data.playerName = bestRecordName;
        data.playerScore = bestRecordScore;

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

            bestRecordScore = data.playerScore;
            bestRecordName = data.playerName;
        }
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(1);
    }

    public void setPlayerName()
    {
        playerName = nameText.text;
    }
}



