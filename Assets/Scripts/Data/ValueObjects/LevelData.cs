using System;
using System.Collections.Generic;
using UnityEngine;

namespace Data.ValueObjects
{
    [Serializable]
    public struct LevelData
    {
        public List<PoolData> PoolList;

        public LevelData(List<PoolData> poolList)
        {
            PoolList = poolList;
        }
    }

    [Serializable]
    public struct PoolData
    {
        public int RequiredObjectCount;
    }
}