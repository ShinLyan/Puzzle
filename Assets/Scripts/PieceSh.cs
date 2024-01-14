using UnityEngine;
using UnityEngine.Rendering;

public class PieceSh : MonoBehaviour
{
    private Vector3 _rightPosition;
    public bool InRightPosition { get; set; }
    public bool IsSelected { get; set; }

    private void Start()
    {
        _rightPosition = transform.position;
        transform.position = new Vector3(Random.Range(6, 13), Random.Range(-5, 5));
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, _rightPosition) < 0.5f)
        {
            if (!IsSelected)
            {
                if (InRightPosition == false)
                {
                    transform.position = _rightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }



            }
        }
    }
}
