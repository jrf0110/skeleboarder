using UnityEngine;
using System.Collections;

public static class MessageFlasher {
  public static void Flash( string msg ){
    GameObject layer = GameObject.Find("MessageFlasher");
    if ( layer == null ) return;
    layer.GetComponent<GUIText>().text = msg;
  }

  //public static void Flash( string msg ){
//    GameObject messageLayer = GameObject.Find("MessageFlasher");
//    if ( messageLayer == null ) return;
//    MessageFlasher.Flash( messageLayer, msg );
//  }

//  public static void Flash( GameObject layer, string msg ){
//    MessageFlasher.RemovePreviousMessages( layer );

//    GameObject child = new GameObject();
//    GUIText gtext = child.AddComponent("GUIText") as GUIText;

//    gtext.fontSize  = 50;
//    gtext.anchor    = TextAnchor.UpperCenter;
//    gtext.text      = msg;
//    gtext.font      = new Font("Arial");

//    //TextMesh mesh = child.AddComponent("TextMesh") as TextMesh;
//    //child.transform.parent = layer.transform;
//    //Fade.use.Alpha( mesh.renderer.material, 0.0, 1.0, 2.0 );
//  }

//  public static void RemovePreviousMessages( GameObject layer ){
//    foreach ( Transform child in layer.transform ){
//      if ( child.gameObject.GetComponent<GUIText>() != null ){
//        GameObject.Destroy( child.gameObject );
//      }
//    }
//  }
}