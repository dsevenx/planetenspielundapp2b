using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlanetenInArea : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

	public RawImage mBackgroundImage;

	public AttractElementVerwalter mAttractElementVerwalter;

	float mZustand;

	void Start()
	{
		init();
	}

	private void init()
  	{
		mZustand = 0f;
	}

	public virtual void OnDrag(PointerEventData pPointerEventData)
	{
		// Nix
	}

	private void Update()
	{
        if (mZustand > 0)
        {
			mZustand = mZustand - Time.deltaTime;
		} else
        {
			mZustand = 0;
        }
	}

	public virtual void OnPointerDown(PointerEventData pPointerEventData)
	{
		// mAktiv = true;
	}

	public virtual void OnPointerUp(PointerEventData pPointerEventData)
	{
		mAttractElementVerwalter.goPlanet();
		mZustand = 10;
	}

}

