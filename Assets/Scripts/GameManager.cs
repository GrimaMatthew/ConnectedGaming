using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static string intialNameP1;
    public static string intialNameP2;

    public static string keyvar;

    [SerializeField] private TMPro.TMP_InputField inpGameName;
    [SerializeField] private TMPro.TMP_InputField inpUniqueCodeToShare;
    [SerializeField] private TMPro.TMP_InputField inpUniqueCodeToJoin;


    public static void LoadScene(string sSceneName)
    {
        SceneManager.LoadScene(sSceneName);
    }


    public void createNewGameInstance()
    {
        if (inpGameName.text != null)
        {
            intialNameP1 = inpGameName.text;
            StartCoroutine(FirebaseController.CreateGameInstance(inpGameName.text));
        }
    }


    public void JoinGame()
    {
        if (inpGameName.text != null)
        {
            intialNameP2 = inpGameName.text;
            FirebaseController.sGameName2 = inpGameName.text;
            LoadScene("JoinLobby");
        }
    }

    public void JoinGameLobby()
    {
        if (inpUniqueCodeToJoin.text != null)
        {
            keyvar = inpUniqueCodeToJoin.text;
            StartCoroutine(FirebaseController.ValidateKey(inpUniqueCodeToJoin.text));
            joinLobby();
        }
    }

    public void joinLobby()
    {
        LoadScene("LiveGame");  
    }


 


    public void Awake()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start":
                break;

            case "Lobby":
                inpUniqueCodeToShare.text = FirebaseController.sUniqueKey;
                break;

            case "LiveGame":
                break;

            default:
                break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
