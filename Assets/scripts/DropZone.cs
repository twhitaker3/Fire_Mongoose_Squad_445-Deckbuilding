using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems; 

public class DropZone : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler {

	public void OnPointerEnter(PointerEventData data){
		//Debug.Log ("OnPointerEnter");
	}
	public void OnDrop(PointerEventData data){
		Debug.Log ("OnDrop to " + gameObject.name);
		Dragable d = data.pointerDrag.GetComponent<Dragable>();
		if (d != null) {
			d.parentToReturnTo = this.transform;
		}
	}
	public void OnPointerExit(PointerEventData data){
		//Debug.Log ("OnPointerExit");
	}
}
