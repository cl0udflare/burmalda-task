using System.Collections.Generic;
using Gameplay.Levels.Configs;
using Gameplay.Levels.Markers;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(LevelTransferConfig))]
    public class LevelTransferConfigEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Find Markers In Scene"))
            {
                FindMarkersInScene((LevelTransferConfig)target);
            }
        }
        
        [ContextMenu("Find Markers In Scene")]
        public void FindMarkersInScene(LevelTransferConfig config)
        {
            PlayerSpawnMarker playerMarker = FindFirstObjectByType<PlayerSpawnMarker>();
            if (!playerMarker)
            {
                Debug.Log("No PlayerSpawnMarker found in scene!");
            }
            else
            {
                config.PlayerSpawn = new PlayerSpawnData
                {
                    Position = playerMarker.transform.position,
                };
            }

            CollectibleSpawnMarker[] collectibleMarkers = FindObjectsByType<CollectibleSpawnMarker>(FindObjectsSortMode.None);
            config.Collectibles = new List<CollectibleSpawnData>();

            foreach (CollectibleSpawnMarker marker in collectibleMarkers)
            {
                config.Collectibles.Add(new CollectibleSpawnData
                {
                    Type = marker.Type,
                    Position = marker.transform.position,
                });
            }

            Debug.Log($"Collected {config.Collectibles.Count} collectible markers.");

            EditorUtility.SetDirty(config);
            AssetDatabase.SaveAssets();
        }
    }
}