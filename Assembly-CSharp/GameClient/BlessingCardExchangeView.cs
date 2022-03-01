using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200192E RID: 6446
	public class BlessingCardExchangeView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600FAB4 RID: 64180 RVA: 0x0044ACEC File Offset: 0x004490EC
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnBlessingCardChanged, new ClientEventSystem.UIEventHandler(this.OnBlessingCardChanged));
			if (this.time != null)
			{
				this.time.text = string.Format("{0}~{1}", Function._TransTimeStampToStr(model.StartTime), Function._TransTimeStampToStr(model.EndTime));
			}
			if (this.cardPackBtn != null)
			{
				this.cardPackBtn.onClick.RemoveAllListeners();
				this.cardPackBtn.onClick.AddListener(new UnityAction(this.OnCardPackBtnClick));
			}
			this.InitItems();
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCardListReq();
		}

		// Token: 0x0600FAB5 RID: 64181 RVA: 0x0044ADA0 File Offset: 0x004491A0
		private void InitItems()
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.itemPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			if (gameObject.GetComponent<BlessingCardExchangeItem>() == null)
			{
				Object.Destroy(gameObject);
				return;
			}
			for (int i = 0; i < DataManager<ZillionaireGameDataManager>.GetInstance().cardExchangeDataList.Count; i++)
			{
				CardExchangeData cardExchangeData = DataManager<ZillionaireGameDataManager>.GetInstance().cardExchangeDataList[i];
				if (cardExchangeData != null)
				{
					if (cardExchangeData.type == 1)
					{
						GameObject gameObject2 = Object.Instantiate<GameObject>(gameObject);
						Utility.AttachTo(gameObject2, this.itemRoot, false);
						BlessingCardExchangeItem component = gameObject2.GetComponent<BlessingCardExchangeItem>();
						if (component != null)
						{
							component.OnItemVisiable(cardExchangeData);
							this.items.Add(cardExchangeData.tableId, component);
						}
					}
					else if (this.blessingCardExchangeItem != null)
					{
						this.blessingCardExchangeItem.OnItemVisiable(cardExchangeData);
						this.items.Add(cardExchangeData.tableId, this.blessingCardExchangeItem);
					}
				}
			}
			Object.Destroy(gameObject);
		}

		// Token: 0x0600FAB6 RID: 64182 RVA: 0x0044AEB0 File Offset: 0x004492B0
		private void UpdateItem()
		{
			for (int i = 0; i < DataManager<ZillionaireGameDataManager>.GetInstance().cardExchangeDataList.Count; i++)
			{
				CardExchangeData cardExchangeData = DataManager<ZillionaireGameDataManager>.GetInstance().cardExchangeDataList[i];
				if (cardExchangeData != null)
				{
					if (this.items.ContainsKey(cardExchangeData.tableId))
					{
						this.items[cardExchangeData.tableId].UpdateData(cardExchangeData);
					}
				}
			}
		}

		// Token: 0x0600FAB7 RID: 64183 RVA: 0x0044AF26 File Offset: 0x00449326
		private void OnCardPackBtnClick()
		{
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BlessingCardPackageFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600FAB8 RID: 64184 RVA: 0x0044AF3A File Offset: 0x0044933A
		private void OnBlessingCardChanged(UIEvent uIEvent)
		{
			this.UpdateItem();
		}

		// Token: 0x0600FAB9 RID: 64185 RVA: 0x0044AF42 File Offset: 0x00449342
		public void Close()
		{
		}

		// Token: 0x0600FABA RID: 64186 RVA: 0x0044AF44 File Offset: 0x00449344
		public void Dispose()
		{
			if (this.items != null)
			{
				this.items.Clear();
			}
			if (this.cardPackBtn != null)
			{
				this.cardPackBtn.onClick.RemoveListener(new UnityAction(this.OnCardPackBtnClick));
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnBlessingCardChanged, new ClientEventSystem.UIEventHandler(this.OnBlessingCardChanged));
		}

		// Token: 0x0600FABB RID: 64187 RVA: 0x0044AFAF File Offset: 0x004493AF
		public void Hide()
		{
		}

		// Token: 0x0600FABC RID: 64188 RVA: 0x0044AFB1 File Offset: 0x004493B1
		public void Show()
		{
			DataManager<ZillionaireGameDataManager>.GetInstance().OnSendWorldMonopolyCardListReq();
		}

		// Token: 0x0600FABD RID: 64189 RVA: 0x0044AFBD File Offset: 0x004493BD
		public void UpdateData(ILimitTimeActivityModel data)
		{
		}

		// Token: 0x04009CA7 RID: 40103
		[SerializeField]
		private Text time;

		// Token: 0x04009CA8 RID: 40104
		[SerializeField]
		private GameObject itemRoot;

		// Token: 0x04009CA9 RID: 40105
		[SerializeField]
		private BlessingCardExchangeItem blessingCardExchangeItem;

		// Token: 0x04009CAA RID: 40106
		[SerializeField]
		private Button cardPackBtn;

		// Token: 0x04009CAB RID: 40107
		[SerializeField]
		private string itemPath = "UIFlatten/Prefabs/OperateActivity/ZillionaireGame/BlessingCardExchangeItem";

		// Token: 0x04009CAC RID: 40108
		private Dictionary<int, BlessingCardExchangeItem> items = new Dictionary<int, BlessingCardExchangeItem>();
	}
}
