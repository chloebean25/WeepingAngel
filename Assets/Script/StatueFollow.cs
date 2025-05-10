using UnityEngine;

public class StatueFollow : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 directionToPlayer = player.position - transform.position;

            directionToPlayer.y = 0;
            if (directionToPlayer.magnitude > 0.1f)
            {
                Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer);

                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
