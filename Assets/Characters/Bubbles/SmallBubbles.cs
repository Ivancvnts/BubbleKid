using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBubbles : MonoBehaviour
{
    [SerializeField] float minLifeTime;
    [SerializeField] float maxLifeTime;

    private float currentLifeTime;
    private float duration;

    // Start is called before the first frame update
    void Start()
    {
        currentLifeTime = 0;
        duration = Random.Range(minLifeTime, maxLifeTime);
    }

    // Update is called once per frame
    void Update()
    {   

        currentLifeTime += Time.deltaTime;

        if (currentLifeTime > duration)
        {
            Destroy(gameObject);
        }
    }
}
