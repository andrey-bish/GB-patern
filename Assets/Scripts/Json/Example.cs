using System;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace Json
{
    public class Example: MonoBehaviour
    {
        private readonly JsonSerializator _serializator = new JsonSerializator();
        public void Start()
        {
            string _path = Application.dataPath + "/JsonData.json";
            if (!File.Exists(_path)) Debug.Log(_path);
            var resultEnemy = _serializator.Deserialize(_path);
            IEnemy[] enemies = new IEnemy[resultEnemy.Length];
            var compositFactory = new CompositFactory();

            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i] = compositFactory.Create(resultEnemy[i].Unit.Health, resultEnemy[i].Unit.Type);
            }
        }
    }
}
