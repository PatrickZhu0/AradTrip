using System;
using System.Collections;
using System.Collections.Generic;
using Protocol;
using XUPorterJSON;

namespace GameClient
{
	// Token: 0x02001177 RID: 4471
	public class ServerListManager : Singleton<ServerListManager>
	{
		// Token: 0x0600AAF5 RID: 43765 RVA: 0x00249E62 File Offset: 0x00248262
		public ServerListManager()
		{
			this.tabs = null;
			this.allusers = null;
			this.savedata = null;
			this.recommendServer = null;
			this.units = null;
		}

		// Token: 0x17001A2D RID: 6701
		// (get) Token: 0x0600AAF7 RID: 43767 RVA: 0x00249E96 File Offset: 0x00248296
		// (set) Token: 0x0600AAF6 RID: 43766 RVA: 0x00249E8D File Offset: 0x0024828D
		public ArrayList tabs { get; private set; }

		// Token: 0x17001A2E RID: 6702
		// (get) Token: 0x0600AAF9 RID: 43769 RVA: 0x00249EA7 File Offset: 0x002482A7
		// (set) Token: 0x0600AAF8 RID: 43768 RVA: 0x00249E9E File Offset: 0x0024829E
		public ArrayList allusers { get; private set; }

		// Token: 0x17001A2F RID: 6703
		// (get) Token: 0x0600AAFB RID: 43771 RVA: 0x00249EB8 File Offset: 0x002482B8
		// (set) Token: 0x0600AAFA RID: 43770 RVA: 0x00249EAF File Offset: 0x002482AF
		public ArrayList savedata { get; private set; }

		// Token: 0x17001A30 RID: 6704
		// (get) Token: 0x0600AAFD RID: 43773 RVA: 0x00249EC9 File Offset: 0x002482C9
		// (set) Token: 0x0600AAFC RID: 43772 RVA: 0x00249EC0 File Offset: 0x002482C0
		public ArrayList recommendServer { get; private set; }

		// Token: 0x17001A31 RID: 6705
		// (get) Token: 0x0600AAFF RID: 43775 RVA: 0x00249EDA File Offset: 0x002482DA
		// (set) Token: 0x0600AAFE RID: 43774 RVA: 0x00249ED1 File Offset: 0x002482D1
		public int newServerID { get; private set; }

		// Token: 0x17001A32 RID: 6706
		// (get) Token: 0x0600AB01 RID: 43777 RVA: 0x00249EEB File Offset: 0x002482EB
		// (set) Token: 0x0600AB00 RID: 43776 RVA: 0x00249EE2 File Offset: 0x002482E2
		public ArrayList units { get; private set; }

		// Token: 0x0600AB02 RID: 43778 RVA: 0x00249EF3 File Offset: 0x002482F3
		public bool IsBasicDataReady()
		{
			return this.IsTabsReady() && this.IsUnitsReady() && this.IsSaveDataReady();
		}

		// Token: 0x0600AB03 RID: 43779 RVA: 0x00249F14 File Offset: 0x00248314
		public bool IsTabsReady()
		{
			return this.tabs != null;
		}

		// Token: 0x0600AB04 RID: 43780 RVA: 0x00249F22 File Offset: 0x00248322
		public bool IsUnitsReady()
		{
			return this.units != null;
		}

		// Token: 0x0600AB05 RID: 43781 RVA: 0x00249F30 File Offset: 0x00248330
		public bool IsSaveDataReady()
		{
			return this.savedata != null;
		}

		// Token: 0x0600AB06 RID: 43782 RVA: 0x00249F3E File Offset: 0x0024833E
		public bool IsRecommendServerReady()
		{
			return null != this.recommendServer;
		}

		// Token: 0x0600AB07 RID: 43783 RVA: 0x00249F4C File Offset: 0x0024834C
		public bool IsAllUserReady()
		{
			return this.allusers != null;
		}

