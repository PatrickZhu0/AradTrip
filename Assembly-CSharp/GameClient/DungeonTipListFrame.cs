using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010BD RID: 4285
	[LoggerModel("Chapter")]
	public class DungeonTipListFrame : ClientFrame
	{
		// Token: 0x0600A1D2 RID: 41426 RVA: 0x0020F902 File Offset: 0x0020DD02
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/DungeonTipList";
		}

		// Token: 0x0600A1D3 RID: 41427 RVA: 0x0020F90C File Offset: 0x0020DD0C
		protected override void _OnOpenFrame()
		{
			this.mInfoRoot.SetActive(false);
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				this.mBuffs[i].Clear();
			}
			this.mBuffs.Clear();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleBuffAdded, new ClientEventSystem.UIEventHandler(this._addBuffEvent));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BattleBuffRemoved, new ClientEventSystem.UIEventHandler(this._removeBuffEvent));
		}

		// Token: 0x0600A1D4 RID: 41428 RVA: 0x0020F994 File Offset: 0x0020DD94
		protected override void _OnCloseFrame()
		{
			this._clearRoot();
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				this.mBuffs[i].Clear();
			}
			this.mBuffs.Clear();
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleBuffAdded, new ClientEventSystem.UIEventHandler(this._addBuffEvent));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BattleBuffRemoved, new ClientEventSystem.UIEventHandler(this._removeBuffEvent));
		}

		// Token: 0x0600A1D5 RID: 41429 RVA: 0x0020FA18 File Offset: 0x0020DE18
		private void _addBuffEvent(UIEvent ui)
		{
			int id = (int)ui.Param1;
			this._updateTipsRoot();
			BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(id, string.Empty, string.Empty);
			if (tableItem == null || tableItem.IconSortOrder <= -1)
			{
				return;
			}
			DungeonTipListFrame.BuffUnit buffUnit = this._addBuffUnit(id);
			if (buffUnit == null)
			{
				return;
			}
			buffUnit.sortOrder = tableItem.IconSortOrder;
			AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(tableItem.Icon, typeof(Sprite), true, 0U);
			if (assetInst != null)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonTipUnit", true, 0U);
				ComTipsUnit component = gameObject.GetComponent<ComTipsUnit>();
				gameObject.name = string.Format(buffUnit.sortOrder.ToString(), new object[0]);
				Utility.AttachTo(gameObject, this.mRoot, false);
				buffUnit.comBuffTipsUnit = component;
				GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonTipInfoUnit", true, 0U);
				ComTipInfoUnit component2 = gameObject2.GetComponent<ComTipInfoUnit>();
				gameObject2.name = gameObject.name;
				Utility.AttachTo(gameObject2, this.mRoot2, false);
				buffUnit.comBuffInfosUnit = component2;
				Sprite sprite = assetInst.obj as Sprite;
				component.SetPercent(1f);
				component.SetSprite(sprite);
				component2.SetData(tableItem);
				component2.SetSprite(sprite);
			}
			this._sortBuffUnits();
			this._updateBuffGraphicOrder();
		}

		// Token: 0x0600A1D6 RID: 41430 RVA: 0x0020FB78 File Offset: 0x0020DF78
		private void _removeBuffEvent(UIEvent ui)
		{
			int id = (int)ui.Param1;
			DungeonTipListFrame.BuffUnit buffUnit = this._removeBuffUnit(id);
			if (buffUnit == null)
			{
				return;
			}
			buffUnit.Clear();
		}

		// Token: 0x0600A1D7 RID: 41431 RVA: 0x0020FBA8 File Offset: 0x0020DFA8
		private void _updateBuffGraphicOrder()
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (null != this.mBuffs[i].comBuffTipsUnit)
				{
					this.mBuffs[i].comBuffTipsUnit.gameObject.transform.SetAsLastSibling();
				}
			}
			for (int j = 0; j < this.mBuffs.Count; j++)
			{
				this.mBuffs[j].comBuffTipsUnit.gameObject.CustomActive(j < this.kMaxShowBuffUnit);
			}
		}

		// Token: 0x0600A1D8 RID: 41432 RVA: 0x0020FC50 File Offset: 0x0020E050
		private BeActor _getPlayerActor()
		{
			if (BattleMain.instance != null)
			{
				IDungeonPlayerDataManager playerManager = BattleMain.instance.GetPlayerManager();
				if (playerManager != null)
				{
					BattlePlayer mainPlayer = playerManager.GetMainPlayer();
					if (mainPlayer != null)
					{
						return mainPlayer.playerActor;
					}
				}
			}
			return null;
		}

		// Token: 0x0600A1D9 RID: 41433 RVA: 0x0020FC90 File Offset: 0x0020E090
		private DungeonTipListFrame.BuffUnit _findBuffUnit(int id)
		{
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				if (id == this.mBuffs[i].id)
				{
					return this.mBuffs[i];
				}
			}
			return null;
		}

		// Token: 0x0600A1DA RID: 41434 RVA: 0x0020FCDE File Offset: 0x0020E0DE
		private void _sortBuffUnits()
		{
			this.mBuffs.Sort();
		}

		// Token: 0x0600A1DB RID: 41435 RVA: 0x0020FCEB File Offset: 0x0020E0EB
		private bool _existBuffUnit(int id)
		{
			return null != this._findBuffUnit(id);
		}

		// Token: 0x0600A1DC RID: 41436 RVA: 0x0020FCFC File Offset: 0x0020E0FC
		private DungeonTipListFrame.BuffUnit _addBuffUnit(int id)
		{
			if (this._existBuffUnit(id))
			{
				return null;
			}
			DungeonTipListFrame.BuffUnit buffUnit = new DungeonTipListFrame.BuffUnit();
			buffUnit.id = id;
			this.mBuffs.Add(buffUnit);
			return buffUnit;
		}

		// Token: 0x0600A1DD RID: 41437 RVA: 0x0020FD34 File Offset: 0x0020E134
		private DungeonTipListFrame.BuffUnit _removeBuffUnit(int id)
		{
			DungeonTipListFrame.BuffUnit buffUnit = this._findBuffUnit(id);
			if (buffUnit == null)
			{
				return null;
			}
			this.mBuffs.Remove(buffUnit);
			return buffUnit;
		}

		// Token: 0x0600A1DE RID: 41438 RVA: 0x0020FD60 File Offset: 0x0020E160
		private void _updateTipsRoot()
		{
			if (null == this.frame)
			{
				return;
			}
			if (null == this.mRoot)
			{
				this.mRoot = Utility.FindGameObject(this.frame, "Root", true);
			}
			if (null == this.mRoot2)
			{
				this.mRoot2 = Utility.FindGameObject(this.frame, "InfoRoot", true);
			}
		}

		// Token: 0x0600A1DF RID: 41439 RVA: 0x0020FDCF File Offset: 0x0020E1CF
		private void _clearRoot()
		{
			this.mRoot2 = null;
			this.mRoot = null;
		}

		// Token: 0x0600A1E0 RID: 41440 RVA: 0x0020FDE0 File Offset: 0x0020E1E0
		protected override void _OnUpdate(float timeElapsed)
		{
			BeActor beActor = this._getPlayerActor();
			if (beActor == null)
			{
				return;
			}
			for (int i = 0; i < this.mBuffs.Count; i++)
			{
				DungeonTipListFrame.BuffUnit buffUnit = this.mBuffs[i];
				if (buffUnit != null && !(null == buffUnit.comBuffTipsUnit))
				{
					BeBuff beBuff = beActor.buffController.HasBuffByID(buffUnit.id);
					if (beBuff != null)
					{
						float percent = (float)beBuff.GetLeftTime() * 1f / (float)beBuff.duration;
						buffUnit.comBuffTipsUnit.SetPercent(percent);
					}
				}
			}
		}

		// Token: 0x0600A1E1 RID: 41441 RVA: 0x0020FE81 File Offset: 0x0020E281
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600A1E2 RID: 41442 RVA: 0x0020FE84 File Offset: 0x0020E284
		[UIEventHandle("Root")]
		private void _onHiddenShow()
		{
		}

		// Token: 0x0600A1E3 RID: 41443 RVA: 0x0020FE86 File Offset: 0x0020E286
		private void _onOpenInfo()
		{
			Singleton<ClientSystemManager>.instance.OpenFrame<DungeonTipInfoFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x04005A45 RID: 23109
		private readonly int kMaxShowBuffUnit = 6;

		// Token: 0x04005A46 RID: 23110
		private const string kPath = "UIFlatten/Prefabs/BattleUI/DungeonTipUnit";

		// Token: 0x04005A47 RID: 23111
		private const string kPath2 = "UIFlatten/Prefabs/BattleUI/DungeonTipInfoUnit";

		// Token: 0x04005A48 RID: 23112
		private List<DungeonTipListFrame.BuffUnit> mBuffs = new List<DungeonTipListFrame.BuffUnit>();

		// Token: 0x04005A49 RID: 23113
		private GameObject mRoot;

		// Token: 0x04005A4A RID: 23114
		private GameObject mRoot2;

		// Token: 0x04005A4B RID: 23115
		[UIObject("InfoRoot")]
		private GameObject mInfoRoot;

		// Token: 0x020010BE RID: 4286
		private class BuffUnit : IComparable<DungeonTipListFrame.BuffUnit>
		{
			// Token: 0x1700199D RID: 6557
			// (get) Token: 0x0600A1E5 RID: 41445 RVA: 0x0020FEA2 File Offset: 0x0020E2A2
			// (set) Token: 0x0600A1E6 RID: 41446 RVA: 0x0020FEAA File Offset: 0x0020E2AA
			public int id { get; set; }

			// Token: 0x1700199E RID: 6558
			// (get) Token: 0x0600A1E7 RID: 41447 RVA: 0x0020FEB3 File Offset: 0x0020E2B3
			// (set) Token: 0x0600A1E8 RID: 41448 RVA: 0x0020FEBB File Offset: 0x0020E2BB
			public int sortOrder { get; set; }

			// Token: 0x1700199F RID: 6559
			// (get) Token: 0x0600A1E9 RID: 41449 RVA: 0x0020FEC4 File Offset: 0x0020E2C4
			// (set) Token: 0x0600A1EA RID: 41450 RVA: 0x0020FECC File Offset: 0x0020E2CC
			public ComTipsUnit comBuffTipsUnit { get; set; }

			// Token: 0x170019A0 RID: 6560
			// (get) Token: 0x0600A1EB RID: 41451 RVA: 0x0020FED5 File Offset: 0x0020E2D5
			// (set) Token: 0x0600A1EC RID: 41452 RVA: 0x0020FEDD File Offset: 0x0020E2DD
			public ComTipInfoUnit comBuffInfosUnit { get; set; }

			// Token: 0x0600A1ED RID: 41453 RVA: 0x0020FEE6 File Offset: 0x0020E2E6
			public int CompareTo(DungeonTipListFrame.BuffUnit other)
			{
				if (this.sortOrder == other.sortOrder)
				{
					return this.id - other.id;
				}
				return this.sortOrder - other.sortOrder;
			}

			// Token: 0x0600A1EE RID: 41454 RVA: 0x0020FF14 File Offset: 0x0020E314
			public void Clear()
			{
				if (null != this.comBuffInfosUnit)
				{
					Object.Destroy(this.comBuffInfosUnit.gameObject);
					this.comBuffInfosUnit = null;
				}
				if (null != this.comBuffTipsUnit)
				{
					Object.Destroy(this.comBuffTipsUnit.gameObject);
					this.comBuffTipsUnit = null;
				}
			}
		}
	}
}
