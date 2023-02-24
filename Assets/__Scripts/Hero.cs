using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    static public Hero S { get; private set; }

    [Header("Inscribed")]
    public float speed = 30;
    public float rollMult = -45;
    public float pitchMult = 30;
    [Header("Dynamic")] [Range(0,4)][SerializeField]
    private float _shieldLevel = 1;
    //public float shieldLevel = 1;
    [Header("This field holds a reference to the last triggering GameObject")]
    private GameObject lastTriggerGo = null;

    void Awake(){
        if (S == null){
            S = this;
        }
        else{
            Debug.LogError("Hero.Awake() - Attempted to assign second Hero.S!");


        }
    }
    // Update is called once per frame
    void Update(){
        // Pull in information from the Input class
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");

        // Change transform.position based on the axes
        Vector3 pos = transform.position;
        pos.x += hAxis * speed * Time.deltaTime;
        pos.y += vAxis * speed * Time.deltaTime;
        transform.position = pos;
        //rotate ship to make it feel more dynamic
        transform.rotation = Quaternion.Euler(vAxis*pitchMult,hAxis*rollMult,0);
    }

    void OnTriggerEnter(Collider other){
        Transform rootT = other.gameObject.transform.root;
        GameObject go = rootT.gameObject;
        //Debug.Log("Shield trigger hit by: " + go.gameObject.name);

        // Make sure it's not the same triggering go as last time
        if(go = lastTriggerGo) return;

        lastTriggerGo = go;

        Enemy enemy = go.GetComponent<Enemy>();

        if(enemy != null){
            shieldLevel--;
            Destroy(go);
        }
        else{
            Debug.LogWarning("Shield trigger hit by non-Enemy: "+go.name);     
        }
    }
    public float shieldLevel{
        get{
            return(_shieldLevel);
        }
        private set{
            _shieldLevel = Mathf.Min(value, 4);
            //if shield will be less than 0
            if(value < 0){
                Destroy(this.gameObject);
            }
        }

    }
   
}
