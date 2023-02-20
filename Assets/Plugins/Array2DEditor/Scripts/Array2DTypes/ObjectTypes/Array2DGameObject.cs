using UnityEngine;
using UnityEngine.UI;
namespace Array2DEditor
{
    [System.Serializable]
    public class Array2DGameObject : Array2D<RawImage>
    {
        [SerializeField]
        CellRowGamObject[] cells = new CellRowGamObject[6];

        protected override CellRow<RawImage> GetCellRow(int idx)
        {
            return cells[idx];
        }
    }
}