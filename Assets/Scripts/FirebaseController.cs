using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using UnityEngine;


//Creating lobby with game deatils
[SerializeField]
public class cls_GameLobby
{
    public string gameNameplr1, gameNameplr2;

    public cls_GameLobby(string gName1, string gName2)
    {
        this.gameNameplr1 = gName1;
        this.gameNameplr2 = gName2;
    }

}

public class FirebaseController : MonoBehaviour
{
    //Reference to database
    private static DatabaseReference dbRef;

    //Unique Key generated by firebase
    public static string sUniqueKey = "";

    //Names chosen for games by players
    public static string sGameName1 = "";

    public static string sGameName2="";


    public static IEnumerator CreateGameInstance(string sGName1)
    {
        //Intialing the first game name
        sGameName1 = sGName1;

        //Creates a unique key by firebase and sets objects as one of the children
        sUniqueKey = dbRef.Child("Objects").Push().Key;

        //Intialising the lobby
        cls_GameLobby lobby = new cls_GameLobby(sGName1, "");

        //puts the key as a child of the object  
        dbRef.Child("Objects").Child(sUniqueKey).ValueChanged += HandleValueChanged;

        
        yield return dbRef.Child("Objects").Child(sUniqueKey).SetRawJsonValueAsync(JsonUtility.ToJson(lobby));
        GameManager.LoadScene("Lobby");

        Debug.Log("Unique Key Generated by Firebase"+sUniqueKey);

    }

    public static void HandleValueChanged(object sender, ValueChangedEventArgs args)
    {
        if (args.DatabaseError != null)
        {
            Debug.LogError(args.DatabaseError.Message);
            return;
        }
        else
        {
            Debug.Log("HERE");
            foreach (var child in args.Snapshot.Children)
            {
                if (child.Key == "gameNameplr2")
                {
                    sGameName2 = child.Value.ToString(); ;
                    Debug.Log("Set Player 2");
                }
            }
        }
    }

    public static IEnumerator ValidateUniqueKey(string Key)
    {
        Debug.Log("Validate Method");
        Debug.Log("Key Value: " + Key);
        Debug.Log("Player2: " + sGameName2);
        yield return dbRef.Child("Objects").Child(Key).GetValueAsync().ContinueWith(task =>
        {
            if (task.IsCompleted)
            {
                DataSnapshot snapShot = task.Result;
                Debug.Log("Snaphto details:  "+ snapShot.Value);

                if (snapShot.Value != null)
                {
                    foreach (var child in snapShot.Children)
                    {
                        Debug.Log("Child Key " + child.Key);
                        if (child.Key == "gameNameplr1")
                        {
                            sGameName1 = child.Value.ToString();
                        }
                    }
                }
          
            }
        });
    }


    public static void AddPlayersToLobby(string gameName1, string gameName2, string key)
    {
        cls_GameLobby GameLobby = new cls_GameLobby(gameName1, gameName2);
        dbRef.Child("Objects").Child(key).SetRawJsonValueAsync(JsonUtility.ToJson(GameLobby));
    }
        
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        dbRef = FirebaseDatabase.DefaultInstance.RootReference;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
