using System;
using System.Collections.Generic;
using Battle;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020010A4 RID: 4260
	public class DungeonBuffInfoFrame : ClientFrame
	{
		// Token: 0x0600A09B RID: 41115 RVA: 0x002067E8 File Offset: 0x00204BE8
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/BattleUI/DungeonBuffInfoFrame";
		}

		// Token: 0x0600A09C RID: 41116 RVA: 0x002067EF File Offset: 0x00204BEF
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._updateAllBuff));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this._removeBuff));
			this._updateAllBuff(null);
		}

		// Token: 0x0600A09D RID: 41117 RVA: 0x0020682E File Offset: 0x00204C2E
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffListChanged, new ClientEventSystem.UIEventHandler(this._updateAllBuff));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffRemoved, new ClientEventSystem.UIEventHandler(this._removeBuff));
		}

		// Token: 0x0600A09E RID: 41118 RVA: 0x00206866 File Offset: 0x00204C66
		private void _clearAll()
		{
			this.mComBuffInfoList.RemoveAll(delegate(ComTipInfoUnit x)
			{
				if (null != x)
				{
					Object.Destroy(x);
					x = null;
				}
				return true;
			});
			this.mBuffList.Clear();
		}

		// Token: 0x0600A09F RID: 41119 RVA: 0x0020689C File Offset: 0x00204C9C
		private void _updateAllBuff(UIEvent ui)
		{
			this._clearAll();
			for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().buffList.Count; i++)
			{
				DungeonBuff dungeonBuff = DataManager<PlayerBaseData>.GetInstance().buffList[i];
				if (dungeonBuff.lefttime > 0f)
				{
					this._realAddBuff(dungeonBuff.id);
				}
			}
			this._updateBuffBoard();
		}

		// Token: 0x0600A0A0 RID: 41120 RVA: 0x00206904 File Offset: 0x00204D04
		private void _removeBuff(UIEvent ui)
		{
			int id = (int)ui.Param1;
			this._removeBuff(id);
			this._updateBuffBoard();
		}

		// Token: 0x0600A0A1 RID: 41121 RVA: 0x0020692C File Offset: 0x00204D2C
		private void _realAddBuff(int id)
		{
			int num = this.mBuffList.BinarySearch(id);
			if (num < 0)
			{
				if (this._addBuffUnit(~num, id))
				{
					this.mBuffList.Insert(~num, id);
				}
				else
				{
					Logger.LogErrorFormat("[bufflist] 添加buff {0} 失败", new object[]
					{
						id
					});
				}
			}
		}

		// Token: 0x0600A0A2 RID: 41122 RVA: 0x00206988 File Offset: 0x00204D88
		private bool _addBuffUnit(int idx, int id)
		{
			BuffTable tableItem = Singleton<TableManager>.instance.GetTableItem<BuffTable>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (!Utility.IsStringValid(tableItem.Icon))
				{
					return false;
				}
				AssetInst assetInst = Singleton<AssetLoader>.instance.LoadRes(tableItem.Icon, typeof(Sprite), true, 0U);
				if (assetInst != null && assetInst.obj != null)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/BattleUI/DungeonBuffInfoUnit", true, 0U);
					ComTipInfoUnit component = gameObject.GetComponent<ComTipInfoUnit>();
					gameObject.name = string.Format(idx.ToString(), new object[0]);
					Utility.AttachTo(gameObject, this.mContentRoot, false);
					Sprite sprite = assetInst.obj as Sprite;
					component.SetData(tableItem);
					component.SetSprite(sprite);
					this.mComBuffInfoList.Insert(idx, component);
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A0A3 RID: 41123 RVA: 0x00206A70 File Offset: 0x00204E70
		private void _updateBuffBoard()
		{
			for (int i = 0; i < this.mComBuffInfoList.Count; i++)
			{
				this.mComBuffInfoList[i].SetBgActive(i % 2 > 0);
			}
		}

		// Token: 0x0600A0A4 RID: 41124 RVA: 0x00206AB0 File Offset: 0x00204EB0
		private void _removeBuff(int id)
		{
			int num = this.mBuffList.BinarySearch(id);
			if (num >= 0)
			{
				if (this.mComBuffInfoList[num].gameObject != null)
				{
					Object.Destroy(this.mComBuffInfoList[num].gameObject);
				}
				this.mBuffList.RemoveAt(num);
				this.mComBuffInfoList.RemoveAt(num);
			}
		}

		// Token: 0x0600A0A5 RID: 41125 RVA: 0x00206B1B File Offset: 0x00204F1B
		[UIEventHandle("Root/Close")]
		private void _onClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonBuffInfoFrame>(this, false);
		}

		// Token: 0x0600A0A6 RID: 41126 RVA: 0x00206B29 File Offset: 0x00204F29
		[UIEventHandle("Bg")]
		private void _onBgClose()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<DungeonBuffInfoFrame>(this, false);
		}

		// Token: 0x04005939 RID: 22841
		private const string kPath2 = "UIFlatten/Prefabs/BattleUI/DungeonBuffInfoUnit";

		// Token: 0x0400593A RID: 22842
		private List<int> mBuffList = new List<int>();

		// Token: 0x0400593B RID: 22843
		private List<ComTipInfoUnit> mComBuffInfoList = new List<ComTipInfoUnit>();

		// Token: 0x0400593C RID: 22844
		[UIObject("Root/Center/Scroll/Viewport/Content")]
		private GameObject mContentRoot;
	}
}
