using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001A93 RID: 6803
	public class WeekSignInAwardRecordView : MonoBehaviour
	{
		// Token: 0x06010B25 RID: 68389 RVA: 0x004BC289 File Offset: 0x004BA689
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06010B26 RID: 68390 RVA: 0x004BC291 File Offset: 0x004BA691
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
			DataManager<WeekSignInDataManager>.GetInstance().ResetWeekSignInRecord();
		}

		// Token: 0x06010B27 RID: 68391 RVA: 0x004BC2AC File Offset: 0x004BA6AC
		private void BindEvents()
		{
			if (this.awardItemList != null)
			{
				this.awardItemList.Initialize();
				ComUIListScript comUIListScript = this.awardItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveGasWeekSignInRecordRes, new ClientEventSystem.UIEventHandler(this.OnReceiveGASWeekSingInRecordRes));
		}

		// Token: 0x06010B28 RID: 68392 RVA: 0x004BC354 File Offset: 0x004BA754
		private void UnBindEvents()
		{
			if (this.awardItemList != null)
			{
				ComUIListScript comUIListScript = this.awardItemList;
				comUIListScript.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScript.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveGasWeekSignInRecordRes, new ClientEventSystem.UIEventHandler(this.OnReceiveGASWeekSingInRecordRes));
		}

		// Token: 0x06010B29 RID: 68393 RVA: 0x004BC3D5 File Offset: 0x004BA7D5
		private void ClearData()
		{
			this._weekSingInType = WeekSignInType.None;
			this._weekSingInRecordList = null;
			this._awardRecordDescription = null;
		}

		// Token: 0x06010B2A RID: 68394 RVA: 0x004BC3EC File Offset: 0x004BA7EC
		public void InitView(int awardRecordType)
		{
			this._weekSingInType = (WeekSignInType)awardRecordType;
			if (this._weekSingInType != WeekSignInType.NewPlayerWeekSignIn && this._weekSingInType != WeekSignInType.ActivityWeekSignIn)
			{
				this._weekSingInType = WeekSignInType.ActivityWeekSignIn;
			}
			int id = 10019;
			if (this._weekSingInType == WeekSignInType.NewPlayerWeekSignIn)
			{
				id = 10018;
			}
			CommonTipsDesc tableItem = Singleton<TableManager>.GetInstance().GetTableItem<CommonTipsDesc>(id, string.Empty, string.Empty);
			if (tableItem != null)
			{
				this._awardRecordDescription = tableItem.Descs;
			}
			this.InitContent();
			DataManager<WeekSignInDataManager>.GetInstance().SendGASWeekSignRecordReq(this._weekSingInType);
		}

		// Token: 0x06010B2B RID: 68395 RVA: 0x004BC478 File Offset: 0x004BA878
		private void InitContent()
		{
			if (this.title != null)
			{
				this.title.text = TR.Value("week_sing_in_award_record_title");
			}
			if (this.awardZeroTips != null)
			{
				this.awardZeroTips.text = TR.Value("week_sing_in_award_record_zero");
			}
		}

		// Token: 0x06010B2C RID: 68396 RVA: 0x004BC4D4 File Offset: 0x004BA8D4
		private void OnReceiveGASWeekSingInRecordRes(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			WeekSignInType weekSignInType = (WeekSignInType)uiEvent.Param1;
			if (weekSignInType != this._weekSingInType)
			{
				return;
			}
			this.UpdateAwardRecordItemList();
		}

		// Token: 0x06010B2D RID: 68397 RVA: 0x004BC514 File Offset: 0x004BA914
		private void UpdateAwardRecordItemList()
		{
			int elementAmount = 0;
			this._weekSingInRecordList = DataManager<WeekSignInDataManager>.GetInstance().GetWeekSignInRecordListByWeekSignInType(this._weekSingInType);
			if (this._weekSingInRecordList != null && this._weekSingInRecordList.Count > 0)
			{
				elementAmount = this._weekSingInRecordList.Count;
			}
			if (this.awardItemList != null)
			{
				this.awardItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x06010B2E RID: 68398 RVA: 0x004BC580 File Offset: 0x004BA980
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._weekSingInRecordList == null || this._weekSingInRecordList.Count <= 0)
			{
				return;
			}
			if (this.awardItemList == null)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._weekSingInRecordList.Count)
			{
				return;
			}
			WeekSignRecord weekSignRecord = this._weekSingInRecordList[item.m_index];
			WeekSignInAwardRecordItem component = item.GetComponent<WeekSignInAwardRecordItem>();
			if (weekSignRecord != null && component != null)
			{
				string itemNameLinkParseString = CommonUtility.GetItemNameLinkParseString((int)weekSignRecord.itemId);
				string text = string.Format(this._awardRecordDescription, new object[]
				{
					weekSignRecord.serverName,
					weekSignRecord.roleName,
					itemNameLinkParseString,
					weekSignRecord.itemNum
				});
				text = text.Replace(Environment.NewLine, string.Empty).Replace("\t", string.Empty);
				component.InitItem(text);
			}
		}

		// Token: 0x06010B2F RID: 68399 RVA: 0x004BC680 File Offset: 0x004BAA80
		private void OnCloseButtonClick()
		{
			WeekSignInUtility.OnCloseWeekSignInAwardRecordFrame();
		}

		// Token: 0x0400AAC4 RID: 43716
		private WeekSignInType _weekSingInType;

		// Token: 0x0400AAC5 RID: 43717
		private List<WeekSignRecord> _weekSingInRecordList;

		// Token: 0x0400AAC6 RID: 43718
		private string _awardRecordDescription;

		// Token: 0x0400AAC7 RID: 43719
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private Text title;

		// Token: 0x0400AAC8 RID: 43720
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400AAC9 RID: 43721
		[SerializeField]
		private Text awardZeroTips;

		// Token: 0x0400AACA RID: 43722
		[Space(10f)]
		[Header("Title")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScript awardItemList;
	}
}
