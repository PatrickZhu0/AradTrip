using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ActivityLimitTime;
using GameClient;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MobileBind
{
	// Token: 0x020017D4 RID: 6100
	public class MobileBindFrame : ClientFrame
	{
		// Token: 0x0600F06D RID: 61549 RVA: 0x0040B564 File Offset: 0x00409964
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MobileBind/MobileBindFrame";
		}

		// Token: 0x0600F06E RID: 61550 RVA: 0x0040B56C File Offset: 0x0040996C
		protected override void _bindExUI()
		{
			this.awardParent = this.mBind.GetGameObject("AwardParent");
			if (this.awardParent)
			{
				int childCount = this.awardParent.transform.childCount;
				this.awardItems = new GameObject[childCount];
				for (int i = 0; i < childCount; i++)
				{
					this.awardItems[i] = this.awardParent.transform.GetChild(i).gameObject;
				}
			}
			this.receiveBtn = this.mBind.GetCom<Button>("ReceiveBtn");
			if (this.receiveBtn)
			{
				this.receiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
				this.receiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveBtnClick));
			}
			this.receiveBtnText = this.mBind.GetCom<Text>("ReceiveBtnText");
			this.receiveBtnGray = this.mBind.GetCom<UIGray>("ReceiveBtnGray");
			this.sdkGotoBindBtn = this.mBind.GetCom<Button>("SDKGotoBind");
			if (this.sdkGotoBindBtn)
			{
				this.sdkGotoBindBtn.onClick.RemoveListener(new UnityAction(this.OnGoToBindPhoneInSDK));
				this.sdkGotoBindBtn.onClick.AddListener(new UnityAction(this.OnGoToBindPhoneInSDK));
				this.sdkGotoBindBtnGray = this.sdkGotoBindBtn.gameObject.GetComponent<UIGray>();
			}
			this.normalBindGo = this.mBind.GetGameObject("NormalBindGo");
			this.mobileNumInput = this.mBind.GetCom<InputField>("MobileNumInput");
			if (this.mobileNumInput)
			{
				this.mobileNumInput.onEndEdit.RemoveListener(new UnityAction<string>(this.OnInputPhoneNumEnd));
				this.mobileNumInput.onEndEdit.AddListener(new UnityAction<string>(this.OnInputPhoneNumEnd));
			}
			this.mobileVerifyInput = this.mBind.GetCom<InputField>("MobileVerifyInput");
			this.sendVerifyBtn = this.mBind.GetCom<Button>("SendMobileVerifyBtn");
			if (this.sendVerifyBtn)
			{
				this.sendVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnSendVerifyBtnClick));
				this.sendVerifyBtn.onClick.AddListener(new UnityAction(this.OnSendVerifyBtnClick));
			}
			this.sendVerifyBtnText = this.mBind.GetCom<Text>("SendMobileVerifyBtnText");
			this.sendVerifyGray = this.mBind.GetCom<UIGray>("VerifyBtnGray");
			this.pushVerifyBtn = this.mBind.GetCom<Button>("PushBtn");
			if (this.pushVerifyBtn)
			{
				this.pushVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnPushVerifyBtnClick));
				this.pushVerifyBtn.onClick.AddListener(new UnityAction(this.OnPushVerifyBtnClick));
			}
			this.closeBtn = this.mBind.GetCom<Button>("closeBtn");
			if (this.closeBtn)
			{
				this.closeBtn.onClick.RemoveListener(new UnityAction(this.OnCloseFrameBtnClick));
				this.closeBtn.onClick.AddListener(new UnityAction(this.OnCloseFrameBtnClick));
			}
		}

		// Token: 0x0600F06F RID: 61551 RVA: 0x0040B8BC File Offset: 0x00409CBC
		protected override void _unbindExUI()
		{
			this.awardParent = null;
			if (this.receiveBtn)
			{
				this.receiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
			}
			this.receiveBtn = null;
			this.receiveBtnGray = null;
			this.receiveBtnText = null;
			if (this.sdkGotoBindBtn)
			{
				this.sdkGotoBindBtn.onClick.RemoveListener(new UnityAction(this.OnGoToBindPhoneInSDK));
			}
			this.sdkGotoBindBtn = null;
			this.sdkGotoBindBtnGray = null;
			this.normalBindGo = null;
			if (this.mobileNumInput)
			{
				this.mobileNumInput.onEndEdit.RemoveListener(new UnityAction<string>(this.OnInputPhoneNumEnd));
			}
			this.mobileNumInput = null;
			this.mobileVerifyInput = null;
			if (this.sendVerifyBtn)
			{
				this.sendVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnSendVerifyBtnClick));
			}
			this.sendVerifyBtn = null;
			this.sendVerifyBtnText = null;
			this.sendVerifyGray = null;
			if (this.pushVerifyBtn)
			{
				this.pushVerifyBtn.onClick.RemoveListener(new UnityAction(this.OnPushVerifyBtnClick));
			}
			this.pushVerifyBtn = null;
			if (this.closeBtn)
			{
				this.closeBtn.onClick.RemoveListener(new UnityAction(this.OnCloseFrameBtnClick));
			}
			this.closeBtn = null;
		}

		// Token: 0x0600F070 RID: 61552 RVA: 0x0040BA34 File Offset: 0x00409E34
		protected override void _OnOpenFrame()
		{
			this.coolDownNum = 60f;
			this.isCoolDown = false;
			this.InitBindPhoneModeShow();
			this.InitBtnsState();
			this.InitAwardItems();
			if (this.mobileNumInput)
			{
				this.mobileNumInput.text = string.Empty;
			}
			if (this.mobileVerifyInput)
			{
				this.mobileVerifyInput.text = string.Empty;
			}
			DataManager<MobileBindManager>.GetInstance().AddSendPhoneNumSuccHandler(new Action(this.OnSendPhoneNumSucc));
			DataManager<MobileBindManager>.GetInstance().AddVerifySuccHandler(new Action(this.OnVerifyPhoneSucc));
			DataManager<MobileBindManager>.GetInstance().AddSDKBindPhoneNumSuccHandler(new Action<string>(this.OnSDKBindPhoneSucc));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncTaskDataChangeListener(new Action(this.OnTaskStateChanged));
			}
			if (!DataManager<MobileBindManager>.GetInstance().SendPhoneVerifySucc)
			{
				DataManager<MobileBindManager>.GetInstance().HasSendVerify = false;
			}
			if (DataManager<MobileBindManager>.GetInstance().HasBindPhone())
			{
				DataManager<MobileBindManager>.GetInstance().HasSendVerify = true;
			}
			if (!DataManager<MobileBindManager>.GetInstance().hasRoleBindPhoneAwardActive)
			{
				SDKInterface.instance.CheckIsPhoneBind();
			}
		}

		// Token: 0x0600F071 RID: 61553 RVA: 0x0040BB60 File Offset: 0x00409F60
		protected override void _OnCloseFrame()
		{
			DataManager<MobileBindManager>.GetInstance().RemoveAllSendPhoneNumSuccHandler();
			DataManager<MobileBindManager>.GetInstance().RemoveAllVerifySuccHandler();
			DataManager<MobileBindManager>.GetInstance().RemoveAllSDKBindPhoneNumSuccHandler();
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RemoveAllSyncTaskDataChangeListener();
			}
			this.currData = null;
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.SDKBindPhone);
		}

		// Token: 0x0600F072 RID: 61554 RVA: 0x0040BBBF File Offset: 0x00409FBF
		protected override void _OnUpdate(float timeElapsed)
		{
			this.StartSendVerifyCountDown();
			if (!DataManager<MobileBindManager>.GetInstance().HasSendVerify)
			{
			}
		}

		// Token: 0x0600F073 RID: 61555 RVA: 0x0040BBD6 File Offset: 0x00409FD6
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600F074 RID: 61556 RVA: 0x0040BBDC File Offset: 0x00409FDC
		private void InitAwardItems()
		{
			this.currData = DataManager<MobileBindManager>.GetInstance().BindPhoneActData;
			if (this.awardItems == null)
			{
				return;
			}
			if (this.currData != null)
			{
				List<ActivityLimitTimeDetailData> activityDetailDataList = this.currData.activityDetailDataList;
				if (activityDetailDataList == null || activityDetailDataList.Count <= 0)
				{
					return;
				}
				if (activityDetailDataList[0] != null)
				{
					List<ActivityLimitTimeAward> awardDataList = activityDetailDataList[0].awardDataList;
					if (awardDataList != null && awardDataList.Count <= this.awardItems.Length)
					{
						for (int i = 0; i < awardDataList.Count; i++)
						{
							ComItem comItem = base.CreateComItem(this.awardItems[i].gameObject);
							ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)awardDataList[i].Id, 100, 0);
							itemData.Count = awardDataList[i].Num;
							comItem.Setup(itemData, delegate(GameObject go, ItemData iData)
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(iData, null, 4, true, false, true);
							});
						}
					}
					else
					{
						Logger.LogError("手机绑定，奖励数量太多了，目前最多4个呀！！！");
					}
				}
			}
		}

		// Token: 0x0600F075 RID: 61557 RVA: 0x0040BCEC File Offset: 0x0040A0EC
		private bool CheckIsRightMobileNum(string mNum)
		{
			if (string.IsNullOrEmpty(mNum))
			{
				return false;
			}
			Regex regex = new Regex("^[1]+\\d{10}");
			return regex.IsMatch(mNum);
		}

		// Token: 0x0600F076 RID: 61558 RVA: 0x0040BD18 File Offset: 0x0040A118
		private void InitBtnsState()
		{
			this.OnTaskStateChanged();
			this.SetSendVerifyBtnState(MobileBindFrame.SendVerifyBtnState.UnEnable);
		}

		// Token: 0x0600F077 RID: 61559 RVA: 0x0040BD28 File Offset: 0x0040A128
		private void SetReceiveBtnState(MobileBindFrame.ReceiveBtnState state)
		{
			if (this.receiveBtnText == null)
			{
				return;
			}
			if (state != MobileBindFrame.ReceiveBtnState.UnReceive)
			{
				if (state != MobileBindFrame.ReceiveBtnState.ToReceive)
				{
					if (state == MobileBindFrame.ReceiveBtnState.Received)
					{
						this.receiveBtnText.text = "已领取";
						this.EnableReceiveBtn(false);
					}
				}
				else
				{
					this.receiveBtnText.text = "领取";
					this.EnableReceiveBtn(true);
				}
			}
			else
			{
				this.receiveBtnText.text = "无法领取";
				this.EnableReceiveBtn(false);
			}
		}

		// Token: 0x0600F078 RID: 61560 RVA: 0x0040BDB4 File Offset: 0x0040A1B4
		private void EnableReceiveBtn(bool enabled)
		{
			if (this.receiveBtnGray)
			{
				this.receiveBtnGray.enabled = !enabled;
			}
			if (this.receiveBtn)
			{
				this.receiveBtn.interactable = enabled;
			}
		}

		// Token: 0x0600F079 RID: 61561 RVA: 0x0040BDF4 File Offset: 0x0040A1F4
		private void SetSendVerifyBtnState(MobileBindFrame.SendVerifyBtnState state)
		{
			if (this.sendVerifyBtnText == null)
			{
				return;
			}
			if (state != MobileBindFrame.SendVerifyBtnState.UnEnable)
			{
				if (state != MobileBindFrame.SendVerifyBtnState.Normal)
				{
					if (state == MobileBindFrame.SendVerifyBtnState.Sending)
					{
						this.sendVerifyBtnText.text = "发送验证码(" + this.coolDownNum + ")";
						this.EnableSendVerifyBtn(false);
					}
				}
				else
				{
					this.sendVerifyBtnText.text = "发送验证码";
					this.EnableSendVerifyBtn(true);
				}
			}
			else
			{
				this.sendVerifyBtnText.text = "发送验证码";
				this.EnableSendVerifyBtn(false);
			}
		}

		// Token: 0x0600F07A RID: 61562 RVA: 0x0040BE95 File Offset: 0x0040A295
		private void EnableSendVerifyBtn(bool enabled)
		{
			if (this.sendVerifyBtn)
			{
				this.sendVerifyBtn.interactable = enabled;
			}
			if (this.sendVerifyGray)
			{
				this.sendVerifyGray.enabled = !enabled;
			}
		}

		// Token: 0x0600F07B RID: 61563 RVA: 0x0040BED4 File Offset: 0x0040A2D4
		private void StartSendVerifyCountDown()
		{
			if (!this.isCoolDown)
			{
				return;
			}
			if (this.coolDownNum <= 0f)
			{
				return;
			}
			this.coolDownNum -= Time.deltaTime;
			if (this.coolDownNum > 0f)
			{
				this.SetSendVerifyBtnState(MobileBindFrame.SendVerifyBtnState.Sending);
			}
			else
			{
				this.SetSendVerifyBtnState(MobileBindFrame.SendVerifyBtnState.Normal);
				this.isCoolDown = false;
			}
		}

		// Token: 0x0600F07C RID: 61564 RVA: 0x0040BF3A File Offset: 0x0040A33A
		private void InitBindPhoneModeShow()
		{
			if (SDKInterface.instance.NeedSDKBindPhoneOpen())
			{
				this.SetBindPhoneModeShow(MobileBindFrame.BindPhoneMode.OpenSDK);
			}
			else
			{
				this.SetBindPhoneModeShow(MobileBindFrame.BindPhoneMode.Normal);
			}
		}

		// Token: 0x0600F07D RID: 61565 RVA: 0x0040BF60 File Offset: 0x0040A360
		private void SetBindPhoneModeShow(MobileBindFrame.BindPhoneMode bindPhoneMode)
		{
			if (bindPhoneMode == MobileBindFrame.BindPhoneMode.Normal)
			{
				if (this.normalBindGo)
				{
					this.normalBindGo.CustomActive(true);
				}
				if (this.sdkGotoBindBtn)
				{
					this.sdkGotoBindBtn.gameObject.CustomActive(false);
				}
			}
			else if (bindPhoneMode == MobileBindFrame.BindPhoneMode.OpenSDK)
			{
				if (this.normalBindGo)
				{
					this.normalBindGo.CustomActive(false);
				}
				if (this.sdkGotoBindBtn)
				{
					this.sdkGotoBindBtn.gameObject.CustomActive(true);
				}
				this.EnableSDKOpenBindPhoneBtn(true);
			}
			else if (bindPhoneMode == MobileBindFrame.BindPhoneMode.Finished)
			{
				this.EnableSDKOpenBindPhoneBtn(false);
			}
		}

		// Token: 0x0600F07E RID: 61566 RVA: 0x0040C013 File Offset: 0x0040A413
		private void EnableSDKOpenBindPhoneBtn(bool enabled)
		{
			if (this.sdkGotoBindBtnGray)
			{
				this.sdkGotoBindBtnGray.enabled = !enabled;
			}
			if (this.sdkGotoBindBtn)
			{
				this.sdkGotoBindBtn.interactable = enabled;
			}
		}

		// Token: 0x0600F07F RID: 61567 RVA: 0x0040C050 File Offset: 0x0040A450
		private void OnSendPhoneNumSucc()
		{
			this.isCoolDown = true;
		}

		// Token: 0x0600F080 RID: 61568 RVA: 0x0040C059 File Offset: 0x0040A459
		private void OnVerifyPhoneSucc()
		{
			this.SetReceiveBtnState(MobileBindFrame.ReceiveBtnState.ToReceive);
			this.SetBindPhoneModeShow(MobileBindFrame.BindPhoneMode.Finished);
		}

		// Token: 0x0600F081 RID: 61569 RVA: 0x0040C069 File Offset: 0x0040A469
		private void OnSDKBindPhoneSucc(string sdkBindPhoneNum)
		{
			this.SendVerifyCodeBySDK(sdkBindPhoneNum, string.Empty);
		}

		// Token: 0x0600F082 RID: 61570 RVA: 0x0040C078 File Offset: 0x0040A478
		private void OnTaskStateChanged()
		{
			this.currData = DataManager<MobileBindManager>.GetInstance().BindPhoneActData;
			if (this.currData != null)
			{
				if (this.currData.activityDetailDataList == null)
				{
					return;
				}
				if (this.currData.activityDetailDataList.Count > 0)
				{
					ActivityTaskState activityDetailState = this.currData.activityDetailDataList[0].ActivityDetailState;
					if (activityDetailState != ActivityTaskState.Over)
					{
						if (activityDetailState != ActivityTaskState.Finished)
						{
							this.SetReceiveBtnState(MobileBindFrame.ReceiveBtnState.UnReceive);
							DataManager<MobileBindManager>.GetInstance().hasRoleBindPhoneAwardActive = false;
						}
						else
						{
							this.SetReceiveBtnState(MobileBindFrame.ReceiveBtnState.ToReceive);
							this.EnableSDKOpenBindPhoneBtn(false);
							DataManager<MobileBindManager>.GetInstance().hasRoleBindPhoneAwardActive = true;
						}
					}
					else
					{
						this.SetReceiveBtnState(MobileBindFrame.ReceiveBtnState.Received);
						UIEventSystem.GetInstance().SendUIEvent(EUIEventID.SDKBindPhoneFinished, false, null, null, null);
						if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MobileBindFrame>(null))
						{
							this.frameMgr.CloseFrame<MobileBindFrame>(null, false);
						}
						DataManager<MobileBindManager>.GetInstance().hasRoleBindPhoneAwardActive = true;
					}
				}
			}
		}

		// Token: 0x0600F083 RID: 61571 RVA: 0x0040C174 File Offset: 0x0040A574
		private void OnReceiveBtnClick()
		{
			if (this.currData == null)
			{
				return;
			}
			if (this.currData.activityDetailDataList == null)
			{
				return;
			}
			if (this.currData.activityDetailDataList.Count == 0)
			{
				return;
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(this.currData.DataId, this.currData.activityDetailDataList[0].DataId);
			}
		}

		// Token: 0x0600F084 RID: 61572 RVA: 0x0040C1F4 File Offset: 0x0040A5F4
		private void OnSendVerifyBtnClick()
		{
			if (this.mobileNumInput)
			{
				string text = this.mobileNumInput.text;
				if (string.IsNullOrEmpty(text))
				{
					SystemNotifyManager.SysNotifyTextAnimation("手机号为空，请检查", CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else if (text.Length != 11)
				{
					SystemNotifyManager.SysNotifyTextAnimation("手机号位数不等于11位，请检查", CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					DataManager<MobileBindManager>.GetInstance().SendPhoneNumber(text);
				}
			}
		}

		// Token: 0x0600F085 RID: 61573 RVA: 0x0040C260 File Offset: 0x0040A660
		private void OnPushVerifyBtnClick()
		{
			if (this.mobileVerifyInput && this.mobileNumInput)
			{
				string text = this.mobileNumInput.text;
				string text2 = this.mobileVerifyInput.text;
				if (string.IsNullOrEmpty(text2) || string.IsNullOrEmpty(text))
				{
					SystemNotifyManager.SysNotifyTextAnimation("手机号或验证码为空，请检查", CommonTipsDesc.eShowMode.SI_UNIQUE);
				}
				else
				{
					DataManager<MobileBindManager>.GetInstance().SendNumberVerify(text, text2);
				}
			}
		}

		// Token: 0x0600F086 RID: 61574 RVA: 0x0040C2D7 File Offset: 0x0040A6D7
		private void OnInputPhoneNumEnd(string input)
		{
			if (this.CheckIsRightMobileNum(input))
			{
				this.SetSendVerifyBtnState(MobileBindFrame.SendVerifyBtnState.Normal);
			}
			else
			{
				this.SetSendVerifyBtnState(MobileBindFrame.SendVerifyBtnState.UnEnable);
			}
		}

		// Token: 0x0600F087 RID: 61575 RVA: 0x0040C2F8 File Offset: 0x0040A6F8
		private void OnGoToBindPhoneInSDK()
		{
			DataManager<MobileBindManager>.GetInstance().HasSendVerify = false;
			SDKInterface.instance.OpenBindPhone();
		}

		// Token: 0x0600F088 RID: 61576 RVA: 0x0040C30F File Offset: 0x0040A70F
		private void OnCloseFrameBtnClick()
		{
			base.Close(false);
		}

		// Token: 0x0600F089 RID: 61577 RVA: 0x0040C318 File Offset: 0x0040A718
		private void SendVerifyCodeBySDK(string phoneNum = "", string verifyCode = "")
		{
			if (SDKInterface.instance.NeedSDKBindPhoneOpen())
			{
				DataManager<MobileBindManager>.GetInstance().SendNumberVerify(phoneNum, string.Empty);
			}
		}

		// Token: 0x04009377 RID: 37751
		private GameObject awardParent;

		// Token: 0x04009378 RID: 37752
		private Button receiveBtn;

		// Token: 0x04009379 RID: 37753
		private UIGray receiveBtnGray;

		// Token: 0x0400937A RID: 37754
		private Text receiveBtnText;

		// Token: 0x0400937B RID: 37755
		private Button sdkGotoBindBtn;

		// Token: 0x0400937C RID: 37756
		private UIGray sdkGotoBindBtnGray;

		// Token: 0x0400937D RID: 37757
		private GameObject normalBindGo;

		// Token: 0x0400937E RID: 37758
		private InputField mobileNumInput;

		// Token: 0x0400937F RID: 37759
		private InputField mobileVerifyInput;

		// Token: 0x04009380 RID: 37760
		private Button sendVerifyBtn;

		// Token: 0x04009381 RID: 37761
		private Text sendVerifyBtnText;

		// Token: 0x04009382 RID: 37762
		private UIGray sendVerifyGray;

		// Token: 0x04009383 RID: 37763
		private Button pushVerifyBtn;

		// Token: 0x04009384 RID: 37764
		private GameObject[] awardItems;

		// Token: 0x04009385 RID: 37765
		private Button closeBtn;

		// Token: 0x04009386 RID: 37766
		private MobileBindFrame.ReceiveBtnState receiveBtnState;

		// Token: 0x04009387 RID: 37767
		private MobileBindFrame.SendVerifyBtnState sendVerifyBtnState;

		// Token: 0x04009388 RID: 37768
		private float coolDownNum;

		// Token: 0x04009389 RID: 37769
		private bool isCoolDown;

		// Token: 0x0400938A RID: 37770
		private ActivityLimitTimeData currData;

		// Token: 0x020017D5 RID: 6101
		public enum ReceiveBtnState
		{
			// Token: 0x0400938D RID: 37773
			UnReceive,
			// Token: 0x0400938E RID: 37774
			ToReceive,
			// Token: 0x0400938F RID: 37775
			Received
		}

		// Token: 0x020017D6 RID: 6102
		public enum SendVerifyBtnState
		{
			// Token: 0x04009391 RID: 37777
			UnEnable,
			// Token: 0x04009392 RID: 37778
			Normal,
			// Token: 0x04009393 RID: 37779
			Sending
		}

		// Token: 0x020017D7 RID: 6103
		public enum BindPhoneMode
		{
			// Token: 0x04009395 RID: 37781
			Normal,
			// Token: 0x04009396 RID: 37782
			OpenSDK,
			// Token: 0x04009397 RID: 37783
			Finished
		}
	}
}
