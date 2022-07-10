/*===============================================================================
Copyright (C) 2022 Immersal - Part of Hexagon. All Rights Reserved.

This file is part of the Immersal SDK.

The Immersal SDK cannot be copied, distributed, or made available to
third-parties for commercial purposes without written permission of Immersal Ltd.

Contact sdk@immersal.com for licensing requests.
===============================================================================*/

using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

namespace Immersal.Samples.ContentPlacement
{
    public class ContentStorageManager : MonoBehaviour
    {
        [HideInInspector]
        public List<MovableContent> contentList = new List<MovableContent>();

        [SerializeField]
        private GameObject m_ContentPrefab = null;

        [SerializeField]
        private GameObject m_PlacementButton = null;
        [SerializeField]
        private GameObject m_DeleteButton = null;
        [SerializeField]
        private GameObject m_CheckButton = null;
        [SerializeField]
        public Immersal.AR.ARSpace m_ARSpace;
        [SerializeField]
        private string m_Filename = "content.json";
        private Savefile m_Savefile;
        private List<Vector3> m_Positions = new List<Vector3>();

        [System.Serializable]
        public struct Savefile
        {
            public List<Vector3> positions;
        }

        public static ContentStorageManager Instance
        {
            get
            {
#if UNITY_EDITOR
                if (instance == null && !Application.isPlaying)
                {
                    instance = UnityEngine.Object.FindObjectOfType<ContentStorageManager>();
                }
#endif
                if (instance == null)
                {
                    Debug.LogError("No ContentStorageManager instance found. Ensure one exists in the scene.");
                }
                return instance;
            }
        }

        private static ContentStorageManager instance = null;

        void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            if (instance != this)
            {
                Debug.LogError("There must be only one ContentStorageManager object in a scene.");
                UnityEngine.Object.DestroyImmediate(this);
                return;
            }

            if (m_ARSpace == null)
            {
                m_ARSpace = GameObject.FindObjectOfType<Immersal.AR.ARSpace>();
            }
        }

        private void Start()
        {
            contentList.Clear();
            // LoadContents();
        }

        public void AddContent()
        {
            Transform cameraTransform = Camera.main.transform;
            GameObject go = Instantiate(m_ContentPrefab, cameraTransform.position + cameraTransform.forward, m_ContentPrefab.transform.rotation, m_ARSpace.transform);
            if (m_DeleteButton) {
                m_DeleteButton.SetActive(true);
            }
            if (m_CheckButton) {
                m_CheckButton.SetActive(true);
            }
            if (m_PlacementButton) {
                m_PlacementButton.SetActive(false);
            }
        }

        public void DeleteAllContent()
        {
            List<MovableContent> copy = new List<MovableContent>();

            foreach (MovableContent content in contentList)
            {
                copy.Add(content);
            }

            foreach(MovableContent content in copy)
            {
                content.RemoveContent();
            }
            if (m_DeleteButton) {
                m_DeleteButton.SetActive(false);
            }
            if (m_CheckButton) {
                m_CheckButton.SetActive(false);
            }
            if (m_PlacementButton) {
                m_PlacementButton.SetActive(true);
            }
        }

        public void SaveContents()
        {
            m_Positions.Clear();
            foreach (MovableContent content in contentList)
            {
                m_Positions.Add(content.transform.localPosition);
            }
            m_Savefile.positions = m_Positions;

            string jsonstring = JsonUtility.ToJson(m_Savefile, true);
            string dataPath = Path.Combine(Application.persistentDataPath, m_Filename);
            File.WriteAllText(dataPath, jsonstring);
        }

        public void LoadContents()
        {
            string dataPath = Path.Combine(Application.persistentDataPath, m_Filename);
            Debug.Log(string.Format("Trying to load file: {0}", dataPath));

            try
            {
                Savefile loadFile = JsonUtility.FromJson<Savefile>(File.ReadAllText(dataPath));

                foreach (Vector3 pos in loadFile.positions)
                {
                    GameObject go = Instantiate(m_ContentPrefab, m_ARSpace.transform);
                    go.transform.localPosition = pos;
                }

                Debug.Log("Successfully loaded file!");
            }
            catch (FileNotFoundException e)
            {
                Debug.Log(e.Message + "\n.json file for content storage not found. Created a new file!");
                File.WriteAllText(dataPath, "");
            }
            catch (NullReferenceException e)
            {
                Debug.Log(e.Message + "\n.json file for content storage not found. Created a new file!");
                File.WriteAllText(dataPath, "");
            }
        }
    }
}