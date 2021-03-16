using UnityEngine;

public class Part : MonoBehaviour
{
    [SerializeField] public PlayerState playerState;
    public GameObject player;
    public Vector3 offset;
    private void Start()
    {
        Physics.gravity=new Vector3(0, -2F, 0);
        GetComponent<BoxCollider>().enabled =false;
        GetComponent<Rigidbody>().useGravity=false;
    }

    private void Update()
    {
        if (playerState.IsUndocked) return;
        offset = 2 * (-player.transform.up);
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
    private void FixedUpdate()
    {
        if (!playerState.IsUndocked) return;
        GetComponent<BoxCollider>().enabled =true;
        GetComponent<Rigidbody>().useGravity=true;
    }
}