using System;
using UnityEngine;

namespace HedgehogTeam.EasyTouch
{
	// Token: 0x0200492F RID: 18735
	public class EasyTouchInput
	{
		// Token: 0x0601AF24 RID: 110372 RVA: 0x00848EBB File Offset: 0x008472BB
		public int TouchCount()
		{
			return this.getTouchCount(true);
		}

		// Token: 0x0601AF25 RID: 110373 RVA: 0x00848EC4 File Offset: 0x008472C4
		private int getTouchCount(bool realTouch)
		{
			int num = 0;
			if (realTouch || EasyTouch.instance.enableRemote)
			{
				num = Input.touchCount;
			}
			else if (Input.GetMouseButton(0) || Input.GetMouseButtonUp(0))
			{
				num = 1;
				if (EasyTouch.GetSecondeFingerSimulation())
				{
					if (Input.GetKey(308) || Input.GetKey(EasyTouch.instance.twistKey) || Input.GetKey(306) || Input.GetKey(EasyTouch.instance.swipeKey))
					{
						num = 2;
					}
					if (Input.GetKeyUp(308) || Input.GetKeyUp(EasyTouch.instance.twistKey) || Input.GetKeyUp(306) || Input.GetKeyUp(EasyTouch.instance.swipeKey))
					{
						num = 2;
					}
				}
				if (num == 0)
				{
					this.complexCenter = Vector2.zero;
					this.oldMousePosition[0] = new Vector2(-1f, -1f);
					this.oldMousePosition[1] = new Vector2(-1f, -1f);
				}
			}
			return num;
		}

		// Token: 0x0601AF26 RID: 110374 RVA: 0x00848FF8 File Offset: 0x008473F8
		public Finger GetMouseTouch(int fingerIndex, Finger myFinger)
		{
			Finger finger;
			if (myFinger != null)
			{
				finger = myFinger;
			}
			else
			{
				finger = new Finger();
				finger.gesture = EasyTouch.GestureType.None;
			}
			if (fingerIndex == 1 && (Input.GetKeyUp(308) || Input.GetKeyUp(EasyTouch.instance.twistKey) || Input.GetKeyUp(306) || Input.GetKeyUp(EasyTouch.instance.swipeKey)))
			{
				finger.fingerIndex = fingerIndex;
				finger.position = this.oldFinger2Position;
				finger.deltaPosition = finger.position - this.oldFinger2Position;
				finger.tapCount = this.tapCount[fingerIndex];
				finger.deltaTime = Time.realtimeSinceStartup - this.deltaTime[fingerIndex];
				finger.phase = 3;
				return finger;
			}
			if (Input.GetMouseButton(0))
			{
				finger.fingerIndex = fingerIndex;
				finger.position = this.GetPointerPosition(fingerIndex);
				if ((double)(Time.realtimeSinceStartup - this.tapeTime[fingerIndex]) > 0.5)
				{
					this.tapCount[fingerIndex] = 0;
				}
				if (Input.GetMouseButtonDown(0) || (fingerIndex == 1 && (Input.GetKeyDown(308) || Input.GetKeyDown(EasyTouch.instance.twistKey) || Input.GetKeyDown(306) || Input.GetKeyDown(EasyTouch.instance.swipeKey))))
				{
					finger.position = this.GetPointerPosition(fingerIndex);
					finger.deltaPosition = Vector2.zero;
					this.tapCount[fingerIndex] = this.tapCount[fingerIndex] + 1;
					finger.tapCount = this.tapCount[fingerIndex];
					this.startActionTime[fingerIndex] = Time.realtimeSinceStartup;
					this.deltaTime[fingerIndex] = this.startActionTime[fingerIndex];
					finger.deltaTime = 0f;
					finger.phase = 0;
					if (fingerIndex == 1)
					{
						this.oldFinger2Position = finger.position;
						this.oldMousePosition[fingerIndex] = finger.position;
					}
					else
					{
						this.oldMousePosition[fingerIndex] = finger.position;
					}
					if (this.tapCount[fingerIndex] == 1)
					{
						this.tapeTime[fingerIndex] = Time.realtimeSinceStartup;
					}
					return finger;
				}
				finger.deltaPosition = finger.position - this.oldMousePosition[fingerIndex];
				finger.tapCount = this.tapCount[fingerIndex];
				finger.deltaTime = Time.realtimeSinceStartup - this.deltaTime[fingerIndex];
				if (finger.deltaPosition.sqrMagnitude < 1f)
				{
					finger.phase = 2;
				}
				else
				{
					finger.phase = 1;
				}
				this.oldMousePosition[fingerIndex] = finger.position;
				this.deltaTime[fingerIndex] = Time.realtimeSinceStartup;
				return finger;
			}
			else
			{
				if (Input.GetMouseButtonUp(0))
				{
					finger.fingerIndex = fingerIndex;
					finger.position = this.GetPointerPosition(fingerIndex);
					finger.deltaPosition = finger.position - this.oldMousePosition[fingerIndex];
					finger.tapCount = this.tapCount[fingerIndex];
					finger.deltaTime = Time.realtimeSinceStartup - this.deltaTime[fingerIndex];
					finger.phase = 3;
					this.oldMousePosition[fingerIndex] = finger.position;
					return finger;
				}
				return null;
			}
		}

