using System.Collections.Generic;
using _Dev.Providers;
using _Dev.Scripts.Data;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Dev.Scripts.Factory
{
    public class BoardFactory
    {
        public BoardData CreateRandomBoard(int width, int height)
        {
            var startPosition = new Vector3(-width / 2f, -height / 2f);
            var cellPresenterPrefab = ServiceLocator.Instance.Get<PrefabProvider>().CellPresenter;
            var cells = new Cell[width][];

            for (var i = 0; i < cells.GetLength(0); i++)
                cells[i] = new Cell[height];

            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var position = startPosition + new Vector3(x, y);
                    var cellPresenter = Object.Instantiate(cellPresenterPrefab, position, Quaternion.identity);
                    var pos = new Vector2Int(x, y);
                    var cell = new Cell(ItemFactory.CreateRandomItem(), pos);
                    cells[x][y] = cell;
                    
                    cellPresenter.Initialize(cell, x + y);
                }
            }

            return new BoardData(width, height, cells);
        }
        
        public BoardData CreateBoard(int width, int height, IReadOnlyList<ItemData> items)
        {
            var startPosition = new Vector3(-width / 2f, -height / 2f);
            var cellPresenterPrefab = ServiceLocator.Instance.Get<PrefabProvider>().CellPresenter;
            var cells = InitEmptyBoard(width, height);

            foreach (var item in items)
            {
                var position = startPosition + new Vector3(item.XCoord, item.YCoord);
                var cellPresenter = Object.Instantiate(cellPresenterPrefab, position, Quaternion.identity);
                var pos = new Vector2Int(item.XCoord, item.YCoord);
                var cell = new Cell(item, pos);
                cells[item.XCoord][item.YCoord] = cell;
                cellPresenter.Initialize(cell, item.XCoord + item.YCoord);
            }

            return new BoardData(width, height, cells);
        }
        
        private static Cell[][] InitEmptyBoard(int w, int h)
        {
            var cells = new Cell[w][];

            for (var i = 0; i < cells.GetLength(0); i++)
                cells[i] = new Cell[h];

            return cells;
        }
    }
}