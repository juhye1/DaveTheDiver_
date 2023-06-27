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
  EType etype;
  public EType ETYPE { get {return etype; } set { this.etype = value;} }
  
  [SerializeField]
  int number;
  public int Number { get {return number; } set { this.number = value;} }
  
  [SerializeField]
  string name;
  public string Name { get {return name; } set { this.name = value;} }
  
  [SerializeField]
  string dialogtext;
  public string Dialogtext { get {return dialogtext; } set { this.dialogtext = value;} }
  
  [SerializeField]
  EEmotionType eemotiontype;
  public EEmotionType EEMOTIONTYPE { get {return eemotiontype; } set { this.eemotiontype = value;} }
  
  [SerializeField]
  bool isnpc;
  public bool Isnpc { get {return isnpc; } set { this.isnpc = value;} }
  
  [SerializeField]
  EName ename;
  public EName ENAME { get {return ename; } set { this.ename = value;} }
  
}