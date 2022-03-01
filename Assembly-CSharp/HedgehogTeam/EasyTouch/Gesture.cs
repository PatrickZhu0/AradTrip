using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x02004931 RID: 18737
	public class Gesture : BaseFinger, ICloneable
	{
		// Token: 0x0601AF2D RID: 110381 RVA: 0x008495F7 File Offset: 0x008479F7
		public object Clone()
		{
			return base.MemberwiseClone();
		}

		// Token: 0x0601AF2E RID: 110382 RVA: 0x008495FF File Offset: 0x008479FF
		public Vector3 GetTouchToWorldPoint(float z)
		{
			return Camera.main.ScreenToWorldPoint(new Vector3(this.position.x, this.position.y, z));
		}

		// Token: 0x0601AF2F RID: 110383 RVA: 0x00849628 File Offset: 0x00847A28
		public Vector3 GetTouchToWorldPoint(Vector3 position3D)
		{
			return Camera.main.ScreenToWorldPoint(new Vector3(this.position.x, this.position.y, Camera.main.transform.InverseTransformPoint(position3D).z));
		}

		// Token: 0x0601AF30 RID: 110384 RVA: 0x00849674 File Offset: 0x00847A74
		public float GetSwipeOrDragAngle()
		{
			return Mathf.Atan2(this.swipeVector.normalized.y, this.swipeVector.normalized.x) * 57.29578f;
		}

		// Token: 0x0601AF31 RID: 110385 RVA: 0x008496B4 File Offset: 0x00847AB4
		public Vector2 NormalizedPosition()
		{
			return new Vector2(100f / (float)Screen.width * this.position.x / 100f, 100f / (float)Screen.height * this.position.y / 100f);
		}

		// Token: 0x0601AF32 RID: 110386 RVA: 0x00849702 File Offset: 0x00847B02
		public bool IsOverUIElement()
		{
			return EasyTouch.IsFingerOverUIElement(this.fingerIndex);
		}

		// Token: 0x0601AF33 RID: 110387 RVA: 0x0084970F File Offset: 0x00847B0F
		public bool IsOverRectTransform(RectTransform tr, Camera camera = null)
		{
			if (camera == null)
			{
				return RectTransformUtility.RectangleContainsScreenPoint(tr, this.position, null);
			}
			return RectTransformUtility.RectangleContainsScreenPoint(tr, this.position, camera);
		}

		// Token: 0x0601AF34 RID: 110388 RVA: 0x00849738 File Offset: 0x00847B38
		public GameObject GetCurrentFirstPickedUIElement(bool isTwoFinger = false)
		{
			return EasyTouch.GetCurrentPickedUIElement(this.fingerIndex, isTwoFinger);
		}

		// Token: 0x0601AF35 RID: 110389 RVA: 0x00849746 File Offset: 0x00847B46
		public GameObject GetCurrentPickedObject(bool isTwoFinger = false)
		{
			return EasyTouch.GetCurrentPickedObject(this.fingerIndex, isTwoFinger);
		}

		// Token: 0x04012C15 RID: 76821
		public EasyTouch.SwipeDirection swipe;

		// Token: 0x04012C16 RID: 76822
		public float swipeLength;

		// Token: 0x04012C17 RID: 76823
		public Vector2 swipeVector;

		// Token: 0x04012C18 RID: 76824
		public float deltaPinch;

		// Token: 0x04012C19 RID: 76825
		public float twistAngle;

		// Token: 0x04012C1A RID: 76826
		public float twoFingerDistance;

		// Token: 0x04012C1B RID: 76827
		public EasyTouch.EvtType type;
	}
}
