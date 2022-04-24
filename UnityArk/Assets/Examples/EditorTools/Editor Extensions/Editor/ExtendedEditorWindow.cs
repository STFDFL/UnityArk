using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Ark.Examples.EditorExtensions
{
    public class ExtendedEditorWindow : EditorWindow
    {
        protected SerializedObject serializedObject;
        protected SerializedProperty currentProperty;

        private string selectedPropertyPath;
        protected SerializedProperty selectedProperty;


        protected void DrawProperties(SerializedProperty prop, bool drawChildren)
        {
            string lastPropPath = string.Empty;
            foreach (SerializedProperty p in prop)
            {
                if (p.isArray && p.propertyType == SerializedPropertyType.Generic)
                {
                    EditorGUILayout.BeginHorizontal();
                    p.isExpanded = EditorGUILayout.Foldout(p.isExpanded, p.displayName);
                    EditorGUILayout.EndHorizontal();

                    if (p.isExpanded)
                    {
                        EditorGUI.indentLevel++;
                        DrawProperties(p, drawChildren);
                        EditorGUI.indentLevel--;
                    }
                }
                else
                {
                    if (!string.IsNullOrEmpty(lastPropPath) && p.propertyPath.Contains(lastPropPath))
                        continue;
                    
                    lastPropPath = p.propertyPath;
                    EditorGUILayout.PropertyField(p, drawChildren);
                }
            }
        }


        protected void DrawSidebar(SerializedProperty prop)
        {
            foreach (SerializedProperty p in prop)
            {
                if (GUILayout.Button(p.displayName))
                {
                    selectedPropertyPath = p.propertyPath;
                }
                EditorGUILayout.Space(1);
            }

            if (!string.IsNullOrEmpty(selectedPropertyPath))
            {
                selectedProperty = serializedObject.FindProperty(selectedPropertyPath);
            }
        }


        protected void DrawField(string propName, bool relative)
        {
            if (relative && currentProperty != null)
            {
                var prop = currentProperty.FindPropertyRelative(propName);
                if (prop == null)
                    Debug.LogError($"Cannot draw property {propName} from {currentProperty.name}.");
                else
                    EditorGUILayout.PropertyField(prop, true);
            }
            else if (serializedObject != null)
            {
                var prop = serializedObject.FindProperty(propName);
                if (prop == null)
                    Debug.LogError($"Cannot draw property {propName} from serializedObject {serializedObject}, not found.");
                else
                    EditorGUILayout.PropertyField(prop, true);
            }
        }

        protected void Apply()
        {
            serializedObject.ApplyModifiedProperties();
        }
    }


}
