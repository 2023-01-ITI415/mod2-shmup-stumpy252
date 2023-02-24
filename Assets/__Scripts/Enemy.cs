using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Inscribed")]
    public float speed = 10f; //movement speed is 10m/s
    public float fireRate = 0.3f; //Seconds/shot
    public float health = 10; //health of enemy
    public int score = 100; // points earned

    // A property: method that acts like a field
    public Vector3 pos{
        get {
            return this.transform.position;
        }
        set{
            this.transform.position = value;
        }
    }
    void Update(){
        Move();
    }
    public void Move(){
        Vector3 tempPos = pos;
        tempPos.y -= speed * Time.deltaTime;
        pos = tempPos;
    }
}
