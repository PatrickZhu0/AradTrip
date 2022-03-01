using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI.Extensions;

// Token: 0x02000238 RID: 568
[RequireComponent(typeof(UISelectableExtension))]
public class ControlButtonAnimation : MonoBehaviour
{
	// Token: 0x060012D8 RID: 4824 RVA: 0x00064808 File Offset: 0x00062C08
	private void Start()
	{
		if (MonoSingleton<LeanTween>.instance != null)
		{
			if (this.bUseGlobalScale)
			{
				this.mPressScale = MonoSingleton<LeanTween>.instance.buttonPressScale;
			}
			this.mEaseCurve = MonoSingleton<LeanTween>.instance.buttonTween;
		}
		this.UIOpress = base.gameObject.GetComponent<UISelectableExtension>();
		if (this.UItrans == null)
		{
			this.UItrans = base.gameObject.GetComponent<RectTransform>();
		}
		if (this.UIOpress && this.UItrans)
		{
			this.UIOpress.OnButtonPress.AddListener(delegate(PointerEventData.InputButton item)
			{
				DOTween.To(() => this.UItrans.localScale, delegate(Vector3 x)
				{
					this.UItrans.localScale = x;
				}, this.mPressScale, this.mPressTime);
			});
			this.UIOpress.OnButtonRelease.AddListener(delegate(PointerEventData.InputButton item)
			{
				Tweener tweener = DOTween.To(() => this.UItrans.localScale, delegate(Vector3 x)
				{
					this.UItrans.localScale = x;
				}, this.mReleaseScale, this.mReleaseTime);
				TweenSettingsExtensions.SetEase<Tweener>(tweener, this.mEaseCurve);
			});
		}
	}

	// Token: 0x060012D9 RID: 4825 RVA: 0x000648DB File Offset: 0x00062CDB
	private void OnDestroy()
	{
		if (null != this.UIOpress)
		{
			this.UIOpress.OnButtonPress.RemoveAllListeners();
			this.UIOpress.OnButtonRelease.RemoveAllListeners();
		}
	}

	// Token: 0x04000C72 RID: 3186
	private UISelectableExtension UIOpress;

	// Token: 0x04000C73 RID: 3187
	public RectTransform UItrans;

	// Token: 0x04000C74 RID: 3188
	public Vector3 mPressScale = new Vector3(0.7f, 0.7f, 0.7f);

	// Token: 0x04000C75 RID: 3189
	public bool bUseGlobalScale = true;

	// Token: 0x04000C76 RID: 3190
	private Vector3 mReleaseScale = new Vector3(1f, 1f, 1f);

	// Token: 0x04000C77 RID: 3191
	private AnimationCurve mEaseCurve = new AnimationCurve(new Keyframe[]
	{
		new Keyframe(0f, 0f),
		new Keyframe(1f, 1f)
	});

	// Token: 0x04000C78 RID: 3192
	private float mPressTime = 0.08f;

	// Token: 0x04000C79 RID: 3193
	private float mReleaseTime = 0.3f;
}
