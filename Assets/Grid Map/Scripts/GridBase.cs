using UnityEngine;

namespace LLFramework
{
    public class GridBase : MonoBehaviour
    {
        [SerializeField] Vector2Int mapSize;
        [SerializeField] GameObject prefab;

        public void GenerateMap()
        {
            for(int i = 0; i < mapSize.x; i++)
            {
                for (int j = 0; j < mapSize.y; j++)
                {
                    Instantiate(prefab, new Vector3(i, 0, j), transform.rotation);
                }
            }
        }

        void Awake()
        {
            GenerateMap();
        }
    }
}
