using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ns
{
    ///<summary>
    ///
    ///<summary>
    public class MouseChoose
    {
        public static MouseChoose Instance;
        public static MouseChoose GetInstance()
        {
            if (Instance == null)
            {
                Instance = new MouseChoose();
            }
            return Instance;
        }

        public Transform GetHitTransform(string tag)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
            if (hit.collider != null && hit.transform.CompareTag(tag))
            {
                Transform hitTransform = hit.transform;
                return hitTransform;
            }
            else
            {
                return null;
            }
        }
        public void ChageSprite (Transform objectTransform, Sprite changeSprite)
        {
            if (objectTransform != null)
            {
                SpriteRenderer spriteRenderer = objectTransform.GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = changeSprite;
            }
        }
    }
}

