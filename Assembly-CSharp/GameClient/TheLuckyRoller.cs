using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02004751 RID: 18257
	internal class TheLuckyRoller : MonoBehaviour
	{
		// Token: 0x0601A398 RID: 107416 RVA: 0x0082557C File Offset: 0x0082397C
		private void Start()
		{
			base.transform.eulerAngles = new Vector3(0f, 0f, 0f);
			this.roolPointer = base.GetComponent<Transform>();
			this.spinning = false;
			if (this.animationCurves.Count <= 0)
			{
				Keyframe[] array = new Keyframe[2];
				array[0] = new Keyframe(0f, 0f);
				array[0].inTangent = 2f;
				array[0].outTangent = 2f;
				array[1] = new Keyframe(1f, 1f);
				array[1].inTangent = 0f;
				array[1].outTangent = 0f;
				AnimationCurve item = new AnimationCurve(array);
				this.animationCurves.Add(item);
			}
		}

		// Token: 0x0601A399 RID: 107417 RVA: 0x00825660 File Offset: 0x00823A60
		public void RotateUp(int itemNum, int itemIndex, bool cw, Action callback)
		{
			this.itemNumber = itemNum;
			this.anglePerItem = (float)(360 / this.itemNumber);
			this.targetItemIndex = itemIndex;
			this.CW = cw;
			this.EndCallBack = callback;
			this.rotateCommand = true;
		}

		// Token: 0x0601A39A RID: 107418 RVA: 0x0082569C File Offset: 0x00823A9C
		private void Update()
		{
			if (this.rotateCommand && !this.spinning)
			{
				this.randomTime = 2;
				float maxAngle = -((float)(360 * this.randomTime) + (float)this.targetItemIndex * this.anglePerItem);
				this.rotateCommand = false;
				base.StartCoroutine(this.SpinTheWheel((float)this.randomTime, maxAngle));
			}
		}

		// Token: 0x0601A39B RID: 107419 RVA: 0x00825700 File Offset: 0x00823B00
		private IEnumerator SpinTheWheel(float time, float maxAngle)
		{
			this.spinning = true;
			float timer = 0f;
			float startAngle = base.transform.eulerAngles.z;
			maxAngle -= startAngle;
			int cw_value = 1;
			if (this.CW)
			{
				cw_value = 1;
			}
			int animationCurveNumber = Random.Range(0, this.animationCurves.Count);
			if (animationCurveNumber >= this.animationCurves.Count || animationCurveNumber < 0)
			{
				Logger.LogError(string.Format("数组索引越界，当前数组大小:{0}，当前索引值:{1}", this.animationCurves.Count, animationCurveNumber));
				yield break;
			}
			AnimationCurve animationCurve = this.animationCurves[animationCurveNumber];
			if (animationCurve == null)
			{
				Logger.LogError("animationCurve is null");
				yield break;
			}
			while (timer < time)
			{
				float angle = maxAngle * animationCurve.Evaluate(timer / time);
				base.transform.eulerAngles = new Vector3(0f, 0f, (float)cw_value * angle + startAngle);
				timer += Time.deltaTime * this.speed;
				yield return 0;
			}
			base.transform.eulerAngles = new Vector3(0f, 0f, (float)cw_value * maxAngle + startAngle);
			if (this.EndCallBack != null)
			{
				this.EndCallBack();
				this.EndCallBack = null;
			}
			this.spinning = false;
			yield break;
		}

		// Token: 0x0601A39C RID: 107420 RVA: 0x0082572C File Offset: 0x00823B2C
		private float GetFitAngle(float angle)
		{
			if (angle > 0f)
			{
				if (angle - 360f > 0f)
				{
					return this.GetFitAngle(angle - 360f);
				}
				return angle;
			}
			else
			{
				if (angle + 360f < 0f)
				{
					return this.GetFitAngle(angle + 360f);
				}
				return angle;
			}
		}

		// Token: 0x040126C4 RID: 75460
		private Transform roolPointer;

		// Token: 0x040126C5 RID: 75461
		private Button button;

		// Token: 0x040126C6 RID: 75462
		public List<AnimationCurve> animationCurves;

		// Token: 0x040126C7 RID: 75463
		public float speed = 1.1f;

		// Token: 0x040126C8 RID: 75464
		private bool spinning;

		// Token: 0x040126C9 RID: 75465
		private float anglePerItem;

		// Token: 0x040126CA RID: 75466
		private int randomTime;

		// Token: 0x040126CB RID: 75467
		private int itemNumber;

		// Token: 0x040126CC RID: 75468
		private bool rotateCommand;

		// Token: 0x040126CD RID: 75469
		private int targetItemIndex;

		// Token: 0x040126CE RID: 75470
		private bool CW = true;

		// Token: 0x040126CF RID: 75471
		private Action EndCallBack;
	}
}
