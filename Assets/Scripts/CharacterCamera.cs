using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCamera : MonoBehaviour
{

    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (player.transform.position.x > -5.64 && player.transform.position.x < 5.6)
        {
            transform.position = new Vector3(player.transform.position.x, 0, transform.position.z);
        }
    }


}
