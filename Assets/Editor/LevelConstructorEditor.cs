using UnityEditor;
using UnityEngine;
using Gameplay.Levels.Configs;
using Gameplay.Obstacles;
using Gameplay.Obstacles.Configs;

namespace Editor
{
    [CustomEditor(typeof(LevelConstructor))]
    public class LevelConstructorEditor : UnityEditor.Editor
    {
        private const float GroundLength = 71f;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Generate Obstacles + Ground"))
            {
                GenerateObstaclesAndGround((LevelConstructor)target);
            }
        }

        private void GenerateObstaclesAndGround(LevelConstructor config)
        {
            ClearSceneGeneratedObjects();

            ObstacleConfig obstacleConfig = LoadObstacleConfig();
            if (!obstacleConfig)
            {
                Debug.LogError("ObstacleConfig not found!");
                return;
            }

            for (int i = 0; i < config.GroundSegments.Count; i++)
            {
                float baseZ = i * GroundLength;
                var segment = config.GroundSegments[i];

                // Ground
                GameObject ground = (GameObject)PrefabUtility.InstantiatePrefab(config.GroundPrefab);
                ground.name = $"GroundSegment_{i}";
                ground.transform.position = new Vector3(0f, 0f, baseZ);

                // Obstacles
                for (int j = 0; j < segment.Obstacles.Count; j++)
                {
                    var group = segment.Obstacles[j];
                    GameObject groupParent = new GameObject($"ObstacleGroup_{i}_{j}");
                    groupParent.transform.SetParent(ground.transform);

                    SpawnObstaclePrefab(group, baseZ, groupParent.transform, obstacleConfig);
                }
            }

            Debug.Log("Ground and obstacles generated.");
        }

        private void SpawnObstaclePrefab(ObstacleGroup group, float baseZ, Transform parent, ObstacleConfig config)
        {
            Obstacle prefab = config.GetPrefab(group.Type);
            if (!prefab)
            {
                Debug.LogWarning($"No prefab found for ObstacleType: {group.Type}");
                return;
            }

            float z = baseZ + group.LocalZ;
            float x = (int)group.Lane * 3f;
            Vector3 pos = new(x, 0f, z);

            GameObject obstacleGO = (GameObject)PrefabUtility.InstantiatePrefab(prefab.gameObject);
            obstacleGO.name = $"{group.Type}_{z}";
            obstacleGO.transform.position = pos;
            obstacleGO.transform.SetParent(parent);
        }

        private void ClearSceneGeneratedObjects()
        {
            foreach (var go in GameObject.FindObjectsOfType<GameObject>())
            {
                if (go.name.StartsWith("GroundSegment_"))
                    DestroyImmediate(go);
            }
        }

        private ObstacleConfig LoadObstacleConfig()
        {
            string[] guids = AssetDatabase.FindAssets("t:ObstacleConfig");
            if (guids.Length == 0) return null;

            string path = AssetDatabase.GUIDToAssetPath(guids[0]);
            return AssetDatabase.LoadAssetAtPath<ObstacleConfig>(path);
        }
    }
}
