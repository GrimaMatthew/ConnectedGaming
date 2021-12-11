using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_InputField inpGameName;
    [SerializeField] private TMPro.TMP_InputField inpUniqueCodeToShare;

    public static void LoadScene(string sSceneName)
    {
        SceneManager.LoadScene(sSceneName);
    }


    public void createNewGameInstance()
    {
        if (inpGameName.text != null)
        {
            StartCoroutine(FirebaseController.CreateGameInstance(inpGameName.text));
        }
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
