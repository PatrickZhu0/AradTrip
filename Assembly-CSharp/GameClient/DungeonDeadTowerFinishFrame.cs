using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020010C6 RID: 4294
	public class DungeonDeadTowerFinishFrame : ClientFrame, IDungeonFinish
	{
		// Token: 0x0600A25E RID: 41566 RVA: 0x002124C0 File Offset: 0x002108C0
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Battle/Finish/DungeonDeadTowerFinish";
		}

		// Token: 0x0600A25F RID: 41567 RVA: 0x002124C7 File Offset: 0x002108C7
		protected override void _OnOpenFrame()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.UpdateLevel));
			this.mState = DungeonDeadTowerFinishFrame.eFinishState.None;
			this.mComItemCache.Clear();
		}

		// Token: 0x0600A260 RID: 41568 RVA: 0x002124F4 File Offset: 0x002108F4
		protected override void _OnCloseFrame()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.LevelChanged, new ClientEventSystem.UIEventHandler(this.UpdateLevel));
			for (int i = 0; i < this.mComItemCache.Count; i++)
			{
				Object.Destroy(this.mComItemCache[i].gameObject);
			}
			this.mComItemCache.Clear();
		}

		// Token: 0x0600A261 RID: 41569 RVA: 0x00212556 File Offset: 0x00210956
		private void UpdateLevel(UIEvent uievent)
		{
			this.setContinueBt(this.NowLevel);
		}

		// Token: 0x0600A262 RID: 41570 RVA: 0x00212564 File Offset: 0x00210964
		protected override void _bindExUI()
		{
			this.mSetCurrentTimeObject = this.mBind.GetGameObject("setCurrentTimeObject");
			this.mSetBestTimeObject = this.mBind.GetGameObject("setBestTimeObject");
			this.mGotList = this.mBind.GetGameObject("gotList");
			this.mContinueButton = this.mBind.GetGameObject("continueButton");
			this.mLevel = this.mBind.GetCom<Text>("level");
			this.mCurrentTime = this.mBind.GetCom<ComTime>("CurrentTime");
			this.mBestTime = this.mBind.GetCom<ComTime>("BestTime");
			this.mGotListRoot = this.mBind.GetGameObject("GotListRoot");
			this.mBack = this.mBind.GetCom<Button>("back");
			this.mBack.onClick.AddListener(new UnityAction(this._onBackButtonClick));
			this.mContinue = this.mBind.GetCom<Button>("continue");
			this.mContinue.onClick.AddListener(new UnityAction(this._onContinueButtonClick));
			this.mGotListItems = this.mBind.GetCom<ComItemList>("GotListItems");
			this.mIsBestRecord = this.mBind.GetGameObject("IsBestRecord");
			this.mCannotContinue = this.mBind.GetGameObject("CannotContinue");
			this.mCannotContinueText = this.mBind.GetCom<Text>("CannotContinueText");
			this.mContinueGray = this.mBind.GetCom<UIGray>("ContinueGray");
			this.mContinueText = this.mBind.GetCom<Text>("ContinueText");
			this.mCannotContinueText1 = this.mBind.GetGameObject("CannotContinueText1");
			this.mCannotContinueText2 = this.mBind.GetGameObject("CannotContinueText2");
		}

		// Token: 0x0600A263 RID: 41571 RVA: 0x00212738 File Offset: 0x00210B38
		protected override void _unbindExUI()
		{
			this.mSetCurrentTimeObject = null;
			this.mSetBestTimeObject = null;
			this.mGotList = null;
			this.mContinueButton = null;
			this.mLevel = null;
			this.mCurrentTime = null;
			this.mBestTime = null;
			this.mGotListRoot = null;
			this.mBack.onClick.RemoveListener(new UnityAction(this._onBackButtonClick));
			this.mBack = null;
			this.mContinue.onClick.RemoveListener(new UnityAction(this._onContinueButtonClick));
			this.mContinue = null;
			this.mGotListItems = null;
			this.mIsBestRecord = null;
			this.mCannotContinue = null;
			this.mCannotContinueText = null;
			this.mContinueGray = null;
			this.mContinueText = null;
			this.mCannotContinueText1 = null;
			this.mCannotContinueText2 = null;
		}

		// Token: 0x0600A264 RID: 41572 RVA: 0x002127FB File Offset: 0x00210BFB
		private void _onBackButtonClick()
		{
			this._onBack();
		}

		// Token: 0x0600A265 RID: 41573 RVA: 0x00212803 File Offset: 0x00210C03
		private void _onContinueButtonClick()
		{
			this._onContinue();
		}

		// Token: 0x170019A1 RID: 6561
		// (get) Token: 0x0600A266 RID: 41574 RVA: 0x0021280B File Offset: 0x00210C0B
		public DungeonDeadTowerFinishFrame.eFinishState state
		{
			get
			{
				return this.mState;
			}
		}

		// Token: 0x0600A267 RID: 41575 RVA: 0x00212813 File Offset: 0x00210C13
		public void SetLevel(int level)
		{
			if (level >= 0)
			{
				this.mLevel.text = level.ToString();
				this.NowLevel = level;
				this.setContinueBt(level);
			}
		}

		// Token: 0x0600A268 RID: 41576 RVA: 0x00212848 File Offset: 0x00210C48
		private void setContinueBt(int level)
		{
			this.mCannotContinue.CustomActive(false);
			this.mCannotContinueText1.CustomActive(false);
			this.mCannotContinueText2.CustomActive(false);
			if (level == 80)
			{
				return;
			}
			DeathTowerAwardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DeathTowerAwardTable>(level + 1, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("DeathTowerTableData is null", new object[0]);
				return;
			}
			int limitLevel = tableItem.LimitLevel;
			if (limitLevel != 0 && (int)DataManager<PlayerBaseData>.GetInstance().Level < limitLevel)
			{
				this.mCannotContinueText1.CustomActive(true);
				this.mCannotContinueText2.CustomActive(true);
				this.mCannotContinue.CustomActive(true);
				if (null != this.mCannotContinueText)
				{
					this.mCannotContinueText.text = string.Format("{0}级开启", limitLevel);
				}
			}
		}

		// Token: 0x0600A269 RID: 41577 RVA: 0x0021291E File Offset: 0x00210D1E
		public void SetCurrentTime(int time)
		{
			if (time < 0)
			{
				this.mSetCurrentTimeObject.SetActive(false);
			}
			this.mCurrentTime.SetTime(time);
		}

		// Token: 0x0600A26A RID: 41578 RVA: 0x0021293F File Offset: 0x00210D3F
		public void SetBestTime(int time)
		{
			if (time < 0)
			{
				this.mSetBestTimeObject.SetActive(false);
			}
			this.mBestTime.SetTime(time);
		}

		// Token: 0x0600A26B RID: 41579 RVA: 0x00212960 File Offset: 0x00210D60
		public void SetFinish(bool isFinish)
		{
			this.mContinueButton.SetActive(!isFinish);
			if (isFinish)
			{
			}
		}

		// Token: 0x0600A26C RID: 41580 RVA: 0x0021297C File Offset: 0x00210D7C
		public void SetName(string name)
		{
		}

		// Token: 0x0600A26D RID: 41581 RVA: 0x0021297E File Offset: 0x00210D7E
		public void SetIsNewRecord(bool isNew)
		{
			this.mIsBestRecord.SetActive(isNew);
		}

		// Token: 0x0600A26E RID: 41582 RVA: 0x0021298C File Offset: 0x00210D8C
		public void SetComItemList(ComItemList.Items[] list)
		{
			if (this.mGotListItems == null)
			{
				return;
			}
			this.mGotListItems.SetItems(list);
		}

		// Token: 0x0600A26F RID: 41583 RVA: 0x002129AC File Offset: 0x00210DAC
		private void _onBack()
		{
			this.mState = DungeonDeadTowerFinishFrame.eFinishState.Back;
			base.Close(false);
		}

		// Token: 0x0600A270 RID: 41584 RVA: 0x002129BC File Offset: 0x00210DBC
		private void _onContinue()
		{
			this.mState = DungeonDeadTowerFinishFrame.eFinishState.Continue;
			base.Close(false);
		}

		// Token: 0x0600A271 RID: 41585 RVA: 0x002129CC File Offset: 0x00210DCC
		public void SetDrops(ComItemList.Items[] items)
		{
		}

		// Token: 0x0600A272 RID: 41586 RVA: 0x002129CE File Offset: 0x00210DCE
		public void SetDiff(int diff)
		{
		}

		// Token: 0x0600A273 RID: 41587 RVA: 0x002129D0 File Offset: 0x00210DD0
		public void SetExp(ulong exp)
		{
		}

		// Token: 0x04005A7A RID: 23162
		private int NowLevel;

		// Token: 0x04005A7B RID: 23163
		private GameObject mSetCurrentTimeObject;

		// Token: 0x04005A7C RID: 23164
		private GameObject mSetBestTimeObject;

		// Token: 0x04005A7D RID: 23165
		private GameObject mGotList;

		// Token: 0x04005A7E RID: 23166
		private GameObject mContinueButton;

		// Token: 0x04005A7F RID: 23167
		private Text mLevel;

		// Token: 0x04005A80 RID: 23168
		private ComTime mCurrentTime;

		// Token: 0x04005A81 RID: 23169
		private ComTime mBestTime;

		// Token: 0x04005A82 RID: 23170
		private GameObject mGotListRoot;

		// Token: 0x04005A83 RID: 23171
		private Button mBack;

		// Token: 0x04005A84 RID: 23172
		private Button mContinue;

		// Token: 0x04005A85 RID: 23173
		private ComItemList mGotListItems;

		// Token: 0x04005A86 RID: 23174
		private GameObject mIsBestRecord;

		// Token: 0x04005A87 RID: 23175
		private GameObject mCannotContinue;

		// Token: 0x04005A88 RID: 23176
		private Text mCannotContinueText;

		// Token: 0x04005A89 RID: 23177
		private UIGray mContinueGray;

		// Token: 0x04005A8A RID: 23178
		private Text mContinueText;

		// Token: 0x04005A8B RID: 23179
		private GameObject mCannotContinueText1;

		// Token: 0x04005A8C RID: 23180
		private GameObject mCannotContinueText2;

		// Token: 0x04005A8D RID: 23181
		private DungeonDeadTowerFinishFrame.eFinishState mState;

		// Token: 0x04005A8E RID: 23182
		private List<ComItem> mComItemCache = new List<ComItem>();

		// Token: 0x020010C7 RID: 4295
		public enum eFinishState
		{
			// Token: 0x04005A90 RID: 23184
			None,
			// Token: 0x04005A91 RID: 23185
			Back,
			// Token: 0x04005A92 RID: 23186
			Continue
		}
	}
}
