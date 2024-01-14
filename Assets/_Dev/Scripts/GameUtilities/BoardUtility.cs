using System;
using _Dev.Providers;
using _Dev.Scripts.Data;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace _Dev.Scripts.GameUtilities
{
    public static class BoardUtility
    {
        public static void CreateBoard(BoardData boardData)
        {
            var startPosition = new Vector3(-boardData.X / 2f, -boardData.Y / 2f);
            var _cellPresenter = ServiceLocator.Instance.Get<PrefabProvider>().CellPresenter;
            
            for (var x = 0; x < boardData.X; x++)
            {
                for (var y = 0; y < boardData.Y; y++)
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