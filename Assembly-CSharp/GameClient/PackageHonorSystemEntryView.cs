using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001941 RID: 6465
	public class PackageHonorSystemEntryView : MonoBehaviour
	{
		// Token: 0x0600FB53 RID: 64339 RVA: 0x0044DC9B File Offset: 0x0044C09B
		private void Awake()
		{
			if (this.entryButtonWithCd != null)
			{
				this.entryButtonWithCd.ResetButtonListener();
				this.entryButtonWithCd.SetButtonListener(new Action(this.OnEntryButtonClicked));
			}
		}

		// Token: 0x0600FB54 RID: 64340 RVA: 0x0044DCD0 File Offset: 0x0044C0D0
		private void OnDestroy()
		{
			if (this.entryButtonWithCd != null)
			{
				this.entryButtonWithCd.ResetButtonListener();
			}
			this._honorSystemLevel = -1;
		}

		// Token: 0x0600FB55 RID: 64341 RVA: 0x0044DCF5 File Offset: 0x0044C0F5
		private void OnEnable()
		{
			this.UpdateEntryController();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveHonorSystemRedPointUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveHonorSystemRedPointUpdateMessage));
		}

		// Token: 0x0600FB56 RID: 64342 RVA: 0x0044DD18 File Offset: 0x0044C118
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveHonorSystemRedPointUpdateMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveHonorSystemRedPointUpdateMessage));
		}

		// Token: 0x0600FB57 RID: 64343 RVA: 0x0044DD35 File Offset: 0x0044C135
		private void OnReceiveHonorSystemRedPointUpdateMessage(UIEvent uiEvent)
		{
			this.UpdateRedPointFlag();
		}

		// Token: 0x0600FB58 RID: 64344 RVA: 0x0044DD3D File Offset: 0x0044C13D
		private void OnEntryButtonClicked()
		{
			HonorSystemUtility.OnOpenHonorSystemFrame();
			if (DataManager<HonorSystemDataManager>.GetInstance().IsShowRedPointFlag)
			{
				DataManager<HonorSystemDataManager>.GetInstance().IsShowRedPointFlag = false;
				HonorSystemUtility.SendHonorSystemRedPointUpdateMessage();
			}
		}

		// Token: 0x0600FB59 RID: 64345 RVA: 0x0044DD63 File Offset: 0x0044C163
		public void UpdateEntryController()
		{
			if (this.entryButtonWithCd != null)
			{
				this.entryButtonWithCd.Reset();
			}
			this.UpdateRedPointFlag();
			this.UpdateHonorSystemLevelInfo();
		}

		// Token: 0x0600FB5A RID: 64346 RVA: 0x0044DD90 File Offset: 0x0044C190
		private void UpdateRedPointFlag()
		{
			bool flag = HonorSystemUtility.IsShowHonorSystemRedPoint();
			CommonUtility.UpdateGameObjectVisible(this.redPointFlag, flag);
		}

		// Token: 0x0600FB5B RID: 64347 RVA: 0x0044DDB0 File Offset: 0x0044C1B0
		private void UpdateHonorSystemLevelInfo()
		{
			if (this._honorSystemLevel == (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel)
			{
				return;
			}
			this._honorSystemLevel = (int)DataManager<HonorSystemDataManager>.GetInstance().PlayerHonorLevel;
			int num = this._honorSystemLevel;
			if (num == 0)
			{
				num = 1000;
			}
			HonorLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<HonorLevelTable>(num, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (this.leftImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.leftImage, tableItem.TitleFlag, true);
			}
			if (this.rightImage != null)
			{
				ETCImageLoader.LoadSprite(ref this.rightImage, tableItem.TitleFlag, true);
			}
			if (this.honorSystemEntryNameLabel != null)
			{
				string titleNameByTitleId = HonorSystemUtility.GetTitleNameByTitleId(tableItem.Title);
				this.honorSystemEntryNameLabel.text = titleNameByTitleId;
			}
		}

		// Token: 0x04009D08 RID: 40200
		private int _honorSystemLevel = -1;

		// Token: 0x04009D09 RID: 40201
		[Space(5f)]
		[Header("EntryController")]
		[Space(5f)]
		[SerializeField]
		private ComButtonWithCd entryButtonWithCd;

		// Token: 0x04009D0A RID: 40202
		[SerializeField]
		private GameObject redPointFlag;

		// Token: 0x04009D0B RID: 40203
		[Space(5f)]
		[Header("HonorSystemLevel")]
		[Space(5f)]
		[SerializeField]
		private Image leftImage;

		// Token: 0x04009D0C RID: 40204
		[SerializeField]
		private Image rightImage;

		// Token: 0x04009D0D RID: 40205
		[SerializeField]
		private Text honorSystemEntryNameLabel;
	}
}