		// Token: 0x0600AB08 RID: 43784 RVA: 0x00249F5C File Offset: 0x0024835C
		public void SaveUserData(RoleInfo[] roles)
		{
			if (this.savedata == null)
			{
				return;
			}
			if (roles == null)
			{
				Logger.LogErrorFormat("[保存服务器列表] roles 为空", new object[0]);
				return;
			}
			try
			{
				ArrayList arrayList = new ArrayList();
				for (int i = 0; i < roles.Length; i++)
				{
					arrayList.Add(new Hashtable
					{
						{
							"t",
							(int)roles[i].occupation
						},
						{
							"l",
							(int)roles[i].level
						}
					});
				}
				uint id = ClientApplication.adminServer.id;
				ArrayList arrayList2 = this.savedata;
				if (arrayList2 == null)
				{
					arrayList2 = new ArrayList();
				}
				int num = -1;
				for (int j = 0; j < arrayList2.Count; j++)
				{
					Hashtable hashtable = arrayList2[j] as Hashtable;
					if (hashtable != null)
					{
						uint num2 = uint.Parse(hashtable["id"].ToString());
						if (num2 == id)
						{
							num = j;
							if (hashtable.ContainsKey("ch"))
							{
								hashtable["ch"] = arrayList;
							}
							else
							{
								hashtable.Add("ch", arrayList);
							}
							break;
						}
					}
				}
				if (num < 0)
				{
					if (arrayList.Count > 0)
					{
						arrayList2.Add(new Hashtable
						{
							{
								"id",
								id
							},
							{
								"ch",
								arrayList
							}
						});
					}
				}
				else if (arrayList.Count <= 0)
				{
					arrayList2.RemoveAt(num);
				}
				string content = MiniJSON.jsonEncode(arrayList2);
				string text = string.Empty;
				if (PlayerLocalSetting.GetValue("AccountDefault") != null)
				{
					text = PlayerLocalSetting.GetValue("AccountDefault").ToString();
					text = SDKInterface.instance.NeedUriEncodeOpenid(text);
				}
				string dirSig = ClientApplication.adminServer.dirSig;
				string url = string.Format("http://{0}/save_data?id={1}&sig={2}", Global.ROLE_SAVEDATA_SERVER_ADDRESS, text, dirSig);
				this.savedata = arrayList2;
				Http.SendPostRequest(url, content, null);
			}
			catch (Exception ex)
			{
				Logger.LogErrorFormat("[保存服务器列表] 粗粗哦 {0}", new object[]
				{
					ex.ToString()
				});
			}
		}

		// Token: 0x0600AB09 RID: 43785 RVA: 0x0024A1A8 File Offset: 0x002485A8
		public Hashtable GetServerHashtableByID(int id)
		{
			if (this.allusers == null)
			{
				return null;
			}
			for (int i = 0; i < this.allusers.Count; i++)
			{
				Hashtable hashtable = this.allusers[i] as Hashtable;
				if (hashtable != null)
				{
					int num = int.Parse(hashtable["id"].ToString());
					if (num == id)
					{
						return hashtable;
					}
				}
			}
			return null;
		}

		// Token: 0x0600AB0A RID: 43786 RVA: 0x0024A216 File Offset: 0x00248616
		public bool IsShowHasCharactorFlag(int serverid)
		{
			return this.GetServerHashtableByID(serverid) != null;
		}

		// Token: 0x0600AB0B RID: 43787 RVA: 0x0024A228 File Offset: 0x00248628
		public Hashtable ShowHasCharatorFlag(uint serverID)
		{
			if (this.savedata == null)
			{
				Logger.LogErrorFormat("savedata is null", new object[0]);
				return null;
			}
			for (int i = 0; i < this.savedata.Count; i++)
			{
				Hashtable hashtable = this.savedata[i] as Hashtable;
				if (hashtable != null)
				{
					int num = int.Parse(hashtable["id"].ToString());
					if ((long)num == (long)((ulong)serverID))
					{
						return hashtable;
					}
				}
			}
			return null;
		}

