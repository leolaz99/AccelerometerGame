using UnityEngine;
using LLFramework;

public class TileLabyrinth : TileBase
{
    enum Type
    {
        Hole,
        Wall,
        Floor,
    }

    [SerializeField] Type type;
}