		// Token: 0x0601AF27 RID: 110375 RVA: 0x00849340 File Offset: 0x00847740
		public Vector2 GetSecondFingerPosition()
		{
			Vector2 result;
			result..ctor(-1f, -1f);
			if ((Input.GetKey(308) || Input.GetKey(EasyTouch.instance.twistKey)) && (Input.GetKey(306) || Input.GetKey(EasyTouch.instance.swipeKey)))
			{
				if (!this.bComplex)
				{
					this.bComplex = true;
					this.deltaFingerPosition = Input.mousePosition - this.oldFinger2Position;
				}
				result = this.GetComplex2finger();
				return result;
			}
			if (Input.GetKey(308) || Input.GetKey(EasyTouch.instance.twistKey))
			{
				result = this.GetPinchTwist2Finger(false);
				this.bComplex = false;
				return result;
			}
			if (Input.GetKey(306) || Input.GetKey(EasyTouch.instance.swipeKey))
			{
				result = this.GetComplex2finger();
				this.bComplex = false;
				return result;
			}
			return result;
		}

		// Token: 0x0601AF28 RID: 110376 RVA: 0x00849444 File Offset: 0x00847844
		private Vector2 GetPointerPosition(int index)
		{
			if (index == 0)
			{
				return Input.mousePosition;
			}
			return this.GetSecondFingerPosition();
		}

		// Token: 0x0601AF29 RID: 110377 RVA: 0x0084946C File Offset: 0x0084786C
		private Vector2 GetPinchTwist2Finger(bool newSim = false)
		{
			Vector2 result;
			if (this.complexCenter == Vector2.zero)
			{
				result.x = (float)Screen.width / 2f - (Input.mousePosition.x - (float)Screen.width / 2f);
				result.y = (float)Screen.height / 2f - (Input.mousePosition.y - (float)Screen.height / 2f);
			}
			else
			{
				result.x = this.complexCenter.x - (Input.mousePosition.x - this.complexCenter.x);
				result.y = this.complexCenter.y - (Input.mousePosition.y - this.complexCenter.y);
			}
			this.oldFinger2Position = result;
			return result;
		}

		// Token: 0x0601AF2A RID: 110378 RVA: 0x00849550 File Offset: 0x00847950
		private Vector2 GetComplex2finger()
		{
			Vector2 result;
			result.x = Input.mousePosition.x - this.deltaFingerPosition.x;
			result.y = Input.mousePosition.y - this.deltaFingerPosition.y;
			this.complexCenter = new Vector2((Input.mousePosition.x + result.x) / 2f, (Input.mousePosition.y + result.y) / 2f);
			this.oldFinger2Position = result;
			return result;
		}

		// Token: 0x04012C06 RID: 76806
		private Vector2[] oldMousePosition = new Vector2[2];

		// Token: 0x04012C07 RID: 76807
		private int[] tapCount = new int[2];

		// Token: 0x04012C08 RID: 76808
		private float[] startActionTime = new float[2];

		// Token: 0x04012C09 RID: 76809
		private float[] deltaTime = new float[2];

		// Token: 0x04012C0A RID: 76810
		private float[] tapeTime = new float[2];

		// Token: 0x04012C0B RID: 76811
		private bool bComplex;

		// Token: 0x04012C0C RID: 76812
		private Vector2 deltaFingerPosition;

		// Token: 0x04012C0D RID: 76813
		private Vector2 oldFinger2Position;

		// Token: 0x04012C0E RID: 76814
		private Vector2 complexCenter;
	}
}
