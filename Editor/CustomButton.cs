#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CovalentNft))]
public class CustomButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        CovalentNft e = (CovalentNft)target;
        if (GUILayout.Button("Preview"))
        {
            e.PreviewNft();
        }
    }
}
#endif
