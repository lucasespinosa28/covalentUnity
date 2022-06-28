#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GetNftMetadata))]
public class CustomButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        GetNftMetadata e = (GetNftMetadata)target;
        if (GUILayout.Button("Preview"))
        {
            e.PreviewNft();
        }
    }
}
#endif
