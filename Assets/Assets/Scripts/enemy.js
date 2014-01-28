﻿var target : Transform; //the enemy's target
var moveSpeed = 3; //move speed
var rotationSpeed = 3; //speed of turning
var range : float=50f;
var stop : float=0;
var myTransform : Transform; //current transform data of this enemy
function Awake()
{
    myTransform = transform; //cache transform data for easy access/preformance
}
 
function Start()
{
     target = GameObject.FindWithTag("Player").transform; //target the player
 
}
 
function Update () {
    //rotate to look at the player
    var distance = Vector3.Distance(myTransform.position, target.position);
 
    
    
 
 
    if(distance>=range && distance>stop){
 
    //move towards the player
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(new Vector3(target.position.x,0,0) - myTransform.position), rotationSpeed*Time.deltaTime);
    myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
    }
    else if (distance<=stop) {
    myTransform.rotation = Quaternion.Slerp(myTransform.rotation,
    Quaternion.LookRotation(new Vector3(target.position.x,0,0) - myTransform.position), rotationSpeed*Time.deltaTime);
    }
 
 
}