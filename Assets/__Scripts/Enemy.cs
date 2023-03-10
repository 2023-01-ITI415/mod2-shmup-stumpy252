using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent( typeof(BoundsCheck) )]
public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 10f; //movement speed is 10m/s
    public float fireRate = 0.3f; //Seconds/shot
    public float health = 10; //health of enemy
    public int score = 100; // points earned
    private BoundsCheck bndCheck;

    

    // A property: method that acts like a field
    public Vector3 pos{
        get {
            return this.transform.position;
        }
        set{
            this.transform.position = value;
        }
    }
    void Awake(){
        bndCheck = GetComponent<BoundsCheck>();
    }
    void Update(){
        Move();
        if(bndCheck.LocIs(BoundsCheck.eScreenLocs.offDown)){
            Destroy(gameObject);
        }
        //if ( !bndCheck.isOnScreen ){
           // if ( pos.y < bndCheck.camHeight - bndCheck.radius ){
               // Destroy(gameObject);
            //}
       //}
    }
    public void Move(){
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
    void OnCollisionEnter(Collision coll){
        GameObject otherGO = coll.gameObject;
        if(otherGO.GetComponent<ProjectileHero>() != null){
            Destroy(otherGO);
            Destroy(gameObject);
        }
        else{
            Debug.Log("Enemy hit by non-ProjectileHero: " + otherGO.name);
        }
    }
        
}

