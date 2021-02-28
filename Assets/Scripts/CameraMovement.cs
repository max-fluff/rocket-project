using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 0, -15);

    private void Start()
    {
        player = GameObject.FindGameObjectsWithTag("Player")[0].transform;
    }
    private void Update()
    {
        transform.position = player.position+offset;
    }
}
