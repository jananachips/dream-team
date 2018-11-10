using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialoguesFormat{
    public string NpcName;
    [TextArea(1,5)]
    public string[] dialogue;
    
}
