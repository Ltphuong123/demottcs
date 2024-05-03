using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TikTokLiveUnity;
using TikTokLiveSharp.Models.Protobuf.Objects;

public class TikTok : MonoBehaviour
{
    [SerializeField] protected string idTiktok;
    async void Start()
    {

        //check nhận like
        TikTokLiveManager.Instance. OnLike += (liveClient,likeEvent) =>
        {
            Debug.Log($"like {likeEvent.Count} {likeEvent.Sender.NickName}");
        };
        //check nhận quà
        TikTokLiveManager.Instance.OnGift +=(liveClient,giftEvent) =>
        {
            Debug.Log($"Gift {giftEvent.Gift.Name} {giftEvent.Sender.NickName}");
        };
        
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
            
            Debug.Log($"MSG {chatEvent.Message} {chatEvent.Sender.NickName}");
        };



        await TikTokLiveManager.Instance.ConnectToStream(idTiktok);
    }

}
