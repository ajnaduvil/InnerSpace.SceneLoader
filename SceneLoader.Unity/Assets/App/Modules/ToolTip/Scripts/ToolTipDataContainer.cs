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
  
        private static string ReadConfigFile(string fileNamePath)
        {
            var sr = File.OpenText(fileNamePath);
            var data = sr.ReadToEnd();
            return data;
        }

        public void LoadOrCreateConfig(string path)
        {
            var fileName = Path.Combine(Application.dataPath, "ToolTipConfig.json");
            if (File.Exists(fileName))
            {
                var stringConfig = ReadConfigFile(fileName);
                JsonUtility.FromJsonOverwrite(stringConfig, this);
            }
            else
            {
                Debug.Log("Config File Doesnot exists!");
                Debug.Log("Creating config file at : " + path);
                CreateConfig(fileName);
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