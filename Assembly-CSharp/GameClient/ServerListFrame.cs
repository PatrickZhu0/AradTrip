using System;
using System.Collections;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001173 RID: 4467
	public sealed class ServerListFrame : ClientFrame
	{
		// Token: 0x0600AAE1 RID: 43745 RVA: 0x00248847 File Offset: 0x00246C47
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Login/ServerList/ServerList";
		}

		// Token: 0x0600AAE2 RID: 43746 RVA: 0x00248850 File Offset: 0x00246C50
		protected override void _bindExUI()
		{
			this.mClose = this.mBind.GetCom<Button>("close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
			this.mTabroot = this.mBind.GetGameObject("tabroot");
			this.mServerroot = this.mBind.GetGameObject("serverroot");
			this.mCharactorroot = this.mBind.GetGameObject("charactorroot");
			this.mTabtogglegroup = this.mBind.GetCom<ToggleGroup>("tabtogglegroup");
			this.mServertogglegroup = this.mBind.GetCom<ToggleGroup>("servertogglegroup");
			this.mCharactortogglegroup = this.mBind.GetCom<ToggleGroup>("charactortogglegroup");
			this.mAllcharator = this.mBind.GetCom<Toggle>("allcharator");
			this.mAllcharator.onValueChanged.AddListener(new UnityAction<bool>(this._onAllcharatorToggleValueChange));
			this.mWaittips = this.mBind.GetGameObject("waittips");
			this.mTips = this.mBind.GetGameObject("Tips");
		}

		// Token: 0x0600AAE3 RID: 43747 RVA: 0x00248974 File Offset: 0x00246D74
		protected override void _unbindExUI()
		{
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
			this.mTabroot = null;
			this.mServerroot = null;
			this.mCharactorroot = null;
			this.mTabtogglegroup = null;
			this.mServertogglegroup = null;
			this.mCharactortogglegroup = null;
			this.mAllcharator.onValueChanged.RemoveListener(new UnityAction<bool>(this._onAllcharatorToggleValueChange));
			this.mAllcharator = null;
			this.mWaittips = null;
			this.mTips = null;
		}

		// Token: 0x0600AAE4 RID: 43748 RVA: 0x002489FF File Offset: 0x00246DFF
		private void _onCloseButtonClick()
		{
			Singleton<ClientSystemManager>.instance.CloseFrame<ServerListFrame>(this, false);
		}

		// Token: 0x0600AAE5 RID: 43749 RVA: 0x00248A0D File Offset: 0x00246E0D
		private void _onAllcharatorToggleValueChange(bool changed)
		{
			this.mTips.CustomActive(changed);
			if (changed)
			{
				this.mServerroot.CustomActive(false);
				this.mCharactorroot.CustomActive(true);
				this._loadCharactorUnit();
			}
		}

		// Token: 0x0600AAE6 RID: 43750 RVA: 0x00248A3F File Offset: 0x00246E3F
		protected override void _OnOpenFrame()
		{
			this.mAllcharator.group = this.mTabtogglegroup;
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._waitForLoadTabs());
		}

		// Token: 0x0600AAE7 RID: 43751 RVA: 0x00248A63 File Offset: 0x00246E63
		protected override void _OnCloseFrame()
		{
			this.mBind.ClearAllCacheBinds();
			Singleton<ServerListManager>.instance.needflushFlag = false;
		}

		// Token: 0x0600AAE8 RID: 43752 RVA: 0x00248A7C File Offset: 0x00246E7C
		private void _loadTabs()
		{
			if (null == this.mBind)
			{
				return;
			}
			string prefabPath = this.mBind.GetPrefabPath("tabunit");
			this.mBind.ClearCacheBinds(prefabPath);
			ArrayList tabs = Singleton<ServerListManager>.instance.tabs;
			if (tabs != null)
			{
				for (int i = 0; i < tabs.Count; i++)
				{
					Hashtable hashtable = tabs[i] as Hashtable;
					if (hashtable != null)
					{
						ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
						if (null != comCommonBind)
						{
							Utility.AttachTo(comCommonBind.gameObject, this.mTabroot, false);
							Image com = comCommonBind.GetCom<Image>("flag");
							Text com2 = comCommonBind.GetCom<Text>("name");
							Toggle com3 = comCommonBind.GetCom<Toggle>("tab");
							com3.group = this.mTabtogglegroup;
							com2.text = hashtable["name"].ToString();
							int num = int.Parse(hashtable["is_new"].ToString());
							this.mBind.GetSprite("newflag", ref com);
							com.gameObject.SetActive(false);
							string serverpath = hashtable["path"].ToString();
							com3.onValueChanged.AddListener(delegate(bool isOn)
							{
								if (isOn)
								{
									this.mServerroot.CustomActive(true);
									this.mCharactorroot.CustomActive(false);
									MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._waitForLoadUnits(serverpath));
								}
							});
							ArrayList arrayList = hashtable["ids"] as ArrayList;
							if (arrayList != null)
							{
								uint id = ClientApplication.adminServer.id;
								for (int j = 0; j < arrayList.Count; j++)
								{
									uint num2 = uint.Parse(arrayList[j].ToString());
									if (id == num2)
									{
										com3.isOn = true;
										break;
									}
								}
							}
							else if (i == 0)
							{
								com3.isOn = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AAE9 RID: 43753 RVA: 0x00248C70 File Offset: 0x00247070
		private void _loadUnits()
		{
			if (null == this.mBind)
			{
				return;
			}
			string prefabPath = this.mBind.GetPrefabPath("serverunit");
			this.mBind.ClearCacheBinds(prefabPath);
			ArrayList units = Singleton<ServerListManager>.instance.units;
			if (units != null)
			{
				for (int i = 0; i < units.Count; i++)
				{
					Hashtable hashtable = units[i] as Hashtable;
					if (hashtable != null)
					{
						ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
						if (null != comCommonBind)
						{
							Utility.AttachTo(comCommonBind.gameObject, this.mServerroot, false);
							Image com = comCommonBind.GetCom<Image>("status");
							Text com2 = comCommonBind.GetCom<Text>("name");
							Toggle com3 = comCommonBind.GetCom<Toggle>("serverunit");
							Image com4 = comCommonBind.GetCom<Image>("typeflag");
							com3.group = this.mServertogglegroup;
							com2.text = hashtable["name"].ToString();
							string ip = hashtable["ip"].ToString();
							ushort port = ushort.Parse(hashtable["port"].ToString());
							uint id = uint.Parse(hashtable["id"].ToString());
							int cstatus = int.Parse(hashtable["status"].ToString());
							string cname = hashtable["name"].ToString();
							if (Singleton<ServerListManager>.instance.IsShowHasCharactorFlag((int)id))
							{
								Hashtable hashtable2 = Singleton<ServerListManager>.instance.ShowHasCharatorFlag(id);
								if (hashtable2 != null)
								{
									ArrayList arrayList = hashtable2["ch"] as ArrayList;
									if (arrayList == null)
									{
										Logger.LogErrorFormat("chs id null", new object[0]);
										return;
									}
									Image[] array = new Image[3];
									Text[] array2 = new Text[3];
									for (int j = 0; j < 3; j++)
									{
										array[j] = comCommonBind.GetCom<Image>(string.Format("head{0}", j));
										array[j].gameObject.SetActive(false);
										array2[j] = comCommonBind.GetCom<Text>(string.Format("text{0}", j));
									}
									int num = int.Parse(hashtable2["id"].ToString());
									int num2 = 0;
									while (num2 < arrayList.Count && num2 < 3)
									{
										Hashtable hashtable3 = arrayList[num2] as Hashtable;
										int id2 = int.Parse(hashtable3["t"].ToString());
										int num3 = int.Parse(hashtable3["l"].ToString());
										if (hashtable3 != null)
										{
											JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(id2, string.Empty, string.Empty);
											if (tableItem != null)
											{
												ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
												if (tableItem2 != null)
												{
													array2[num2].text = string.Format("{0}级", num3);
													array[num2].gameObject.SetActive(true);
													array[num2].transform.parent.parent.gameObject.SetActive(true);
													ETCImageLoader.LoadSprite(ref array[num2], tableItem2.IconPath, true);
												}
											}
										}
										num2++;
									}
								}
							}
							if (hashtable.ContainsKey("is_recommend"))
							{
								bool flag = 0 != int.Parse(hashtable["is_recommend"].ToString());
							}
							bool active = false;
							if (hashtable.ContainsKey("is_new"))
							{
								active = (0 != int.Parse(hashtable["is_new"].ToString()));
							}
							com4.gameObject.SetActive(active);
							if (id == ClientApplication.adminServer.id)
							{
								bool isChanged = ClientApplication.adminServer.id != id;
								ClientApplication.adminServer.ip = ip;
								ClientApplication.adminServer.port = port;
								ClientApplication.adminServer.id = id;
								ClientApplication.adminServer.state = (eAdminServerStatus)cstatus;
								ClientApplication.adminServer.name = cname;
								this._sendUIEvent(isChanged);
								com3.isOn = true;
							}
							com3.onValueChanged.AddListener(delegate(bool isOn)
							{
								if (isOn)
								{
									bool isChanged2 = ClientApplication.adminServer.id != id;
									ClientApplication.adminServer.ip = ip;
									ClientApplication.adminServer.port = port;
									ClientApplication.adminServer.id = id;
									ClientApplication.adminServer.state = (eAdminServerStatus)cstatus;
									ClientApplication.adminServer.name = cname;
									this._sendUIEvent(isChanged2);
									this._onCloseButtonClick();
								}
							});
							this._setServerStatus(com, (eAdminServerStatus)cstatus);
						}
					}
				}
			}
		}

		// Token: 0x0600AAEA RID: 43754 RVA: 0x00249120 File Offset: 0x00247520
		private void _loadCharactorUnit()
		{
			string prefabPath = this.mBind.GetPrefabPath("charactorunit");
			this.mBind.ClearCacheBinds(prefabPath);
			ArrayList savedata = Singleton<ServerListManager>.instance.savedata;
			if (savedata != null)
			{
				for (int i = 0; i < savedata.Count; i++)
				{
					Hashtable hashtable = savedata[i] as Hashtable;
					if (hashtable != null)
					{
						ArrayList arrayList = hashtable["ch"] as ArrayList;
						int id3 = int.Parse(hashtable["id"].ToString());
						Hashtable serverHashtableByID = Singleton<ServerListManager>.instance.GetServerHashtableByID(id3);
						if (serverHashtableByID != null)
						{
							if (arrayList != null && arrayList.Count > 0)
							{
								ComCommonBind comCommonBind = this.mBind.LoadExtraBind(prefabPath);
								if (null != comCommonBind)
								{
									Utility.AttachTo(comCommonBind.gameObject, this.mCharactorroot, false);
									Image[] array = new Image[3];
									Text[] array2 = new Text[3];
									for (int j = 0; j < 3; j++)
									{
										array[j] = comCommonBind.GetCom<Image>(string.Format("head{0}", j));
										array[j].gameObject.SetActive(false);
										array2[j] = comCommonBind.GetCom<Text>(string.Format("text{0}", j));
									}
									Image com = comCommonBind.GetCom<Image>("status");
									Text com2 = comCommonBind.GetCom<Text>("name");
									Toggle com3 = comCommonBind.GetCom<Toggle>("charactor");
									int num = 0;
									while (num < arrayList.Count && num < 3)
									{
										Hashtable hashtable2 = arrayList[num] as Hashtable;
										if (hashtable2 != null)
										{
											int id2 = int.Parse(hashtable2["t"].ToString());
											int num2 = int.Parse(hashtable2["l"].ToString());
											JobTable tableItem = Singleton<TableManager>.instance.GetTableItem<JobTable>(id2, string.Empty, string.Empty);
											if (tableItem != null)
											{
												ResTable tableItem2 = Singleton<TableManager>.instance.GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
												if (tableItem2 != null)
												{
													array2[num].text = string.Format("{0}级", num2);
													array[num].transform.parent.parent.gameObject.SetActive(true);
													array[num].gameObject.SetActive(true);
													ETCImageLoader.LoadSprite(ref array[num], tableItem2.IconPath, true);
												}
											}
										}
										num++;
									}
									com3.group = this.mCharactortogglegroup;
									if (serverHashtableByID != null)
									{
										string ip = serverHashtableByID["ip"].ToString();
										ushort port = ushort.Parse(serverHashtableByID["port"].ToString());
										uint id = uint.Parse(serverHashtableByID["id"].ToString());
										int cstatus = int.Parse(serverHashtableByID["status"].ToString());
										string cname = serverHashtableByID["name"].ToString();
										com2.text = cname;
										com3.onValueChanged.AddListener(delegate(bool isOn)
										{
											bool isChanged = ClientApplication.adminServer.id != id;
											ClientApplication.adminServer.ip = ip;
											ClientApplication.adminServer.port = port;
											ClientApplication.adminServer.id = id;
											ClientApplication.adminServer.state = (eAdminServerStatus)cstatus;
											ClientApplication.adminServer.name = cname;
											this._sendUIEvent(isChanged);
											this._onCloseButtonClick();
										});
										this._setServerStatus(com, (eAdminServerStatus)cstatus);
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600AAEB RID: 43755 RVA: 0x00249493 File Offset: 0x00247893
		private void _sendUIEvent(bool isChanged)
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ServerListSelectChanged, isChanged, null, null, null);
		}

		// Token: 0x0600AAEC RID: 43756 RVA: 0x002494B0 File Offset: 0x002478B0
		private void _setServerStatus(Image img, eAdminServerStatus status)
		{
			if (img == null)
			{
				return;
			}
			switch (status)
			{
			case eAdminServerStatus.Offline:
				this.mBind.GetSprite("statusoffline", ref img);
				img.gameObject.AddComponent<UIGray>();
				break;
			case eAdminServerStatus.Ready:
				this.mBind.GetSprite("statusready", ref img);
				break;
			case eAdminServerStatus.Buzy:
				this.mBind.GetSprite("statusbuzy", ref img);
				break;
			case eAdminServerStatus.Full:
				this.mBind.GetSprite("statusfull", ref img);
				break;
			}
		}

		// Token: 0x0600AAED RID: 43757 RVA: 0x00249550 File Offset: 0x00247950
		private IEnumerator _waitForLoadTabs()
		{
			this.mWaittips.CustomActive(true);
			if (!Singleton<ServerListManager>.instance.IsTabsReady() || Singleton<ServerListManager>.instance.needflushFlag)
			{
				yield return Singleton<ServerListManager>.instance.SendHttpReqTab();
			}
			this.mWaittips.CustomActive(false);
			this._loadTabs();
			yield return Yielders.EndOfFrame;
			this._loadUnits();
			yield break;
		}

		// Token: 0x0600AAEE RID: 43758 RVA: 0x0024956C File Offset: 0x0024796C
		private IEnumerator _waitForLoadUnits(string serverpath)
		{
			this.mWaittips.CustomActive(true);
			yield return Singleton<ServerListManager>.instance.SendHttpReqServerUnit(serverpath);
			if (!Singleton<ServerListManager>.instance.IsTabsReady() || Singleton<ServerListManager>.instance.needflushFlag)
			{
				yield return Yielders.EndOfFrame;
			}
			this.mWaittips.CustomActive(false);
			this._loadUnits();
			yield break;
		}

		// Token: 0x04005FCD RID: 24525
		private Button mClose;

		// Token: 0x04005FCE RID: 24526
		private GameObject mTabroot;

		// Token: 0x04005FCF RID: 24527
		private GameObject mServerroot;

		// Token: 0x04005FD0 RID: 24528
		private GameObject mCharactorroot;

		// Token: 0x04005FD1 RID: 24529
		private ToggleGroup mTabtogglegroup;

		// Token: 0x04005FD2 RID: 24530
		private ToggleGroup mServertogglegroup;

		// Token: 0x04005FD3 RID: 24531
		private ToggleGroup mCharactortogglegroup;

		// Token: 0x04005FD4 RID: 24532
		private Toggle mAllcharator;

		// Token: 0x04005FD5 RID: 24533
		private GameObject mWaittips;

		// Token: 0x04005FD6 RID: 24534
		private GameObject mTips;

		// Token: 0x04005FD7 RID: 24535
		private ServerListFrame.eState mState;

		// Token: 0x02001174 RID: 4468
		public enum eState
		{
			// Token: 0x04005FD9 RID: 24537
			None,
			// Token: 0x04005FDA RID: 24538
			Loading
		}
	}
}
