using System;
using System.Collections.Generic;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001994 RID: 6548
	public class PkFriendsFrame : ClientFrame
	{
		// Token: 0x0600FEE4 RID: 65252 RVA: 0x00468A81 File Offset: 0x00466E81
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PkFriendsFrame";
		}

		// Token: 0x0600FEE5 RID: 65253 RVA: 0x00468A88 File Offset: 0x00466E88
		protected sealed override void _OnOpenFrame()
		{
			this.mCurRequsetType = (RequestType)this.userData;
			this.InitInterface();
			this.SendQueryFriendStatus();
			this.BindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideEnd, null, null, null, null);
		}

		// Token: 0x0600FEE6 RID: 65254 RVA: 0x00468AC0 File Offset: 0x00466EC0
		protected sealed override void _OnCloseFrame()
		{
			this.ClearData();
			this.UnBindUIEvent();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.pkGuideStart, null, null, null, null);
		}

		// Token: 0x0600FEE7 RID: 65255 RVA: 0x00468AE4 File Offset: 0x00466EE4
		private void ClearData()
		{
			for (int i = 0; i < this.FriendsItemList.Count; i++)
			{
				Button componentInChildren = this.FriendsItemList[i].GetComponentInChildren<Button>();
				if (componentInChildren != null)
				{
					componentInChildren.onClick.RemoveAllListeners();
				}
			}
			this.FriendsItemList.Clear();
			this.Icons.Clear();
			this.names.Clear();
			this.Levels.Clear();
			this.Jobs.Clear();
			this.states.Clear();
			this.FriendInfoList.Clear();
			this.pkLv.Clear();
		}

		// Token: 0x0600FEE8 RID: 65256 RVA: 0x00468B8E File Offset: 0x00466F8E
		[UIEventHandle("middle/title/btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<PkFriendsFrame>(this, false);
		}

		// Token: 0x0600FEE9 RID: 65257 RVA: 0x00468B9D File Offset: 0x00466F9D
		protected void BindUIEvent()
		{
		}

		// Token: 0x0600FEEA RID: 65258 RVA: 0x00468B9F File Offset: 0x00466F9F
		protected void UnBindUIEvent()
		{
		}

		// Token: 0x0600FEEB RID: 65259 RVA: 0x00468BA1 File Offset: 0x00466FA1
		private void InitInterface()
		{
			this.CreateFriendsListPreferb();
		}

		// Token: 0x0600FEEC RID: 65260 RVA: 0x00468BAC File Offset: 0x00466FAC
		private void OnClickPk(int iIndex)
		{
			if (iIndex < 0 || iIndex >= this.FriendInfoList.Count)
			{
				return;
			}
			int functionUnlockLevel = Utility.GetFunctionUnlockLevel(FunctionUnLock.eFuncType.Duel);
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.FriendInfoList[iIndex].roleId);
			if ((int)relationByRoleID.level < functionUnlockLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation("该好友尚未解锁pk功能", CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			SceneRequest cmd = new SceneRequest
			{
				type = (byte)this.mCurRequsetType,
				target = this.FriendInfoList[iIndex].roleId,
				targetName = string.Empty
			};
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<SceneRequest>(ServerType.GATE_SERVER, cmd);
			SystemNotifyManager.SysNotifyTextAnimation("邀请已发送", CommonTipsDesc.eShowMode.SI_UNIQUE);
			this.OnClose();
		}

		// Token: 0x0600FEED RID: 65261 RVA: 0x00468C68 File Offset: 0x00467068
		private void CreateFriendsListPreferb()
		{
			for (int i = 0; i < this.ShowNum; i++)
			{
				this.CreateSinglePrefab(i);
			}
		}

		// Token: 0x0600FEEE RID: 65262 RVA: 0x00468C94 File Offset: 0x00467094
		private void SendQueryFriendStatus()
		{
			WorldMatchQueryFriendStatusReq cmd = new WorldMatchQueryFriendStatusReq();
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<WorldMatchQueryFriendStatusReq>(ServerType.GATE_SERVER, cmd);
		}

		// Token: 0x0600FEEF RID: 65263 RVA: 0x00468CB8 File Offset: 0x004670B8
		[MessageHandle(606707U, false, 0)]
		private void OnQueryFriendStatusRes(MsgDATA msg)
		{
			WorldMatchQueryFriendStatusRes worldMatchQueryFriendStatusRes = new WorldMatchQueryFriendStatusRes();
			worldMatchQueryFriendStatusRes.decode(msg.bytes);
			for (int i = 0; i < worldMatchQueryFriendStatusRes.infoes.Length; i++)
			{
				this.FriendInfoList.Add(worldMatchQueryFriendStatusRes.infoes[i]);
			}
			this.FriendInfoList.Sort(delegate(FriendMatchStatusInfo x, FriendMatchStatusInfo y)
			{
				if (x.status < y.status)
				{
					return 1;
				}
				if (x.status > y.status)
				{
					return -1;
				}
				return 0;
			});
			int num = 0;
			while (num < this.ShowNum && num < this.FriendInfoList.Count)
			{
				RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.FriendInfoList[num].roleId);
				this.ShowFriendsData(num, this.FriendInfoList[num], relationByRoleID);
				num++;
			}
			if (this.FriendInfoList.Count > this.ShowNum)
			{
				for (int j = this.FriendInfoList.Count - this.ShowNum - 1; j < this.FriendInfoList.Count; j++)
				{
					this.CreateSinglePrefab(j);
					RelationData relationByRoleID2 = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(this.FriendInfoList[j].roleId);
					this.ShowFriendsData(j, this.FriendInfoList[j], relationByRoleID2);
				}
			}
		}

		// Token: 0x0600FEF0 RID: 65264 RVA: 0x00468E0C File Offset: 0x0046720C
		private void CreateSinglePrefab(int idx)
		{
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(this.ElementPath, true, 0U);
			if (gameObject == null)
			{
				return;
			}
			Utility.AttachTo(gameObject, this.ContentObjRoot, false);
			Text[] componentsInChildren = gameObject.GetComponentsInChildren<Text>();
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				if (componentsInChildren[i].name == "name")
				{
					this.names.Add(componentsInChildren[i]);
				}
				else if (componentsInChildren[i].name == "level")
				{
					this.Levels.Add(componentsInChildren[i]);
				}
				else if (componentsInChildren[i].name == "job")
				{
					this.Jobs.Add(componentsInChildren[i]);
				}
				else if (componentsInChildren[i].name == "state")
				{
					this.states.Add(componentsInChildren[i]);
				}
			}
			Image[] componentsInChildren2 = gameObject.GetComponentsInChildren<Image>();
			for (int j = 0; j < componentsInChildren2.Length; j++)
			{
				if (componentsInChildren2[j].name == "icon")
				{
					this.Icons.Add(componentsInChildren2[j]);
				}
				else if (componentsInChildren2[j].name == "pkLv")
				{
					this.pkLv.Add(componentsInChildren2[j]);
				}
			}
			int iIndex = idx;
			Button componentInChildren = gameObject.GetComponentInChildren<Button>();
			componentInChildren.onClick.AddListener(delegate()
			{
				this.OnClickPk(iIndex);
			});
			this.FriendsItemList.Add(gameObject);
			gameObject.SetActive(false);
		}

		// Token: 0x0600FEF1 RID: 65265 RVA: 0x00468FC4 File Offset: 0x004673C4
		private void ShowFriendsData(int index, FriendMatchStatusInfo info, RelationData data)
		{
			if (index >= this.FriendsItemList.Count || index >= this.names.Count || index >= this.Levels.Count || index >= this.Jobs.Count || index >= this.pkLv.Count || index < 0)
			{
				return;
			}
			this.FriendsItemList[index].gameObject.SetActive(true);
			this.names[index].text = data.name;
			this.Levels[index].text = "lv." + data.level.ToString();
			Text text = this.Jobs[index];
			this.SetJobDataByJobID(index, (int)data.occu, ref text);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			bool flag = false;
			string pathByPkPoints = Utility.GetPathByPkPoints(DataManager<PlayerBaseData>.GetInstance().pkPoints, ref num, ref num2, ref num3, ref flag);
			if (pathByPkPoints != string.Empty && pathByPkPoints != "-" && pathByPkPoints != "0")
			{
				Image image = this.pkLv[index];
				ETCImageLoader.LoadSprite(ref image, pathByPkPoints, true);
			}
			this.states[index].text = this.GetStatesStrByType(info.status);
		}

		// Token: 0x0600FEF2 RID: 65266 RVA: 0x00469130 File Offset: 0x00467530
		private void SetJobDataByJobID(int iIndex, int JobId, ref Text Job)
		{
			string path = string.Empty;
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(JobId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			path = tableItem2.IconPath;
			Image image = this.Icons[iIndex];
			ETCImageLoader.LoadSprite(ref image, path, true);
			Job.text = tableItem.Name;
		}

		// Token: 0x0600FEF3 RID: 65267 RVA: 0x004691B0 File Offset: 0x004675B0
		private string GetStatesStrByType(byte state)
		{
			string result = string.Empty;
			if (state == 1)
			{
				result = string.Format(TR.Value("Friens_Busy_State"), "忙碌");
			}
			else if (state == 2)
			{
				result = "下线";
			}
			else
			{
				result = "空闲";
			}
			return result;
		}

		// Token: 0x0400A0C3 RID: 41155
		private string ElementPath = "UIFlatten/Prefabs/Pk/PkFriendsElement";

		// Token: 0x0400A0C4 RID: 41156
		private int ShowNum = 7;

		// Token: 0x0400A0C5 RID: 41157
		private List<GameObject> FriendsItemList = new List<GameObject>();

		// Token: 0x0400A0C6 RID: 41158
		private List<Image> Icons = new List<Image>();

		// Token: 0x0400A0C7 RID: 41159
		private List<Text> names = new List<Text>();

		// Token: 0x0400A0C8 RID: 41160
		private List<Text> Levels = new List<Text>();

		// Token: 0x0400A0C9 RID: 41161
		private List<Text> Jobs = new List<Text>();

		// Token: 0x0400A0CA RID: 41162
		private List<Text> states = new List<Text>();

		// Token: 0x0400A0CB RID: 41163
		private List<Image> pkLv = new List<Image>();

		// Token: 0x0400A0CC RID: 41164
		private List<FriendMatchStatusInfo> FriendInfoList = new List<FriendMatchStatusInfo>();

		// Token: 0x0400A0CD RID: 41165
		private RequestType mCurRequsetType = RequestType.Request_Challenge_PK;

		// Token: 0x0400A0CE RID: 41166
		[UIObject("middle/Scroll View/Viewport/Content")]
		protected GameObject ContentObjRoot;
	}
}
