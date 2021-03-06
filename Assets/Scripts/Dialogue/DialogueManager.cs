﻿using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance
    {
        get
        {
            if(s_Instance != null)
            {
                return s_Instance;
            }

            s_Instance = FindObjectOfType<DialogueManager>();

            if (s_Instance != null)
            {
                return s_Instance;
            }

            return Create();
        }
    }

    private static DialogueManager s_Instance;

    static DialogueManager Create()
    {
        GameObject gameObject = new GameObject("Localization");
        return s_Instance = gameObject.AddComponent<DialogueManager>();
    }

    public string textFilePath;
    public List<Phrases> phrases;

    public List<Phrase> this[string key]
    {
        get
        {
            foreach(var item in phrases)
            {
                if(item.key == key)
                {
                    return item.phrases;
                }
            }

            return null;
        }
    }

    public bool CheckForTextRead()
    {
        foreach(var phrase in phrases)
        {
            if(phrase.phrases.Count == 0)
            {
                return false;
            }
        }

        return true;
    }

}
