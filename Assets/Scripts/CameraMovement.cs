using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 0, -15);
    private void Update()
    {
        transform.position = player.transform.position+offset;
    }
}
