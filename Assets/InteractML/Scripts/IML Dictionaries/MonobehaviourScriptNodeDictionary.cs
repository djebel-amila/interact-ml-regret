﻿using UnityEngine;

namespace InteractML
{
    /// <summary>
    /// Class that holds a serializable dictionary 
    /// </summary>
    [System.Serializable]
    public class MonobehaviourScriptNodeDictionary : SerializableDictionary<MonoBehaviour, ScriptNode>
    {
    }
}
