using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TikTokLiveUnity;
using TikTokLiveSharp.Models.Protobuf.Objects;
using Unity.VisualScripting;

public class TikTok : MonoBehaviour
{
    [SerializeField] protected string idTiktok;

    async void Start()
    {
        idTiktok=PlayerPrefs.GetString("Id_TikTok");
        
        //check nhận comment
        TikTokLiveManager.Instance.OnChatMessage +=(liveClient,chatEvent) =>
        {
            // Spawn Squadron 0 khi nhan coment la 1
            if(chatEvent.Message=="1"){
                EnemySpawner.Instance.SpawnSquad(0);
            }
            // Spawn Squadron 1 khi nhan coment la 2
            if(chatEvent.Message=="2"){
                EnemySpawner.Instance.SpawnSquad(1);
            }
            if(chatEvent.Message=="3"){
                EnemySpawner.Instance.SpawnSquad(2);
            }
            
            Debug.Log($"MSG {chatEvent.Message} {chatEvent.Sender.NickName}");
        };



        await TikTokLiveManager.Instance.ConnectToStream(idTiktok);
    }

}
