using System;
using UnityEngine;

namespace Battle
{
	// Token: 0x020041EE RID: 16878
	public static class GeUtility
	{
		// Token: 0x06017557 RID: 95575 RVA: 0x0072DCE0 File Offset: 0x0072C0E0
		public static void AttachTo(GameObject go, GameObject parent, bool keepPos = false)
		{
			if (null == go || null == parent)
			{
				return;
			}
			Transform transform = go.transform;
			Vector3 localScale = transform.transform.localScale;
			Vector3 localPosition = transform.transform.localPosition;
			Quaternion localRotation = transform.transform.localRotation;
			go.transform.SetParent(parent.transform, true);
			transform.localScale = localScale;
			transform.localRotation = localRotation;
			transform.localPosition = localPosition;
		}

		// Token: 0x06017558 RID: 95576 RVA: 0x0072DD58 File Offset: 0x0072C158
		public static bool CheckArrayItems<T>(T[] array) where T : Object
		{
			if (array == null)
			{
				return true;
			}
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] == null)
				{
					return false;
				}
			}
			return true;
		}
	}
}
