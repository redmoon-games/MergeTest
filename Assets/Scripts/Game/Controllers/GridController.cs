using System;
using UnityEngine;

namespace Game.Controllers
{
    public class GridController : MonoBehaviour
    {
        [SerializeField] private int columnCount;
        [SerializeField] private int rowCount;
        [SerializeField] private Grid grid;
        [SerializeField] private GameObject prefabCell;

        private Transform[,] _cells;
        
        private void Start()
        {
            _cells = new Transform[columnCount, rowCount];
            for (int i = 0; i < columnCount; i++)
            {
                for (int k = 0; k < rowCount; k++)
                {
                    var localPos = grid.GetCellCenterLocal(new Vector3Int(k, i, 0));
                    _cells[i, k] = Instantiate(prefabCell, localPos, Quaternion.identity, transform).transform;
                }
            }

            var width = columnCount * (grid.cellGap.x * 1 + grid.cellSize.x);
            var height = columnCount * (grid.cellGap.y * 1 + grid.cellSize.y);
            
            transform.position -= new Vector3(width, height) / 2;
        }
    }
}
