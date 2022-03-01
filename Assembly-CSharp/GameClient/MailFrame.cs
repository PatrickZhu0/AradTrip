using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001749 RID: 5961
	internal class MailFrame : WndFrame
	{
		// Token: 0x0600EA16 RID: 59926 RVA: 0x003DFDB4 File Offset: 0x003DE1B4
		protected override void _OnOpenFrame()
		{
			this.CreateFinish = false;
			this.fUpdateInterval = 0f;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(11, string.Empty, string.Empty);
			this.ItemsNum = tableItem.Value;
			this.UpdateOneKeyBtn();
			this.CreateMailListPreferb();
			this.CreateRewardMailListPreferb();
			this.InitPackageItems();
			this.UpdateNoMailTip();
			this.CreateFinish = true;
			this.helpBtn.gameObject.SetActive(false);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this._OnUpdateMailItemList));
		}

		// Token: 0x0600EA17 RID: 59927 RVA: 0x003DFE48 File Offset: 0x003DE248
		protected override void _OnCloseFrame()
		{
			bool flag = true;
			if (DataManager<PlayerBaseData>.GetInstance().mails.OneKeyReceiveNum > 0)
			{
				flag = false;
			}
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.NewMailNotify, new ClientEventSystem.UIEventHandler(this._OnUpdateMailItemList));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.MailFrameClose, "NewMail", flag, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.NewMailNotify, null, null, null, null);
		}

		// Token: 0x0600EA18 RID: 59928 RVA: 0x003DFEB8 File Offset: 0x003DE2B8
		public override string GetContentPath()
		{
			return "UIFlatten/Prefabs/Mail/MailPanel";
		}

		// Token: 0x0600EA19 RID: 59929 RVA: 0x003DFEBF File Offset: 0x003DE2BF
		private void _OnUpdateMailItemList(UIEvent iEvent)
		{
			this.UpdateRewardMailListPreferb();
		}

		// Token: 0x0600EA1A RID: 59930 RVA: 0x003DFEC7 File Offset: 0x003DE2C7
		private void OnClose()
		{
			DataManager<PlayerBaseData>.GetInstance().mails.SortMailList();
			DataManager<PlayerBaseData>.GetInstance().mails.SortRewardMailList();
			this.ClearData();
			this.frameMgr.CloseFrame<MailFrame>(this, false);
		}

		// Token: 0x0600EA1B RID: 59931 RVA: 0x003DFEFA File Offset: 0x003DE2FA
		[UIEventHandle("Title/Close")]
		private void OnClickClose()
		{
			this.OnClose();
		}

		// Token: 0x0600EA1C RID: 59932 RVA: 0x003DFF02 File Offset: 0x003DE302
		[UIEventHandle("Title/Help")]
		private void OnClickHelp()
		{
		}

		// Token: 0x0600EA1D RID: 59933 RVA: 0x003DFF04 File Offset: 0x003DE304
		public override string GetTitle()
		{
			return "邮件";
		}

		// Token: 0x0600EA1E RID: 59934 RVA: 0x003DFF0C File Offset: 0x003DE30C
		private void ClearData()
		{
			for (int i = 0; i < this.MailItemObjList.Count; i++)
			{
				if (!(this.MailItemObjList[i] == null))
				{
					Button[] componentsInChildren = this.MailItemObjList[i].GetComponentsInChildren<Button>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (componentsInChildren[j].name == "NormalBack")
						{
							componentsInChildren[j].onClick.RemoveAllListeners();
							break;
						}
					}
				}
			}
			for (int k = 0; k < this.RewardMailItemObjList.Count; k++)
			{
				if (!(this.RewardMailItemObjList[k] == null))
				{
					Button[] componentsInChildren2 = this.RewardMailItemObjList[k].GetComponentsInChildren<Button>();
					for (int l = 0; l < componentsInChildren2.Length; l++)
					{
						if (componentsInChildren2[l].name == "NormalBack")
						{
							componentsInChildren2[l].onClick.RemoveAllListeners();
							break;
						}
					}
				}
			}
			this.ItemsNum = 0;
			this.CreatMailObjNum = 0;
			this.CreatRewardMailObjNum = 0;
			this.CurSelMailID = 0UL;
			this.CreateFinish = false;
			this.fUpdateInterval = 0f;
			this.Items.Clear();
			this.ShowTipItemData.Clear();
			this.MailItemObjList.Clear();
			this.RewardMailItemObjList.Clear();
		}

		// Token: 0x0600EA1F RID: 59935 RVA: 0x003E008C File Offset: 0x003DE48C
		private void OnClickMail(List<MailTitleInfo> mailList, DictionaryView<ulong, GameMailData.MailData> mailDics, int iIndex, string rootPath)
		{
			MailTitleInfo mailTitleInfo = mailList[iIndex];
			if (this.CurSelMailID == mailTitleInfo.id)
			{
				return;
			}
			this.CurSelMailID = mailTitleInfo.id;
			if (mailTitleInfo.status == 0)
			{
				this.OnSendReadMailReq(mailList, iIndex);
			}
			else
			{
				GameMailData.MailData mailData = DataManager<PlayerBaseData>.GetInstance().mails.FindMailData(mailDics, mailTitleInfo.id);
				if (mailData == null)
				{
					this.OnSendReadMailReq(mailList, iIndex);
				}
				else
				{
					this.UpdateMailDetail(mailData);
					this.UpdateSelMailLeftTime(mailList, rootPath);
				}
			}
		}

		// Token: 0x0600EA20 RID: 59936 RVA: 0x003E0111 File Offset: 0x003DE511
		private void OnClickTakeMail(int iIndex)
		{
		}

		// Token: 0x0600EA21 RID: 59937 RVA: 0x003E0114 File Offset: 0x003DE514
		private void OnClickReceive(List<MailTitleInfo> mailList)
		{
			MailTitleInfo mailTitleInfo = DataManager<PlayerBaseData>.GetInstance().mails.FindMailTitleInfo(mailList, this.CurSelMailID);
			if (mailTitleInfo == null)
			{
				SystemNotifyManager.SystemNotify(1022, string.Empty);
				return;
			}
			if (mailTitleInfo.hasItem == 0)
			{
				SystemNotifyManager.SystemNotify(1021, string.Empty);
				return;
			}
			this.OnSendReceiveMailReq(false);
		}

		// Token: 0x0600EA22 RID: 59938 RVA: 0x003E0170 File Offset: 0x003DE570
		[UIEventHandle("Content/MailPanel(Clone)/Rewardsbottom/BtnAcceptAll")]
		private void OnAcceptAllClickReceiveAll()
		{
			if (DataManager<PlayerBaseData>.GetInstance().mails.OneKeyReceiveRewardNum <= 0)
			{
				SystemNotifyManager.SystemNotify(1022, string.Empty);
				return;
			}
			this.OnSendReceiveMailReq(true);
		}

		// Token: 0x0600EA23 RID: 59939 RVA: 0x003E019E File Offset: 0x003DE59E
		[UIEventHandle("Content/MailPanel(Clone)/bottom/BtnDelete")]
		private void OnClickDelete()
		{
			this.OnDeleteMail(DataManager<PlayerBaseData>.GetInstance().mails.mailList);
		}

		// Token: 0x0600EA24 RID: 59940 RVA: 0x003E01B5 File Offset: 0x003DE5B5
		[UIEventHandle("Content/MailPanel(Clone)/Rewardsbottom/Buttons/BtnDelete")]
		private void OnClickBtnDeleteClick()
		{
			this.OnDeleteMail(DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList);
		}

		// Token: 0x0600EA25 RID: 59941 RVA: 0x003E01CC File Offset: 0x003DE5CC
		private void OnDeleteMail(List<MailTitleInfo> mailList)
		{
			MailTitleInfo mailTitleInfo = DataManager<PlayerBaseData>.GetInstance().mails.FindMailTitleInfo(mailList, this.CurSelMailID);
			if (mailTitleInfo == null)
			{
				SystemNotifyManager.SystemNotify(1024, string.Empty);
				return;
			}
			if (mailTitleInfo.hasItem == 1)
			{
				SystemNotifyManager.SystemNotify(1023, string.Empty);
				return;
			}
			this.OnSendDeleteMailReq(false, mailList);
		}

		// Token: 0x0600EA26 RID: 59942 RVA: 0x003E022A File Offset: 0x003DE62A
		[UIEventHandle("Content/MailPanel(Clone)/bottom/BtnDeleteAll")]
		private void OnClickDeleteAll()
		{
			if (DataManager<PlayerBaseData>.GetInstance().mails.OneKeyDeleteNum <= 0)
			{
				SystemNotifyManager.SystemNotify(1024, string.Empty);
				return;
			}
			this.OnSendDeleteMailReq(true, DataManager<PlayerBaseData>.GetInstance().mails.mailList);
		}

		// Token: 0x0600EA27 RID: 59943 RVA: 0x003E0267 File Offset: 0x003DE667
		[UIEventHandle("Content/MailPanel(Clone)/Rewardsbottom/BtnDeleteAll")]
		private void OnClickBtnDeleteAllCLick()
		{
			if (DataManager<PlayerBaseData>.GetInstance().mails.OneKeyDeleteRewardNum <= 0)
			{
				SystemNotifyManager.SystemNotify(1024, string.Empty);
				return;
			}
			this.OnSendDeleteMailReq(true, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList);
		}

		// Token: 0x0600EA28 RID: 59944 RVA: 0x003E02A4 File Offset: 0x003DE6A4
		private void OnSendReadMailReq(List<MailTitleInfo> mailList, int iIndex)
		{
			WorldReadMailReq worldReadMailReq = new WorldReadMailReq();
			worldReadMailReq.id = mailList[iIndex].id;
			MonoSingleton<NetManager>.instance.SendCommand<WorldReadMailReq>(ServerType.GATE_SERVER, worldReadMailReq);
		}

		// Token: 0x0600EA29 RID: 59945 RVA: 0x003E02D8 File Offset: 0x003DE6D8
		private void OnSendReceiveMailReq(bool bReceiveAll)
		{
			WorldGetMailItems worldGetMailItems = new WorldGetMailItems();
			if (bReceiveAll)
			{
				worldGetMailItems.type = 1;
				worldGetMailItems.id = 0UL;
			}
			else
			{
				worldGetMailItems.type = 0;
				worldGetMailItems.id = this.CurSelMailID;
			}
			MonoSingleton<NetManager>.instance.SendCommand<WorldGetMailItems>(ServerType.GATE_SERVER, worldGetMailItems);
		}

		// Token: 0x0600EA2A RID: 59946 RVA: 0x003E0328 File Offset: 0x003DE728
		private void OnSendDeleteMailReq(bool bDeleteAll, List<MailTitleInfo> mailList)
		{
			WorldDeleteMail worldDeleteMail = new WorldDeleteMail();
			if (bDeleteAll)
			{
				List<ulong> deleteMailList = DataManager<PlayerBaseData>.GetInstance().mails.GetDeleteMailList(mailList);
				worldDeleteMail.ids = new ulong[deleteMailList.Count];
				for (int i = 0; i < deleteMailList.Count; i++)
				{
					worldDeleteMail.ids[i] = deleteMailList[i];
				}
			}
			else
			{
				worldDeleteMail.ids = new ulong[1];
				worldDeleteMail.ids[0] = this.CurSelMailID;
			}
			MonoSingleton<NetManager>.instance.SendCommand<WorldDeleteMail>(ServerType.GATE_SERVER, worldDeleteMail);
		}

		// Token: 0x0600EA2B RID: 59947 RVA: 0x003E03B8 File Offset: 0x003DE7B8
		[MessageHandle(601507U, false, 0)]
		private void OnWorldSyncMailStatusRes(MsgDATA msg)
		{
			WorldSyncMailStatus res = msg.decode<WorldSyncMailStatus>();
			if (this.BaseTypes[0].isOn)
			{
				this.OnWorldSyncMailStatusRess(DataManager<PlayerBaseData>.GetInstance().mails.mailList, res, this.RootObjPath, DataManager<PlayerBaseData>.GetInstance().mails.mailDics);
			}
			else
			{
				this.OnWorldSyncMailStatusRess(DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, res, this.RwardRootObjPath, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics);
			}
		}

		// Token: 0x0600EA2C RID: 59948 RVA: 0x003E043C File Offset: 0x003DE83C
		private void OnWorldSyncMailStatusRess(List<MailTitleInfo> mailList, WorldSyncMailStatus res, string rootPath, DictionaryView<ulong, GameMailData.MailData> mailDics)
		{
			bool flag = false;
			int i = 0;
			while (i < mailList.Count)
			{
				if (mailList[i].id != res.id)
				{
					i++;
				}
				else
				{
					string path = rootPath + string.Format("/MailItem{0}", i);
					GameObject gameObject = Utility.FindGameObject(path, true);
					if (gameObject == null)
					{
						Logger.LogError("can't find obj : MailItemobj");
						return;
					}
					if (mailList[i].status != res.status)
					{
						mailList[i].status = res.status;
						GameMailData.MailData mailData = DataManager<PlayerBaseData>.GetInstance().mails.FindMailData(mailDics, res.id);
						if (mailData != null)
						{
							mailData.info.status = res.status;
						}
						this.UpdateMailStatus(ref gameObject, mailList[i]);
					}
					if (mailList[i].hasItem != res.hasItem)
					{
						GameObject gameObject2 = Utility.FindGameObject(gameObject, "Take", true);
						UIGray uigray = gameObject2.GetComponent<UIGray>();
						if (uigray == null)
						{
							uigray = gameObject2.AddComponent<UIGray>();
						}
						uigray.enabled = true;
						gameObject2.GetComponent<Button>().interactable = false;
						Text componentInChildren = gameObject2.GetComponentInChildren<Text>();
						componentInChildren.text = "已领取";
						GameObject gameObject3 = Utility.FindGameObject(gameObject, "AttachIcon", true);
						gameObject3.CustomActive(false);
						mailList[i].hasItem = res.hasItem;
						if (mailList == DataManager<PlayerBaseData>.GetInstance().mails.mailList)
						{
							DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyNum();
						}
						else
						{
							DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyRewardNum();
						}
						if (res.hasItem == 0)
						{
							GameMailData.MailData mailData2 = DataManager<PlayerBaseData>.GetInstance().mails.FindMailData(mailDics, res.id);
							if (mailData2 != null)
							{
								mailData2.items.Clear();
								mailData2.detailItems.Clear();
							}
							if (this.CurSelMailID == res.id)
							{
								this.ClearItemsIcon();
							}
						}
						this.UpdateOneKeyBtn();
					}
					flag = true;
					break;
				}
			}
			if (!flag)
			{
			}
		}

		// Token: 0x0600EA2D RID: 59949 RVA: 0x003E065C File Offset: 0x003DEA5C
		[MessageHandle(601505U, false, 0)]
		private void OnWorldReadMailRes(MsgDATA msg)
		{
			WorldReadMailRet res = msg.decode<WorldReadMailRet>();
			if (this.BaseTypes[0].isOn)
			{
				this.OnWorldReadMailRess(DataManager<PlayerBaseData>.GetInstance().mails.UnreadNum, DataManager<PlayerBaseData>.GetInstance().mails.mailList, DataManager<PlayerBaseData>.GetInstance().mails.mailDics, res, this.RootObjPath);
			}
			else
			{
				this.OnWorldReadMailRess(DataManager<PlayerBaseData>.GetInstance().mails.UnreadRewardNum, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics, res, this.RwardRootObjPath);
			}
		}

		// Token: 0x0600EA2E RID: 59950 RVA: 0x003E06FC File Offset: 0x003DEAFC
		private void OnWorldReadMailRess(int UnReadNum, List<MailTitleInfo> mailList, DictionaryView<ulong, GameMailData.MailData> mailDics, WorldReadMailRet res, string rootPath)
		{
			UnReadNum--;
			GameMailData.MailData mailData = new GameMailData.MailData();
			mailData.info = DataManager<PlayerBaseData>.GetInstance().mails.FindMailTitleInfo(mailList, res.id);
			mailData.content = res.content;
			mailData.items = new List<ItemReward>(res.items);
			mailData.detailItems = res.detailItems;
			if (DataManager<PlayerBaseData>.GetInstance().mails.FindMailData(mailDics, res.id) == null)
			{
				mailDics.Add(res.id, mailData);
			}
			GameMailData.MailData mailDetailData = mailData;
			this.UpdateMailDetail(mailDetailData);
			this.UpdateSelMailLeftTime(mailList, rootPath);
		}

		// Token: 0x0600EA2F RID: 59951 RVA: 0x003E079C File Offset: 0x003DEB9C
		[MessageHandle(601511U, false, 0)]
		private void OnWorldSyncDeleteMailRes(MsgDATA msg)
		{
			WorldNotifyDeleteMail worldNotifyDeleteMail = msg.decode<WorldNotifyDeleteMail>();
			if (this.BaseTypes[0].isOn)
			{
				for (int i = 0; i < worldNotifyDeleteMail.ids.Length; i++)
				{
					DataManager<PlayerBaseData>.GetInstance().mails.DeleteMailTitleInfo(worldNotifyDeleteMail.ids[i]);
					DataManager<PlayerBaseData>.GetInstance().mails.DeleteMailData(worldNotifyDeleteMail.ids[i]);
				}
				DataManager<PlayerBaseData>.GetInstance().mails.SortMailList();
				DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyNum();
				this.UpdateMailList(this.CreatMailObjNum, DataManager<PlayerBaseData>.GetInstance().mails.mailList, DataManager<PlayerBaseData>.GetInstance().mails.mailDics, this.RootObjPath);
				this.UpdateChoosenBaseType(0);
			}
			else
			{
				for (int j = 0; j < worldNotifyDeleteMail.ids.Length; j++)
				{
					DataManager<PlayerBaseData>.GetInstance().mails.DeleteRewardMailTitleInfo(worldNotifyDeleteMail.ids[j]);
					DataManager<PlayerBaseData>.GetInstance().mails.DeleteRewardMailData(worldNotifyDeleteMail.ids[j]);
				}
				DataManager<PlayerBaseData>.GetInstance().mails.SortRewardMailList();
				DataManager<PlayerBaseData>.GetInstance().mails.UpdateOneKeyRewardNum();
				this.UpdateMailList(this.CreatRewardMailObjNum, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics, this.RwardRootObjPath);
				this.UpdateChoosenBaseType(1);
			}
			SystemNotifyManager.SystemNotify(1026, string.Empty);
		}

		// Token: 0x0600EA30 RID: 59952 RVA: 0x003E090E File Offset: 0x003DED0E
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600EA31 RID: 59953 RVA: 0x003E0914 File Offset: 0x003DED14
		protected override void _OnUpdate(float timeElapsed)
		{
			if (!this.CreateFinish)
			{
				return;
			}
			this.fUpdateInterval += timeElapsed;
			if (this.fUpdateInterval <= 60f)
			{
				return;
			}
			this.fUpdateInterval = 0f;
			if (this.BaseTypes[0].isOn)
			{
				this.UpdateLeftTime(this.CreatMailObjNum, DataManager<PlayerBaseData>.GetInstance().mails.mailList, this.RootObjPath);
			}
			else
			{
				this.UpdateLeftTime(this.CreatRewardMailObjNum, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, this.RwardRootObjPath);
			}
		}

		// Token: 0x0600EA32 RID: 59954 RVA: 0x003E09B0 File Offset: 0x003DEDB0
		private void CreateMailListPreferb()
		{
			this.CreatMailObjNum = 0;
			GameObject gameObject = Utility.FindGameObject(this.frame, this.RootObjPath, true);
			if (gameObject == null)
			{
				Logger.LogError("can't find obj : RootObjPath");
				return;
			}
			this.MailItemObjList.Clear();
			for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().mails.mailList.Count; i++)
			{
				MailTitleInfo mailInfo = DataManager<PlayerBaseData>.GetInstance().mails.mailList[i];
				GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.MailItemPath, true, 0U);
				if (gameObject2 == null)
				{
					Logger.LogError("can't create obj in MailFrame");
					return;
				}
				gameObject2.name = string.Format("MailItem{0}", i);
				Utility.AttachTo(gameObject2, gameObject, false);
				this.MailItemObjList.Add(gameObject2);
				this.CreatMailObjNum++;
				this.UpdateMailPerferbInterface(ref gameObject2, mailInfo);
				this.UpdateMailStatus(ref gameObject2, mailInfo);
				this.UpdateMailPerferbBtnBind(ref gameObject2, DataManager<PlayerBaseData>.GetInstance().mails.mailList, DataManager<PlayerBaseData>.GetInstance().mails.mailDics, this.RootObjPath, i);
			}
		}

		// Token: 0x0600EA33 RID: 59955 RVA: 0x003E0AD8 File Offset: 0x003DEED8
		private void CreateRewardMailListPreferb()
		{
			this.CreatRewardMailObjNum = 0;
			GameObject gameObject = Utility.FindGameObject(this.frame, this.RwardRootObjPath, true);
			if (gameObject == null)
			{
				Logger.LogError("can't find obj : RootObjPath");
				return;
			}
			this.RewardMailItemObjList.Clear();
			for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Count; i++)
			{
				MailTitleInfo mailInfo = DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList[i];
				GameObject gameObject2 = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.MailItemPath, true, 0U);
				if (gameObject2 == null)
				{
					Logger.LogError("can't create obj in MailFrame");
					return;
				}
				gameObject2.name = string.Format("MailItem{0}", i);
				Utility.AttachTo(gameObject2, gameObject, false);
				this.RewardMailItemObjList.Add(gameObject2);
				this.CreatRewardMailObjNum++;
				this.UpdateMailPerferbInterface(ref gameObject2, mailInfo);
				this.UpdateMailStatus(ref gameObject2, mailInfo);
				this.UpdateMailPerferbBtnBind(ref gameObject2, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics, this.RwardRootObjPath, i);
			}
		}

		// Token: 0x0600EA34 RID: 59956 RVA: 0x003E0C00 File Offset: 0x003DF000
		private void UpdateRewardMailListPreferb()
		{
			GameObject gameObject = Utility.FindGameObject(this.frame, this.RwardRootObjPath, true);
			if (gameObject == null)
			{
				Logger.LogError("can't find obj : RootObjPath");
				return;
			}
			if (DataManager<PlayerBaseData>.GetInstance().mails != null && DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList != null)
			{
				for (int i = 0; i < DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Count; i++)
				{
					MailTitleInfo mailTitleInfo = DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList[i];
					if (mailTitleInfo != null)
					{
						if (i < this.RewardMailItemObjList.Count)
						{
							GameObject gameObject2 = this.RewardMailItemObjList[i];
							if (gameObject2 == null)
							{
								Logger.LogError("can't create obj in MailFrame");
								return;
							}
							gameObject2.name = string.Format("MailItem{0}", i);
							this.UpdateMailPerferbInterface(ref gameObject2, mailTitleInfo);
							this.UpdateMailStatus(ref gameObject2, mailTitleInfo);
							this.UpdateMailPerferbBtnBind(ref gameObject2, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics, this.RwardRootObjPath, i);
						}
						else
						{
							GameObject gameObject3 = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.MailItemPath, true, 0U);
							if (gameObject3 == null)
							{
								Logger.LogError("can't create obj in MailFrame");
								return;
							}
							gameObject3.name = string.Format("MailItem{0}", i);
							Utility.AttachTo(gameObject3, gameObject, false);
							this.RewardMailItemObjList.Add(gameObject3);
							this.CreatRewardMailObjNum++;
							this.UpdateMailPerferbInterface(ref gameObject3, mailTitleInfo);
							this.UpdateMailStatus(ref gameObject3, mailTitleInfo);
							this.UpdateMailPerferbBtnBind(ref gameObject3, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics, this.RwardRootObjPath, i);
						}
					}
				}
			}
		}

		// Token: 0x0600EA35 RID: 59957 RVA: 0x003E0DD0 File Offset: 0x003DF1D0
		private void InitPackageItems()
		{
			GameObject gameObject = Utility.FindGameObject(this.frame, this.RewardItemRootPath, true);
			if (gameObject == null)
			{
				Logger.LogError("can't find componnent : RewardItemRootPath");
				return;
			}
			RectTransform[] componentsInChildren = gameObject.GetComponentsInChildren<RectTransform>();
			int num = 0;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (!(componentsInChildren[i].name != string.Format("Pos{0}", num + 1)))
				{
					ComItem item = base.CreateComItem(componentsInChildren[i].gameObject);
					if (num < this.ItemsNum)
					{
						this.Items.Add(item);
					}
					num++;
				}
			}
		}

		// Token: 0x0600EA36 RID: 59958 RVA: 0x003E0E7C File Offset: 0x003DF27C
		private void UpdateMailList(int creatMailObj, List<MailTitleInfo> mailList, DictionaryView<ulong, GameMailData.MailData> mailDics, string rootPath)
		{
			if (creatMailObj >= mailList.Count)
			{
				for (int i = 0; i < creatMailObj; i++)
				{
					string path = rootPath + string.Format("/MailItem{0}", i);
					GameObject gameObject = Utility.FindGameObject(path, true);
					if (gameObject == null)
					{
						Logger.LogError("can't find obj : MailItemobj");
						return;
					}
					if (i < mailList.Count)
					{
						MailTitleInfo mailInfo = mailList[i];
						this.UpdateMailPerferbInterface(ref gameObject, mailInfo);
						this.UpdateMailStatus(ref gameObject, mailInfo);
						this.UpdateMailPerferbBtnBind(ref gameObject, mailList, mailDics, rootPath, i);
						gameObject.SetActive(true);
					}
					else
					{
						gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600EA37 RID: 59959 RVA: 0x003E0F2C File Offset: 0x003DF32C
		private void UpdateMailPerferbInterface(ref GameObject MailItemobj, MailTitleInfo MailInfo)
		{
			Text[] componentsInChildren = MailItemobj.GetComponentsInChildren<Text>();
			int num = 0;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == "MailTitle")
				{
					componentsInChildren[i].text = MailInfo.title;
					num++;
				}
				else if (componentsInChildren[i].name == "MailSender")
				{
					componentsInChildren[i].text = MailInfo.sender;
					num++;
				}
				else if (componentsInChildren[i].name == "SendTime")
				{
					componentsInChildren[i].text = Function.GetBeginTimeStr(MailInfo.date, ShowtimeType.Normal);
					num++;
				}
				else if (componentsInChildren[i].name == "TimeLeft")
				{
					if (MailInfo.deadline - MailInfo.date > 0U)
					{
						componentsInChildren[i].text = Function.GetLeftTimeStr(MailInfo.date, MailInfo.deadline - MailInfo.date, ShowtimeType.Normal);
					}
					num++;
				}
				if (num == 4)
				{
					break;
				}
			}
		}

		// Token: 0x0600EA38 RID: 59960 RVA: 0x003E1048 File Offset: 0x003DF448
		private void UpdateLeftTime(int creatMailNum, List<MailTitleInfo> mailList, string rootPath)
		{
			if (creatMailNum >= mailList.Count)
			{
				for (int i = 0; i < creatMailNum; i++)
				{
					string path = rootPath + string.Format("/MailItem{0}", i);
					GameObject gameObject = Utility.FindGameObject(path, true);
					if (gameObject == null)
					{
						Logger.LogError("can't find obj : MailItemobj");
						return;
					}
					if (i < mailList.Count)
					{
						this.CalSelMailLeftTime(ref gameObject, mailList, i);
						gameObject.SetActive(true);
					}
					else
					{
						gameObject.SetActive(false);
					}
				}
			}
		}

		// Token: 0x0600EA39 RID: 59961 RVA: 0x003E10D8 File Offset: 0x003DF4D8
		private void UpdateSelMailLeftTime(List<MailTitleInfo> mailList, string rootPath)
		{
			int i = 0;
			while (i < mailList.Count)
			{
				if (mailList[i].id != this.CurSelMailID)
				{
					i++;
				}
				else
				{
					string path = rootPath + string.Format("/MailItem{0}", i);
					GameObject gameObject = Utility.FindGameObject(path, true);
					if (gameObject == null)
					{
						Logger.LogError("can't find obj : MailItemobj");
						return;
					}
					this.CalSelMailLeftTime(ref gameObject, mailList, i);
					break;
				}
			}
		}

		// Token: 0x0600EA3A RID: 59962 RVA: 0x003E1160 File Offset: 0x003DF560
		private void UpdateMailStatus(ref GameObject MailItemobj, MailTitleInfo MailInfo)
		{
			Image[] componentsInChildren = MailItemobj.GetComponentsInChildren<Image>(true);
			int num = 0;
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == "Icon")
				{
					string path;
					if (MailInfo.status == 0)
					{
						path = this.MailUnReadPath;
					}
					else
					{
						path = this.MailReadPath;
					}
					ETCImageLoader.LoadSprite(ref componentsInChildren[i], path, true);
					num++;
				}
				else if (componentsInChildren[i].name == "NewMailPrompt")
				{
					if (MailInfo.status == 0)
					{
						componentsInChildren[i].gameObject.SetActive(true);
					}
					else
					{
						componentsInChildren[i].gameObject.SetActive(false);
					}
					num++;
				}
				if (num == 2)
				{
					break;
				}
			}
			Button[] componentsInChildren2 = MailItemobj.GetComponentsInChildren<Button>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				if (componentsInChildren2[j].name == "Take")
				{
					UIGray uigray = componentsInChildren2[j].gameObject.GetComponent<UIGray>();
					if (uigray == null)
					{
						uigray = componentsInChildren2[j].gameObject.AddComponent<UIGray>();
					}
					Text componentInChildren = componentsInChildren2[j].gameObject.GetComponentInChildren<Text>();
					if (MailInfo.hasItem == 0)
					{
						uigray.enabled = true;
						componentsInChildren2[j].interactable = false;
						componentInChildren.text = "已领取";
					}
					else
					{
						uigray.enabled = false;
						componentsInChildren2[j].interactable = true;
						componentInChildren.text = "领取";
					}
					break;
				}
			}
			GameObject gameObject = Utility.FindGameObject(MailItemobj, "AttachIcon", true);
			if (MailInfo.hasItem == 0)
			{
				gameObject.CustomActive(false);
			}
			else
			{
				gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600EA3B RID: 59963 RVA: 0x003E132C File Offset: 0x003DF72C
		private void UpdateMailPerferbBtnBind(ref GameObject MailItemobj, List<MailTitleInfo> mailList, DictionaryView<ulong, GameMailData.MailData> mailDics, string rootPath, int iBtnIdx)
		{
			Button[] componentsInChildren = MailItemobj.GetComponentsInChildren<Button>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == "NormalBack")
				{
					componentsInChildren[i].onClick.RemoveAllListeners();
					int index = iBtnIdx;
					componentsInChildren[i].onClick.AddListener(delegate()
					{
						this.OnClickMail(mailList, mailDics, index, rootPath);
					});
				}
				else if (componentsInChildren[i].name == "Take")
				{
					componentsInChildren[i].onClick.RemoveAllListeners();
					int index = iBtnIdx;
					componentsInChildren[i].onClick.AddListener(delegate()
					{
						this.OnClickTakeMail(index);
					});
				}
			}
		}

		// Token: 0x0600EA3C RID: 59964 RVA: 0x003E1428 File Offset: 0x003DF828
		private void UpdateMailDetail(GameMailData.MailData MailDetailData)
		{
			if (MailDetailData == null || MailDetailData.info == null || MailDetailData.items == null || MailDetailData.detailItems == null)
			{
				if (MailDetailData == null)
				{
					Logger.LogError("MailDetailData is null");
				}
				else if (MailDetailData.info == null)
				{
					Logger.LogError("MailDetailData.info is null");
				}
				else if (MailDetailData.items == null)
				{
					Logger.LogError("MailDetailData.items is null");
				}
				else if (MailDetailData.detailItems == null)
				{
					Logger.LogError("MailDetailData.detailItems is null");
				}
				return;
			}
			this.ShowTipItemData.Clear();
			this.MailTitle.text = MailDetailData.info.title;
			this.SenderName.text = MailDetailData.info.sender;
			if (this.MailContent != null)
			{
				string value = MailDetailData.content.Replace("\\n", "\n");
				this.MailContent.SetText(value, true);
			}
			this.ClearItemsIcon();
			if (MailDetailData.info.hasItem == 1)
			{
				int num = 0;
				int num2 = 0;
				while (num2 < MailDetailData.items.Count && num2 < this.ItemsNum)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)MailDetailData.items[num2].id, 100, 0);
					if (itemData != null)
					{
						itemData.Count = (int)MailDetailData.items[num2].num;
						itemData.StrengthenLevel = (int)MailDetailData.items[num2].strength;
						this.SetUpItem(itemData, num2);
						num++;
					}
					num2++;
				}
				int num3 = 0;
				while (num3 < MailDetailData.detailItems.Count && num + num3 < this.ItemsNum)
				{
					ItemData itemData2 = DataManager<ItemDataManager>.GetInstance().CreateItemDataFromNet(MailDetailData.detailItems[num3]);
					if (itemData2 != null)
					{
						itemData2.Count = (int)MailDetailData.detailItems[num3].num;
						this.SetUpItem(itemData2, num + num3);
					}
					num3++;
				}
				this.mStateContrl.Key = this.mShow;
			}
			else
			{
				this.mStateContrl.Key = this.mHide;
			}
		}

		// Token: 0x0600EA3D RID: 59965 RVA: 0x003E1668 File Offset: 0x003DFA68
		private void UpdateNoMailTip()
		{
			if ((DataManager<PlayerBaseData>.GetInstance().mails.mailList.Count > 0 && DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Count > 0) || (DataManager<PlayerBaseData>.GetInstance().mails.mailList.Count > 0 && DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Count <= 0))
			{
				this.UpdateChoosenBaseType(0);
			}
			else if (DataManager<PlayerBaseData>.GetInstance().mails.mailList.Count <= 0 && DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Count > 0)
			{
				this.UpdateChoosenBaseType(1);
			}
			else
			{
				this.UpdateChoosenBaseType(0);
			}
		}

		// Token: 0x0600EA3E RID: 59966 RVA: 0x003E1730 File Offset: 0x003DFB30
		private void UpdateOneKeyBtn()
		{
		}

		// Token: 0x0600EA3F RID: 59967 RVA: 0x003E1734 File Offset: 0x003DFB34
		private void SetUpItem(ItemData data, int Index)
		{
			if (this.Items == null || Index >= this.Items.Count)
			{
				return;
			}
			int idx = Index;
			this.Items[Index].Setup(data, delegate(GameObject obj, ItemData item)
			{
				this.OnShowItemTip(idx);
			});
			this.ShowTipItemData.Add(data);
		}

		// Token: 0x0600EA40 RID: 59968 RVA: 0x003E179C File Offset: 0x003DFB9C
		private void ClearItemsIcon()
		{
			for (int i = 0; i < this.Items.Count; i++)
			{
				if (this.Items[i] != null)
				{
					this.Items[i].Setup(null, null);
				}
			}
		}

		// Token: 0x0600EA41 RID: 59969 RVA: 0x003E17F0 File Offset: 0x003DFBF0
		private void ClearMailDetail()
		{
			this.MailTitle.text = string.Empty;
			this.SenderName.text = string.Empty;
			if (this.MailContent != null)
			{
				this.MailContent.SetText(string.Empty, true);
			}
			this.ClearItemsIcon();
		}

		// Token: 0x0600EA42 RID: 59970 RVA: 0x003E1845 File Offset: 0x003DFC45
		private void OnShowItemTip(int iIndex)
		{
			if (iIndex >= this.ShowTipItemData.Count)
			{
				return;
			}
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.ShowTipItemData[iIndex], null, 4, true, false, true);
		}

		// Token: 0x0600EA43 RID: 59971 RVA: 0x003E1874 File Offset: 0x003DFC74
		private void CalSelMailLeftTime(ref GameObject MailItemobj, List<MailTitleInfo> mailList, int index)
		{
			MailTitleInfo mailTitleInfo = mailList[index];
			Text[] componentsInChildren = MailItemobj.GetComponentsInChildren<Text>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == "TimeLeft")
				{
					if (mailTitleInfo.deadline - mailTitleInfo.date > 0U)
					{
						componentsInChildren[i].text = Function.GetLeftTimeStr(mailTitleInfo.date, mailTitleInfo.deadline - mailTitleInfo.date, ShowtimeType.Normal);
					}
					break;
				}
			}
		}

		// Token: 0x0600EA44 RID: 59972 RVA: 0x003E18FC File Offset: 0x003DFCFC
		[UIEventHandle("Content/MailPanel(Clone)/Toggles/toggle{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 2)]
		private void OnSwitchBaseType(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			if (iIndex == 0)
			{
				if (DataManager<PlayerBaseData>.GetInstance().mails.mailList.Count <= 0)
				{
					this.noMailTipGo.gameObject.CustomActive(true);
					this.mailListRect.gameObject.CustomActive(false);
					this.rewardsMailListRect.gameObject.CustomActive(false);
					this.bottonImg.gameObject.CustomActive(false);
					this.rewardsBottomRect.gameObject.CustomActive(false);
					this.mailInfoRect.gameObject.CustomActive(false);
				}
				else
				{
					this.OnClickMail(DataManager<PlayerBaseData>.GetInstance().mails.mailList, DataManager<PlayerBaseData>.GetInstance().mails.mailDics, 0, this.RootObjPath);
					this.noMailTipGo.gameObject.CustomActive(false);
					this.mailListRect.gameObject.CustomActive(true);
					this.rewardsMailListRect.gameObject.CustomActive(false);
					this.bottonImg.gameObject.CustomActive(true);
					this.rewardsBottomRect.gameObject.CustomActive(false);
					this.mailInfoRect.gameObject.CustomActive(true);
				}
			}
			else if (DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList.Count <= 0)
			{
				this.noMailTipGo.gameObject.CustomActive(true);
				this.rewardsMailListRect.gameObject.CustomActive(false);
				this.bottonImg.gameObject.CustomActive(false);
				this.mailListRect.gameObject.CustomActive(false);
				this.rewardsBottomRect.gameObject.CustomActive(false);
				this.mailInfoRect.gameObject.CustomActive(false);
			}
			else
			{
				this.OnClickMail(DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList, DataManager<PlayerBaseData>.GetInstance().mails.rewardMailDics, 0, this.RwardRootObjPath);
				this.noMailTipGo.gameObject.CustomActive(false);
				this.rewardsMailListRect.gameObject.CustomActive(true);
				this.bottonImg.gameObject.CustomActive(false);
				this.mailListRect.gameObject.CustomActive(false);
				this.rewardsBottomRect.gameObject.CustomActive(true);
				this.mailInfoRect.gameObject.CustomActive(true);
			}
		}

		// Token: 0x0600EA45 RID: 59973 RVA: 0x003E1B50 File Offset: 0x003DFF50
		[UIEventHandle("Content/MailPanel(Clone)/bottom/BtnAccpet")]
		private void OnAcceptBtnClick()
		{
			if (this.announcementAccpetBtn != null)
			{
				this.announcementAccpetBtn.enabled = false;
				InvokeMethod.Invoke(this, 0.3f, delegate()
				{
					if (this.announcementAccpetBtn != null)
					{
						this.announcementAccpetBtn.enabled = true;
					}
				});
			}
			this.OnClickReceive(DataManager<PlayerBaseData>.GetInstance().mails.mailList);
		}

		// Token: 0x0600EA46 RID: 59974 RVA: 0x003E1BA8 File Offset: 0x003DFFA8
		[UIEventHandle("Content/MailPanel(Clone)/Rewardsbottom/Buttons/BtnAccpet")]
		private void OnAcceptButtonClick()
		{
			if (this.rewardsAccpetBtn != null)
			{
				this.rewardsAccpetBtn.enabled = false;
				InvokeMethod.Invoke(this, 0.3f, delegate()
				{
					if (this.rewardsAccpetBtn != null)
					{
						this.rewardsAccpetBtn.enabled = true;
					}
				});
			}
			this.OnClickReceive(DataManager<PlayerBaseData>.GetInstance().mails.rewardMailList);
		}

		// Token: 0x0600EA47 RID: 59975 RVA: 0x003E1C00 File Offset: 0x003E0000
		private void UpdateChoosenBaseType(int iIndex)
		{
			for (int i = 0; i < this.BaseTypes.Length; i++)
			{
				this.BaseTypes[i].isOn = false;
				if (i == iIndex)
				{
					this.BaseTypes[i].isOn = true;
					break;
				}
			}
		}

		// Token: 0x04008DF3 RID: 36339
		private const string WndRoot = "Content/MailPanel(Clone)/";

		// Token: 0x04008DF4 RID: 36340
		private string RootObjPath = "Content/MailPanel(Clone)/MailList/Scroll View/Viewport/Content";

		// Token: 0x04008DF5 RID: 36341
		private string RwardRootObjPath = "Content/MailPanel(Clone)/RewardsMailList/Scroll View/Viewport/Content";

		// Token: 0x04008DF6 RID: 36342
		private string RewardItemRootPath = "Content/MailPanel(Clone)/MainInfomation/infomationback/Items";

		// Token: 0x04008DF7 RID: 36343
		private string MailItemPath = "UIFlatten/Prefabs/Mail/MailItem";

		// Token: 0x04008DF8 RID: 36344
		private string MailUnReadPath = "UI/Image/Packed/p_UI_Mail.png:UI_Youjian_Tubiao_Youjianguan";

		// Token: 0x04008DF9 RID: 36345
		private string MailReadPath = "UI/Image/Packed/p_UI_Mail.png:UI_Youjian_Tubiao_YoujianKai";

		// Token: 0x04008DFA RID: 36346
		private int ItemsNum;

		// Token: 0x04008DFB RID: 36347
		private double MailLastsTime = 2592000.0;

		// Token: 0x04008DFC RID: 36348
		private const int BaseTabNum = 2;

		// Token: 0x04008DFD RID: 36349
		private List<GameObject> MailItemObjList = new List<GameObject>();

		// Token: 0x04008DFE RID: 36350
		private List<GameObject> RewardMailItemObjList = new List<GameObject>();

		// Token: 0x04008DFF RID: 36351
		private List<ComItem> Items = new List<ComItem>();

		// Token: 0x04008E00 RID: 36352
		private List<ItemData> ShowTipItemData = new List<ItemData>();

		// Token: 0x04008E01 RID: 36353
		private int CreatMailObjNum;

		// Token: 0x04008E02 RID: 36354
		private int CreatRewardMailObjNum;

		// Token: 0x04008E03 RID: 36355
		private ulong CurSelMailID;

		// Token: 0x04008E04 RID: 36356
		private bool CreateFinish;

		// Token: 0x04008E05 RID: 36357
		private float fUpdateInterval;

		// Token: 0x04008E06 RID: 36358
		[UIControl("Content/MailPanel(Clone)/", typeof(StateController), 0)]
		private StateController mStateContrl;

		// Token: 0x04008E07 RID: 36359
		private string mShow = "show";

		// Token: 0x04008E08 RID: 36360
		private string mHide = "hide";

		// Token: 0x04008E09 RID: 36361
		[UIControl("Content/MailPanel(Clone)/MainInfomation/titileback/title", null, 0)]
		protected Text MailTitle;

		// Token: 0x04008E0A RID: 36362
		[UIControl("Content/MailPanel(Clone)/MainInfomation/senderContent/senderback/sendername", null, 0)]
		protected Text SenderName;

		// Token: 0x04008E0B RID: 36363
		[UIControl("Content/MailPanel(Clone)/MainInfomation/infomationback/Units/SerViewPort/Content/infomation", null, 0)]
		protected LinkParse MailContent;

		// Token: 0x04008E0C RID: 36364
		[UIControl("Content/MailPanel(Clone)/bottom/BtnAcceptAll/Text", null, 0)]
		protected Text OneKeyReceive;

		// Token: 0x04008E0D RID: 36365
		[UIControl("Title/Help", null, 0)]
		protected Button helpBtn;

		// Token: 0x04008E0E RID: 36366
		[UIControl("Content/MailPanel(Clone)/bottom/BtnAccpet", null, 0)]
		private Button announcementAccpetBtn;

		// Token: 0x04008E0F RID: 36367
		[UIControl("Content/MailPanel(Clone)/Rewardsbottom/Buttons/BtnAccpet", null, 0)]
		private Button rewardsAccpetBtn;

		// Token: 0x04008E10 RID: 36368
		[UIControl("Content/MailPanel(Clone)/NoMailTip", typeof(Text), 0)]
		private Text noMailTipGo;

		// Token: 0x04008E11 RID: 36369
		[UIControl("Content/MailPanel(Clone)/bottom", typeof(Image), 0)]
		private Image bottonImg;

		// Token: 0x04008E12 RID: 36370
		[UIControl("Content/MailPanel(Clone)/Rewardsbottom", null, 0)]
		private RectTransform rewardsBottomRect;

		// Token: 0x04008E13 RID: 36371
		[UIControl("Content/MailPanel(Clone)/MainInfomation", typeof(RectTransform), 0)]
		private RectTransform mailInfoRect;

		// Token: 0x04008E14 RID: 36372
		[UIControl("Content/MailPanel(Clone)/MailList", typeof(RectTransform), 0)]
		private RectTransform mailListRect;

		// Token: 0x04008E15 RID: 36373
		[UIControl("Content/MailPanel(Clone)/RewardsMailList", typeof(RectTransform), 0)]
		private RectTransform rewardsMailListRect;

		// Token: 0x04008E16 RID: 36374
		[UIControl("Content/MailPanel(Clone)/Toggles/toggle{0}", typeof(Toggle), 1)]
		private Toggle[] BaseTypes = new Toggle[2];
	}
}
