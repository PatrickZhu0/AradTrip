using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001632 RID: 5682
	public class GuildManorRankListFrame : GameFrame
	{
		// Token: 0x0600DF33 RID: 57139 RVA: 0x0038F2C6 File Offset: 0x0038D6C6
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildManorRankList";
		}

		// Token: 0x0600DF34 RID: 57140 RVA: 0x0038F2CD File Offset: 0x0038D6CD
		protected override void OnOpenFrame()
		{
			this.sortList = (this.userData as BaseSortList);
			this.InitRankComUIList();
			this.UpdateRankComUIList();
			this.UpdateMyGuildRank();
		}

		// Token: 0x0600DF35 RID: 57141 RVA: 0x0038F2F2 File Offset: 0x0038D6F2
		protected override void OnCloseFrame()
		{
			this.sortList = null;
		}

		// Token: 0x0600DF36 RID: 57142 RVA: 0x0038F2FC File Offset: 0x0038D6FC
		protected override void _bindExUI()
		{
			this.rankComUIList = this.mBind.GetCom<ComUIListScript>("rankComUIList");
			this.testTxt = this.mBind.GetCom<Text>("testTxt");
			this.testBtn = this.mBind.GetCom<Button>("testBtn");
			this.testBtn.SafeSetOnClickListener(delegate
			{
			});
			this.testImg = this.mBind.GetCom<Image>("testImg");
			this.testSlider = this.mBind.GetCom<Slider>("testSlider");
			this.testSlider.SafeSetValueChangeListener(delegate(float value)
			{
			});
			this.testToggle = this.mBind.GetCom<Toggle>("testToggle");
			this.testToggle.SafeSetOnValueChangedListener(delegate(bool value)
			{
			});
			this.testGo = this.mBind.GetGameObject("testGo");
			this.myGuildRank = this.mBind.GetCom<GuildManorRankListItem>("myGuildRank");
			this.myGuildRankRoot = this.mBind.GetGameObject("myGuildRankRoot");
		}

		// Token: 0x0600DF37 RID: 57143 RVA: 0x0038F448 File Offset: 0x0038D848
		protected override void _unbindExUI()
		{
			this.rankComUIList = null;
			this.testTxt = null;
			this.testBtn = null;
			this.testImg = null;
			this.testSlider = null;
			this.testToggle = null;
			this.testGo = null;
			this.myGuildRank = null;
			this.myGuildRankRoot = null;
		}

		// Token: 0x0600DF38 RID: 57144 RVA: 0x0038F494 File Offset: 0x0038D894
		protected override void OnBindUIEvent()
		{
			base.BindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600DF39 RID: 57145 RVA: 0x0038F4AD File Offset: 0x0038D8AD
		protected override void OnUnBindUIEvent()
		{
			base.UnBindUIEvent(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this._OnOnCountValueChange));
		}

		// Token: 0x0600DF3A RID: 57146 RVA: 0x0038F4C6 File Offset: 0x0038D8C6
		public override bool IsNeedUpdate()
		{
			return false;
		}

		// Token: 0x0600DF3B RID: 57147 RVA: 0x0038F4C9 File Offset: 0x0038D8C9
		protected override void _OnUpdate(float timeElapsed)
		{
		}

		// Token: 0x0600DF3C RID: 57148 RVA: 0x0038F4CC File Offset: 0x0038D8CC
		private void InitRankComUIList()
		{
			if (this.rankComUIList == null)
			{
				return;
			}
			this.rankComUIList.Initialize();
			this.rankComUIList.onBindItem = ((GameObject go) => go);
			this.rankComUIList.onItemVisiable = delegate(ComUIListElementScript go)
			{
				if (go == null)
				{
					return;
				}
				if (this.rankComUIListDatas == null)
				{
					return;
				}
				ComUIListTemplateItem component = go.GetComponent<ComUIListTemplateItem>();
				if (component == null)
				{
					return;
				}
				if (go.m_index >= 0 && go.m_index < this.rankComUIListDatas.Count)
				{
					component.SetUp(this.rankComUIListDatas[go.m_index]);
				}
			};
		}

		// Token: 0x0600DF3D RID: 57149 RVA: 0x0038F538 File Offset: 0x0038D938
		private int GetMaxGuildBattleTerrScoreRank()
		{
			int num = 0;
			Dictionary<int, object> table = Singleton<TableManager>.instance.GetTable<GuildBattleScoreRankRewardTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					GuildBattleScoreRankRewardTable guildBattleScoreRankRewardTable = keyValuePair.Value as GuildBattleScoreRankRewardTable;
					if (guildBattleScoreRankRewardTable != null)
					{
						if (guildBattleScoreRankRewardTable.ID >= num)
						{
							num = guildBattleScoreRankRewardTable.ID;
						}
					}
				}
			}
			return num;
		}

		// Token: 0x0600DF3E RID: 57150 RVA: 0x0038F5A8 File Offset: 0x0038D9A8
		private void CalcRankComUIListDatas()
		{
			this.rankComUIListDatas = new List<GuildBattleTerrScoreRank>();
			if (this.rankComUIListDatas == null)
			{
				return;
			}
			if (this.sortList == null)
			{
				return;
			}
			if (this.sortList.entries == null)
			{
				return;
			}
			for (int i = 0; i < this.sortList.entries.Count; i++)
			{
				this.rankComUIListDatas.Add(this.sortList.entries[i] as GuildBattleTerrScoreRank);
			}
			int maxGuildBattleTerrScoreRank = this.GetMaxGuildBattleTerrScoreRank();
			for (int j = this.rankComUIListDatas.Count; j < maxGuildBattleTerrScoreRank; j++)
			{
				this.rankComUIListDatas.Add(new GuildBattleTerrScoreRank
				{
					ranking = (ushort)(j + 1)
				});
			}
			this.rankComUIListDatas.Sort(delegate(GuildBattleTerrScoreRank a, GuildBattleTerrScoreRank b)
			{
				if (a == null || b == null)
				{
					return 0;
				}
				return a.ranking.CompareTo(b.ranking);
			});
		}

		// Token: 0x0600DF3F RID: 57151 RVA: 0x0038F692 File Offset: 0x0038DA92
		private void UpdateRankComUIList()
		{
			if (this.rankComUIList == null)
			{
				return;
			}
			this.CalcRankComUIListDatas();
			if (this.rankComUIListDatas == null)
			{
				return;
			}
			this.rankComUIList.SetElementAmount(this.rankComUIListDatas.Count);
		}

		// Token: 0x0600DF40 RID: 57152 RVA: 0x0038F6D0 File Offset: 0x0038DAD0
		private void UpdateMyGuildRank()
		{
			if (this.myGuildRank == null)
			{
				return;
			}
			if (this.sortList == null)
			{
				return;
			}
			GuildBattleTerrScoreRank guildBattleTerrScoreRank = this.sortList.selfEntry as GuildBattleTerrScoreRank;
			if (guildBattleTerrScoreRank == null)
			{
				return;
			}
			this.myGuildRank.SetUp(guildBattleTerrScoreRank);
			this.myGuildRankRoot.CustomActive(this.sortList.entries != null && this.sortList.entries.Count > 0);
		}

		// Token: 0x0600DF41 RID: 57153 RVA: 0x0038F750 File Offset: 0x0038DB50
		private void _OnOnCountValueChange(UIEvent uiEvent)
		{
		}

		// Token: 0x04008484 RID: 33924
		private List<GuildBattleTerrScoreRank> rankComUIListDatas = new List<GuildBattleTerrScoreRank>();

		// Token: 0x04008485 RID: 33925
		private BaseSortList sortList;

		// Token: 0x04008486 RID: 33926
		private ComUIListScript rankComUIList;

		// Token: 0x04008487 RID: 33927
		private Text testTxt;

		// Token: 0x04008488 RID: 33928
		private Button testBtn;

		// Token: 0x04008489 RID: 33929
		private Image testImg;

		// Token: 0x0400848A RID: 33930
		private Slider testSlider;

		// Token: 0x0400848B RID: 33931
		private Toggle testToggle;

		// Token: 0x0400848C RID: 33932
		private GameObject testGo;

		// Token: 0x0400848D RID: 33933
		private GuildManorRankListItem myGuildRank;

		// Token: 0x0400848E RID: 33934
		private GameObject myGuildRankRoot;
	}
}
