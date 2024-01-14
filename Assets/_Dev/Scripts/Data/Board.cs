using System;
using _Dev.Providers;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Dev.Scripts.Data
{
    public readonly struct Board
    {
        private readonly int _boardWidth;
        private readonly int _boardHeight;
        private readonly CellPresenter _cellPresenter;

        public Board(int boardWidth, int boardHeight)
        {
            _boardWidth = boardWidth;
            _boardHeight = boardHeight;
            _cellPresenter = ServiceLocator.Instance.Get<PrefabProvider>().CellPresenter;
        }

        public void CreateBoard()
        {
            var startPosition = new Vector3(-_boardWidth / 2f, -_boardHeight / 2f);
            
            for (var x = 0; x < _boardWidth; x++)
            {
                for (var y = 0; y < _boardHeight; y++)
                {
                    var position = startPosition + new Vector3(x, y);
                    var itemType = (ItemType) Enum.GetValues(typeof(ItemType)).GetValue(Random.Range(1, 7));
                    var cell = Object.Instantiate(_cellPresenter, position, Quaternion.identity);
                    cell.Initialize(ItemContainer.GetItemDataByType(itemType), x + y);
                }
            }
        }
    }
}