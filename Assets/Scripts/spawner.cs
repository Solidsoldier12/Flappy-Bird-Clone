using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnTime = 1f;
    public float minHeight = -1f;
    public float maxHeight = 1f;
    void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), spawnTime, spawnTime);
    }
    void OnDisable()
    {
        CancelInvoke( nameof(Spawn) );
    }
    void Spawn()
    {
        GameObject pipe = Instantiate(prefab, transform.position, Quaternion.identity);
        pipe.transform.position += Vector3.up * Random.Range(minHeight, maxHeight) ;
    }
}
