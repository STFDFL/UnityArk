using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Ark.Examples.EditorExtensions
{

    public class AssetHandler
    {
        [OnOpenAsset()]
        public static bool OpenEditor(int instanceId, int line)
        {
            GameDataObject obj = EditorUtility.InstanceIDToObject(instanceId) as GameDataObject;
            if (obj != null)
            { 
                GameDataObjectEditorWindow.Open(obj);
                return true;
            }
            return false;
        }
    }

    [CustomEditor(typeof(GameDataObject))]
    public class GameDataObjectCustomEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Open Editor"))
            {
                GameDataObjectEditorWindow.Open((GameDataObject)target);
            }
            base.OnInspectorGUI();
        }
    }

}
