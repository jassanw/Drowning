using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movementSpeed = 10f;
    public float tiltMultiplier = 3f;
    public float defaultJumpForce = 10f;
    public float jumpForce = 10f;

    [SerializeField] private Sprite golenBootsPlayerSprite;
    [SerializeField] private Sprite defaultPlayerSprite;
    [SerializeField] private SpriteRenderer playerSpriteRend;
    [SerializeField] private AudioSource jumpingAudio;
    [SerializeField] private AudioClip goldenBootsJumpingSound;
    [SerializeField] private AudioClip defaultJumpingSound;
    [SerializeField] BoxCollider2D boxCollider;

    public Rigidbody2D playerRigidBody;
    float movement = 0.0f;
    float direction;

    private int score;
  

    private void Awake()
    {
        Events.PlayerScoreUpdate.AddListener(UpdateScore);
    }

    private void OnDestory()
    {
        Events.PlayerScoreUpdate.RemoveListenr(UpdateScore);   
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
        jumpForce = defaultJumpForce;
        jumpingAudio.clip = defaultJumpingSound;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
            movement = Input.GetAxis("Horizontal") * movementSpeed;
            if (Input.acceleration.x != 0)
            {
                movement = Input.acceleration.x * movementSpeed * tiltMultiplier;
            }

            if (movement > 1 || movement < -1)
            {
                direction = movement / Math.Abs(movement);
                playerRigidBody.transform.localScale = new Vector3(
                    direction * Math.Abs(playerRigidBody.transform.localScale.x),
                    playerRigidBody.transform.localScale.y,
                    0
                );
            }
    }

    private void FixedUpdate()
    {
        Vector2 velocity = playerRigidBody.velocity;
        velocity.x = movement;
        playerRigidBody.velocity = velocity;
       
    }

    public Vector3 GetPosition(){
        return transform.position;
    }

    public void SetMovementSpeed(float movementSpeed)
    {
        this.movementSpeed = movementSpeed;
    }

    public void DeactivatePlayer() {
        gameObject.SetActive(false);
    }

    public void SetDefaultJumpforce()
    {
        jumpForce = defaultJumpForce;
    }

    public void ResetPlayer()
    {
        movementSpeed = 10f;
        jumpForce = 10f;
        playerRigidBody.gravityScale = 1;
        playerRigidBody.mass = 1;
        playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }


    public void OnPlatformJump()
    {
        Vector2 velocity = playerRigidBody.velocity;
        velocity.y = jumpForce;
        playerRigidBody.velocity = velocity;
        jumpingAudio.Play();
    }

    public void SetGoldenBootsSprite()
    {
        playerSpriteRend.sprite = golenBootsPlayerSprite;
    }

    public void SetDefaultCharacterSprite()
    {
        playerSpriteRend.sprite = defaultPlayerSprite;
    }

    public void RemoveItemEffect(Enums.Items itemType)
    {
        switch (itemType)
        {
            case Enums.Items.JumpyBoots:
                SetDefaultCharacterSprite();
                SetDefaultJumpforce();
                jumpingAudio.clip = defaultJumpingSound;
                break;

            case Enums.Items.FlyingFeather:
                break;

            case Enums.Items.Web:
                playerRigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
                break;
            default:
                return;
        }
    }

    public void ApplyItemEffect(Enums.Items itemType)
    {
        switch (itemType)
        {
            case Enums.Items.JumpyBoots:
                jumpForce = 14f;
                SetGoldenBootsSprite();
                jumpingAudio.clip = goldenBootsJumpingSound;
                break;

            case Enums.Items.FlyingFeather:
                playerRigidBody.velocity = new Vector2(playerRigidBody.velocity.x, 16f);
                break;

            case Enums.Items.Web:
                playerRigidBody.constraints = RigidbodyConstraints2D.FreezeAll;
                break;
            default:
                return;
        }
    }

    public int GetScore()
    {
        return score;
    }

    public void OnPlayerDied()
    {
        boxCollider.enabled = false;
        StartCoroutine(DisablePlayerAfterDelay());
    }

    private void UpdateScore(int newScore)
    {
        score = newScore; 
    }

    private IEnumerator DisablePlayerAfterDelay()
    {
        yield return new WaitForSeconds(1.5f);
        gameObject.gameObject.SetActive(false);
    }
  
}
