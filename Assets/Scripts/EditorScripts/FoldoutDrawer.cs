using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(FoldoutAttribute))]
public class FoldoutDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        FoldoutAttribute foldoutAttribute = (FoldoutAttribute)attribute;
        foldoutAttribute.FoldedOut = EditorGUI.Foldout(position, foldoutAttribute.FoldedOut, foldoutAttribute.Name, true);

        if (foldoutAttribute.FoldedOut)
        {
            EditorGUI.PropertyField(position, property, label, true);
        }
    }

    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        FoldoutAttribute foldoutAttribute = (FoldoutAttribute)attribute;
        if (!foldoutAttribute.FoldedOut)
        {
            return 0;
        }
        return EditorGUI.GetPropertyHeight(property, label);
    }
}
