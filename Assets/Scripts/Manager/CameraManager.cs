using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class CameraManager :BaseManager
{

   private Camera GameCamera;
   private Camera MenuCamera;
   private FollowTarget followTarget;
   private bool isBegin;
   public CameraManager(GameFacade facade) : base(facade){}

   void Update()
   {
      
   }
   
   public override void OnInit()
   {
      GameCamera = GameObject.Find("GameCamera").GetComponent<Camera>();
      MenuCamera = GameObject.Find("MenuCamera").GetComponent<Camera>();
      followTarget = GameCamera.GetComponent<FollowTarget>();
      
   }

   public void FollowTarget(Transform target)
   {
      followTarget.target = target;
      followTarget.enabled = true;
   }


   public void EnterGame()
   {
      
      GameCamera.depth = 1;
      FollowTarget(facade.getCameraTarget().transform);
      //FollowTarget();
   }

   public void CancleFllow()
   {
      followTarget.target = null;
      followTarget.enabled = false;
   }

   public void ExitGame()
   {
      CancleFllow();
      GameCamera.depth = -1;
   }
   
   
}
