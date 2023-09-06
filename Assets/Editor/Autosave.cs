using UnityEngine;
using UnityEditor.SceneManagement;
using UnityEditor;

[InitializeOnLoad]
public class Autosave
{

    static Autosave()
    {
        EditorApplication.playModeStateChanged += SaveOnPlay;
    }

    // запуск при входе/выходе из состояния режима воспроизведения
    public static void SaveOnPlay(PlayModeStateChange state)
    {
        // срабатывает каждый раз при нажатии кнопки воспроизведения
        if (state == PlayModeStateChange.ExitingEditMode)
        {
            Debug.Log("Autosaving...");
            EditorSceneManager.SaveOpenScenes();
            AssetDatabase.SaveAssets();
        }
    }
    
    
}
