using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioDataSO", menuName = "SO/AudioData")]
public class AudioDataSO : ScriptableObject
{
    [field: Header("List of AudioData")]
    [field: Tooltip("Some SO Id for task")]
    [field: SerializeField] public string Id;

    [SerializeField] public AudioTypes AudioType;

    [field: Space]
    [field: SerializeField] public List<AudioData> DangerousAudioDatas;
    //[field: SerializeField] public List<AudioData> PeacefulAudioDatas;
    //[field: SerializeField] public List<AudioData> NeutralAudioDatas;

    [TextArea(5, 20)]
    [SerializeField] public string Description;
}

[Serializable]
public class AudioData
{
    [Header("AudioData")]
    [field: SerializeField] public AudioClip AudioClip;
    [field: Range(0f, 1f)]
    [field: SerializeField] public float Volume;
}


[CustomEditor(typeof(AudioDataSO))]
[CanEditMultipleObjects]
public class AudioDataCustomEditor : Editor
{
    private SerializedProperty _idPropety;
    private SerializedProperty _descriptionProperty;

    private SerializedProperty _dangerousAudioDatas;
    private SerializedProperty _peacefulAudioDatas;
    private SerializedProperty _neutralAudioDatas;

    private SerializedProperty _audioDatas;

    private AudioTypes _audioType;

    private bool _showDescription;
    private bool _showList;

    private void OnEnable()
    {
        Debug.Log("Enable Audio Data Custom Editor!");

        _idPropety = serializedObject.FindProperty("Id");
        _descriptionProperty = serializedObject.FindProperty("Description");

        _audioDatas = serializedObject.FindProperty("DangerousAudioDatas");

        //_dangerousAudioDatas = serializedObject.FindProperty("DangerousAudioDatas");
        //_peacefulAudioDatas = serializedObject.FindProperty("PeacefulAudioDatas");
        //_neutralAudioDatas = serializedObject.FindProperty("NeutralAudioDatas");

        //_audioType = serializedObject.FindProperty("AudioType");

        Debug.Log(_idPropety);
        Debug.Log(_descriptionProperty);
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        serializedObject.Update();

        EditorGUILayout.PropertyField(_idPropety);

        switch (_audioType)
        {
            case AudioTypes.Dangerous: Debug.Log("1234");
                break;
            case AudioTypes.Peaceful:
                break;
            case AudioTypes.Neutral:
                break;
        }
        if (GUILayout.Button("Show List"))
        {
            _showList = true;
        }
        
        if (GUILayout.Button("Show List & Description"))
        {
            _showDescription = true;
            _showList = true;
        }
        
        if (GUILayout.Button("Hide List & Description"))
        {
            _showDescription = false;
            _showList = false;
        }

        if (_showDescription)
        {
            EditorGUILayout.PropertyField(_descriptionProperty);
        }
        
        if (_showList)
        {
            EditorGUILayout.PropertyField(_audioDatas);
        }

        serializedObject.ApplyModifiedProperties();
    }
}

public enum AudioTypes
{
    Dangerous,
    Peaceful,
    Neutral
}