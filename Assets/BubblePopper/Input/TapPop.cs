
using UnityEngine;

public class TapPop : MonoBehaviour
{
    private InputManager IM;

    private void Awake()
    {
        IM = InputManager.Instance;
    }

    private void OnEnable()
    {
        IM.onStartTouch += tapStart;
    }
    private void OnDisable()
    {

        IM.onStartTouch -= tapStart;
    }

    private void tapStart(Ray r, float time)
    {

        RaycastHit hit;
        if (Physics.SphereCast(r.origin, .1f, r.direction, out hit, 100f)){
            if (hit.transform.tag == "Bubble")
            {
                hit.transform.gameObject.GetComponent<BubbleControl>().pop();
            }
            
        }
    }

}
