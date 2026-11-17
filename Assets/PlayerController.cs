using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;
    [SerializeField] Rigidbody rb;

    Vector3 move = Vector3.zero;
    [SerializeField] float speed = 5f;

    bool attack = false;
    float atkTimer = 0f;

    [SerializeField] float spawnRate;
    float ratTimer = 0;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ratTimer += Time.deltaTime;
        if (ratTimer  > spawnRate)
        {
            Factory.Instance.Spawn("Rat");
            ratTimer = 0;
        }

        if (attack)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer > .3f)
            {
                attack = false;
                atkTimer = 0f;
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            move.z++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            move.z--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            move.x++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            move.x--;
        }
        rb.linearVelocity = move.normalized*speed;
        move = Vector3.zero;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            attack = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (attack) 
        {
            if (other.gameObject.tag == "Rat")
            {
                Destroy(other.gameObject);
            }
        }
    }
}
