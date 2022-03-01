using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000F8A RID: 3978
public class ImageNumber : MonoBehaviour
{
	// Token: 0x060099F0 RID: 39408 RVA: 0x001D9BF6 File Offset: 0x001D7FF6
	private void OnEnable()
	{
		this.UpdateNumber();
	}

	// Token: 0x060099F1 RID: 39409 RVA: 0x001D9C00 File Offset: 0x001D8000
	private void OnDisable()
	{
		for (int i = 0; i < this.allImageNodes.Length; i++)
		{
			this.allImageNodes[i].image.enabled = false;
		}
	}

	// Token: 0x060099F2 RID: 39410 RVA: 0x001D9C39 File Offset: 0x001D8039
	public void SetTextNumber(int num)
	{
		this.number = num;
		this.UpdateNumber();
	}

	// Token: 0x060099F3 RID: 39411 RVA: 0x001D9C48 File Offset: 0x001D8048
	private void UpdateNumber()
	{
		int num = this.number;
		for (int i = 0; i < this.allImageNodes.Length; i++)
		{
			int num2 = num % 10;
			num /= 10;
			if (num > 0 || num2 > 0)
			{
				this.allImageNodes[i].image.sprite = this.numberList[num2];
				this.allImageNodes[i].image.enabled = true;
				this.allImageNodes[i].number = num2;
			}
			else
			{
				this.allImageNodes[i].image.enabled = false;
				this.allImageNodes[i].number = 0;
			}
		}
	}

	// Token: 0x060099F4 RID: 39412 RVA: 0x001D9CF0 File Offset: 0x001D80F0
	public void Update()
	{
		for (int i = 0; i < this.allImageNodes.Length; i++)
		{
			ImageNumber.ImageNode imageNode = this.allImageNodes[i];
			ImageNumber.eImageNumberState state = imageNode.state;
			if (state != ImageNumber.eImageNumberState.Animating)
			{
				if (state != ImageNumber.eImageNumberState.End)
				{
					if (state == ImageNumber.eImageNumberState.None)
					{
						if (imageNode.isDirty)
						{
							imageNode.Play();
						}
					}
				}
				else
				{
					imageNode.state = ImageNumber.eImageNumberState.None;
				}
			}
			else if (imageNode.animateTime > 0f)
			{
				imageNode.animateTime -= Time.deltaTime;
			}
			else
			{
				imageNode.state = ImageNumber.eImageNumberState.End;
			}
		}
	}

	// Token: 0x04004F46 RID: 20294
	public Sprite[] numberList = new Sprite[10];

	// Token: 0x04004F47 RID: 20295
	public ImageNumber.ImageNode[] allImageNodes = new ImageNumber.ImageNode[0];

	// Token: 0x04004F48 RID: 20296
	public int number;

	// Token: 0x04004F49 RID: 20297
	public float offsetX;

	// Token: 0x04004F4A RID: 20298
	public float offsetXStep;

	// Token: 0x04004F4B RID: 20299
	public float offsetY;

	// Token: 0x04004F4C RID: 20300
	public float offsetYStep;

	// Token: 0x02000F8B RID: 3979
	public enum eImageNumberState
	{
		// Token: 0x04004F4E RID: 20302
		None,
		// Token: 0x04004F4F RID: 20303
		Animating,
		// Token: 0x04004F50 RID: 20304
		End
	}

	// Token: 0x02000F8C RID: 3980
	[Serializable]
	public class ImageNode
	{
		// Token: 0x17001939 RID: 6457
		// (get) Token: 0x060099F6 RID: 39414 RVA: 0x001D9DA8 File Offset: 0x001D81A8
		// (set) Token: 0x060099F7 RID: 39415 RVA: 0x001D9DB0 File Offset: 0x001D81B0
		public ImageNumber.eImageNumberState state
		{
			get
			{
				return this.mState;
			}
			set
			{
				this.mState = value;
			}
		}

		// Token: 0x1700193A RID: 6458
		// (get) Token: 0x060099F8 RID: 39416 RVA: 0x001D9DB9 File Offset: 0x001D81B9
		// (set) Token: 0x060099F9 RID: 39417 RVA: 0x001D9DC1 File Offset: 0x001D81C1
		public float animateTime { get; set; }

		// Token: 0x1700193B RID: 6459
		// (get) Token: 0x060099FA RID: 39418 RVA: 0x001D9DCA File Offset: 0x001D81CA
		// (set) Token: 0x060099FB RID: 39419 RVA: 0x001D9DD2 File Offset: 0x001D81D2
		public int number
		{
			get
			{
				return this.mNumber;
			}
			set
			{
				if (value != this.mNumber)
				{
					this.mNumber = value;
					this.isDirty = true;
				}
			}
		}

		// Token: 0x1700193C RID: 6460
		// (get) Token: 0x060099FC RID: 39420 RVA: 0x001D9DEE File Offset: 0x001D81EE
		// (set) Token: 0x060099FD RID: 39421 RVA: 0x001D9DF6 File Offset: 0x001D81F6
		public bool isDirty { get; private set; }

		// Token: 0x060099FE RID: 39422 RVA: 0x001D9E00 File Offset: 0x001D8200
		public void Play()
		{
			this.state = ImageNumber.eImageNumberState.Animating;
			this.image.transform.localScale = Vector3.one;
			for (int i = 0; i < this.allAnimate.Length; i++)
			{
				if (null != this.allAnimate[i])
				{
					this.allAnimate[i].DORestart(false);
				}
			}
			this._resetAnimateTime();
			this.isDirty = false;
		}

		// Token: 0x060099FF RID: 39423 RVA: 0x001D9E70 File Offset: 0x001D8270
		private void _resetAnimateTime()
		{
			float num = 0f;
			for (int i = 0; i < this.allAnimate.Length; i++)
			{
				if (null != this.allAnimate[i] && this.allAnimate[i].loops > 0)
				{
					num = Mathf.Max(num, this.allAnimate[i].delay + this.allAnimate[i].duration * (float)this.allAnimate[i].loops);
				}
			}
			this.animateTime = num;
		}

		// Token: 0x04004F51 RID: 20305
		public DOTweenAnimation[] allAnimate = new DOTweenAnimation[0];

		// Token: 0x04004F52 RID: 20306
		public Image image;

		// Token: 0x04004F53 RID: 20307
		private ImageNumber.eImageNumberState mState;

		// Token: 0x04004F55 RID: 20309
		private int mNumber;
	}
}
