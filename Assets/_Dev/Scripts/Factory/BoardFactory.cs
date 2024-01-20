﻿using System.Collections.Generic;
using _Dev.Providers;
using _Dev.Scripts.Data;
using Unity.Mathematics;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Dev.Scripts.Factory
{
    public class BoardFactory
    {
        public BoardData CreateBoard(int width, int height)
        {
            var startPosition = new Vector3(-width / 2f, -height / 2f);
            var cellPresenterPrefab = ServiceLocator.Instance.Get<PrefabProvider>().CellPresenter;
            var cellDictionary = new Dictionary<Vector2Int, Cell>();
            
            for (var x = 0; x < width; x++)
            {
                for (var y = 0; y < height; y++)
                {
                    var position = startPosition + new Vector3(x, y);
                    var cellPresenter = Object.Instantiate(cellPresenterPrefab, position, Quaternion.identity);
                    var pos = new Vector2Int(x, y);
                    var cell = new Cell(ItemFactory.CreateRandomItem(), pos);
                    cellDictionary.Add(pos, cell);
                    
                    cellPresenter.Initialize(cell, x + y);
                }
            }

            return new BoardData(width, height, cellDictionary);
        }
    }
}