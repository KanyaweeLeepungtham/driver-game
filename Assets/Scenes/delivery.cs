using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delivery : MonoBehaviour
{
 // private = ใช้ได้แค่ในคำสั่งนี้ ใช้กับคำสั่งอื่นตัวแปรอื่นไม่ได้ เปลี่ยนตัวแปรก็ไม่ได้
  [SerializeField] float destroyDelay = 0.5f;
  [SerializeField] Color32 hasPackageColor = new Color32(1,1,1,1);
  [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);

   bool hasPackage;
  SpriteRenderer spriteRenderer;
   void Start ()
   {
     spriteRenderer = GetComponent<SpriteRenderer>(); 
   }
      void OnTriggerEnter2D(Collider2D other) 
   {
     if ( other.tag == "Package" && !hasPackage)
     {
       Debug.Log("package pick up");
       hasPackage = true ;
       spriteRenderer.color = hasPackageColor;
       Destroy(other.gameObject,destroyDelay);
      
     }
     if( other.tag == "customer" && hasPackage )
     {
     // write only hasPAckage because we have bool
       Debug.Log("package delivered");
       hasPackage = false;
       spriteRenderer.color = noPackageColor;
     }
   }
}
