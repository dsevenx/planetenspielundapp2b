﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MoveSteuerung : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler
{

	public RawImage mBackgroundImage;

	public RawImage mJoystickImage;

	private Vector3 mInputVector;

	void Start()
	{
		init();
	}

	public virtual void OnDrag(PointerEventData pPointerEventData)
	{
		Vector2 lVectorPosInBackgroundImage;

		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
				 mBackgroundImage.rectTransform
			, pPointerEventData.position
			, pPointerEventData.pressEventCamera
			, out lVectorPosInBackgroundImage))
		{

			lVectorPosInBackgroundImage.x = (lVectorPosInBackgroundImage.x /
			mBackgroundImage.rectTransform.sizeDelta.x);

			lVectorPosInBackgroundImage.y = (lVectorPosInBackgroundImage.y /
			mBackgroundImage.rectTransform.sizeDelta.y);

			if (lVectorPosInBackgroundImage.magnitude > 1)
			{
				lVectorPosInBackgroundImage = lVectorPosInBackgroundImage.normalized;
			}

			mInputVector = new Vector2(lVectorPosInBackgroundImage.x
				, lVectorPosInBackgroundImage.y
			);

			// Debug.Log ("MOVE x:" + mInputVector.x + " y:" + mInputVector.y);

			mJoystickImage.rectTransform.anchoredPosition =
				new Vector3(lVectorPosInBackgroundImage.x *
					(mBackgroundImage.rectTransform.sizeDelta.x / 5)
					, lVectorPosInBackgroundImage.y *
					(mBackgroundImage.rectTransform.sizeDelta.y / 5));
		}
	}

	public virtual void OnPointerDown(PointerEventData pPointerEventData)
	{
		OnDrag(pPointerEventData);
	}

	public virtual void OnPointerUp(PointerEventData pPointerEventData)
	{
		init();
	}

	public void init()
	{
		mInputVector = Vector3.zero;
		mJoystickImage.rectTransform.anchoredPosition = Vector3.zero;
	}

	public float getXMove()
	{
		return mInputVector.x;
	}
	public float getYMove()
	{
		return mInputVector.y;
	}

}


