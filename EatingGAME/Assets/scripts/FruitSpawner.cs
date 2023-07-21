using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruits; // Meyve prefabları
    private BoxCollider2D col; // Collider bileşeni
    private float x1, x2; // Min ve max x değerleri
    private int score = 0; // Toplam puan

    public float spawnIntervalMin = 1f; // Min spawn aralığı
    public float spawnIntervalMax = 2f; // Max spawn aralığı

    private void Awake()
    {
        col = GetComponent<BoxCollider2D>(); // Collider bileşenini al

        x1 = transform.position.x - col.bounds.size.x / 2f; // Min x değeri
        x2 = transform.position.x + col.bounds.size.x / 2f; // Max x değeri
    }

    private void Start()
    {
        StartCoroutine(SpawnFruit());
    }

    private IEnumerator SpawnFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(spawnIntervalMin, spawnIntervalMax));

            Vector3 spawnPosition = transform.position;
            spawnPosition.x = Random.Range(x1, x2); // Rastgele x değeri

            GameObject spawnedFruit = Instantiate(fruits[Random.Range(0, fruits.Length)], spawnPosition, Quaternion.identity);

            StartCoroutine(DestroyFruitAfterDelay(spawnedFruit, 5f)); // 5 saniye sonra meyveyi yok et
        }
    }

    private IEnumerator DestroyFruitAfterDelay(GameObject fruit, float delay)
    {
        yield return new WaitForSeconds(delay);

        if (fruit != null)
        {
            Destroy(fruit);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Bomb"))
        {
            score--;
            print(score);
           // Destroy(other.gameObject);
            //Destroy(gameObject); // Game Over
        }
        else if (other.CompareTag("Fruit"))
        {
            
            score++; // Her meyveyi yakaladığınızda puanı artırır
            print(score); // Puanı yazdırır
        }
    }
}
