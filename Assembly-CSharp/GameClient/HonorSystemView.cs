using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200167C RID: 5756
	public class HonorSystemView : MonoBehaviour
	{
		// Token: 0x0600E24A RID: 57930 RVA: 0x003A21CF File Offset: 0x003A05CF
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x0600E24B RID: 57931 RVA: 0x003A21D7 File Offset: 0x003A05D7
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x0600E24C RID: 57932 RVA: 0x003A21E8 File Offset: 0x003A05E8
		private void BindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveHonorSystemResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveHonorSystemResMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this.OnReceiveItemUseSucceedMessage));
		}

		// Token: 0x0600E24D RID: 57933 RVA: 0x003A2268 File Offset: 0x003A0668
		private void UnBindEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveHonorSystemResMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveHonorSystemResMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ItemUseSuccess, new ClientEventSystem.UIEventHandler(this.OnReceiveItemUseSucceedMessage));
		}

		// Token: 0x0600E24E RID: 57934 RVA: 0x003A22CC File Offset: 0x003A06CC
		private void ClearData()
		{
		}

		// Token: 0x0600E24F RID: 57935 RVA: 0x003A22CE File Offset: 0x003A06CE
		public void InitView()
		{
			DataManager<HonorSystemDataManager>.GetInstance().OnSendSceneHonorReq();
			this.InitBaseView();
		}

		// Token: 0x0600E250 RID: 57936 RVA: 0x003A22E0 File Offset: 0x003A06E0
		private void InitBaseView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("Honor_System_Title");
			}
		}

		// Token: 0x0600E251 RID: 57937 RVA: 0x003A2308 File Offset: 0x003A0708
		private void OnReceiveHonorSystemResMessage(UIEvent uiEvent)
		{
			this.InitHonorSystemController();
		}

		// Token: 0x0600E252 RID: 57938 RVA: 0x003A2310 File Offset: 0x003A0710
		private void OnReceiveItemUseSucceedMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			ItemData itemData = (ItemData)uiEvent.Param1;
			if (itemData == null || itemData.TableID <= 0)
			{
				return;
			}
			if (itemData.TableID == 330000252 || itemData.TableID == 330000253)
			{
				DataManager<HonorSystemDataManager>.GetInstance().IsAlreadyUseProtectCard = true;
				this.UpdateHonorSystemProtectCardUseContent();
			}
		}

		// Token: 0x0600E253 RID: 57939 RVA: 0x003A2380 File Offset: 0x003A0780
		private void InitHonorSystemController()
		{
			if (this.honorCommonController != null)
			{
				this.honorCommonController.InitHonorCommonController();
			}
			if (this.honorTotalController != null)
			{
				this.honorTotalController.InitHonorTotalController();
			}
			if (this.honorPreHistoryController != null)
			{
				this.honorPreHistoryController.InitHonorPreHistoryController();
			}
		}

		// Token: 0x0600E254 RID: 57940 RVA: 0x003A23E1 File Offset: 0x003A07E1
		private void UpdateHonorSystemProtectCardUseContent()
		{
			if (this.honorCommonController != null)
			{
				this.honorCommonController.UpdateProtectCardUsedContent();
			}
		}

		// Token: 0x0600E255 RID: 57941 RVA: 0x003A23FF File Offset: 0x003A07FF
		private void OnCloseFrame()
		{
			HonorSystemUtility.OnCloseHonorSystemFrame();
		}

		// Token: 0x04008768 RID: 34664
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x04008769 RID: 34665
		[Space(10f)]
		[Header("ContentController")]
		[Space(10f)]
		[SerializeField]
		private HonorCommonController honorCommonController;

		// Token: 0x0400876A RID: 34666
		[SerializeField]
		private HonorTotalController honorTotalController;

		// Token: 0x0400876B RID: 34667
		[SerializeField]
		private HonorPreHistoryController honorPreHistoryController;

		// Token: 0x0400876C RID: 34668
		[Space(10f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;
	}
}
