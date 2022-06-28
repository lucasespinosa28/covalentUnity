#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(NftMetadata))]
public class CustomButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        NftMetadata e = (NftMetadata)target;
        if (GUILayout.Button("Preview"))
        {
            e.PreviewNft();
        }
    }
}
#endif
