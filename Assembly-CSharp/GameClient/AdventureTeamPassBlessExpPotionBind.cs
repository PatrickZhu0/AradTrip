using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001425 RID: 5157
	public class AdventureTeamPassBlessExpPotionBind : MonoBehaviour
	{
		// Token: 0x0600C80C RID: 51212 RVA: 0x00308124 File Offset: 0x00306524
		private void Awake()
		{
			if (this.fillupEffectGo == null)
			{
				this.fillupEffectGo = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject("Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_xiaopin", true, 0U);
				this.fillupEffectGo.CustomActive(false);
				Utility.AttachTo(this.fillupEffectGo, this.emptyExpFlyGo, false);
			}
		}

		// Token: 0x0600C80D RID: 51213 RVA: 0x00308177 File Offset: 0x00306577
		private void OnDestroy()
		{
			this.isEmpty = false;
			this.fillupEffectGo = null;
			if (this.waitToPlayExpFillupEffect != null)
			{
				base.StopCoroutine(this.waitToPlayExpFillupEffect);
				this.waitToPlayExpFillupEffect = null;
			}
		}

		// Token: 0x0600C80E RID: 51214 RVA: 0x003081A5 File Offset: 0x003065A5
		public void InitView(string indexStr, bool bEmpty)
		{
			this.SetDrugIndex(indexStr);
			this.SetDrugStatus(bEmpty);
		}

		// Token: 0x0600C80F RID: 51215 RVA: 0x003081B5 File Offset: 0x003065B5
		public void Useup()
		{
			if (!this.isEmpty)
			{
				this.SetEffectShow(true);
				this.SetDrugStatus(true);
			}
		}

		// Token: 0x0600C810 RID: 51216 RVA: 0x003081D0 File Offset: 0x003065D0
		public void Fillup()
		{
			if (this.isEmpty)
			{
				this.SetEffectShow(true);
				this.SetDrugStatus(false);
			}
		}

		// Token: 0x0600C811 RID: 51217 RVA: 0x003081EC File Offset: 0x003065EC
		public void SetEffectShow(bool bShow)
		{
			if (this.fillupEffectGo)
			{
				if (!bShow)
				{
					this.fillupEffectGo.CustomActive(false);
				}
				else
				{
					if (this.waitToPlayExpFillupEffect != null)
					{
						base.StopCoroutine(this.waitToPlayExpFillupEffect);
					}
					this.waitToPlayExpFillupEffect = base.StartCoroutine(this._WaitToPlayExpFillupEffect());
				}
			}
		}

		// Token: 0x0600C812 RID: 51218 RVA: 0x0030824C File Offset: 0x0030664C
		private IEnumerator _WaitToPlayExpFillupEffect()
		{
			this.fillupEffectGo.CustomActive(false);
			this.fillupEffectGo.CustomActive(true);
			yield return Yielders.GetWaitForSeconds(this.mEffectExpFillupDuration);
			this.fillupEffectGo.CustomActive(false);
			yield break;
		}

		// Token: 0x0600C813 RID: 51219 RVA: 0x00308267 File Offset: 0x00306667
		public bool GetDrugIsEmpty()
		{
			return this.isEmpty;
		}

		// Token: 0x0600C814 RID: 51220 RVA: 0x0030826F File Offset: 0x0030666F
		public void SetDrugStatus(bool bEmpty)
		{
			if (this.drugGray)
			{
				this.drugGray.enabled = bEmpty;
			}
			this.isEmpty = bEmpty;
		}

		// Token: 0x0600C815 RID: 51221 RVA: 0x00308294 File Offset: 0x00306694
		public void SetDrugIndex(string index)
		{
			if (this.drugIndex)
			{
				this.drugIndex.text = index;
			}
		}

		// Token: 0x0600C816 RID: 51222 RVA: 0x003082B2 File Offset: 0x003066B2
		public GameObject GetEmptyExpFlyTarget()
		{
			return this.emptyExpFlyGo;
		}

		// Token: 0x04007330 RID: 29488
		private const string EFFUI_EXP_POTION_FILL_UP_RES_PATH = "Effects/UI/Prefab/EffUI_yongbingtuan/Prefab/EffUI_yongbingtuan_xiaopin";

		// Token: 0x04007331 RID: 29489
		[SerializeField]
		private UIGray drugGray;

		// Token: 0x04007332 RID: 29490
		[SerializeField]
		private Text drugIndex;

		// Token: 0x04007333 RID: 29491
		[SerializeField]
		private GameObject emptyExpFlyGo;

		// Token: 0x04007334 RID: 29492
		[SerializeField]
		[Header("经验激活一个的动画时长")]
		private float mEffectExpFillupDuration = 3f;

		// Token: 0x04007335 RID: 29493
		private bool isEmpty;

		// Token: 0x04007336 RID: 29494
		private GameObject fillupEffectGo;

		// Token: 0x04007337 RID: 29495
		private Coroutine waitToPlayExpFillupEffect;
	}
}
