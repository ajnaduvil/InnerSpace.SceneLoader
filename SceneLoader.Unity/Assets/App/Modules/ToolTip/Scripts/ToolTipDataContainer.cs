using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Innerspace.TestApp.ToolTip
{
    /// <summary>
    /// Tooltip container scriptable object. Also can serialise/deserialise from a path using <see cref="LoadOrCreateConfig(string)"/>
    /// </summary>
    [CreateAssetMenu(fileName = "ToolTipContainer", menuName = "Innerspace/TooltipData", order = 1)]    
    public class ToolTipDataContainer : ScriptableObject
    {
        public ToolTipData[] toolTips;
        static string GetConfigPath()
        {
            var path = Path.Combine(Application.persistentDataPath, "ToolTipConfig.json");
            return path;
        }

        private static string ReadConfigFile()
        {
            var path = GetConfigPath();
            var sr = File.OpenText(path);
            var data = sr.ReadToEnd();
            return data;

        }

        public void LoadOrCreateConfig(string path)
        {
            if (File.Exists(path))
            {
                var stringConfig = ReadConfigFile();
                JsonUtility.FromJsonOverwrite(stringConfig, this);
            }
            else
            {
                Debug.Log("Config File Doesnot exists!");
                Debug.Log("Creating config file at : " + path);
                CreateConfig(path);
                Debug.Log("Config File Created :" + path);
            }
        }

        private void CreateConfig(string fileNameFullPath)
        {
            var jsonConfigData = JsonUtility.ToJson(this);
            //Simple pretty print
            jsonConfigData = jsonConfigData.Replace(",", ",\n");
            var streamWriter = File.CreateText(fileNameFullPath);
            streamWriter.Write(jsonConfigData);
            streamWriter.Close();
        }

    }


    /// <summary>
    /// Tooltip data class
    /// </summary>
    [System.Serializable]
    public class ToolTipData
    {
        public string header;
        public string info;
    }


}