// using Gameplay.Levels.Configs;
// using UnityEditor;
// using UnityEngine;
//
// namespace Gameplay.Levels
// {
//     public class LevelEditorHelper : MonoBehaviour
//     {
//         [SerializeField] private LevelTransferConfig _levelConfig;
//         [SerializeField] private LaneConfig _laneSystem;
//         [SerializeField] private GameObject collectibleMarkerPrefab;
//         [SerializeField] private GameObject playerSpawnMarkerPrefab;
//
//         [ContextMenu("Generate Ground & Markers")]
//         public void GenerateLevel()
//         {
//             ClearAll();
//             float segmentLength = GetGroundLength();
//
//             for (int i = 0; i < _levelConfig.GroundSegments.Count; i++)
//             {
//                 float baseZ = i * segmentLength;
//                 Vector3 position = new Vector3(0, 0, baseZ);
//                 GameObject segment = PrefabUtility.InstantiatePrefab(_levelConfig.GroundPrefab) as GameObject;
//                 segment.transform.position = position;
//                 segment.name = $"GroundSegment_{i}";
//                 segment.transform.SetParent(transform);
//
//                 var data = _levelConfig.GroundSegments[i];
//
//                 foreach (var obs in data.Obstacles)
//                 {
//                     Vector3 pos = _laneSystem.GetWorldPosition(obs.Lane, baseZ + obs.LocalZ);
//                     GameObject obj = PrefabUtility.InstantiatePrefab(obs.ObstaclePrefab) as GameObject;
//                     obj.transform.position = pos;
//                     obj.name = $"Obstacle_{obs.ObstaclePrefab.name}_{obs.Lane}_{obs.LocalZ}";
//                     obj.transform.SetParent(transform);
//                 }
//
//                 foreach (var group in data.Coins)
//                 {
//                     for (int j = 0; j < group.Count; j++)
//                     {
//                         float z = baseZ + group.StartZ + j * group.StepZ;
//                         Vector3 pos = _laneSystem.GetWorldPosition(group.Lane, z);
//                         GameObject marker = PrefabUtility.InstantiatePrefab(collectibleMarkerPrefab) as GameObject;
//                         marker.transform.position = pos;
//                         marker.name = $"CollectibleMarker_{group.Type}_{z}";
//                         marker.transform.SetParent(transform);
//                     }
//                 }
//             }
//
//             Vector3 playerPos = _levelConfig.PlayerSpawn.Position;
//             GameObject playerMarker = PrefabUtility.InstantiatePrefab(playerSpawnMarkerPrefab) as GameObject;
//             playerMarker.transform.position = playerPos;
//             playerMarker.name = "PlayerSpawnMarker";
//             playerMarker.transform.SetParent(transform);
//         }
//
//         [ContextMenu("Clear All")]
//         public void ClearAll()
//         {
//             foreach (Transform child in transform)
//                 DestroyImmediate(child.gameObject);
//         }
//
//         private float GetGroundLength()
//         {
//             if (!_levelConfig.GroundPrefab.TryGetComponent(out Renderer renderer))
//             {
//                 Debug.LogWarning("Ground prefab has no renderer; using default length = 71");
//                 return 71f;
//             }
//
//             return renderer.bounds.size.z;
//         }
//     }
// }