		// Token: 0x0600AB0C RID: 43788 RVA: 0x0024A2A8 File Offset: 0x002486A8
		public IEnumerator SendHttpReqCharactorUnit()
		{
			this.savedata = null;
			object originAccountObj = PlayerLocalSetting.GetValue("AccountDefault");
			string accountname = (originAccountObj != null) ? originAccountObj.ToString() : string.Empty;
			WaitHttpRequest req = new WaitHttpRequest(string.Format("get_data?id={0}", accountname));
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				this.savedata = req.GetResultJson();
				if (this.savedata == null)
				{
					this.savedata = new ArrayList();
				}
			}
			yield return Yielders.EndOfFrame;
			if (this.savedata != null)
			{
				this.allusers = null;
				List<string> allIds = new List<string>();
				for (int i = 0; i < this.savedata.Count; i++)
				{
					Hashtable hashtable = this.savedata[i] as Hashtable;
					if (hashtable != null)
					{
						string text = string.Empty;
						if (hashtable.ContainsKey("id"))
						{
							text = hashtable["id"].ToString();
						}
						if (hashtable.ContainsKey("ch"))
						{
							ArrayList arrayList = hashtable["ch"] as ArrayList;
						}
						if (!string.IsNullOrEmpty(text))
						{
							allIds.Add(text);
						}
					}
				}
				string param = string.Format("nodes?ids={0}", string.Join(",", allIds.ToArray()));
				WaitHttpRequest req2 = new WaitHttpRequest(param);
				yield return req2;
				if (req2.GetResult() == BaseWaitHttpRequest.eState.Success)
				{
					this.allusers = req2.GetResultJson();
				}
			}
			yield break;
		}

		// Token: 0x0600AB0D RID: 43789 RVA: 0x0024A2C4 File Offset: 0x002486C4
		public IEnumerator SendHttpReqTab()
		{
			this.tabs = null;
			WaitHttpRequest req = new WaitHttpRequest("zone_list");
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				this.tabs = req.GetResultJson();
			}
			yield break;
		}

		// Token: 0x0600AB0E RID: 43790 RVA: 0x0024A2E0 File Offset: 0x002486E0
		public IEnumerator SendHttpReqNodeMap(int originID)
		{
			WaitHttpRequest req = new WaitHttpRequest(string.Format("node_map?id={0}", originID));
			this.newServerID = -1;
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				try
				{
					this.newServerID = int.Parse(req.GetResultString());
				}
				catch (Exception ex)
				{
				}
			}
			yield break;
		}

		// Token: 0x0600AB0F RID: 43791 RVA: 0x0024A304 File Offset: 0x00248704
		public IEnumerator SendHttpReqRecommondServer()
		{
			WaitHttpRequest req = new WaitHttpRequest("recommend");
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				ArrayList serverIds = req.GetResultJson();
				List<string> allIds = new List<string>();
				if (serverIds != null)
				{
					string item = string.Empty;
					for (int i = 0; i < serverIds.Count; i++)
					{
						item = serverIds[i].ToString();
						allIds.Add(item);
					}
				}
				if (allIds.Count > 0)
				{
					this.recommendServer = null;
					string param = string.Format("nodes?ids={0}", string.Join(",", allIds.ToArray()));
					WaitHttpRequest recommendReq = new WaitHttpRequest(param);
					yield return recommendReq;
					if (recommendReq.GetResult() == BaseWaitHttpRequest.eState.Success)
					{
						this.recommendServer = recommendReq.GetResultJson();
					}
				}
			}
			yield break;
		}

		// Token: 0x0600AB10 RID: 43792 RVA: 0x0024A320 File Offset: 0x00248720
		public IEnumerator SendHttpReqServerUnit(string serverpath)
		{
			this.units = null;
			string param = string.Format("zone_nodes?path={0}", serverpath);
			WaitHttpRequest req = new WaitHttpRequest(param);
			yield return req;
			if (req.GetResult() == BaseWaitHttpRequest.eState.Success)
			{
				this.units = req.GetResultJson();
			}
			yield break;
		}

		// Token: 0x04005FE1 RID: 24545
		public bool needflushFlag;
	}
}
