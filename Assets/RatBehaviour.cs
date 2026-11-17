using UnityEngine;

public class RatBehaviour : MonoBehaviour
{
    GameObject player;
    [SerializeField] Rigidbody rb;
    [SerializeField] float minDist = 1;
    [SerializeField] float speed = 2;
    float dist;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(player.transform.position, this.transform.position);
        if (dist >  minDist)
        {
            rb.linearVelocity = Vector3.Normalize(player.transform.position - this.transform.position) * speed;
        }
    }
}
