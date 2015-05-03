using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler {

	public Transform parentToReturnTo = null;

	public void OnBeginDrag(PointerEventData data){
		Debug.Log ("on begin drag");
		parentToReturnTo = this.transform.parent;
		this.transform.SetParent(this.transform.parent.parent);
		GetComponent<CanvasGroup> ().blocksRaycasts = false;
	}
	public void OnDrag(PointerEventData data){
		//Debug.Log ("on drag");
		this.transform.position = data.position;
	}
	public void OnEndDrag(PointerEventData data){
		Debug.Log ("on end drag");
		this.transform.SetParent (parentToReturnTo);
		GetComponent<CanvasGroup> ().blocksRaycasts = true;
	}

}