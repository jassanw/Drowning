using System;
using System.Collections;
using UnityEngine;


public class ItemManager : MonoBehaviour
{
    [SerializeField] Player player;


    [SerializeField] Item jumpyBoots;
    [SerializeField] Item flyingFeather;
    [SerializeField] Item web;


    private void Start()
    {
        Item.OnItemPickUp += OnItemPickUp;
    }

    private void OnDestroy()
    {
        Item.OnItemPickUp -= OnItemPickUp;
    }

    private void OnItemPickUp(Enums.Items itemType)
    {
        ResetPowerUps();
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
        player.jumpForce = 14f;
        StartCoroutine(ItemRunning(3.5f));
    }

    private void OnWebPickUp()
    {
        player.playerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
        StartCoroutine(ItemRunning(1.5f));
    }

    private void OnFlyingFeatherPickUp()
    {
        player.playerRigidBody.velocity = new Vector2(player.playerRigidBody.velocity.x, 16f);
        StartCoroutine(ItemRunning(1.3f));
    }

    private void ResetPowerUps()
    {
        StopAllCoroutines();
        player.ResetPlayer();
    }


    private IEnumerator ItemRunning(float time)
    {
        yield return new WaitForSeconds(time);
        player.ResetPlayer();
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
                throw new Exception();
        }
    }

}
