using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEngine.SceneManagement;


[CustomEditor(typeof(MapTrigger))]
public class LevelSelector : Editor {

    public override void OnInspectorGUI () {                   
        MapTrigger MYTrigger = (MapTrigger)target;
        EditorGUILayout.LabelField("Это загрузчик уровня?");
        MYTrigger.StartBattlePoint = EditorGUILayout.Toggle(MYTrigger.StartBattlePoint);
        EditorGUILayout.Separator();
        if (MYTrigger.StartBattlePoint == true)
        {            
            MYTrigger.LevelNumber = EditorGUILayout.IntField("LevelNumber",MYTrigger.LevelNumber);
            if (MYTrigger.LevelNumber >= 0 && EditorBuildSettings.scenes.Length > MYTrigger.LevelNumber)
            {               
                EditorGUILayout.LabelField(EditorBuildSettings.scenes[MYTrigger.LevelNumber].path);
            }
            else EditorGUILayout.LabelField("Нет такой сцены");
        }
        else
        {
            EditorGUILayout.LabelField("Объекты взаимодействия");
            EditorGUILayout.HelpBox("При входе в триггер в аниматоре включается Play, при выходе наоборот", MessageType.Info);
            MYTrigger.a = EditorGUILayout.Foldout(MYTrigger.a, "Objects");
            if(MYTrigger.a)
            {
                for(int i=0;i< MYTrigger.MapObjects.Count; i++)
                {
                    if (MYTrigger.MapObjects[i] == null) MYTrigger.MapObjects.RemoveAt(i);
                }
                MYTrigger.b = EditorGUILayout.IntField("Size",MYTrigger.b);                
                for (int i = 0; i< MYTrigger.b; i++)
                {                  
                    GameObject obj = null;
                    if(MYTrigger.MapObjects.Count<=i) MYTrigger.MapObjects.Add(obj);
                    MYTrigger.MapObjects[i] = EditorGUILayout.ObjectField("Element " + i, MYTrigger.MapObjects[i], typeof(GameObject),true) as GameObject;                   
                   
                }         
            }

            

        }
        
        

	}
}
