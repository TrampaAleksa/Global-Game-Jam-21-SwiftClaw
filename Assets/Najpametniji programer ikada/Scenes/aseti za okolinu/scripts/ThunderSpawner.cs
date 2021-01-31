using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderSpawner : MonoBehaviour
{
    public GameObject[] lightings;
    public Transform[] spawnPoints;
    private Transform nextCheckPoint;

    public int spawnSecondsMin = 0;
    public int spawnSecondsMax = 10;

    float spawnTime;
    public float soundTime=1f;
    public float destroyThunderTime = 0.9f;
    public AudioSource thunderSound;


    void Start()
    {
        StartCoroutine(StartSpawning());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator StartSpawning()
    {
        spawnTime = Random.Range(spawnSecondsMin, spawnSecondsMax);

        yield return new WaitForSeconds(spawnTime);       
        GameObject lighting=Instantiate(lightings[Random.Range(0, lightings.Length)],spawnPoints[Random.Range(0, spawnPoints.Length)].position, Random.rotation);

        yield return new WaitForSeconds(soundTime);
        thunderSound.Play();

        yield return new WaitForSeconds(destroyThunderTime);
        Destroy(lighting);



        StartCoroutine(StartSpawning());
    }

}
