using UnityEngine;

public class NPCController : MonoBehaviour 
{
    bool player_dectection = false;

    // Update is called once per frame
    void Update()
    {

        if (player_dectection && Input.GetKeyDown(KeyCode.E))
        {
            print("it worked somehow?!?!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            player_dectection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_dectection = false;
    }
}
