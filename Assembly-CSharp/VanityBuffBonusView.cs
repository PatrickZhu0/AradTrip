using System;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x02001929 RID: 6441
public class VanityBuffBonusView : MonoBehaviour
{
	// Token: 0x0600FA9A RID: 64154 RVA: 0x0044A158 File Offset: 0x00448558
	public void Init(VanityBuffBonusModel data)
	{
		if (data == null)
		{
			return;
		}
		if (this.icon != null)
		{
			ETCImageLoader.LoadSprite(ref this.icon, data.iconPath, true);
		}
		if (this.des != null)
		{
			this.des.text = data.des.ToString();
		}
		this.mPosVec3 = data.pos;
	}

	// Token: 0x0600FA9B RID: 64155 RVA: 0x0044A1C3 File Offset: 0x004485C3
	public void PlayAnimation()
	{
		base.Invoke("PlayPosMoveScaleAnimation", 1f);
	}

	// Token: 0x0600FA9C RID: 64156 RVA: 0x0044A1D8 File Offset: 0x004485D8
	private void PlayPosMoveScaleAnimation()
	{
		RectTransform rect = this.mPosRoot.GetComponent<RectTransform>();
		TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => rect.position, delegate(Vector3 r)
		{
			rect.position = r;
		}, this.mPosVec3, 1f), 12);
		TweenSettingsExtensions.OnComplete<TweenerCore<Vector3, Vector3, VectorOptions>>(TweenSettingsExtensions.SetEase<TweenerCore<Vector3, Vector3, VectorOptions>>(DOTween.To(() => rect.localScale, delegate(Vector3 r)
		{
			rect.localScale = r;
		}, this.mScaleVec3, 1f), 12), delegate()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.VanityBonusAnimationEnd, null, null, null, null);
		});
	}

	// Token: 0x04009C8C RID: 40076
	[SerializeField]
	private Image icon;

	// Token: 0x04009C8D RID: 40077
	[SerializeField]
	private Text des;

	// Token: 0x04009C8E RID: 40078
	[SerializeField]
	private GameObject mPosRoot;

	// Token: 0x04009C8F RID: 40079
	[SerializeField]
	private Vector3 mScaleVec3;

	// Token: 0x04009C90 RID: 40080
	private Vector3 mPosVec3;
}
