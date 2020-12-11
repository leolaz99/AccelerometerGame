using UnityEngine;

namespace LLFramework
{ 
    [System.Serializable]
    public struct Mod
    {
        public Vector2Int position;
        public int type;
    }


    public class GridBase : MonoBehaviour
    {
        [SerializeField] Vector2Int mapSize;
        [SerializeField] GameObject prefabFloor;
        [SerializeField] GameObject prefabWall;
        [SerializeField] GameObject prefabHole;
        [SerializeField] Mod[] mods;
        TileBase[,] tile;
    
        public void GenerateMap()
        {
            tile = new TileBase[mapSize.x, mapSize.y];

            for(int i = 0; i < mapSize.x; i++)
            {
                for (int j = 0; j < mapSize.y; j++)
                {
                    if (i == 0 || j == mapSize.y - 1 || i == mapSize.x - 1 || j == 0)
                    {
                        tile[i, j] = Instantiate(prefabWall, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();
                        tile[i, j].id = 1;
                    }

                    else
                    {
                        int rand = Random.Range(0, 2);
                        if (rand == 0)
                        {
                            tile[i, j] = Instantiate(prefabHole, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();
                            tile[i, j].id = 0;
                        }

                        else
                        {
                            tile[i, j] = Instantiate(prefabFloor, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();
                            tile[i, j].id = 2;
                        }
                    }

                    for (int c = 0; c < mods.Length; c++)
                    {
                        if (mods[c].position.x == i && mods[c].position.y == j)
                        {
                            if (mods[c].type == 0)
                                tile[i, j] = Instantiate(prefabHole, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();

                            if (mods[c].type == 1)
                                tile[i, j] = Instantiate(prefabWall, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();

                            if (mods[c].type == 2)
                                tile[i, j] = Instantiate(prefabFloor, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();
                        }
                    }
                }
            }           
        }
    }
}