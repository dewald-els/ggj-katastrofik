using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeEnergySpawner : MonoBehaviour
{
    public GameObject negativeEnergy;
    public int numberOfEnergies = 5;

    void Start()
    {
        for (int i = 0; i < numberOfEnergies; i++)
        {
            Vector2 spawnPosition = RandomSpawnPosition();
            Debug.Log(spawnPosition);
            Instantiate(negativeEnergy, spawnPosition, Quaternion.identity);
        }
    }

    public Vector2 RandomSpawnPosition()
    {
        // Source: http://answers.unity.com/comments/1325774/view.html
        Vector3 postition = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Random.Range(0, Screen.width),
                Random.Range(0, Screen.height),
                0
            )
        );

        return new Vector2(
            postition.x,
            postition.y
        );
    }

}
