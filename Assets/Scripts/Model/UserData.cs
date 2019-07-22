using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class UserData
{
    
       //房间内信息设置
        public UserData(string userData)
        {
            //string[] strs = userData.Split(',');
            this.NickName = userData;
        }
        //用户信息设置
        public UserData(int id, string nickName, int exp, int level)
        {
            this.Id = id;
            this.NickName = nickName;
            this.Exp = exp;
            this.Level = level;
        }

        //房间列表信息
        public UserData(string nickName,int roomId )
        {
            this.NickName = nickName;
            this.RoomId = roomId;
        }

       
        
        public int Id { get; set; }
        public string NickName { get; set; }
        public int Exp { get; set; }
        public int Level { get; set; }
        
        public int RoomId { get; set; }
}
