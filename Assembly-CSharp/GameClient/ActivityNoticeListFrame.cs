using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001752 RID: 5970
	internal class ActivityNoticeListFrame : ClientFrame
	{
		// Token: 0x0600EA9A RID: 60058 RVA: 0x003E32DD File Offset: 0x003E16DD
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/MainFrameTown/ActivityNoticeListFrame";
		}

		// Token: 0x0600EA9B RID: 60059 RVA: 0x003E32E4 File Offset: 0x003E16E4
		protected override void _OnOpenFrame()
		{
			this.InitInterface();
		}

		// Token: 0x0600EA9C RID: 60060 RVA: 0x003E32EC File Offset: 0x003E16EC
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600EA9D RID: 60061 RVA: 0x003E32F4 File Offset: 0x003E16F4
		private void ClearData()
		{
			for (int i = 0; i < this.EleObjList.Count; i++)
			{
				if (!(this.EleObjList[i] == null))
				{
					ComCommonBind component = this.EleObjList[i].GetComponent<ComCommonBind>();
					if (!(component == null))
					{
						GameObject gameObject = component.GetGameObject("BtGo");
						gameObject.GetComponent<Button>().onClick.RemoveAllListeners();
					}
				}
			}
			this.EleObjList.Clear();
		}

		// Token: 0x0600EA9E RID: 60062 RVA: 0x003E3384 File Offset: 0x003E1784
		private void OnGo(int index)
		{
			List<NotifyInfo> activityNoticeDataList = DataManager<ActivityNoticeDataManager>.GetInstance().GetActivityNoticeDataList();
			if (index < 0 || index >= activityNoticeDataList.Count)
			{
				return;
			}
			NotifyInfo notifyInfo = activityNoticeDataList[index];
			if (notifyInfo.type == 1U)
			{
				Utility.EnterGuildBattle();
			}
			else if (notifyInfo.type == 8U)
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<JoinGuildDungeonActivityFrame>(FrameLayer.Middle, null, string.Empty);
			}
			else if (notifyInfo.type == 2U)
			{
				DataManager<BudoManager>.GetInstance().TryBeginActive();
			}
			else if (notifyInfo.type == 6U)
			{
				MoneyRewardsEnterFrame.CommandOpen(null);
			}
			else if (notifyInfo.type == 3U)
			{
				ActivityJarData activityJarData = new ActivityJarData();
				activityJarData.nActivityID = (int)notifyInfo.param;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActivityJarFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityJarFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityJarFrame>(FrameLayer.Middle, activityJarData, string.Empty);
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(notifyInfo);
			}
			else if (notifyInfo.type == 4U)
			{
				ActivityJarData activityJarData2 = new ActivityJarData();
				activityJarData2.nActivityID = (int)notifyInfo.param;
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ActivityJarFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<ActivityJarFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<ActivityJarFrame>(FrameLayer.Middle, activityJarData2, string.Empty);
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(notifyInfo);
			}
			else if (notifyInfo.type == 7U)
			{
				if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PocketJarFrame>(null))
				{
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<PocketJarFrame>(null, false);
				}
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PocketJarFrame>(FrameLayer.Middle, null, string.Empty);
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(notifyInfo);
			}
			else if (notifyInfo.type == 9U)
			{
				DataManager<ActiveManager>.GetInstance().OpenActiveFrame(9380, 6000);
				DataManager<ActivityNoticeDataManager>.GetInstance().DeleteActivityNotice(notifyInfo);
			}
			this.frameMgr.CloseFrame<ActivityNoticeListFrame>(this, false);
		}

		// Token: 0x0600EA9F RID: 60063 RVA: 0x003E3560 File Offset: 0x003E1960
		private void InitInterface()
		{
			this.UpdateEleObjList();
		}

		// Token: 0x0600EAA0 RID: 60064 RVA: 0x003E3568 File Offset: 0x003E1968
		private void UpdateEleObjList()
		{
			List<NotifyInfo> activityNoticeDataList = DataManager<ActivityNoticeDataManager>.GetInstance().GetActivityNoticeDataList();
			for (int i = 0; i < activityNoticeDataList.Count; i++)
			{
				if (activityNoticeDataList[i].type == 6U)
				{
					NotifyInfo value = activityNoticeDataList[0];
					activityNoticeDataList[0] = activityNoticeDataList[i];
					activityNoticeDataList[i] = value;
				}
			}
			if (activityNoticeDataList.Count > this.EleObjList.Count)
			{
				int num = activityNoticeDataList.Count - this.EleObjList.Count;
				for (int j = 0; j < num; j++)
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.ActivityListElePath, true, 0U);
					if (!(gameObject == null))
					{
						Utility.AttachTo(gameObject, this.mEleRoot, false);
						this.EleObjList.Add(gameObject);
					}
				}
			}
			for (int k = 0; k < this.EleObjList.Count; k++)
			{
				if (k < activityNoticeDataList.Count)
				{
					ComCommonBind component = this.EleObjList[k].GetComponent<ComCommonBind>();
					if (component == null)
					{
						this.EleObjList[k].SetActive(false);
					}
					else
					{
						string text = null;
						GameObject gameObject2 = component.GetGameObject("Icon");
						GameObject gameObject3 = component.GetGameObject("Des");
						if (activityNoticeDataList[k].type == 1U)
						{
							text = "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Gonghui";
							gameObject3.GetComponent<Text>().text = TR.Value("Activity_Guild_tip");
						}
						if (activityNoticeDataList[k].type == 8U)
						{
							text = "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Gonghui";
							gameObject3.GetComponent<Text>().text = TR.Value("Activity_Guild_Dungeon_tip");
						}
						else if (activityNoticeDataList[k].type == 2U)
						{
							text = "UI/Image/Packed/p_MainUI01.png:UI_MainUI_Shousuo_Icon_Juedou";
							gameObject3.GetComponent<Text>().text = TR.Value("Activity_Budo_tip");
						}
						else if (activityNoticeDataList[k].type == 6U)
						{
							text = "UI/Image/Packed/p_MainUI01.png:UI_MainUI_Shousuo_Icon_Juedou";
							gameObject3.GetComponent<Text>().text = TR.Value("Activity_MoneyRewards_tip");
						}
						else if (activityNoticeDataList[k].type == 3U)
						{
							ActivityJarTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ActivityJarTable>((int)activityNoticeDataList[k].param, string.Empty, string.Empty);
							if (tableItem != null)
							{
								JarData jarData = DataManager<JarDataManager>.GetInstance().GetJarData(tableItem.JarID);
								if (jarData != null)
								{
									text = "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Moguan";
									gameObject3.GetComponent<Text>().text = TR.Value("notice_jar_open", jarData.strName);
								}
							}
						}
						else if (activityNoticeDataList[k].type == 4U)
						{
							ActivityJarTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ActivityJarTable>((int)activityNoticeDataList[k].param, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								JarData jarData2 = DataManager<JarDataManager>.GetInstance().GetJarData(tableItem2.JarID);
								if (jarData2 != null)
								{
									text = "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Moguan";
									gameObject3.GetComponent<Text>().text = TR.Value("notice_jar_sale_reset", jarData2.strName);
								}
							}
						}
						else if (activityNoticeDataList[k].type == 7U)
						{
							text = "UI/Image/Packed/p_MainUIIcon.png:UI_MainUI_Tubiao_Moguan";
							gameObject3.GetComponent<Text>().text = TR.Value("notice_mogicjar_integral_emptying");
						}
						else if (activityNoticeDataList[k].type == 9U)
						{
							text = "UI/Image/Packed/p_UI_Fuli.png:UI_Fuli_JiangLiZanCunXiang";
							gameObject3.GetComponent<Text>().text = TR.Value("notice_month_card_high_grade_expire_24h");
						}
						if (text != null)
						{
							Image component2 = gameObject2.GetComponent<Image>();
							if (component2)
							{
								ETCImageLoader.LoadSprite(ref component2, text, true);
								if (activityNoticeDataList[k].type == 9U)
								{
									component2.SetNativeSize();
								}
							}
						}
						GameObject gameObject4 = component.GetGameObject("BtGo");
						Button component3 = gameObject4.GetComponent<Button>();
						component3.onClick.RemoveAllListeners();
						int iIndex = k;
						component3.onClick.AddListener(delegate()
						{
							this.OnGo(iIndex);
						});
						this.EleObjList[k].SetActive(true);
					}
				}
				else
				{
					this.EleObjList[k].SetActive(false);
				}
			}
		}

		// Token: 0x0600EAA1 RID: 60065 RVA: 0x003E39C4 File Offset: 0x003E1DC4
		protected override void _bindExUI()
		{
			this.mEleRoot = this.mBind.GetGameObject("EleRoot");
			this.mBtClose = this.mBind.GetCom<Button>("BtClose");
			this.mBtClose.onClick.AddListener(new UnityAction(this._onBtCloseButtonClick));
		}

		// Token: 0x0600EAA2 RID: 60066 RVA: 0x003E3A19 File Offset: 0x003E1E19
		protected override void _unbindExUI()
		{
			this.mEleRoot = null;
			this.mBtClose.onClick.RemoveListener(new UnityAction(this._onBtCloseButtonClick));
			this.mBtClose = null;
		}

		// Token: 0x0600EAA3 RID: 60067 RVA: 0x003E3A45 File Offset: 0x003E1E45
		private void _onBtCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ActivityNoticeListFrame>(this, false);
		}

		// Token: 0x04008E4A RID: 36426
		private string ActivityListElePath = "UIFlatten/Prefabs/MainFrameTown/ActivityNoticeEle";

		// Token: 0x04008E4B RID: 36427
		private List<GameObject> EleObjList = new List<GameObject>();

		// Token: 0x04008E4C RID: 36428
		private GameObject mEleRoot;

		// Token: 0x04008E4D RID: 36429
		private Button mBtClose;
	}
}
