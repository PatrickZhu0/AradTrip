using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001102 RID: 4354
	public class ChijiActorShowMenuFrame : ClientFrame
	{
		// Token: 0x0600A50D RID: 42253 RVA: 0x0022099B File Offset: 0x0021ED9B
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chiji/ChijiActorShowMenuFrame";
		}

		// Token: 0x0600A50E RID: 42254 RVA: 0x002209A4 File Offset: 0x0021EDA4
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.otherPlayerData = (this.userData as ChijiOtherPlayerData);
			}
			this._InitInterface();
			this._SetFramePosition(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
		}

		// Token: 0x0600A50F RID: 42255 RVA: 0x002209F8 File Offset: 0x0021EDF8
		protected override void _OnCloseFrame()
		{
			this._ClearData();
		}

		// Token: 0x0600A510 RID: 42256 RVA: 0x00220A00 File Offset: 0x0021EE00
		private void _ClearData()
		{
			if (this.otherPlayerData != null)
			{
				this.otherPlayerData = null;
			}
		}

		// Token: 0x0600A511 RID: 42257 RVA: 0x00220A14 File Offset: 0x0021EE14
		private void _InitInterface()
		{
			if (this.mName != null)
			{
				this.mName.text = this.otherPlayerData.beTownPlayerData.Name;
			}
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.otherPlayerData.beTownPlayerData.JobID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("JobTable not Find ID = {0}", new object[]
				{
					this.otherPlayerData.beTownPlayerData.JobID
				});
			}
			else
			{
				ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
				if (tableItem2 != null)
				{
					path = tableItem2.IconPath;
				}
			}
			if (this.mJobName != null)
			{
				this.mJobName.text = tableItem.Name;
			}
			if (this.mPortrait != null)
			{
				ETCImageLoader.LoadSprite(ref this.mPortrait, path, true);
			}
		}

		// Token: 0x0600A512 RID: 42258 RVA: 0x00220B14 File Offset: 0x0021EF14
		private void _SetFramePosition(Vector2 pos)
		{
			RectTransform component = this.mContent.GetComponent<RectTransform>();
			RectTransform rectTransform = component.transform.parent as RectTransform;
			Vector2 anchoredPosition;
			if (RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, pos, Singleton<ClientSystemManager>.GetInstance().UICamera, ref anchoredPosition))
			{
				Vector2 vector;
				vector..ctor(10f, 10f);
				float x = vector.x;
				float num = rectTransform.rect.size.x - vector.x - component.rect.size.x;
				float y = vector.y;
				float num2 = -(rectTransform.rect.size.y - vector.y - component.rect.size.y);
				anchoredPosition.x = Mathf.Clamp(anchoredPosition.x, x, num);
				anchoredPosition.y = Mathf.Clamp(anchoredPosition.y, num2, y);
				component.anchoredPosition = anchoredPosition;
			}
		}

		// Token: 0x0600A513 RID: 42259 RVA: 0x00220C28 File Offset: 0x0021F028
		protected override void _bindExUI()
		{
			this.mBtClose = this.mBind.GetCom<Button>("btClose");
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtPk = this.mBind.GetCom<Button>("btPk");
			if (null != this.mBtPk)
			{
				this.mBtPk.onClick.AddListener(new UnityAction(this._onBtPkButtonClick));
			}
			this.mPortrait = this.mBind.GetCom<Image>("portrait");
			this.mName = this.mBind.GetCom<Text>("name");
			this.mJobName = this.mBind.GetCom<Text>("jobName");
			this.mContent = this.mBind.GetGameObject("Content");
		}

		// Token: 0x0600A514 RID: 42260 RVA: 0x00220D14 File Offset: 0x0021F114
		protected override void _unbindExUI()
		{
			if (null != this.mBtClose)
			{
				this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			}
			this.mBtClose = null;
			if (null != this.mBtPk)
			{
				this.mBtPk.onClick.RemoveListener(new UnityAction(this._onBtPkButtonClick));
			}
			this.mBtPk = null;
			this.mPortrait = null;
			this.mName = null;
			this.mJobName = null;
			this.mContent = null;
		}

		// Token: 0x0600A515 RID: 42261 RVA: 0x00220DA5 File Offset: 0x0021F1A5
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChijiActorShowMenuFrame>(this, false);
		}

		// Token: 0x0600A516 RID: 42262 RVA: 0x00220DB4 File Offset: 0x0021F1B4
		private void _onBtPkButtonClick()
		{
			ClientSystemGameBattle clientSystemGameBattle = Singleton<ClientSystemManager>.GetInstance().CurrentSystem as ClientSystemGameBattle;
			if (clientSystemGameBattle != null && clientSystemGameBattle.MainPlayer != null && this.otherPlayerData != null && this.otherPlayerData.beTownPlayerData != null)
			{
				DataManager<ChijiDataManager>.GetInstance().SendBattlePkSomeOneReq(this.otherPlayerData.beTownPlayerData.GUID, clientSystemGameBattle.MainPlayer.GetPKDungeonID());
			}
			this._onBtCloseButtonClick();
		}

		// Token: 0x04005C1A RID: 23578
		private ChijiOtherPlayerData otherPlayerData;

		// Token: 0x04005C1B RID: 23579
		private Button mBtClose;

		// Token: 0x04005C1C RID: 23580
		private Button mBtPk;

		// Token: 0x04005C1D RID: 23581
		private Image mPortrait;

		// Token: 0x04005C1E RID: 23582
		private Text mName;

		// Token: 0x04005C1F RID: 23583
		private Text mJobName;

		// Token: 0x04005C20 RID: 23584
		private GameObject mContent;
	}
}
