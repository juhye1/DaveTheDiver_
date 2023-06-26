using UnityEngine;
using System.Collections;

///
/// !!! Machine generated code !!!
/// !!! DO NOT CHANGE Tabs to Spaces !!!
/// 
[System.Serializable]
public class DialogueData
{
  [SerializeField]
  string type;
  public string Type { get {return type; } set { this.type = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  string dialogtext;
  public string Dialogtext { get {return dialogtext; } set { this.dialogtext = value;} }
  
  [SerializeField]
  EEmotionType eemotiontype;
  public EEmotionType EEMOTIONTYPE { get {return eemotiontype; } set { this.eemotiontype = value;} }
  
}