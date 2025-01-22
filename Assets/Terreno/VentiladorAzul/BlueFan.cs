using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFan : MonoBehaviour
{
    [SerializeField] float timePerBubble;
    [SerializeField] float timePerSmallBubble;

    public GameObject bubblePrefab;
    public GameObject smallBubblePrefab;
    public Transform spawnPoint;

    private float currentBubbleSpawnTime;
    private float currentSmallBubbleSpawnTime;

    // Start is called before the first frame update
    void Start()
    {
        currentBubbleSpawnTime = 0;
        Instantiate(bubblePrefab, spawnPoint.position, spawnPoint.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        currentBubbleSpawnTime += Time.deltaTime;
        if(currentBubbleSpawnTime > timePerBubble)
        {
            currentBubbleSpawnTime = 0;
            Instantiate(bubblePrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
