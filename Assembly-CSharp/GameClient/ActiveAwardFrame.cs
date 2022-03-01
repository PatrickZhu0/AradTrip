using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000004 RID: 4
	internal class ActiveAwardFrame : ClientFrame
	{
		// Token: 0x0600000F RID: 15 RVA: 0x00004B92 File Offset: 0x00002F92
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/ActiveAwardFrame";
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004B99 File Offset: 0x00002F99
		[UIEventHandle("ButtonTempBlue")]
		private void _OnClickClose()
		{
			this.frameMgr.CloseFrame<ActiveAwardFrame>(this, false);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004BA8 File Offset: 0x00002FA8
		private void _SetAwards()
		{
			if (this.awardsData == null)
			{
				return;
			}
			this.m_kTitle.text = this.awardsData.title;
			int num = 0;
			while (this.awardsData.datas != null && num < this.awardsData.datas.Count)
			{
				AwardItemData awardItemData = this.awardsData.datas[num];
				if (awardItemData != null && awardItemData.Num > 0)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(awardItemData.ID);
					if (commonItemTableDataByID != null)
					{
						commonItemTableDataByID.Count = awardItemData.Num;
						GameObject gameObject = Object.Instantiate<GameObject>(this.goPrefabs);
						if (gameObject != null)
						{
							Utility.AttachTo(gameObject, this.goParent, false);
							gameObject.CustomActive(true);
							ComItem comItem = base.CreateComItem(gameObject);
							comItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this._OnItemClicked));
							comItem.gameObject.transform.SetAsFirstSibling();
							Text text = Utility.FindComponent<Text>(gameObject, "Name", true);
							text.text = commonItemTableDataByID.GetColorName(string.Empty, false);
						}
					}
				}
				num++;
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00004CCF File Offset: 0x000030CF
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00004CE7 File Offset: 0x000030E7
		protected override void _OnOpenFrame()
		{
			this.awardsData = (this.userData as ActiveAwardFrameData);
			this.goPrefabs.CustomActive(false);
			this._SetAwards();
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00004D0C File Offset: 0x0000310C
		protected override void _OnCloseFrame()
		{
			this.awardsData = null;
		}

		// Token: 0x04000007 RID: 7
		private ActiveAwardFrameData awardsData;

		// Token: 0x04000008 RID: 8
		[UIControl("Title/Text", typeof(Text), 0)]
		private Text m_kTitle;

		// Token: 0x04000009 RID: 9
		[UIObject("Awards")]
		private GameObject goParent;

		// Token: 0x0400000A RID: 10
		[UIObject("Awards/ItemParent")]
		private GameObject goPrefabs;
	}
}
