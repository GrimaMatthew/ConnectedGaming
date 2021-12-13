using System.Collections;
using System.Collections.Generic;
using Firebase.Extensions;
using Firebase.Storage;
using UnityEngine;

public class DLCManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        string[] fileNames = { "Square.png", "Circle.png" };
        FirebaseStorage storage = FirebaseStorage.DefaultInstance;
        StorageReference storeRef = storage.GetReferenceFromUrl("gs://connectedgamingassign.appspot.com");

        foreach (string f in fileNames)
        {
            Debug.Log("Filen: " + f);
            GameObject playerIcon = new GameObject();
            playerIcon.transform.parent = GameObject.Find("DLCManager").transform;
            playerIcon.AddComponent<SpriteRenderer>();

            if (f == "Square.png")
            {
                playerIcon.name = f;
                playerIcon.AddComponent<SquareMover>();
                playerIcon.transform.position = new Vector3(0, 0, 0);
                

            }
            else if (f == "Circle.png")
            {
                playerIcon.name = f;
                playerIcon.AddComponent<CircleMover>();
                playerIcon.transform.position = new Vector3(1000, 0, 0);

                Vector3 scaledown = new Vector3(0.5f, 0.5f, 0);
                playerIcon.transform.localScale = scaledown;
            }

            StorageReference imagePla = storeRef.Child("DLC").Child(f);
            DownloadDLC(imagePla, playerIcon);
        }
        
    }


    private void DownloadDLC (StorageReference reference , GameObject playericon)
    {
        const long maxSize = 1 * 1024 * 1024;
        reference.GetBytesAsync(maxSize).ContinueWithOnMainThread(task =>
        {
            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogException(task.Exception);
            }
            else
            {
                byte[] fileContent = task.Result;
                Texture2D tex = new Texture2D(1024, 1024);
                tex.LoadImage(fileContent);
                Sprite mySprite = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);
                playericon.GetComponent<SpriteRenderer>().sprite = mySprite;
            }
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
