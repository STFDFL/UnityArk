using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

namespace Ark.Examples.EditorExtensions
{
    public class GameDataObjectEditorWindow : ExtendedEditorWindow
    {
        AnimBool showExtraFields;




        public static void Open(GameDataObject dataObject)
        {
            GameDataObjectEditorWindow window = GetWindow<GameDataObjectEditorWindow>("Game Data Editor");
            window.serializedObject = new SerializedObject(dataObject);
        }

        private void OnGUI()
        {
            currentProperty = serializedObject.FindProperty("gameData");

            EditorGUILayout.BeginHorizontal();

            EditorGUILayout.BeginVertical("box",GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));
            DrawSidebar(currentProperty);
            EditorGUILayout.EndVertical();

            EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
            if (selectedProperty != null)
            {
                DrawSelectedPropertiesPanel();
            }
            else
            {
                EditorGUILayout.LabelField("Select an item from the list");
            }
            EditorGUILayout.EndVertical();

            EditorGUILayout.EndHorizontal();

            Apply();
        }


        void OnEnable()
        {
            showExtraFields = new AnimBool(true);
            showExtraFields.valueChanged.AddListener(Repaint);
        }


        private void DrawSelectedPropertiesPanel()
        {
            currentProperty = selectedProperty;

            EditorGUILayout.BeginHorizontal();
            DrawCharStats();
            DrawCharInfo();
            EditorGUILayout.EndHorizontal();
        }

        private void DrawCharStats()
        {
            //Extra block that can be toggled on and off.
            EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
            showExtraFields.target = EditorGUILayout.ToggleLeft("Show Char Stats", showExtraFields.target);
            if (EditorGUILayout.BeginFadeGroup(showExtraFields.faded))
            {
                EditorGUI.indentLevel++;
                EditorGUILayout.PrefixLabel("Stats");
                DrawField("strenght", true);
                DrawField("intellect", true);
                DrawField("charisma", true);
                DrawField("dexterity", true);
                EditorGUI.indentLevel--;
            }
            EditorGUILayout.EndFadeGroup();
            EditorGUILayout.EndVertical();
        }

        private void DrawCharInfo()
        {
            EditorGUILayout.BeginVertical("box", GUILayout.ExpandHeight(true));
            DrawField("name", true);
            DrawField("isHero", true);
            DrawField("race", true);
            DrawField("health", true);
            EditorGUILayout.EndVertical();

        }
    }

}
