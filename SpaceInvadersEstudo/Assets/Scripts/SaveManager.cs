using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance { set; get; }
    public SaveState state;
    public Text record;
    Player player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();
        record.text = ""+ state.record;
    }

    private void Update()
    {
        
        Save();
        
    }
    private void OnApplicationQuit()
    {
        Save();
        Debug.Log(Helper.Serialize<SaveState>(state));
    }
    //Save
    public void Save()
    {
        if(player.points > state.record)
        {
            state.record = player.points;
            record.text = "" + state.record;
        }
        
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    //Load
    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
            Debug.Log(state.record);
        }
        else
        {
            state = new SaveState();
            Save();
            Debug.Log("No save file found, creating a new one!");
        }
    }
}
