using UnityEngine;

public class RatSpawner : MonoBehaviour
{
    [SerializeField] GameObject rat;
    [SerializeField] float spawnRate;
    [SerializeField] GameObject bottomLeft;
    [SerializeField] GameObject topRight;

    float timer = 0;
    Vector3 spawnPos = Vector3.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPos.y = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > spawnRate)
        {
            spawnPos.x = Random.Range(bottomLeft.transform.position.x, topRight.transform.position.x);
            spawnPos.z = Random.Range(bottomLeft.transform.position.z, topRight.transform.position.z);
            Instantiate(rat, spawnPos, Quaternion.identity);
            timer = 0;
        }
    }
}
