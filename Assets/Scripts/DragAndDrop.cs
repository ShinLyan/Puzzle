using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDrop : MonoBehaviour
{
    public GameObject SelectedPiece;

    private int _orderInLayer = 1;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.transform.CompareTag("Piece"))
            {
                if (!hit.transform.GetComponent<PieceSh>().InRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PieceSh>().IsSelected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = _orderInLayer;
                    _orderInLayer++;
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PieceSh>().IsSelected = false;
                SelectedPiece = null;
            }
        }

        if (SelectedPiece != null)
        {
            var mousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(mousePoint.x, mousePoint.y, 0);
        }
    }
}
