using UnityEngine;

namespace LLFramework
{
    public class GridBase : MonoBehaviour
    {
        [SerializeField] Vector2Int mapSize;
        [SerializeField] GameObject prefabFloor;
        [SerializeField] GameObject prefabWall;
        [SerializeField] GameObject prefabHole;

        TileBase[,] tile;
        //public TileBase[] t;

        public void GenerateMap()
        {
            tile = new TileBase[mapSize.x, mapSize.y];
            int x = mapSize.x * mapSize.y;
            //t = new TileBase[x];
            //int n = 0;
            

            for(int i = 0; i < mapSize.x; i++)
            {
                for (int j = 0; j < mapSize.y; j++)
                {
                    if(i==0 || j==mapSize.y-1 || i == mapSize.x-1 || j == 0)
                    {
                        tile[i, j] = Instantiate(prefabWall, new Vector3(i, 0, j), transform.rotation).GetComponent<TileBase>();                      
                        tile[i, j].id = 1;
                        //n++;
                        //t[n-1] = tile[i, j];
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
                }
            }           
        }
    }
}