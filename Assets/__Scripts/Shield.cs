using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    [Header("Inscrribed")]
    public float roatationsPerSecond = 0.1f;

    [Header("Dynamic")]
    public float levelShown = 0; // This is set between lines c & d

    //this non-public variable will not appear in the inspector

    Material mat;
    void Start(){
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        //read the current shield level from the hero singleton
        int currLevel = Mathf.FloorToInt(Hero.S.shieldLevel);
        //if it is differnt than level shown...
        if(levelShown != currLevel){
            levelShown = currLevel;
            //adjust texture offset to show different shield levels
            mat.mainTextureOffset = new Vector2(0.2f*levelShown, 0);
        }
            //rotate shield a bit every frame in a time based way
        float rZ = -(roatationsPerSecond*Time.time*360) % 360f;

        transform.rotation = Quaternion.Euler(0,0,rZ);
        
        
    }
}
