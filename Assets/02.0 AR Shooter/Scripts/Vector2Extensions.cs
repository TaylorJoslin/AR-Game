﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public static class Vector2Extensions
{
	public static bool IsPointOverUIObject(this Vector2 pos)
	{
		// if it's over something else return true
		PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
		eventDataCurrentPosition.position = new Vector2(pos.x, pos.y);

		List<RaycastResult> results = new List<RaycastResult>();
		EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

		int uiObjects = 0; // only count things not on the UI layer
		for (int i = 0; i < results.Count; i++)
		{
			if (results[0].gameObject.layer == 5) uiObjects++; // 5 is the UI layer
		}

		return (uiObjects > 0);
	}
}
