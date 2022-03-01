using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001873 RID: 6259
	public class ArborDayTreeIdentifyItem : MonoBehaviour
	{
		// Token: 0x0600F535 RID: 62773 RVA: 0x00422591 File Offset: 0x00420991
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600F536 RID: 62774 RVA: 0x00422599 File Offset: 0x00420999
		private void ClearData()
		{
			this._treeIdentifyItemId = 0;
			this._itemTable = null;
			this._treeIdentifyItemIdStr = null;
			this._treeIndex = 0;
		}

		// Token: 0x0600F537 RID: 62775 RVA: 0x004225B7 File Offset: 0x004209B7
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x0600F538 RID: 62776 RVA: 0x004225BF File Offset: 0x004209BF
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x0600F539 RID: 62777 RVA: 0x004225C7 File Offset: 0x004209C7
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
		}

		// Token: 0x0600F53A RID: 62778 RVA: 0x004225E4 File Offset: 0x004209E4
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnCountValueChange, new ClientEventSystem.UIEventHandler(this.OnCountValueChangeChanged));
		}

		// Token: 0x0600F53B RID: 62779 RVA: 0x00422604 File Offset: 0x00420A04
		private void OnCountValueChangeChanged(UIEvent uiEvent)
		{
			if (this._treeIdentifyItemId <= 0)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			string a = (string)uiEvent.Param1;
			if (string.Equals(a, this._treeIdentifyItemIdStr))
			{
				this.UpdateItemOwnerFlag();
			}
		}

		// Token: 0x0600F53C RID: 62780 RVA: 0x00422654 File Offset: 0x00420A54
		public void InitItem(int itemId, string itemIdStr, int treeIndex)
		{
			this._treeIdentifyItemId = itemId;
			this._treeIdentifyItemIdStr = itemIdStr;
			this._treeIndex = treeIndex;
			if (this._treeIdentifyItemId <= 0)
			{
				return;
			}
			this._itemTable = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this._treeIdentifyItemId, string.Empty, string.Empty);
			if (this._itemTable == null)
			{
				return;
			}
			this.InitView();
		}

		// Token: 0x0600F53D RID: 62781 RVA: 0x004226B5 File Offset: 0x00420AB5
		private void InitView()
		{
			this.InitItemBaseView();
			this.UpdateItemOwnerFlag();
		}

		// Token: 0x0600F53E RID: 62782 RVA: 0x004226C4 File Offset: 0x00420AC4
		private void InitItemBaseView()
		{
			if (this.treeIndexLabel != null)
			{
				string text = TR.Value("Arbor_Day_Tree_Index_Format", this._treeIndex);
				this.treeIndexLabel.text = text;
			}
			if (this.treeIdentifyItemRoot != null)
			{
				CommonNewItem commonNewItem = this.treeIdentifyItemRoot.GetComponentInChildren<CommonNewItem>();
				if (commonNewItem == null)
				{
					commonNewItem = CommonUtility.CreateCommonNewItem(this.treeIdentifyItemRoot);
				}
				if (commonNewItem != null)
				{
					commonNewItem.InitItem(this._treeIdentifyItemId, 1);
				}
			}
		}

		// Token: 0x0600F53F RID: 62783 RVA: 0x00422754 File Offset: 0x00420B54
		private void UpdateItemOwnerFlag()
		{
			int counterValueByCounterStr = ArborDayUtility.GetCounterValueByCounterStr(this._treeIdentifyItemIdStr);
			if (counterValueByCounterStr > 0)
			{
				CommonUtility.UpdateGameObjectVisible(this.treeIdentifyItemOwnerFlag, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.treeIdentifyItemOwnerFlag, false);
			}
		}

		// Token: 0x0600F540 RID: 62784 RVA: 0x00422791 File Offset: 0x00420B91
		public void RecycleItem()
		{
			this._treeIdentifyItemId = 0;
			this._treeIdentifyItemIdStr = null;
			this._itemTable = null;
		}

		// Token: 0x0600F541 RID: 62785 RVA: 0x004227A8 File Offset: 0x00420BA8
		public void UpdateItem()
		{
			if (this._itemTable == null)
			{
				return;
			}
			this.UpdateItemOwnerFlag();
		}

		// Token: 0x04009664 RID: 38500
		private int _treeIdentifyItemId;

		// Token: 0x04009665 RID: 38501
		private ItemTable _itemTable;

		// Token: 0x04009666 RID: 38502
		private int _treeIndex;

		// Token: 0x04009667 RID: 38503
		private string _treeIdentifyItemIdStr;

		// Token: 0x04009668 RID: 38504
		[Space(10f)]
		[Header("TreeRoot")]
		[Space(10f)]
		[SerializeField]
		private Text treeIndexLabel;

		// Token: 0x04009669 RID: 38505
		[SerializeField]
		private GameObject treeIdentifyItemRoot;

		// Token: 0x0400966A RID: 38506
		[SerializeField]
		private GameObject treeIdentifyItemOwnerFlag;
	}
}
