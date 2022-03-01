using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02000E5D RID: 3677
[RequireComponent(typeof(RectTransform), typeof(LayoutElement))]
public class TittleAniSizeConvert : MonoBehaviour
{
	// Token: 0x06009212 RID: 37394 RVA: 0x001B151B File Offset: 0x001AF91B
	private void Start()
	{
		this.Initialize();
	}

	// Token: 0x06009213 RID: 37395 RVA: 0x001B1524 File Offset: 0x001AF924
	private void FromScale(float fNewScaleX = 1f, float fNewScaleY = 1f)
	{
		if (this.target.transform.localScale.x < 25f)
		{
			this.kScale.x = 150f * fNewScaleX;
		}
		else
		{
			this.kScale.x = this.target.transform.localScale.x * fNewScaleX;
		}
		if (this.target.transform.localScale.y < 25f)
		{
			this.kScale.y = 150f * fNewScaleY;
		}
		else
		{
			this.kScale.y = this.target.transform.localScale.y * fNewScaleY;
		}
		this.target.transform.localScale = this.kScale;
	}

	// Token: 0x06009214 RID: 37396 RVA: 0x001B1604 File Offset: 0x001AFA04
	public float GetAnimationLength()
	{
		if (this.animator != null)
		{
			AnimationClip[] animationClips = this.animator.runtimeAnimatorController.animationClips;
			if (animationClips != null && animationClips.Length > 0)
			{
				return animationClips[0].length;
			}
		}
		return 0f;
	}

	// Token: 0x06009215 RID: 37397 RVA: 0x001B1650 File Offset: 0x001AFA50
	public void Initialize()
	{
		if (!this.bInit)
		{
			if (this.target != null)
			{
				this.spriteRender = this.target.GetComponent<SpriteRenderer>();
				this.animator = this.target.GetComponent<Animator>();
				this.tittleHelpComponent = this.target.GetComponent<TittleHelpComponent>();
				if (this.spriteRender != null)
				{
					this.spriteRender.sortingOrder = 100;
				}
				this.FromScale(1f, 1f);
			}
			this.kLayoutElement = base.GetComponent<LayoutElement>();
			this.bInit = true;
		}
	}

	// Token: 0x06009216 RID: 37398 RVA: 0x001B16F0 File Offset: 0x001AFAF0
	public void ResetTarget(Transform target, float fScaleX = 1f, float fScaleY = 1f, int sortingOrder = 100)
	{
		if (this.target != target)
		{
			this.target = target;
			this.spriteRender = null;
			if (target != null)
			{
				this.spriteRender = target.GetComponent<SpriteRenderer>();
				this.animator = target.GetComponent<Animator>();
				this.tittleHelpComponent = target.GetComponent<TittleHelpComponent>();
				if (this.spriteRender != null)
				{
					this.spriteRender.sortingOrder = sortingOrder;
				}
				this.FromScale(fScaleX, fScaleY);
			}
		}
	}

	// Token: 0x06009217 RID: 37399 RVA: 0x001B1774 File Offset: 0x001AFB74
	private void Update()
	{
		if (this.spriteRender != null)
		{
			if (this.kLayoutElement != null && this.spriteRender.sprite != null)
			{
				this.kLayoutElement.preferredWidth = this.spriteRender.sprite.bounds.size.x * this.kScale.x;
				this.kLayoutElement.preferredHeight = this.spriteRender.sprite.bounds.size.y * this.kScale.y;
			}
		}
		else if (this.tittleHelpComponent != null && this.kLayoutElement != null && this.kLayoutElement != null)
		{
			this.kLayoutElement.preferredWidth = this.kScale.x * this.tittleHelpComponent.Bounds.x;
			this.kLayoutElement.preferredHeight = this.kScale.y * this.tittleHelpComponent.Bounds.y;
		}
	}

	// Token: 0x0400491D RID: 18717
	public Transform target;

	// Token: 0x0400491E RID: 18718
	public Vector3 kScale = new Vector3(150f, 150f, 1f);

	// Token: 0x0400491F RID: 18719
	private bool bInit;

	// Token: 0x04004920 RID: 18720
	private SpriteRenderer spriteRender;

	// Token: 0x04004921 RID: 18721
	private Animator animator;

	// Token: 0x04004922 RID: 18722
	private TittleHelpComponent tittleHelpComponent;

	// Token: 0x04004923 RID: 18723
	private LayoutElement kLayoutElement;

	// Token: 0x04004924 RID: 18724
	private string stopName = string.Empty;
}
