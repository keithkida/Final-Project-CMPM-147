// using UnityEngine;

// public class MapPlayerSpawn : MonoBehaviour
// {
//     public int currentMapIndex = 0;

//     void Start()
//     {
//         SpawnPlayer();
//     }

//     void SpawnPlayer()
//     {
//         // NEW API — no more warnings
//         PlayerSpawnPoint[] points = FindObjectsByType<PlayerSpawnPoint>(FindObjectsSortMode.None);

//         foreach (var point in points)
//         {
//             if (point.mapIndex == currentMapIndex)
//             {
//                 var player = FindFirstObjectByType<PlayerStats>();
//                 if (player != null)
//                 {
//                     player.transform.position = point.transform.position;
//                     return;
//                 }
//             }
//         }

//         Debug.LogWarning("No matching PlayerSpawnPoint found!");
//     }
// }
