using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class UIControl : MonoBehaviour
    {
        private UIlogic UIlogicScript;
        private void Start()
        {
            UIlogicScript = GetComponent<UIlogic>();
        }
        private void Update()
        {
            UIlogicScript.BloodComAndShow();
            UIlogicScript.SkillPositionControl();
            Transform chosenGuaTransform = MouseChoose.GetInstance().GetHitTransform("Gua");
            if (chosenGuaTransform != null)
            {
                ChooseGua(chosenGuaTransform);
            }
        }

        private void ChooseGua(Transform chosenGuaTransform)
        {
            SpriteRenderer spriteRenderer = chosenGuaTransform.GetComponent<SpriteRenderer>();
            Sprite guaSprite = spriteRenderer.sprite;
            spriteRenderer.color = Color.red;
            if (Input.GetMouseButton(0))
            {
                MouseChoose.GetInstance().ChageSprite(UIlogicScript.chosenGua.transform, guaSprite);
                UIlogicScript.chosenGua.transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            else
            {
                UIlogicScript.chosenGuaSprite = null;
            }
        }
    }
}

