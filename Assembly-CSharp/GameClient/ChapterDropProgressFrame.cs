using System;
using Network;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200152B RID: 5419
	public class ChapterDropProgressFrame : ClientFrame
	{
		// Token: 0x0600D301 RID: 54017 RVA: 0x00344396 File Offset: 0x00342796
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterDropProgress";
		}

		// Token: 0x0600D302 RID: 54018 RVA: 0x003443A0 File Offset: 0x003427A0
		protected override void _bindExUI()
		{
			this.mRoom = this.mBind.GetGameObject("Room");
			this.mTextNumber = this.mBind.GetCom<Text>("TextNumber");
			this.mButtonReset = this.mBind.GetCom<Button>("ButtonReset");
			if (null != this.mButtonReset)
			{
				this.mButtonReset.onClick.AddListener(new UnityAction(this._onButtonResetButtonClick));
			}
			this.mButtonClose = this.mBind.GetCom<Button>("ButtonClose");
			if (null != this.mButtonClose)
			{
				this.mButtonClose.onClick.AddListener(new UnityAction(this._onButtonCloseButtonClick));
			}
			this.mUIGrayReset = this.mBind.GetCom<UIGray>("UIGrayReset");
		}

		// Token: 0x0600D303 RID: 54019 RVA: 0x00344478 File Offset: 0x00342878
		protected override void _unbindExUI()
		{
			this.mRoom = null;
			this.mTextNumber = null;
			if (null != this.mButtonReset)
			{
				this.mButtonReset.onClick.RemoveListener(new UnityAction(this._onButtonResetButtonClick));
			}
			this.mButtonReset = null;
			if (null != this.mButtonClose)
			{
				this.mButtonClose.onClick.RemoveListener(new UnityAction(this._onButtonCloseButtonClick));
			}
			this.mButtonClose = null;
			this.mUIGrayReset = null;
		}

		// Token: 0x0600D304 RID: 54020 RVA: 0x00344504 File Offset: 0x00342904
		private void _onButtonResetButtonClick()
		{
			int num = this._getLeftTimes();
			if (num > 0 || (num == 0 && ChapterNormalHalfFrame.IsYiJieDungeon(this.dungeonId) && ChapterNormalHalfFrame.IsCurrentDungeonInChallenge()))
			{
				this._onSceneDungeonResetAreaIndex();
			}
		}

		// Token: 0x0600D305 RID: 54021 RVA: 0x00344545 File Offset: 0x00342945
		private void _onButtonCloseButtonClick()
		{
			base.Close(false);
		}

		// Token: 0x0600D306 RID: 54022 RVA: 0x0034454E File Offset: 0x0034294E
		public void SetData(int dungeonId, uint areaIndex)
		{
			this.dungeonId = dungeonId;
			this.resetFlag = false;
			this._setNumber();
			this._setProgress(areaIndex);
		}

		// Token: 0x0600D307 RID: 54023 RVA: 0x0034456C File Offset: 0x0034296C
		private void _initFrame()
		{
			if (this.mRoom == null)
			{
				return;
			}
			this.uiGrayArray = new UIGray[5];
			this.checkMarkArray = new Image[5];
			for (int i = 0; i < 5; i++)
			{
				GameObject gameObject = Object.Instantiate<GameObject>(this.mRoom);
				gameObject.CustomActive(true);
				gameObject.name = string.Format("Room{0}", i);
				gameObject.transform.SetParent(this.mRoom.transform.parent);
				gameObject.transform.SetSiblingIndex(i);
				gameObject.transform.localScale = Vector3.one;
				gameObject.transform.localPosition = Vector3.zero;
				Transform transform = gameObject.transform.Find("Box");
				if (transform != null)
				{
					this.uiGrayArray[i] = transform.GetComponent<UIGray>();
				}
				Transform transform2 = gameObject.transform.Find("Check");
				this.checkMarkArray[i] = transform2.GetComponent<Image>();
			}
		}

		// Token: 0x0600D308 RID: 54024 RVA: 0x0034466F File Offset: 0x00342A6F
		private void _setNumber()
		{
			this.mTextNumber.text = string.Format(TR.Value("drop_progress_reset_text"), this._getLeftTimes());
		}

		// Token: 0x0600D309 RID: 54025 RVA: 0x00344698 File Offset: 0x00342A98
		private int _getLeftTimes()
		{
			int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(this.dungeonId);
			int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(this.dungeonId);
			int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600D30A RID: 54026 RVA: 0x003446CC File Offset: 0x00342ACC
		private void _setProgress(uint index)
		{
			this.mButtonReset.enabled = (index != 0U);
			this.mUIGrayReset.enabled = (index == 0U);
			for (int i = 0; i < 5; i++)
			{
				bool enabled = (index & 1U) == 1U;
				index >>= 1;
				this.uiGrayArray[i].enabled = enabled;
				this.checkMarkArray[i].enabled = enabled;
			}
		}

		// Token: 0x0600D30B RID: 54027 RVA: 0x00344734 File Offset: 0x00342B34
		private void _onSceneDungeonResetAreaIndex()
		{
			this.resetFlag = true;
			SceneDungeonResetAreaIndexReq sceneDungeonResetAreaIndexReq = new SceneDungeonResetAreaIndexReq();
			sceneDungeonResetAreaIndexReq.dungeonId = (uint)this.dungeonId;
			NetManager.Instance().SendCommand<SceneDungeonResetAreaIndexReq>(ServerType.GATE_SERVER, sceneDungeonResetAreaIndexReq);
		}

		// Token: 0x0600D30C RID: 54028 RVA: 0x00344767 File Offset: 0x00342B67
		private void _onCounterChanged(UIEvent ui)
		{
			if (this.resetFlag)
			{
				this.resetFlag = false;
				this._setNumber();
				this._setProgress(0U);
			}
		}

		// Token: 0x0600D30D RID: 54029 RVA: 0x00344788 File Offset: 0x00342B88
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._onCounterChanged));
		}

		// Token: 0x0600D30E RID: 54030 RVA: 0x003447A5 File Offset: 0x00342BA5
		private void _unBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._onCounterChanged));
		}

		// Token: 0x0600D30F RID: 54031 RVA: 0x003447C2 File Offset: 0x00342BC2
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this._initFrame();
			this._bindEvents();
		}

		// Token: 0x0600D310 RID: 54032 RVA: 0x003447D6 File Offset: 0x00342BD6
		protected override void _OnCloseFrame()
		{
			base._OnCloseFrame();
			this._unBindEvents();
		}

		// Token: 0x04007B7C RID: 31612
		private UIGray[] uiGrayArray;

		// Token: 0x04007B7D RID: 31613
		private Image[] checkMarkArray;

		// Token: 0x04007B7E RID: 31614
		private int dungeonId;

		// Token: 0x04007B7F RID: 31615
		private bool resetFlag;

		// Token: 0x04007B80 RID: 31616
		private GameObject mRoom;

		// Token: 0x04007B81 RID: 31617
		private Text mTextNumber;

		// Token: 0x04007B82 RID: 31618
		private Button mButtonReset;

		// Token: 0x04007B83 RID: 31619
		private Button mButtonClose;

		// Token: 0x04007B84 RID: 31620
		private UIGray mUIGrayReset;
	}
}
