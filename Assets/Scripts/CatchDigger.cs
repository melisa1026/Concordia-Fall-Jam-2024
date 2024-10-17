using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatchDigger : MonoBehaviour
{
    void Update()
    {
        // if the spotter is watching and the digger is not hiding, he gets caught
        if(Spotter.isWatching && !PlayerControls.isHiding)
            SceneManager.LoadScene("Lose");
    }
}
