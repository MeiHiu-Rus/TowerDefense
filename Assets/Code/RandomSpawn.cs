using UnityEngine;

public class RandomSpawn : MonoBehaviour
{
    public GameObject redUnitOne;
    public GameObject redUnitTwo;
    public float minY = -0.7f;
    public float maxY = 0.7f;

    void Start()
    {
        ScheduleNextSpawn();
    }

    void ScheduleNextSpawn()
    {
        // Tạo một khoảng thời gian spawnInterval ngẫu nhiên trong khoảng 1 đến 3 giây
        float spawnInterval = Random.Range(3f, 8f);

        // Gọi SpawnRandomPrefab sau spawnInterval giây
        Invoke("SpawnRandomPrefab", spawnInterval);
    }

    void SpawnRandomPrefab()
    {
        // Chọn ngẫu nhiên giữa prefab1 và prefab2
        GameObject prefabToSpawn = Random.Range(0, 2) == 0 ? redUnitOne : redUnitTwo;

        // Tạo vị trí ngẫu nhiên trên trục y và cố định trục x = 3
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPosition = new Vector3(3, randomY, 0);

        // Tạo góc xoay với trục y là 180 độ
        Quaternion spawnRotation = Quaternion.Euler(0, 180, 0);

        // Spawn đối tượng tại vị trí (3, randomY, 0) với góc xoay 180 độ trên trục y
        Instantiate(prefabToSpawn, spawnPosition, spawnRotation);

        // Lên lịch lần spawn tiếp theo với spawnInterval mới
        ScheduleNextSpawn();
    }
}
