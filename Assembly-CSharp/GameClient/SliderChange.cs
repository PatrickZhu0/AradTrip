using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020015D5 RID: 5589
	internal class SliderChange : MonoBehaviour
	{
		// Token: 0x0600DB0A RID: 56074 RVA: 0x0037302C File Offset: 0x0037142C
		private void Start()
		{
			this.isRemove = false;
			if (this.animationCurves.Count <= 0)
			{
				Keyframe[] array = new Keyframe[2];
				Keyframe[] array2 = array;
				int num = 0;
				Keyframe keyframe = new Keyframe(0f, 0f);
				keyframe.inTangent = 2f;
				keyframe.outTangent = 2f;
				array2[num] = keyframe;
				Keyframe[] array3 = array;
				int num2 = 1;
				keyframe = new Keyframe(1f, 1f);
				keyframe.inTangent = 0f;
				keyframe.outTangent = 0f;
				array3[num2] = keyframe;
				AnimationCurve item = new AnimationCurve(array);
				this.animationCurves.Add(item);
			}
			if (this.slider != null)
			{
				this.sliderWidth = this.slider.transform.parent.GetComponent<RectTransform>().sizeDelta.x;
			}
		}

		// Token: 0x0600DB0B RID: 56075 RVA: 0x00373110 File Offset: 0x00371510
		public void StartRemove(Vector2 beginPos, Vector2 endPos, Action callback)
		{
			this.removeCommand = true;
			this.startPosition = beginPos;
			RectTransform component = base.GetComponent<RectTransform>();
			if (component == null || this.slider == null)
			{
				this.removeCommand = false;
			}
			component.anchoredPosition = this.startPosition;
			this.endPosition = endPos;
			if (callback != null)
			{
				this.EndCallBack = callback;
			}
		}

		// Token: 0x0600DB0C RID: 56076 RVA: 0x00373178 File Offset: 0x00371578
		private void Update()
		{
			if (this.removeCommand && !this.isRemove)
			{
				int num = 2;
				this.removeCommand = false;
				base.StartCoroutine(this.SpinTheWheel((float)num));
			}
		}

		// Token: 0x0600DB0D RID: 56077 RVA: 0x003731B4 File Offset: 0x003715B4
		private IEnumerator SpinTheWheel(float time)
		{
			this.isRemove = true;
			float timer = 0f;
			int animationCurveNumber = Random.Range(0, this.animationCurves.Count);
			RectTransform thisRectTransform = base.GetComponent<RectTransform>();
			while (timer < time)
			{
				float tempX = (this.endPosition.x - this.startPosition.x) * this.animationCurves[animationCurveNumber].Evaluate(timer / time) + this.startPosition.x;
				Vector2 tempVec = new Vector2(tempX, thisRectTransform.anchoredPosition3D.y);
				thisRectTransform.anchoredPosition = tempVec;
				this.slider.value = tempX / this.sliderWidth;
				timer += Time.deltaTime * this.speed;
				yield return 0;
			}
			thisRectTransform.anchoredPosition = this.endPosition;
			if (this.EndCallBack != null && Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<EquipRecoveryFrame>(null))
			{
				this.EndCallBack();
				this.EndCallBack = null;
			}
			this.isRemove = false;
			yield break;
		}

		// Token: 0x040080F6 RID: 33014
		private RectTransform root;

		// Token: 0x040080F7 RID: 33015
		public List<AnimationCurve> animationCurves;

		// Token: 0x040080F8 RID: 33016
		public float speed = 1f;

		// Token: 0x040080F9 RID: 33017
		public Slider slider;

		// Token: 0x040080FA RID: 33018
		private bool isRemove;

		// Token: 0x040080FB RID: 33019
		private int randomTime;

		// Token: 0x040080FC RID: 33020
		private Vector2 startPosition;

		// Token: 0x040080FD RID: 33021
		private Vector2 endPosition;

		// Token: 0x040080FE RID: 33022
		private bool removeCommand;

		// Token: 0x040080FF RID: 33023
		private Action EndCallBack;

		// Token: 0x04008100 RID: 33024
		private float sliderWidth;
	}
}
