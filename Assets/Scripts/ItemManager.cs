using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    [SerializeField] Player player;

   
    [SerializeField] Item jumpyBoots;
    [SerializeField] Item flyingFeather;
    [SerializeField] Item web;

    [SerializeField] List<ItemAudioSource> itemAudioSouceList;

    [SerializeField] AudioSource audioSource;
    private delegate void OnItemFinshed();
    private Dictionary<Enums.Items, Coroutine> itemCoroutineDict;
    private Coroutine test;

    private void Start()
    {
        
        Item.OnItemPickUp += OnItemPickUp;
        itemCoroutineDict = new Dictionary<Enums.Items, Coroutine>();
    }

    private void OnDestroy()
    {
        Item.OnItemPickUp -= OnItemPickUp;
    }

    private void OnItemPickUp(Enums.Items itemType)
    {
        if (itemCoroutineDict.ContainsKey(itemType))
        {
            StopCoroutine(itemCoroutineDict[itemType]);
            itemCoroutineDict.Remove(itemType);
        }
        switch (itemType)
        {
            case Enums.Items.JumpyBoots:
                OnJumpyBootsPickUp();
                break;
            case Enums.Items.FlyingFeather:
                OnFlyingFeatherPickUp();
                break;
            case Enums.Items.Web:
                OnWebPickUp();
                break;
            default:
                throw new Exception("Item Picked Up Not Found");
        }
    }

    private void OnJumpyBootsPickUp()
    {
        player.ApplyItemEffect(Enums.Items.JumpyBoots);
        PlayItemSoundEffect(itemAudioSouceList.FirstOrDefault(x => x.ItemType == Enums.Items.JumpyBoots).ItemPickUpAudioClip);
        Coroutine bootsCoroutine = StartCoroutine(ItemRunning(3.5f, () => RemovePlayerItemEffect(Enums.Items.JumpyBoots)));
        itemCoroutineDict.Add(Enums.Items.JumpyBoots, bootsCoroutine);
    }

    private void OnWebPickUp()
    {
        player.ApplyItemEffect(Enums.Items.Web);
        PlayItemSoundEffect(itemAudioSouceList.FirstOrDefault(x => x.ItemType == Enums.Items.Web).ItemPickUpAudioClip);
        Coroutine webCoroutine = StartCoroutine(ItemRunning(1.2f, () => RemovePlayerItemEffect(Enums.Items.Web)));
        itemCoroutineDict.Add(Enums.Items.Web, webCoroutine);
    }

    private void OnFlyingFeatherPickUp()
    {
        player.ApplyItemEffect(Enums.Items.FlyingFeather);
        PlayItemSoundEffect(itemAudioSouceList.FirstOrDefault(x => x.ItemType == Enums.Items.FlyingFeather).ItemPickUpAudioClip);
        Coroutine flyingFeatherCoroutine = StartCoroutine(ItemRunning(1.3f,() => RemovePlayerItemEffect(Enums.Items.FlyingFeather)));
        itemCoroutineDict.Add(Enums.Items.FlyingFeather, flyingFeatherCoroutine);
    }

    private void PlayItemSoundEffect(AudioClip audioClip)
    {
        if (audioClip == null) return;

        audioSource.clip = audioClip;
        audioSource.Play();
     
    }

    private void RemovePlayerItemEffect(Enums.Items itemType)
    {
        player.RemoveItemEffect(itemType);
        itemCoroutineDict.Remove(itemType);
    }

    private IEnumerator ItemRunning(float time, OnItemFinshed onItemFinshedDelegate = null)
    {
        yield return new WaitForSeconds(time);
        onItemFinshedDelegate?.Invoke();
    }

    public Item GetRandomItem()
    {
        Enums.Items randomItem = Enums.GetRandomItemEnum();
        switch (randomItem)
        {
            case Enums.Items.JumpyBoots:
                return jumpyBoots;
            case Enums.Items.FlyingFeather:
                return flyingFeather;
            case Enums.Items.Web:
                return web;
            default:
                throw new Exception("Item not Found");
        }
    }

    [System.Serializable]
    private struct ItemAudioSource
    {
        public Enums.Items ItemType;
        public AudioClip ItemPickUpAudioClip;
    }

}
