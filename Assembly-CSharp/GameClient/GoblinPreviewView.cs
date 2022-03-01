using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A74 RID: 6772
	public class GoblinPreviewView : MonoBehaviour
	{
		// Token: 0x060109F8 RID: 68088 RVA: 0x004B3A24 File Offset: 0x004B1E24
		public void InitPreviewView()
		{
			this.specialItemId = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(501, string.Empty, string.Empty).Value;
			this.InitComUIList();
			this.InitBtn();
			this.InitUI();
			List<MallItemInfo> list = new List<MallItemInfo>();
			list = DataManager<MallNewDataManager>.GetInstance().GetMallItemInfoList(6, 0, 0);
			this.tempMallItemInfoList.Clear();
			if (list != null)
			{
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i].buyGotInfos != null && list[i].buyGotInfos.Length != 0)
					{
						this.tempMallItemInfoList.Add(list[i]);
					}
				}
				this.giftComUIList.SetElementAmount(this.tempMallItemInfoList.Count);
			}
		}

		// Token: 0x060109F9 RID: 68089 RVA: 0x004B3AEF File Offset: 0x004B1EEF
		private void InitComUIList()
		{
			this.giftComUIList.Initialize();
			this.giftComUIList.onItemVisiable = delegate(ComUIListElementScript item)
			{
				if (item.m_index >= 0)
				{
					GoblinPreviewItem component = item.GetComponent<GoblinPreviewItem>();
					if (component != null)
					{
						component.InitUI(this.tempMallItemInfoList[item.m_index]);
					}
				}
			};
		}

		// Token: 0x060109FA RID: 68090 RVA: 0x004B3B14 File Offset: 0x004B1F14
		private void InitBtn()
		{
			this.CloseBtn.onClick.RemoveAllListeners();
			this.CloseBtn.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GoblinPreviewFrame>(null, false);
			});
			this.GoToMallBtn.onClick.RemoveAllListeners();
			this.GoToMallBtn.onClick.AddListener(delegate()
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<GoblinPreviewFrame>(null, false);
				Singleton<ClientSystemManager>.instance.OpenFrame<MallNewFrame>(FrameLayer.Middle, new MallNewFrameParamData
				{
					MallNewType = MallNewType.LimitTimeMall
				}, string.Empty);
			});
		}

		// Token: 0x060109FB RID: 68091 RVA: 0x004B3B9C File Offset: 0x004B1F9C
		private void InitUI()
		{
			this.moneyNum.text = DataManager<AccountShopDataManager>.GetInstance().GetSpecialItemNum(this.specialItemId).ToString();
		}

		// Token: 0x0400A9A2 RID: 43426
		[Space(5f)]
		[Header("Title")]
		[SerializeField]
		private Text moneyNum;

		// Token: 0x0400A9A3 RID: 43427
		[SerializeField]
		private Button CloseBtn;

		// Token: 0x0400A9A4 RID: 43428
		[Space(5f)]
		[Header("Middle")]
		[SerializeField]
		private ComUIListScript giftComUIList;

		// Token: 0x0400A9A5 RID: 43429
		[Space(5f)]
		[Header("Bottom")]
		[SerializeField]
		private Button GoToMallBtn;

		// Token: 0x0400A9A6 RID: 43430
		private List<MallItemInfo> tempMallItemInfoList = new List<MallItemInfo>();

		// Token: 0x0400A9A7 RID: 43431
		private int specialItemId;
	}
}
