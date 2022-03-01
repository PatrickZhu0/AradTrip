using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000006 RID: 6
	internal class ActiveAwardFrameNew : ClientFrame
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00004D25 File Offset: 0x00003125
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Activity/ActiveAwardFrameNew";
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00004D2C File Offset: 0x0000312C
		[UIEventHandle("ButtonTempBlue")]
		private void _OnClickClose()
		{
			DataManager<ActiveManager>.GetInstance().SendSubmitActivity(1940, 0U);
			this.frameMgr.CloseFrame<ActiveAwardFrameNew>(this, false);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00004D4C File Offset: 0x0000314C
		private void _SetAwards()
		{
			if (this.awardsData == null)
			{
				return;
			}
			if (this.awardsData.canGet)
			{
				UIGray component = this.GetBt.GetComponent<UIGray>();
				if (component == null)
				{
					Logger.LogErrorFormat("can not find uigray", new object[0]);
					return;
				}
				this.GetBt.GetComponent<Button>().enabled = true;
				component.enabled = false;
			}
			else
			{
				UIGray component2 = this.GetBt.GetComponent<UIGray>();
				if (component2 == null)
				{
					Logger.LogErrorFormat("can not find uigray", new object[0]);
					return;
				}
				this.GetBt.GetComponent<Button>().enabled = false;
				component2.enabled = true;
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

		// Token: 0x0600001A RID: 26 RVA: 0x00004F15 File Offset: 0x00003315
		private void _OnItemClicked(GameObject obj, ItemData item)
		{
			if (item != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(item, null, 4, true, false, true);
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00004F2D File Offset: 0x0000332D
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			this.awardsData = (this.userData as ActiveAwardFrameDataNew);
			this.goPrefabs.CustomActive(false);
			this._SetAwards();
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00004F5E File Offset: 0x0000335E
		protected override void _OnCloseFrame()
		{
			this.awardsData = null;
		}

		// Token: 0x0400000E RID: 14
		private ActiveAwardFrameDataNew awardsData;

		// Token: 0x0400000F RID: 15
		[UIControl("Title/Text", typeof(Text), 0)]
		private Text m_kTitle;

		// Token: 0x04000010 RID: 16
		[UIObject("Awards")]
		private GameObject goParent;

		// Token: 0x04000011 RID: 17
		[UIObject("Awards/ItemParent")]
		private GameObject goPrefabs;

		// Token: 0x04000012 RID: 18
		[UIObject("ButtonTempBlue")]
		private GameObject GetBt;
	}
}
