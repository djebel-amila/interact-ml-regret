﻿using UnityEngine;
using UnityEditor;
using System.Collections;
using InteractML;

[CustomEditor(typeof(RapidlibComponent))] //name of script you want to created in the editor as a component 
[CanEditMultipleObjects]
public class RapidLibComponentEditor : Editor
{
    private string nameButton;

    public override void OnInspectorGUI()
    {

        RapidlibComponent rapidLib = (RapidlibComponent)target;

        // Show information about runtime keys for interaction
        GUIStyle styleGUIBox = new GUIStyle(GUI.skin.box);
        styleGUIBox.richText = true;
        if (rapidLib.AllowKeyboardShortcuts)
        {
            GUILayout.Box("<b>Runtime Keys:</b>\n <b>Collect Data:</b> Space  | <b>Train:</b> T | <b>Run:</b> R", styleGUIBox);
            //GUILayout.Box("<b>Runtime Keys:</b>\n <b>Run:</b> R", styleGUIBox);
        }

        // DEFAULT INSPECTOR
        DrawDefaultInspector();


        // DESIRED OUTPUT FIELD
        if (rapidLib.outputs != null)
        {
            EditorGUILayout.LabelField("Desired Output: ");
            for (int i = 0; i < rapidLib.outputs.Length; i++)
            {
                rapidLib.outputs[i] = EditorGUILayout.DoubleField("Output " + (i + 1), rapidLib.outputs[i]);

            }
        }

        // If dtw is the learning type...
        if (rapidLib.learningType == EasyRapidlib.LearningType.DTW)
        {
            // NUMBER OF TRAINING SERIES
            int numExampleSeries = (rapidLib.GetTrainingExamplesSeries() != null ? rapidLib.GetTrainingExamplesSeries().Count : 0);
            GUILayout.Label("No. Training Series: " + numExampleSeries);
        }
        // If it is classification or regression...
        else
        {
            // NUMBER OF TRAINING EXAMPLES
            int numExamples = (rapidLib.GetTrainingExamples() != null ? rapidLib.GetTrainingExamples().Count : 0);
            GUILayout.Label("No. Training Examples: " + numExamples);
        }


        // ADD TRAINING EXAMPLE BUTTON
        //if (GUILayout.Button("add training example"))
        //{
        //    rapidLib.AddTrainingExample();
        //}
        nameButton = "";

        // COLLECT DATA BUTTON
        if (rapidLib.CollectingData || rapidLib.Training)
            nameButton = "STOP Collecting Data";
        else
            nameButton = "Collect Data";
        // Disable button if model is runnning
        if (rapidLib.Running || rapidLib.Training)
            GUI.enabled = false;
        if (GUILayout.Button(nameButton))
        {
            rapidLib.ToggleCollectingData();
        }
        // Always enable it back at the end
        GUI.enabled = true;

        // RUN BUTTON
        if (rapidLib.Running)
            nameButton = "STOP Running";
        else
            nameButton = "Run";
        // Disable button if model is Collecting data only for classification and regression
        if (rapidLib.CollectingData && rapidLib.learningType != EasyRapidlib.LearningType.DTW) 
            GUI.enabled = false;
        if (GUILayout.Button(nameButton))
        {
            rapidLib.ToggleRunning();
        }
        // Always enable it back at the end
        GUI.enabled = true;

        // TRAIN BUTTON
        if (rapidLib.Running)
            nameButton = "STOP Training";
        else
            nameButton = "Train";
        // Disable button if model is Collecting data OR Running
        if (rapidLib.CollectingData || rapidLib.Running)
            GUI.enabled = false;
        if (GUILayout.Button(nameButton))
        {
            rapidLib.Train();
        }

        // CLEAR ALL TRAINING EXAMPLES BUTTON
        nameButton = "Delete All Training Examples";
        // Disable button if model is Collecting data OR Running
        if (rapidLib.CollectingData || rapidLib.Running || rapidLib.Training)
            GUI.enabled = false;
        if (GUILayout.Button(nameButton))
        {
            rapidLib.ClearTrainingExamples();
        }

        // Always enable it back at the end
        GUI.enabled = true;


        // DEBUG SAVING LOADING BUTTON
        if (GUILayout.Button("Save Stuff"))
        {
            rapidLib.SaveDataToDisk();
        }

        if (GUILayout.Button("Load Stuff"))
        {
            rapidLib.LoadDataFromDisk();
        }
    }
}