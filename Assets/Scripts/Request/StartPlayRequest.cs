using System;
using System.Collections;
using System.Collections.Generic;
using Common;
using UnityEngine;
using UnityEngineInternal;

public class StartPlayRequest :BaseRequest
{

   private bool isAddContorlScript = false;
   private int RoleType;
   private VSPanel vsPanel;
   public override void Start()
   {
      //requestCode = RequestCode.Game;
      actionCode = ActionCode.StartPlay;
      vsPanel = GetComponent<VSPanel>();
      base.Start();
   }


   void Update()
   {
      if (isAddContorlScript)
      {
         facade.AddControlScript(RoleType);
         facade.EnterGameCamera();
         vsPanel.OnStartPlayResponse();
         
         isAddContorlScript = false;
      }
   }
   public override void OnResponse(string data)
   {
      isAddContorlScript = true;
      RoleType = Int32.Parse(data);
      
   }
}
