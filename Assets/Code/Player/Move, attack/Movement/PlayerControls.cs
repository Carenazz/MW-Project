﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour
{
    #region Variables

    #region Movements
    private Rigidbody2D rigid;

    [SerializeField]
    private float jumpSpeed, jDistance, pDist = 0.5f, speed, movement;
    #endregion

    #region Health system

    public HealthBar healthBar;

    [SerializeField]
    private int maxHealth = 100;
    public int currentHealth;
    private float deathTimer;

    #endregion

    #region Climb Variables
    private float inputVertical;
    public float distance, bDistance = 3f;
    public float climbSpeed;
    #endregion

    #region Levels and experience

    public int level = 1, expA, maxExp = 100;

    #endregion

    // Attack
    Weapon weapon;

    #region Timer + Bools
    [SerializeField]
    private bool isPressing, isGrounded, isClimbing, isJumping, doubleJump;
    [SerializeField]
    private float bTimer = 0f, rTimer = 10f;
    #endregion

    #region Components and Layermasks
    // Components
    LevelColl scenes;
    SpriteRenderer SRender;
    Collider2D mcoll;
    private LevelSystem levelSystem;
    public XPBar expBar;
    Hanging hang;

    // Animations
    public Animator animator;

    // Layer Masks & transforms
    public Transform jumpPoint;
    public LayerMask whatIsLadder, whatIsPlatform, whatIsPushable, whatIsButton;
    #endregion

    // Inventory inspired by CodeMonkey

    private Inventory inventory;

    #region stats

    Stats stats;

    #endregion

    // Debugging attemtps.
    private static PlayerControls playerInstance;

    public static PlayerControls Instance { get { return playerInstance; } }

    Camera_New cam;
    // private bool created = false;
    #endregion

    private void Awake()
    {
        if (playerInstance != null && playerInstance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            playerInstance = this;
        }
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        #region variables declared
        speed = 7f;
        movement = 0f;
        deathTimer = 1.5f;
        #endregion

        #region Getting components
        SRender = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
        weapon = GetComponent<Weapon>();
        scenes = GetComponent<LevelColl>();
        mcoll = GetComponent<Collider2D>();
        stats = GetComponent<Stats>();
        hang = GetComponent<Hanging>();
        cam = GetComponent<Camera_New>();
        #endregion

        #region Level System
        LevelSystem levelSystem = new LevelSystem();
        #endregion

        DontDestroyOnLoad(this.gameObject);

        inventory = new Inventory();
    }

    void Update()
    {

        if (currentHealth > 0)
        {
            if (isPressing == false)
            {
                #region movement system
                Move();

                Pushing();

                Climbing();

                Jump();

                hang.HangCheck();
                #endregion

                PButton();

                rTimer -= Time.deltaTime;
            }
            else
            {
                #region button Timer
                if (bTimer >= 0f)
                {
                    bTimer -= Time.deltaTime;
                }
                else if (bTimer <= 0)
                {
                    isPressing = false;
                    animator.SetBool("Button", false);
                }
                #endregion
            }
            #region RegenTimer
            if (rTimer <= 0)
            {
                rTimer = 10f;
                Regeneration();
            }
            #endregion
        }

        #region Life handler and death
        else if (currentHealth <= 0)
        {
            Dying();
        }
        else
        {
            Debug.Log("Some error has occured");
        }
        #endregion

        #region Currenthealth max Limits
        if (currentHealth > maxHealth + stats.stamina * 10)
        {
            currentHealth = maxHealth + stats.stamina * 10; 
        }
        #endregion

        #region testing purposes for exp
        if (Input.GetKeyDown(KeyCode.K))
        {
            // Virker kun en gang?
            expBar.UpdateBar(50);
        }
        #endregion
    }

    #region Collision and interactions

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.tag == "Platform" || collision.transform.tag == "mPlatform")
        {
            isJumping = false;
            animator.SetBool("Jumping", false);
            isClimbing = false;
            animator.SetBool("Climber", false);
            doubleJump = false;
            animator.SetBool("DoubleJump", false);
        }

        if (collision.transform.tag == "mPlatform")
        {
            this.transform.parent = collision.gameObject.transform;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.tag == "mPlatform")
        {
            this.transform.parent = null;
            DontDestroyOnLoad(this);
        }
    }

    public void PButton()
    {
        RaycastHit2D buttonInfo = Physics2D.Raycast(transform.position, Vector2.up, bDistance, whatIsButton);

        if (buttonInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                isPressing = true;
                animator.SetBool("Button", true);
                bTimer = Time.deltaTime + 1.25f;
            }
        }
    }

    #endregion

    #region Movement
    private void Move()
    {

        if (Input.GetAxis("Horizontal") != 0f)
        {
            // Movement and rotation

            movement = Input.GetAxis("Horizontal");

            animator.SetFloat("Speed", Mathf.Abs(movement));

            if (movement > 0f)
            {
                rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
                transform.eulerAngles = new Vector3(0, 0, 0);

            }
            else if (movement < 0f)
            {
                rigid.velocity = new Vector2(movement * speed, rigid.velocity.y);
                transform.eulerAngles = new Vector3(0, -180, 0);
            }
        }
    }

    void Jump()
    {
        // Make jumping a bit more easy and not point precision.

        RaycastHit2D platInfo = Physics2D.Raycast(jumpPoint.position, Vector2.left, pDist, whatIsPlatform);

        if (platInfo.collider != null)
        {
            if (Input.GetButtonDown("Jump") && !isJumping && !isClimbing)
            {
                rigid.velocity = new Vector2(rigid.velocity.x, 7 + stats.agility / 10);
                {
                    isJumping = true;
                    animator.SetBool("Jumping", true);
                }
            }
        }
        else if (Input.GetButtonDown("Jump") && isJumping && !doubleJump && !isClimbing)
        {
            rigid.velocity = new Vector2(rigid.velocity.x, 7 + stats.agility / 10);
            {
                doubleJump = true;
                animator.SetTrigger("DoubleJump");
            }
        }
    }

    void Climbing()
    {
        // Climbing inspired by Blackthornprod

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, whatIsLadder);

        if (hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                isClimbing = true;
                animator.SetBool("Climber", true);
            }

            else
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    isClimbing = false;
                    animator.SetBool("Climber", false);
                }
            }
        }
        if (isClimbing == true && hitInfo.collider != null)
        {
            inputVertical = Input.GetAxisRaw("Vertical");
            rigid.velocity = new Vector2(rigid.velocity.x, inputVertical * climbSpeed);
            rigid.gravityScale = 0;
        }
        else
        {
            rigid.gravityScale = 2;
            animator.SetBool("Climber", false);
        }
    }

    void Pushing()
    {
        // Inspired ny BlackthornProd's "Climbing" using Raycast.

        RaycastHit2D pushInfo = Physics2D.Raycast(transform.position + transform.up * 1, Vector2.left, 0.5f, whatIsPushable);
        RaycastHit2D pushInfo2 = Physics2D.Raycast(transform.position + transform.up * 1, Vector2.right, 0.5f, whatIsPushable);
        if (pushInfo.collider != null || pushInfo2.collider != null)
        {
            animator.SetBool("Pusher", true);
        }
        else
        {
            animator.SetBool("Pusher", false);
        }
    }
    #endregion

    #region Damage / Death
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        animator.SetTrigger("Hurt");
    }

    public void Healed(int amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
    }

    private void Regeneration()
    {
        currentHealth += 5 * stats.will;
        healthBar.SetHealth(currentHealth);
    }
    
    void Dying()
    {
        animator.SetBool("Death", true);
        weapon.enabled = false;
        if (deathTimer > 0)
        {
            deathTimer -= Time.deltaTime;
            mcoll.enabled = !mcoll.enabled;
        }
        else if (deathTimer <= 0)
        {
            animator.SetBool("Death", false);
            currentHealth = maxHealth;
            healthBar.SetMaxHealth(maxHealth);
            deathTimer = 1.5f;
            transform.position = GameObject.FindWithTag("Respawn").transform.position;
            weapon.enabled = true;
            mcoll.enabled = true;
        }
    }

    #endregion

    #region LevelUp animations & WIP
    public void SetLevelSystem(LevelSystem levelSystem)
    {
        this.levelSystem = levelSystem;

        levelSystem.onLevelChange += LevelSystem_OnLevelChange;
    }

    private void LevelSystem_OnLevelChange(object sender, EventArgs e)
    {
        // Flash(new Color(1, 1, 1, 1));
        level++;
    }

    /*
    private void Flash(Color flashColor)
    {
        
    }
    */
    #endregion

    #region Experience and Levels

    private void ExpGain(int amount)
    {
        expA += amount;
        expBar.UpdateBar(amount);
    }

    #endregion

    #region Save System

    public void SavePlayer()
    {
        SaveLoad.SavePlayer(this);
        stats.SaveStats();
        scenes.SaveLevel();
    }

    public void LoadPlayer()
    {
        if (scenes.currentScene != 1)
        {
            scenes.LoadLevel();
        }

        PlayerData data = SaveLoad.LoadPlayer();

        level = data.levels;
        currentHealth = data.health;

        Vector3 position;
        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        transform.position = position;

        stats.LoadStats();
    }

    #endregion
}