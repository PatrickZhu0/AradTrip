using System;

namespace UnityEngine.UI.Extensions
{
	// Token: 0x02004AF0 RID: 19184
	[ExecuteInEditMode]
	[AddComponentMenu("UI/Effects/Extensions/SoftMaskScript")]
	public class SoftMaskScript : MonoBehaviour
	{
		// Token: 0x0601BE84 RID: 114308 RVA: 0x0088AF80 File Offset: 0x00889380
		private void Start()
		{
			this.myRect = base.GetComponent<RectTransform>();
			if (!this.MaskArea)
			{
				this.MaskArea = this.myRect;
			}
			if (base.GetComponent<Graphic>() != null)
			{
				this.mat = new Material(AssetShaderLoader.Find("UI Extensions/SoftMaskShader"));
				base.GetComponent<Graphic>().material = this.mat;
			}
			if (base.GetComponent<Text>())
			{
				this.isText = true;
				this.mat = new Material(AssetShaderLoader.Find("UI Extensions/SoftMaskShaderText"));
				base.GetComponent<Text>().material = this.mat;
				this.GetCanvas();
				if (base.transform.parent.GetComponent<Mask>() == null)
				{
					base.transform.parent.gameObject.AddComponent<Mask>();
				}
				base.transform.parent.GetComponent<Mask>().enabled = false;
			}
		}

		// Token: 0x0601BE85 RID: 114309 RVA: 0x0088B078 File Offset: 0x00889478
		private void GetCanvas()
		{
			Transform transform = base.transform;
			int num = 100;
			int num2 = 0;
			while (this.canvas == null && num2 < num)
			{
				this.canvas = transform.gameObject.GetComponent<Canvas>();
				if (this.canvas == null)
				{
					transform = this.GetParentTranform(transform);
				}
				num2++;
			}
		}

		// Token: 0x0601BE86 RID: 114310 RVA: 0x0088B0DC File Offset: 0x008894DC
		private Transform GetParentTranform(Transform t)
		{
			return t.parent;
		}

		// Token: 0x0601BE87 RID: 114311 RVA: 0x0088B0E4 File Offset: 0x008894E4
		private void Update()
		{
			this.SetMask();
		}

		// Token: 0x0601BE88 RID: 114312 RVA: 0x0088B0EC File Offset: 0x008894EC
		private void SetMask()
		{
			this.maskRect = this.MaskArea.rect;
			this.contentRect = this.myRect.rect;
			if (this.isText)
			{
				this.maskScalingRect = null;
				if (this.canvas.renderMode == null && Application.isPlaying)
				{
					this.p = this.canvas.transform.InverseTransformPoint(this.MaskArea.transform.position);
					this.siz = new Vector2(this.maskRect.width, this.maskRect.height);
				}
				else
				{
					this.worldCorners = new Vector3[4];
					this.MaskArea.GetWorldCorners(this.worldCorners);
					this.siz = this.worldCorners[2] - this.worldCorners[0];
					this.p = this.MaskArea.transform.position;
				}
				this.min = this.p - new Vector2(this.siz.x, this.siz.y) * 0.5f;
				this.max = this.p + new Vector2(this.siz.x, this.siz.y) * 0.5f;
			}
			else
			{
				if (this.maskScalingRect != null)
				{
					this.maskRect = this.maskScalingRect.rect;
				}
				this.centre = this.myRect.transform.InverseTransformPoint(this.MaskArea.transform.position);
				if (this.maskScalingRect != null)
				{
					this.centre = this.myRect.transform.InverseTransformPoint(this.maskScalingRect.transform.position);
				}
				this.AlphaUV = new Vector2(this.maskRect.width / this.contentRect.width, this.maskRect.height / this.contentRect.height);
				this.min = this.centre;
				this.max = this.min;
				this.siz = new Vector2(this.maskRect.width, this.maskRect.height) * 0.5f;
				this.min -= this.siz;
				this.max += this.siz;
				this.min = new Vector2(this.min.x / this.contentRect.width, this.min.y / this.contentRect.height) + new Vector2(0.5f, 0.5f);
				this.max = new Vector2(this.max.x / this.contentRect.width, this.max.y / this.contentRect.height) + new Vector2(0.5f, 0.5f);
			}
			this.mat.SetFloat("_HardBlend", (float)((!this.HardBlend) ? 0 : 1));
			this.mat.SetVector("_Min", this.min);
			this.mat.SetVector("_Max", this.max);
			this.mat.SetTexture("_AlphaMask", this.AlphaMask);
			this.mat.SetInt("_FlipAlphaMask", (!this.FlipAlphaMask) ? 0 : 1);
			if (!this.isText)
			{
				this.mat.SetVector("_AlphaUV", this.AlphaUV);
			}
			this.mat.SetFloat("_CutOff", this.CutOff);
		}

		// Token: 0x0401374A RID: 79690
		private Material mat;

		// Token: 0x0401374B RID: 79691
		private Canvas canvas;

		// Token: 0x0401374C RID: 79692
		[Tooltip("The area that is to be used as the container.")]
		public RectTransform MaskArea;

		// Token: 0x0401374D RID: 79693
		private RectTransform myRect;

		// Token: 0x0401374E RID: 79694
		[Tooltip("A Rect Transform that can be used to scale and move the mask - Does not apply to Text UI Components being masked")]
		public RectTransform maskScalingRect;

		// Token: 0x0401374F RID: 79695
		[Tooltip("Texture to be used to do the soft alpha")]
		public Texture AlphaMask;

		// Token: 0x04013750 RID: 79696
		[Tooltip("At what point to apply the alpha min range 0-1")]
		[Range(0f, 1f)]
		public float CutOff;

		// Token: 0x04013751 RID: 79697
		[Tooltip("Implement a hard blend based on the Cutoff")]
		public bool HardBlend;

		// Token: 0x04013752 RID: 79698
		[Tooltip("Flip the masks alpha value")]
		public bool FlipAlphaMask;

		// Token: 0x04013753 RID: 79699
		private Vector3[] worldCorners;

		// Token: 0x04013754 RID: 79700
		private Vector2 AlphaUV;

		// Token: 0x04013755 RID: 79701
		private Vector2 min;

		// Token: 0x04013756 RID: 79702
		private Vector2 max = Vector2.one;

		// Token: 0x04013757 RID: 79703
		private Vector2 p;

		// Token: 0x04013758 RID: 79704
		private Vector2 siz;

		// Token: 0x04013759 RID: 79705
		private Rect maskRect;

		// Token: 0x0401375A RID: 79706
		private Rect contentRect;

		// Token: 0x0401375B RID: 79707
		private Vector2 centre;

		// Token: 0x0401375C RID: 79708
		private bool isText;
	}
}
