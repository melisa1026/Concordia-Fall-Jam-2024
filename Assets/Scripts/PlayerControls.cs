using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControls : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

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


    void Start()
    {
        // SpriteRenderer attached to character
        spriteRenderer = GetComponent<SpriteRenderer>();

        headstones = GameObject.FindGameObjectsWithTag("headstone");

        // Had an issue where character started at far right side and moved to the left
        // this re arranges the array in order to start from left and move to the right
        System.Array.Sort(headstones, (a, b) => a.transform.position.x.CompareTo(b.transform.position.x));

        if (headstones.Length > 0)
        {
            transform.position = headstones[0].transform.position;
        }
        headStoneIndex = 0;
    }

    void Update()
    {
        // Checks if hidding or not
        HideGrave();

        //  Checks is pressing D 
        if (Input.GetKeyDown(KeyCode.D) && currentStone != null && !isDigging && !isHiding && !isWalking)
        {
            // Start the digging
            DigGrave();
        }

    }

    // Method for hide
    private void HideGrave()
    {
        if (Input.GetKey(KeyCode.H) && !isWalking)
        {
            spriteRenderer.sortingOrder = behindSortingOrder;
            isHiding = true;
            Debug.Log("Hidding!");
        }
        else
        {
            spriteRenderer.sortingOrder = normalSortingOrder;
            isHiding = false;
        }
    }

    // Method for digging action
    private void DigGrave()
    {
        isDigging = true;
        currentDigProgress += diggingIncrement;

        Debug.Log("Dug " + currentDigProgress + " %");

        // Visual update of the bar
        if (completionBar != null) 
        {
            bool isBarFull = completionBar.IncreaseBar();
            if (isBarFull)
            {
                if (popupS != null) 
                {
                    popupS.popup();
                }
                MoveGrave();
            }
        }

        // Move to next gravesite
        if (currentDigProgress > 100f)
        {
            Debug.Log("Grave complete");

            if (popupS != null)
            {
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
            ChangeScenePhase2();
            Debug.Log("Mission complete");
        }

    }

    // Movement of player
    IEnumerator MoveToPosition(Vector2 pos)
    {
        isWalking = true;
        while (Vector2.Distance(transform.position, pos) > 0.1f)
        {
            // Move character smoothly to the target position
            transform.position = Vector2.MoveTowards(transform.position, pos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        isWalking = false;
    }

    // Detect area
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("headstone"))
        {
            Debug.Log("Entered headstone");
            currentStone = other;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("For some reason this fixes it"))
        {
            Debug.Log("Exited headstone");
            currentStone = null;
        }
    }

    void ChangeScenePhase2()
    {
        Debug.Log("Changing Scene");
        SceneManager.LoadScene("Phase II");
    }
}
