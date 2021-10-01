
using UnityEngine;

public class Utils : MonoBehaviour
{
    public static Ray ScreenToWorld(Camera camera, Vector2 pos)
    {
        return camera.ScreenPointToRay(pos);
    }
}
