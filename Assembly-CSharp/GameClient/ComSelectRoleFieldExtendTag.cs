using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200142C RID: 5164
	public class ComSelectRoleFieldExtendTag : MonoBehaviour
	{
		// Token: 0x0600C84C RID: 51276 RVA: 0x00309568 File Offset: 0x00307968
		private void Awake()
		{
			if (this.lockBtn)
			{
				this.lockBtn.onClick.AddListener(new UnityAction(this._OnlockBtnClick));
			}
			if (this.unlockBtn)
			{
				this.unlockBtn.onClick.AddListener(new UnityAction(this._OnUnlockBtnClick));
			}
			if (this.newUnlockEffectGo == null)
			{
				this.newUnlockEffectGo = Singleton<AssetLoader>.instance.LoadResAsGameObject("Effects/UI/Prefab/EffUI_jueselanjiesuo/Prefab/EffUI_jueselanjiesuo", true, 0U);
				this.newUnlockEffectGo.CustomActive(false);
				Utility.AttachTo(this.newUnlockEffectGo, this.newUnlockEffectRoot, false);
			}
			this.newUnlockImg.CustomActive(false);
		}

		// Token: 0x0600C84D RID: 51277 RVA: 0x00309620 File Offset: 0x00307A20
		private void OnDestroy()
		{
			if (this.lockBtn)
			{
				this.lockBtn.onClick.RemoveListener(new UnityAction(this._OnlockBtnClick));
			}
			if (this.unlockBtn)
			{
				this.unlockBtn.onClick.RemoveListener(new UnityAction(this._OnUnlockBtnClick));
			}
			if (this.waitToShowNewUnlockEffect != null)
			{
				base.StopCoroutine(this.waitToShowNewUnlockEffect);
				this.waitToShowNewUnlockEffect = null;
			}
			this.newUnlockEffectGo = null;
		}

		// Token: 0x0600C84E RID: 51278 RVA: 0x003096AC File Offset: 0x00307AAC
		private void _OnlockBtnClick()
		{
			string msgContent = TR.Value("select_role_lock_field_tip");
			SystemNotifyManager.SysNotifyMsgBoxOK(msgContent, null, string.Empty, false);
		}

		// Token: 0x0600C84F RID: 51279 RVA: 0x003096D4 File Offset: 0x00307AD4
		private void _OnUnlockBtnClick()
		{
			string msgContent = TR.Value("select_role_unlock_field_tip", ClientApplication.playerinfo.unLockedExtendRoleFieldNum, ClientApplication.playerinfo.extendRoleFieldNum);
			SystemNotifyManager.SysNotifyMsgBoxOK(msgContent, null, string.Empty, false);
		}

		// Token: 0x0600C850 RID: 51280 RVA: 0x00309718 File Offset: 0x00307B18
		private IEnumerator _WaitToShowNewUnlockEffect()
		{
			yield return Yielders.GetWaitForSeconds(this.newUnlockEffectShowDelayTime);
			this.newUnlockEffectRoot.CustomActive(true);
			this.newUnlockEffectGo.CustomActive(true);
			yield return Yielders.GetWaitForSeconds(this.newUnlockEffectDuration_1);
			this.unlockBtn.CustomActive(false);
			yield return Yielders.GetWaitForSeconds(this.newUnlockEffectDuration_2);
			this.newUnlockEffectGo.CustomActive(false);
			yield break;
		}

		// Token: 0x0600C851 RID: 51281 RVA: 0x00309733 File Offset: 0x00307B33
		public void SetLockShow()
		{
			this.unlockBtn.CustomActive(true);
			this.newUnlockImg.CustomActive(false);
			this.lockImg.CustomActive(false);
			this.newUnlockEffectRoot.CustomActive(false);
		}

		// Token: 0x0600C852 RID: 51282 RVA: 0x00309765 File Offset: 0x00307B65
		public void SetUnlockShow()
		{
			this.lockImg.CustomActive(false);
			this.newUnlockImg.CustomActive(false);
			this.unlockBtn.CustomActive(false);
			this.newUnlockEffectRoot.CustomActive(false);
		}

		// Token: 0x0600C853 RID: 51283 RVA: 0x00309797 File Offset: 0x00307B97
		public void SetLockTagShow()
		{
			this.lockImg.CustomActive(true);
			this.newUnlockImg.CustomActive(false);
			this.unlockBtn.CustomActive(false);
			this.newUnlockEffectRoot.CustomActive(false);
		}

		// Token: 0x0600C854 RID: 51284 RVA: 0x003097CC File Offset: 0x00307BCC
		public void SetNewUnlockTagShow()
		{
			this.lockImg.CustomActive(false);
			this.unlockBtn.CustomActive(false);
			if (this.waitToShowNewUnlockEffect != null)
			{
				base.StopCoroutine(this.waitToShowNewUnlockEffect);
			}
			this.waitToShowNewUnlockEffect = base.StartCoroutine(this._WaitToShowNewUnlockEffect());
		}

		// Token: 0x0600C855 RID: 51285 RVA: 0x0030981C File Offset: 0x00307C1C
		public void SetNewUnlockTotalShow()
		{
			this.lockImg.CustomActive(false);
			this.unlockBtn.CustomActive(true);
			if (this.waitToShowNewUnlockEffect != null)
			{
				base.StopCoroutine(this.waitToShowNewUnlockEffect);
			}
			this.waitToShowNewUnlockEffect = base.StartCoroutine(this._WaitToShowNewUnlockEffect());
		}

		// Token: 0x04007361 RID: 29537
		private Coroutine waitToShowNewUnlockEffect;

		// Token: 0x04007362 RID: 29538
		private const string NEW_UNLOCK_EFFECT_RES_PATH = "Effects/UI/Prefab/EffUI_jueselanjiesuo/Prefab/EffUI_jueselanjiesuo";

		// Token: 0x04007363 RID: 29539
		[SerializeField]
		private Button lockBtn;

		// Token: 0x04007364 RID: 29540
		[SerializeField]
		private Image lockImg;

		// Token: 0x04007365 RID: 29541
		[SerializeField]
		private Image newUnlockImg;

		// Token: 0x04007366 RID: 29542
		[SerializeField]
		private Button unlockBtn;

		// Token: 0x04007367 RID: 29543
		[SerializeField]
		private GameObject newUnlockEffectRoot;

		// Token: 0x04007368 RID: 29544
		[Space(10f)]
		[Header("新解锁特效延迟显示的时间")]
		[SerializeField]
		private float newUnlockEffectShowDelayTime = 0.3f;

		// Token: 0x04007369 RID: 29545
		[Header("新解锁特效显示的阶段1_持续时间")]
		[SerializeField]
		private float newUnlockEffectDuration_1 = 0.3f;

		// Token: 0x0400736A RID: 29546
		[Header("新解锁特效显示的阶段2_持续时间")]
		[SerializeField]
		private float newUnlockEffectDuration_2 = 0.9f;

		// Token: 0x0400736B RID: 29547
		private GameObject newUnlockEffectGo;
	}
}
