using System.Collections.Generic;
using _Dev.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Dev.Scripts.Systems.ServiceLocator
{
    [CreateAssetMenu(fileName = "ServiceDictionary", menuName = "ServiceDictionary")]
    public class ServicesDictionary : SerializedScriptableObject
    {
        public Dictionary<string, IGameService> service;
        
    }
}