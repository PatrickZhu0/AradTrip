using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C1C RID: 7196
	internal class TeamRequesterListFrame : ClientFrame
	{
		// Token: 0x06011A60 RID: 72288 RVA: 0x0052A033 File Offset: 0x00528433
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Team/TeamRequesterList";
		}

		// Token: 0x06011A61 RID: 72289 RVA: 0x0052A03A File Offset: 0x0052843A
		protected override void _OnOpenFrame()
		{
			this.requesters = (this.userData as List<TeammemberBaseInfo>);
			this.InitInterface();
			DataManager<TeamDataManager>.GetInstance().ClearNewRequesterMark();
			DataManager<RedPointDataManager>.GetInstance().NotifyRedPointChanged(ERedPoint.TeamNewRequester);
		}

		// Token: 0x06011A62 RID: 72290 RVA: 0x0052A06C File Offset: 0x0052846C
		protected override void _OnCloseFrame()
		{
			this._Clear();
		}

		// Token: 0x06011A63 RID: 72291 RVA: 0x0052A074 File Offset: 0x00528474
		private void _Clear()
		{
			for (int i = 0; i < this.RejectList.Count; i++)
			{
				this.RejectList[i].onClick.RemoveAllListeners();
			}
			for (int j = 0; j < this.AgreeList.Count; j++)
			{
				this.AgreeList[j].onClick.RemoveAllListeners();
			}
			this.IconList.Clear();
			this.LevelList.Clear();
			this.NameList.Clear();
			this.JobList.Clear();
			this.RejectList.Clear();
			this.AgreeList.Clear();
			this.RequestersObj.Clear();
			this.requesters.Clear();
		}

		// Token: 0x06011A64 RID: 72292 RVA: 0x0052A13D File Offset: 0x0052853D
		[UIEventHandle("middle/Title/Close")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<TeamRequesterListFrame>(this, false);
		}

		// Token: 0x06011A65 RID: 72293 RVA: 0x0052A14C File Offset: 0x0052854C
		private void OnReject(int iIndex)
		{
			if (iIndex < 0 || this.requesters.Count <= 0 || iIndex >= this.requesters.Count)
			{
				return;
			}
			this.SendDealResult(this.requesters[iIndex].id, 0);
		}

		// Token: 0x06011A66 RID: 72294 RVA: 0x0052A19C File Offset: 0x0052859C
		private void OnAgree(int iIndex)
		{
			if (iIndex < 0 || this.requesters.Count <= 0 || iIndex >= this.requesters.Count)
			{
				return;
			}
			this.SendDealResult(this.requesters[iIndex].id, 1);
		}

		// Token: 0x06011A67 RID: 72295 RVA: 0x0052A1EC File Offset: 0x005285EC
		[UIEventHandle("middle/OneKeyClear")]
		private void OnOneKeyClear()
		{
			for (int i = 0; i < this.requesters.Count; i++)
			{
				this.SendDealResult(this.requesters[i].id, 0);
			}
		}

		// Token: 0x06011A68 RID: 72296 RVA: 0x0052A22D File Offset: 0x0052862D
		private void InitInterface()
		{
			this.CreatePrefabs();
			this.UpdateInterface();
		}

		// Token: 0x06011A69 RID: 72297 RVA: 0x0052A23C File Offset: 0x0052863C
		private void CreatePrefabs()
		{
			for (int i = 0; i < this.requesters.Count; i++)
			{
				GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject("UIFlatten/Prefabs/Team/TeamRequesterEle", true, 0U);
				if (!(gameObject == null))
				{
					Utility.AttachTo(gameObject, this.rootObj, false);
					this.RequestersObj.Add(gameObject);
					Image[] componentsInChildren = gameObject.GetComponentsInChildren<Image>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (componentsInChildren[j].name == "Icon")
						{
							this.IconList.Add(componentsInChildren[j]);
						}
					}
					Text[] componentsInChildren2 = gameObject.GetComponentsInChildren<Text>();
					for (int k = 0; k < componentsInChildren2.Length; k++)
					{
						if (componentsInChildren2[k].name == "Level")
						{
							this.LevelList.Add(componentsInChildren2[k]);
						}
						else if (componentsInChildren2[k].name == "Name")
						{
							this.NameList.Add(componentsInChildren2[k]);
						}
						else if (componentsInChildren2[k].name == "Job")
						{
							this.JobList.Add(componentsInChildren2[k]);
						}
					}
					Button[] componentsInChildren3 = gameObject.GetComponentsInChildren<Button>();
					for (int l = 0; l < componentsInChildren3.Length; l++)
					{
						if (componentsInChildren3[l].name == "reject")
						{
							int Idx = i;
							componentsInChildren3[l].onClick.AddListener(delegate()
							{
								this.OnReject(Idx);
							});
							this.RejectList.Add(componentsInChildren3[l]);
						}
						else if (componentsInChildren3[l].name == "agree")
						{
							int Idx = i;
							componentsInChildren3[l].onClick.AddListener(delegate()
							{
								this.OnAgree(Idx);
							});
							this.AgreeList.Add(componentsInChildren3[l]);
						}
					}
				}
			}
		}

		// Token: 0x06011A6A RID: 72298 RVA: 0x0052A468 File Offset: 0x00528868
		private void UpdateInterface()
		{
			for (int i = 0; i < this.RequestersObj.Count; i++)
			{
				if (i < this.requesters.Count)
				{
					this.NameList[i].text = this.requesters[i].name;
					this.LevelList[i].text = string.Format("Lv.{0}", this.requesters[i].level);
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)this.requesters[i].occu, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.JobList[i].text = tableItem.Name;
						ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
						if (tableItem2 != null)
						{
							Image image = this.IconList[i];
							ETCImageLoader.LoadSprite(ref image, tableItem2.IconPath, true);
						}
					}
					ComCommonBind component = this.RequestersObj[i].GetComponent<ComCommonBind>();
					StaticUtility.SafeSetVisible(component, "returnPlayer", false);
					StaticUtility.SafeSetVisible(component, "myFriend", false);
					StaticUtility.SafeSetVisible(component, "myGuild", false);
					TeammemberBaseInfo teammemberBaseInfo = this.requesters[i];
					if (teammemberBaseInfo != null)
					{
						RelationData relationData = null;
						bool flag = DataManager<RelationDataManager>.GetInstance().FindPlayerIsRelation(teammemberBaseInfo.id, ref relationData);
						bool flag2 = DataManager<GuildDataManager>.GetInstance().IsSameGuild(teammemberBaseInfo.playerLabelInfo.guildId);
						if (teammemberBaseInfo.playerLabelInfo.returnStatus == 1)
						{
							StaticUtility.SafeSetVisible(component, "returnPlayer", true);
						}
						else if (flag)
						{
							StaticUtility.SafeSetVisible(component, "myFriend", true);
						}
						else if (flag2)
						{
							StaticUtility.SafeSetVisible(component, "myGuild", true);
						}
						if (component != null)
						{
							Button com = component.GetCom<Button>("btnIcon");
							com.SafeSetOnClickListener(delegate
							{
								DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(teammemberBaseInfo.id, 0U, 0U);
							});
						}
					}
					this.RequestersObj[i].SetActive(true);
				}
				else
				{
					this.RequestersObj[i].SetActive(false);
				}
			}
		}

		// Token: 0x06011A6B RID: 72299 RVA: 0x0052A6B8 File Offset: 0x00528AB8
		private void SendDealResult(ulong targetid, byte agree)
		{
			WorldTeamProcessRequesterReq worldTeamProcessRequesterReq = new WorldTeamProcessRequesterReq();
			worldTeamProcessRequesterReq.targetId = targetid;
			worldTeamProcessRequesterReq.agree = agree;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldTeamProcessRequesterReq>(ServerType.GATE_SERVER, worldTeamProcessRequesterReq);
		}

		// Token: 0x06011A6C RID: 72300 RVA: 0x0052A6E8 File Offset: 0x00528AE8
		[MessageHandle(601641U, false, 0)]
		private void OnTeamRequestersListRes(MsgDATA msg)
		{
			WorldTeamProcessRequesterRes worldTeamProcessRequesterRes = new WorldTeamProcessRequesterRes();
			worldTeamProcessRequesterRes.decode(msg.bytes);
			if (worldTeamProcessRequesterRes.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)worldTeamProcessRequesterRes.result, string.Empty);
				return;
			}
			for (int i = 0; i < this.requesters.Count; i++)
			{
				if (this.requesters[i].id == worldTeamProcessRequesterRes.targetId)
				{
					this.requesters.RemoveAt(i);
					break;
				}
			}
			this.UpdateInterface();
		}

		// Token: 0x0400B7E4 RID: 47076
		private List<GameObject> RequestersObj = new List<GameObject>();

		// Token: 0x0400B7E5 RID: 47077
		private List<Button> RejectList = new List<Button>();

		// Token: 0x0400B7E6 RID: 47078
		private List<Button> AgreeList = new List<Button>();

		// Token: 0x0400B7E7 RID: 47079
		private List<Image> IconList = new List<Image>();

		// Token: 0x0400B7E8 RID: 47080
		private List<Text> LevelList = new List<Text>();

		// Token: 0x0400B7E9 RID: 47081
		private List<Text> NameList = new List<Text>();

		// Token: 0x0400B7EA RID: 47082
		private List<Text> JobList = new List<Text>();

		// Token: 0x0400B7EB RID: 47083
		private List<TeammemberBaseInfo> requesters = new List<TeammemberBaseInfo>();

		// Token: 0x0400B7EC RID: 47084
		[UIObject("middle/Scroll View/Viewport/Content")]
		private GameObject rootObj;
	}
}
