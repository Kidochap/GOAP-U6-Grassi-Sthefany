using UnityEngine;

public class TesterSpawner : MonoBehaviour
{
    public GameObject testerPrefab;
    public int initialTesterCount = 0;

    void Start()
    {
        for (int i = 0; i < initialTesterCount; i++)
        {
            Instantiate(testerPrefab, transform.position, Quaternion.identity);
        }
        Invoke(nameof(InstantiateTester), Random.Range(5, 10));
    }

    void InstantiateTester()
    {
        Instantiate(testerPrefab, transform.position, Quaternion.identity);
        Invoke(nameof(InstantiateTester), Random.Range(5, 10));
    }
}
