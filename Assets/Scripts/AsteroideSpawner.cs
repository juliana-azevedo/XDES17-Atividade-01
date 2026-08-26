using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class AsteroideSpawner : MonoBehaviour
{
   List<Transform> spawnPos;
   
   [SerializeField] List<GameObject> asteroidePrefabs; // Alocação de memoria esta sendo feito pelo editor

   void Awake()
   {
      spawnPos = new List<Transform>();

      foreach (Transform child in transform)
      {
         spawnPos.Add(child);
      }
   }

   void Start()
   {
      InvokeRepeating("SpawnAsteroide", 0f, 1.5f);
   }

   void SpawnAsteroide()
   {
      int spawnIndice = Random.Range(0, spawnPos.Count);
      int asteroideIndice = Random.Range(0, asteroidePrefabs.Count);
      
      Instantiate(asteroidePrefabs[asteroideIndice], spawnPos[spawnIndice].position, Quaternion.identity);
   }
  
}
