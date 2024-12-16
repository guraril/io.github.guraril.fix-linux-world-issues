using System;
using System.IO;
using UnityEditor;

namespace com.guraril.linux_world_fix
{
    public static class GamePaths
    {
        static readonly string defaultVRChatPath = Environment.GetEnvironmentVariable("HOME") + "/.local/share/Steam/steamapps/common/VRChat/VRChat.exe";
        static readonly string defaultProtonPath = Environment.GetEnvironmentVariable("HOME") + "/.local/share/Steam/steamapps/common/Proton - Experimental/proton";
        static readonly string defaultCompatdataPath = Environment.GetEnvironmentVariable("HOME") + "/.local/share/Steam/steamapps/compatdata/";

        public static string GetVRChatPath()
        {
            if (EditorPrefs.HasKey("FixLinuxVRCWorldIssue:VRChatPath"))
            {
                return EditorPrefs.GetString("FixLinuxVRCWorldIssue:VRChatPath");
            }
            else if (File.Exists(defaultVRChatPath))
            {
                EditorPrefs.SetString(
                    "FixLinuxVRCWorldIssue:VRChatPath", defaultVRChatPath);
                return defaultVRChatPath;
            }
            else
            {
                return "";
            }
        }
        public static string GetProtonPath()
        {
            if (EditorPrefs.HasKey("FixLinuxVRCWorldIssue:ProtonPath"))
            {
                return EditorPrefs.GetString("FixLinuxVRCWorldIssue:ProtonPath");
            }
            else if (File.Exists(defaultProtonPath))
            {
                EditorPrefs.SetString("FixLinuxVRCWorldIssue:ProtonPath", defaultProtonPath);
                return defaultProtonPath;
            }
            else
            {
                return "";
            }
        }
        public static string GetCompatdataPath()
        {
            if (EditorPrefs.HasKey("FixLinuxVRCWorldIssue:compatdataPath"))
            {
                return EditorPrefs.GetString("FixLinuxVRCWorldIssue:compatdataPath");
            }
            else if (Directory.Exists(defaultCompatdataPath))
            {
                EditorPrefs.SetString("FixLinuxVRCWorldIssue:compatdataPath", defaultCompatdataPath);
                return defaultCompatdataPath;
            }
            else
            {
                return "";
            }
        }

        // TODO: このへんなんとかまとめる
        public static bool SetVRChatPath(string path)
        {
            if (File.Exists(path)) { EditorPrefs.SetString("FixLinuxVRCWorldIssue:VRChatPath", path); return true; }
            else { EditorUtility.DisplayDialog("Invalid path", "The path: \"" + path + "\" is not exists.", "Ok"); return false; }
        }
        public static bool SetProtonPath(string path)
        {
            if (File.Exists(path)) { EditorPrefs.SetString("FixLinuxVRCWorldIssue:ProtonPath", path); return true; }
            else { EditorUtility.DisplayDialog("Invalid path", "The path: \"" + path + "\" is not exists.", "Ok"); return false; }
        }
        public static bool SetCompatdataPath(string path)
        {
            if (Directory.Exists(path)) { EditorPrefs.SetString("FixLinuxVRCWorldIssue:compatdataPath", path); return true; }
            else { EditorUtility.DisplayDialog("Invalid path", "The path: \"" + path + "\" is not exists.", "Ok"); return false; }
        }
    }
}