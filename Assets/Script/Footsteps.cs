using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepsSound;

    private void Update()
    {
        if(Input.GetKey(KeyCode.W)|| Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.S)|| Input.GetKey(KeyCode.D))
        {
            footstepsSound.enabled = true;
            if (Input.GetKey(KeyCode.LeftShift))
            {
                footstepsSound.enabled = true;
            }
        }
        else
        {
            footstepsSound.enabled = false;
        }
    }
}
