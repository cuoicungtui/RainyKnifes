using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject Knife;

    private float Min_X  = -1.9f;

    private float Max_X = 3.86f;


    public float Min_t = 0.2f;

    public float Max_t = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSpawning());
        
    }

    IEnumerator StartSpawning()
    {
        yield return new WaitForSeconds(Random.Range(Min_t, Max_t));

        GameObject k = Instantiate(Knife);

        float x = Random.Range(Min_X, Max_X);

        k.transform.position = new Vector2(x, transform.position.y);

        Destroy(k, 5f);

       // Debug.Log("x = "+ x);

        StartCoroutine(StartSpawning());

    }
}
