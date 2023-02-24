using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
///Keeps a GameObject on screen
///Note that this ONLY works for Orthographic Main Camera
///</summary>
public class BoundsCheck : MonoBehaviour
{
    [Header("Dynamic")]
    public float camWidth;
    public float camHeight;
    
    void Awake(){
        camHeight = Camera.main.orthographicSize;
        camWidth = camHeight * Camera.main.aspect;
    }
    void LateUpdate(){
        Vector3 pos = transform.position;
        if(pos.x > camWidth){
            pos.x = camWidth;
        }
        if(pos.x < -camWidth){
            pos.x = -camWidth;
        }
        if(pos.y > camHeight){
            pos.y = camHeight;
        }
        if(pos.y < -camHeight){
            pos.y = -camHeight;
        }
        transform.position = pos;
    }
}
