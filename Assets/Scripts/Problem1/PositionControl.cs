using UnityEngine;

public class PositionControl : MonoBehaviour
{
    [SerializeField] private Transform[] toControl;

    void Start()
    {
        Vector2 pos = transform.position;

        for (int i = 0; i < toControl.Length; i++)
        {
            if (Vector2.Distance(toControl[i].position, transform.position) != 0)
                toControl[i].position = pos;
        }
    }
}
