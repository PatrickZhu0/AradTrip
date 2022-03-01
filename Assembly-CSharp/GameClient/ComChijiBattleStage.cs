using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001128 RID: 4392
	public class ComChijiBattleStage : MonoBehaviour
	{
		// Token: 0x0600A6D9 RID: 42713 RVA: 0x0022BD00 File Offset: 0x0022A100
		private void Start()
		{
			this._BindUIEvent();
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage == this.BattleStage)
			{
				if (!this.bHasLoadedBigIcon)
				{
					this._SetBigIcon();
					this.bHasLoadedBigIcon = true;
				}
			}
			else if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage >= this.BigStage && !this.bHasLoadedFinishIcon)
			{
				this._SetFinishIcon();
				this.bHasLoadedFinishIcon = true;
			}
		}

		// Token: 0x0600A6DA RID: 42714 RVA: 0x0022BD72 File Offset: 0x0022A172
		private void OnDestroy()
		{
			this._UnBindUIEvent();
			this.BattleStage = ChiJiTimeTable.eBattleStage.BS_NONE;
			this.bHasLoadedBigIcon = false;
			this.bHasLoadedFinishIcon = false;
			if (this.icon != null)
			{
				this.icon = null;
			}
		}

		// Token: 0x0600A6DB RID: 42715 RVA: 0x0022BDA7 File Offset: 0x0022A1A7
		private void _BindUIEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ChijiBattleStageChanged, new ClientEventSystem.UIEventHandler(this._OnStageChanged));
		}

		// Token: 0x0600A6DC RID: 42716 RVA: 0x0022BDC4 File Offset: 0x0022A1C4
		private void _UnBindUIEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ChijiBattleStageChanged, new ClientEventSystem.UIEventHandler(this._OnStageChanged));
		}

		// Token: 0x0600A6DD RID: 42717 RVA: 0x0022BDE4 File Offset: 0x0022A1E4
		private void _OnStageChanged(UIEvent iEvent)
		{
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage < this.BattleStage)
			{
				return;
			}
			if (this.BattleStage == ChiJiTimeTable.eBattleStage.BS_PUT_ITEM_1)
			{
			}
			if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage == this.BattleStage)
			{
				if (!this.bHasLoadedBigIcon)
				{
					this._SetBigIcon();
					this.bHasLoadedBigIcon = true;
				}
			}
			else if (DataManager<ChijiDataManager>.GetInstance().CurBattleStage >= this.BigStage && !this.bHasLoadedFinishIcon)
			{
				this._SetFinishIcon();
				this.bHasLoadedFinishIcon = true;
			}
		}

		// Token: 0x0600A6DE RID: 42718 RVA: 0x0022BE74 File Offset: 0x0022A274
		private void _SetFinishIcon()
		{
			if (this.icon != null)
			{
				ETCImageLoader.LoadSprite(ref this.icon, this.FinishIconPath, true);
				RectTransform component = this.icon.GetComponent<RectTransform>();
				if (component != null)
				{
					component.sizeDelta = this.normalSize;
				}
			}
			if (this.EffectObjRoot != null)
			{
				this.EffectObjRoot.CustomActive(false);
			}
		}

		// Token: 0x0600A6DF RID: 42719 RVA: 0x0022BEE8 File Offset: 0x0022A2E8
		private void _SetBigIcon()
		{
			if (this.icon != null)
			{
				ETCImageLoader.LoadSprite(ref this.icon, this.BigIconPath, true);
				RectTransform component = this.icon.GetComponent<RectTransform>();
				if (component != null)
				{
					component.sizeDelta = this.bigSize;
				}
			}
			if (this.EffectObjRoot != null)
			{
				this.EffectObjRoot.CustomActive(true);
			}
		}

		// Token: 0x0600A6E0 RID: 42720 RVA: 0x0022BF5A File Offset: 0x0022A35A
		private void Update()
		{
		}

		// Token: 0x04005D61 RID: 23905
		public ChiJiTimeTable.eBattleStage BattleStage;

		// Token: 0x04005D62 RID: 23906
		public ChiJiTimeTable.eBattleStage BigStage;

		// Token: 0x04005D63 RID: 23907
		public Image icon;

		// Token: 0x04005D64 RID: 23908
		public GameObject EffectObjRoot;

		// Token: 0x04005D65 RID: 23909
		public string FinishIconPath = string.Empty;

		// Token: 0x04005D66 RID: 23910
		public string BigIconPath = string.Empty;

		// Token: 0x04005D67 RID: 23911
		public Vector2 normalSize = new Vector2(0f, 0f);

		// Token: 0x04005D68 RID: 23912
		public Vector2 bigSize = new Vector2(0f, 0f);

		// Token: 0x04005D69 RID: 23913
		private bool bHasLoadedBigIcon;

		// Token: 0x04005D6A RID: 23914
		private bool bHasLoadedFinishIcon;
	}
}
