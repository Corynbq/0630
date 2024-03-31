using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class UIlogic : MonoBehaviour
    {
        [HideInInspector]
        public LuBanProperties banProperties;

        [Header ("GuaShow")]
        public Sprite[] guaSpriteAssemble;
        public GameObject[] randomGuaImagePosition;
        public GameObject chosenGua;
        public GameObject[] skillImagePosition;

        [Header("BloodBarShow")]
        public Scrollbar bloodBar;

        [Header("SkillButton(随机，移动障碍物，旋转)")]
        public Button[] skillButtons;

        [HideInInspector]
        public SpriteRenderer chosenGuaSpriteRenderer;
        [HideInInspector]
        public Sprite chosenGuaSprite;

        private void Start()
        {
            chosenGuaSpriteRenderer = chosenGua.GetComponent<SpriteRenderer>();
            chosenGuaSprite = chosenGuaSpriteRenderer.GetComponent<Sprite>();
        }
        public void SkillPositionControl()
        {
            foreach (GameObject skillPosition in skillImagePosition)
            {
                ChargeSkillImage(skillPosition);
            }
        }

        public void BloodComAndShow()
        {
            bloodBar.size = (float)banProperties.currentBlood / (float)banProperties.maxBlood;
        }
        public void ShowGuaPicture(Gua gua, GameObject randomGua)
        {
            Image randomGuaImage = randomGua.GetComponent<Image>();
            switch (gua)
            {
                case Gua.Qian:
                    randomGuaImage.sprite = guaSpriteAssemble[0]; break;
                case Gua.Dui:
                    randomGuaImage.sprite = guaSpriteAssemble[1]; break;
                case Gua.Li:
                    randomGuaImage.sprite = guaSpriteAssemble[2]; break;
                case Gua.Zhen:
                    randomGuaImage.sprite = guaSpriteAssemble[3]; break;
                case Gua.Xun:
                    randomGuaImage.sprite = guaSpriteAssemble[4]; break;
                case Gua.Kan:
                    randomGuaImage.sprite = guaSpriteAssemble[5]; break;
                case Gua.Gen:
                    randomGuaImage.sprite = guaSpriteAssemble[6]; break;
                case Gua.Kun:
                    randomGuaImage.sprite = guaSpriteAssemble[7]; break;
            }
        }
        public void ChargeSkillImage(GameObject skillImagePosition)
        {
            Image skillImage =skillImagePosition.GetComponent<Image>();
            if (Vector3.Distance(skillImagePosition.transform.position, chosenGua.transform.position) <= 0.5f)
            {
                skillImage.sprite = chosenGuaSprite;
            }
        }
    }
}

