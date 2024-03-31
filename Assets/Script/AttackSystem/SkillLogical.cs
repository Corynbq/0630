using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class SkillLogical :MonoBehaviour
    {
        public void SkillChoose(int choice)
        {
            switch (choice)
            {
                case 0:
                    RepeatRandomGua();
                    break;
                case 1:
                    MoveBarrier();
                    break;
                case 2:
                    RotateMap();
                    break;
            }
        }

        private void RotateMap()
        {
            
        }

        private void MoveBarrier()
        {
            //
        }

        private Gua[] RepeatRandomGua()
        {
            Gua[] guas = new Gua[2];
            guas[0]=RandomGua.GetInstance().GetRandomGua();
            guas[1]= RandomGua.GetInstance().GetRandomGua();
            return guas;
        }
    }
}

