using UnityEngine;

public class Part : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset;
    private void Start()
    {
        Physics.gravity=new Vector3(0, -2F, 0);
        player = GameObject.Find("PlayerDouble");
        GetComponent<BoxCollider>().enabled =false;
        GetComponent<Rigidbody>().useGravity=false;
    }

    void Update()
    {
        if (PlayerState.IsUndocked()) return;
        offset = 2 * (-player.transform.up);
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation;
    }
    private void FixedUpdate()
    {
        if (!PlayerState.IsUndocked()) return;
        GetComponent<BoxCollider>().enabled =true;
        GetComponent<Rigidbody>().useGravity=true;
    }
}