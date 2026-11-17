using UnityEngine;

public class Factory : MonoBehaviour
{
    public static Factory Instance;

    [SerializeField] GameObject rat;
    [SerializeField] GameObject bottomLeft;
    [SerializeField] GameObject topRight;

    Vector3 spawnPos = Vector3.zero;

    void Awake()
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
        spawnPos.y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn(string name)
    {
        if (name == "Rat")
        {
            spawnPos.x = Random.Range(bottomLeft.transform.position.x, topRight.transform.position.x);
            spawnPos.z = Random.Range(bottomLeft.transform.position.z, topRight.transform.position.z);
            Instantiate(rat, spawnPos, Quaternion.identity);
        }
    }
}
