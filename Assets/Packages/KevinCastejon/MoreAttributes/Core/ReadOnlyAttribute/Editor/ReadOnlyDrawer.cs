using UnityEngine;
using UnityEditor;

namespace KevinCastejon.MoreAttributes
{
    [CustomPropertyDrawer(typeof(ReadOnlyAttribute))]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            // Pour d�sactiver l'UI (rendre en lecture seule)
            EditorGUI.BeginDisabledGroup(true);

            // On dessine la propri�t�
            EditorGUI.PropertyField(position, property, label);

            // On r�active l'UI
            EditorGUI.EndDisabledGroup();
        }
    }
}