using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public AudioSource shovelSound;
    public AudioSource walkingSound;
    public AudioSource hidingSound;
    public AudioSource popUpSound;

    // Hidding
    public int normalSortingOrder = 8; // normal layer of character
    public int behindSortingOrder = 5; // layer behind the gravestones
    public static bool isHiding = false;

    // walking
    public static bool isWalking = false;

    // Digging
    public float diggingIncrement = 10f;
    public float currentDigProgress = 0f;
    private bool isDigging = false;

    // This is for the HeadstoneObject... not sure if I did this corectly but needed something
    // to make character aware of gravestone locations
    private Collider2D currentStone = null;
    private GameObject[] headstones;
    private int headStoneIndex = 0;

    public float moveSpeed = 2f;

    // Completion bar
    public CompletionBar completionBar;

    // Pop-up Object
    public Popup popupS;

    public static bool allCollected = false;


    void Start()
    {
        // gameObject.tag = "headstone";
        // gameObject.tag = "For some reason this fixes it";

        allCollected = false;
        isWalking = false;
        isHiding = false;
        isDigging = false;

        // SpriteRenderer attached to character
        spriteRenderer = GetComponent<SpriteRenderer>();

        headstones = GameObject.FindGameObjectsWithTag("headstone");

        // Had an issue where character started at far right side and moved to the left
        // this re arranges the array in order to start from left and move to the right
        System.Array.Sort(headstones, (a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        if (headstones.Length > 0)
        {
            transform.position = new Vector3(headstones[0].transform.position.x , transform.position.y , transform.position.z);
        }
        headStoneIndex = 0;
    }

    void Update()
    {
        // Checks if hidding or not
        HideGrave();

        //  Checks is pressing D 
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetButtonDown("DButton")) && !isDigging && !isHiding && !isWalking)
        {
            // Shovel sound
            if (shovelSound != null)
            {
                shovelSound.Play();
            }
            
            // Start the digging
            DigGrave();
        }

    }

    // Method for hide
    private void HideGrave()
    {
        if ((Input.GetKeyUp(KeyCode.H) || Input.GetButtonUp("HButton")) && !isWalking)
        {

            GetComponent<Animator>().Play("stand");
        }
        
        if ((Input.GetKey(KeyCode.H) || Input.GetButton("HButton")) && !isWalking)
        {
            GetComponent<Animator>().Play("hide");
            spriteRenderer.sortingOrder = behindSortingOrder;
            isHiding = true;
        }
        else
        {
            // Hidding sound
            if (hidingSound != null)
            {
                hidingSound.Play();
            }
            spriteRenderer.sortingOrder = normalSortingOrder;
            isHiding = false;
        }
    }

    // Method for digging action
    private void DigGrave()
    {
        GetComponent<Animator>().Play("dig");

        isDigging = true;
        currentDigProgress += diggingIncrement;


        // Visual update of the bar
        if (completionBar != null) 
        {
            bool isBarFull = completionBar.IncreaseBar();
            if (isBarFull)
            {
                if (popupS != null) 
                {
                    popUpSound.Play();
                    popupS.popup();
                }
                MoveGrave();
            }
        }

        // Move to next gravesite
        if (currentDigProgress > 100f)
        {

            if (popupS != null)
            {
                popUpSound.Play();
                popupS.popup();
            }

            if (completionBar != null)
            {
                completionBar.ResetBar();
            }
            MoveGrave();
        }
        isDigging = false;
    }

    // character auto move
    private void MoveGrave()
    {
        headStoneIndex++;

        if (headStoneIndex < headstones.Length)
        {
            // Increments array for next headstone
            currentStone = headstones[headStoneIndex].GetComponent<Collider2D>();

            // Move character to next headstone
            StartCoroutine(MoveToPosition(headstones[headStoneIndex].transform.position));

            // Reset dig progress
            currentDigProgress = 0;
        }
        else
        {
           allCollected = true;
        }

    }

    // Movement of player
    IEnumerator MoveToPosition(Vector2 pos)
    {
        isWalking = true;

        // walking sound
        if (walkingSound != null && !walkingSound.isPlaying)
        {
            walkingSound.Play();
        }

        GetComponent<Animator>().Play("walk");

        while (Vector2.Distance(transform.position, new Vector2(pos.x, transform.position.y)) > 0.1f)
        {
            // Move character smoothly to the target position
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(pos.x, transform.position.y), moveSpeed * Time.deltaTime);
            yield return null;
        }

        GetComponent<Animator>().Play("stand");

        isWalking = false;

        // stop walking sound when player is not walking
        if (walkingSound != null && walkingSound.isPlaying)
        {
            walkingSound.Stop();
        }

    }

    // // Detect area
    // void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.CompareTag("headstone"))
    //     {
    //         currentStone = other;
    //     }
    // }

    // void OnTriggerExit2D(Collider2D other)
    // {
    //     if (other.CompareTag("For some reason this fixes it"))
    //     {
    //         currentStone = null;
    //     }
    // }

    public static void ChangeScenePhase2()
    {
        SceneManager.LoadScene("Phase II");
    }
}
