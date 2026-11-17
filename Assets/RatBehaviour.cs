using UnityEngine;

public class RatBehaviour : MonoBehaviour
{
    GameObject player;
    [SerializeField] Rigidbody rb;
    [SerializeField] float speed = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = PlayerController.Instance.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = Vector3.Normalize(player.transform.position - this.transform.position) * speed;
    }
}
