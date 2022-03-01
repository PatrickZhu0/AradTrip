using System;
using System.Collections.Generic;
using DG.Tweening;
using GamePool;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001165 RID: 4453
	public class CreateActorFrame : ClientFrame
	{
		// Token: 0x0600AA08 RID: 43528 RVA: 0x00243554 File Offset: 0x00241954
		protected override void _bindExUI()
		{
			this.mCtrlMovie = this.mBind.GetCom<MediaPlayerCtrl>("MovieCtrl");
			this.mImgMovie = this.mBind.GetCom<RawImage>("imgMovie");
			this.mTxtMoive = this.mBind.GetCom<Text>("txtMoive");
			this.mJobImageRoot = this.mBind.GetGameObject("jobImageRoot");
			this.mTxtJobSimpleDesc = this.mBind.GetCom<Text>("txtJobSimpleDesc");
			this.mImgJobName = this.mBind.GetCom<Image>("imgJobName");
			this.mObjRender = this.mBind.GetCom<GeObjectRenderer>("objRender");
			this.mSpineRoot = this.mBind.GetGameObject("spineRoot");
			this.mAppointmentActivity = this.mBind.GetGameObject("AppointmentActivity");
			this.mRecommendProPerty = this.mBind.GetCom<Text>("RecommendProPerty");
			this.mJobTips = this.mBind.GetCom<Text>("JobTips");
			Vector3 localScale = this.mImgMovie.transform.localScale;
			localScale.y = -1f;
			this.mImgMovie.transform.localScale = localScale;
			this.mImgMovie.CustomActive(false);
			if (this.mCtrlMovie != null && this.mImgMovie != null)
			{
				MediaPlayerCtrl mediaPlayerCtrl = this.mCtrlMovie;
				mediaPlayerCtrl.OnReady = (MediaPlayerCtrl.VideoReady)Delegate.Combine(mediaPlayerCtrl.OnReady, new MediaPlayerCtrl.VideoReady(delegate()
				{
					if (this.mTxtMoive != null)
					{
						this.mTxtMoive.CustomActive(false);
					}
					this.mImgMovie.CustomActive(true);
					if (this.mImgMovie != null)
					{
						this.mImgMovie.color = Color.black;
					}
					DOTween.To(delegate()
					{
						if (this.mImgMovie != null)
						{
							return this.mImgMovie.color;
						}
						return Color.white;
					}, delegate(Color value)
					{
						if (this.mImgMovie != null)
						{
							this.mImgMovie.color = value;
						}
					}, Color.white, 1f);
					if (this.mCtrlMovie != null)
					{
						this.mCtrlMovie.SetVolume(0f);
					}
					DOTween.To(delegate()
					{
						if (this.mCtrlMovie != null)
						{
							return this.mCtrlMovie.GetVolume();
						}
						return 1f;
					}, delegate(float value)
					{
						if (this.mCtrlMovie != null)
						{
							this.mCtrlMovie.SetVolume(value);
						}
					}, 1f, 1f);
					if (this.mCtrlMovie != null)
					{
						this.mCtrlMovie.Play();
					}
				}));
				MediaPlayerCtrl mediaPlayerCtrl2 = this.mCtrlMovie;
				mediaPlayerCtrl2.OnVideoError = (MediaPlayerCtrl.VideoError)Delegate.Combine(mediaPlayerCtrl2.OnVideoError, new MediaPlayerCtrl.VideoError(delegate(MediaPlayerCtrl.MEDIAPLAYER_ERROR errorCode, MediaPlayerCtrl.MEDIAPLAYER_ERROR errorCodeExtra)
				{
					if (this.mTxtMoive != null)
					{
						this.mTxtMoive.CustomActive(true);
					}
					if (this.mImgMovie != null)
					{
						this.mImgMovie.CustomActive(false);
					}
					Logger.LogErrorFormat("play moive code:{0}, extra:{1}", new object[]
					{
						errorCode,
						errorCodeExtra
					});
				}));
				MediaPlayerCtrl mediaPlayerCtrl3 = this.mCtrlMovie;
				mediaPlayerCtrl3.OnVideoFirstFrameReady = (MediaPlayerCtrl.VideoFirstFrameReady)Delegate.Combine(mediaPlayerCtrl3.OnVideoFirstFrameReady, new MediaPlayerCtrl.VideoFirstFrameReady(delegate()
				{
				}));
			}
		}

		// Token: 0x0600AA09 RID: 43529 RVA: 0x00243738 File Offset: 0x00241B38
		protected override void _unbindExUI()
		{
			this.mCtrlMovie = null;
			this.mImgMovie = null;
			this.mTxtMoive = null;
			this.mJobImageRoot = null;
			this.mTxtJobSimpleDesc = null;
			this.mImgJobName = null;
			this.mObjRender = null;
			this.mSpineRoot = null;
			this.mAppointmentActivity = null;
			this.mRecommendProPerty = null;
			this.mJobTips = null;
		}

		// Token: 0x0600AA0A RID: 43530 RVA: 0x00243792 File Offset: 0x00241B92
		private void SetJobName(Image img, string path)
		{
			if (img != null)
			{
				ETCImageLoader.LoadSprite(ref img, path, true);
			}
		}

		// Token: 0x0600AA0B RID: 43531 RVA: 0x002437AA File Offset: 0x00241BAA
		private void _InitBaseJobItem()
		{
			this.goBaseJobItemParent = Utility.FindChild(this.frame, "BaseJobScrollView/ViewPort/Content");
			this.goBaseJobItemPrefab = Utility.FindChild(this.frame, "BaseJobScrollView/ViewPort/Content/Toggle");
			this.goBaseJobItemPrefab.CustomActive(false);
		}

		// Token: 0x0600AA0C RID: 43532 RVA: 0x002437E4 File Offset: 0x00241BE4
		private void _OnBaseJobSelected(JobTable jobItem)
		{
			if (jobItem != null)
			{
				if (jobItem.Open == 1)
				{
					this.currentBaseJobID = jobItem.ID;
					this.SetJobName(this.mImgJobName, jobItem.Job_xuanjue_zhiye);
					this.mTxtJobSimpleDesc.text = jobItem.JobSimpleDes;
					this._CreateChangeJobItems();
					this.UpdateSexToggles(jobItem);
					if (jobItem.sex >= JobTable.esex.Male && jobItem.sex < (JobTable.esex)this.SexToggles.Length)
					{
						this.SexToggles[(int)jobItem.sex].isOn = true;
					}
				}
				if (ClientApplication.playerinfo.GetRoleHasApponintmentOccu(jobItem.ID))
				{
					this.appointmenRoleID = jobItem.ID;
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<BookingActivitiesFrame>(FrameLayer.Middle, jobItem.AppointmentRoleID, string.Empty);
				}
			}
		}

		// Token: 0x0600AA0D RID: 43533 RVA: 0x002438B4 File Offset: 0x00241CB4
		private void _CreateBaseJobItems()
		{
			this.m_kBaseJobItems.RecycleAllObject();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			List<JobTable> list = new List<JobTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					JobTable jobTable = keyValuePair.Value as JobTable;
					if (jobTable != null && jobTable.CanCreateRole == 1 && ((Global.Settings.isBanShuVersion && jobTable.ID != 20) || !Global.Settings.isBanShuVersion) && (jobTable.sex == JobTable.esex.Male || (jobTable.sex == JobTable.esex.Female && jobTable.OppositeSexJob == 0)))
					{
						list.Add(jobTable);
					}
				}
			}
			if (list.Count > 1)
			{
				list.Sort((JobTable x, JobTable y) => x.BaseJobSort.CompareTo(y.BaseJobSort));
			}
			for (int i = 0; i < list.Count; i++)
			{
				JobTable jobTable2 = list[i];
				BaseJobItem baseJobItem = this.m_kBaseJobItems.Create(new object[]
				{
					this.goBaseJobItemParent,
					this.goBaseJobItemPrefab,
					jobTable2,
					Delegate.CreateDelegate(typeof(CachedSelectedObject<JobTable, BaseJobItem>.OnSelectedDelegate), this, "_OnBaseJobSelected")
				});
				if (baseJobItem != null && CachedSelectedObject<JobTable, BaseJobItem>.Selected == null)
				{
					baseJobItem.OnSelected();
				}
			}
		}

		// Token: 0x0600AA0E RID: 43534 RVA: 0x00243A25 File Offset: 0x00241E25
		private void _DestroyBaseJobItems()
		{
			CachedSelectedObject<JobTable, BaseJobItem>.Clear();
			this.m_kBaseJobItems.DestroyAllObjects();
			this.goBaseJobItemPrefab = null;
			this.goBaseJobItemParent = null;
		}

		// Token: 0x0600AA0F RID: 43535 RVA: 0x00243A45 File Offset: 0x00241E45
		private void _InitChangeJobItem()
		{
			this.goChangeJobItemParent = Utility.FindChild(this.frame, "ChangeJobSelected");
			this.goChangeJobItemPrefab = Utility.FindChild(this.frame, "ChangeJobSelected/Toggle");
			this.goChangeJobItemPrefab.CustomActive(false);
		}

		// Token: 0x0600AA10 RID: 43536 RVA: 0x00243A80 File Offset: 0x00241E80
		private void _OnChangeJobSelected(JobTable jobItem)
		{
			if (jobItem != null)
			{
				if (jobItem.Open > 0)
				{
					if (jobItem.ID == this.currentMovieJobID)
					{
						return;
					}
					this.currentMovieJobID = jobItem.ID;
					DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID = this.currentMovieJobID;
					this._PlayMovie(jobItem.Video);
					JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.currentMovieJobID, string.Empty, string.Empty);
					if (tableItem != null)
					{
						this.mJobTips.text = string.Format(TR.Value("PreChangeJob"), tableItem.Name);
					}
					this.ShowJobImage(tableItem);
					this.ShowmRecommendProPerty(tableItem);
				}
				else
				{
					SystemNotifyManager.SystemNotify(2600003, string.Empty);
				}
			}
		}

		// Token: 0x0600AA11 RID: 43537 RVA: 0x00243B3C File Offset: 0x00241F3C
		private void _CreateChangeJobItems()
		{
			CachedSelectedObject<JobTable, ChangeJobItem>.Clear();
			this.m_kChangeJobItems.RecycleAllObject();
			if (CachedSelectedObject<JobTable, BaseJobItem>.Selected == null)
			{
				return;
			}
			List<JobTable> list = ListPool<JobTable>.Get();
			list.Clear();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<JobTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					JobTable jobTable = keyValuePair.Value as JobTable;
					if (jobTable != null && jobTable.CanCreateRole != 1 && jobTable.prejob == this.currentBaseJobID)
					{
						if (jobTable.Open > 0)
						{
							list.Insert(0, jobTable);
						}
						else
						{
							list.Add(jobTable);
						}
					}
				}
			}
			for (int i = 0; i < list.Count; i++)
			{
				if (list[i].Open > 0)
				{
					for (int j = i + 1; j < list.Count; j++)
					{
						if (list[j].Open > 0 && list[i].JobSort > list[j].JobSort)
						{
							JobTable value = list[i];
							list[i] = list[j];
							list[j] = value;
						}
					}
				}
			}
			for (int k = 0; k < list.Count; k++)
			{
				JobTable jobTable2 = list[k];
				ChangeJobItem changeJobItem = this.m_kChangeJobItems.Create(new object[]
				{
					this.goChangeJobItemParent,
					this.goChangeJobItemPrefab,
					jobTable2,
					Delegate.CreateDelegate(typeof(CachedSelectedObject<JobTable, ChangeJobItem>.OnSelectedDelegate), this, "_OnChangeJobSelected")
				});
				if (changeJobItem != null && CachedSelectedObject<JobTable, ChangeJobItem>.Selected == null)
				{
					changeJobItem.OnSelected();
				}
			}
			list.Clear();
			ListPool<JobTable>.Release(list);
		}

		// Token: 0x0600AA12 RID: 43538 RVA: 0x00243D24 File Offset: 0x00242124
		private void UpdateSexToggles(JobTable basejobItem)
		{
			for (int i = 0; i < this.SexToggles.Length; i++)
			{
				if (i == (int)basejobItem.sex)
				{
					this.SexTogglesGray[i].enabled = false;
					this.SexTogglesGray[i].SetEnable(false);
					this.SexImgsGray[i].gameObject.CustomActive(false);
				}
				else
				{
					this.SexTogglesGray[i].enabled = (basejobItem.OppositeSexJob == 0);
					this.SexTogglesGray[i].SetEnable(basejobItem.OppositeSexJob == 0);
					this.SexImgsGray[i].gameObject.CustomActive(basejobItem.OppositeSexJob == 0);
				}
			}
		}

		// Token: 0x0600AA13 RID: 43539 RVA: 0x00243DD1 File Offset: 0x002421D1
		private void _DestroyChangeJobItems()
		{
			CachedSelectedObject<JobTable, ChangeJobItem>.Clear();
			this.m_kChangeJobItems.DestroyAllObjects();
			this.goChangeJobItemPrefab = null;
			this.goChangeJobItemParent = null;
		}

		// Token: 0x0600AA14 RID: 43540 RVA: 0x00243DF1 File Offset: 0x002421F1
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/SelectRole/CreateRoleFrameNew";
		}

		// Token: 0x0600AA15 RID: 43541 RVA: 0x00243DF8 File Offset: 0x002421F8
		protected override void _OnOpenFrame()
		{
			this.currentBaseJobID = 0;
			this.currentMovieJobID = 0;
			this.currentShowPortraitID = 0;
			if (ClientApplication.playerinfo.apponintmentOccus.Length > 0)
			{
				this.appointmenRoleID = (int)ClientApplication.playerinfo.apponintmentOccus[0];
			}
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(350, string.Empty, string.Empty);
			this.appointment_Max_Role = tableItem.Value;
			this.mAppointmentActivity.CustomActive(ClientApplication.playerinfo.GetHasApponintmentActiviti());
			this._InitChangeJobItem();
			this._InitBaseJobItem();
			this._CreateBaseJobItems();
		}

		// Token: 0x0600AA16 RID: 43542 RVA: 0x00243E8B File Offset: 0x0024228B
		public void OnDragDemoRole(float delta)
		{
		}

		// Token: 0x0600AA17 RID: 43543 RVA: 0x00243E8D File Offset: 0x0024228D
		protected override void _OnCloseFrame()
		{
			this._DestroyChangeJobItems();
			this._DestroyBaseJobItems();
			this._StopMovie();
		}

		// Token: 0x0600AA18 RID: 43544 RVA: 0x00243EA4 File Offset: 0x002422A4
		private int _GetLength(string content)
		{
			int num = 0;
			for (int i = 0; i < content.Length; i++)
			{
				if (content[i] >= '一' && content[i] <= '龥')
				{
					num += 2;
				}
				else
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0600AA19 RID: 43545 RVA: 0x00243EFC File Offset: 0x002422FC
		[UIEventHandle("sex/sex{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 2)]
		private void OnSexSelect(int iIndex, bool value)
		{
			if (iIndex < 0 || !value)
			{
				return;
			}
			if (this.SexTogglesGray[iIndex].enabled)
			{
				this.SexImgs[iIndex].gameObject.CustomActive(false);
				SystemNotifyManager.SystemNotify(2600003, string.Empty);
				return;
			}
			this.SexImgs[iIndex].gameObject.CustomActive(true);
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.currentBaseJobID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (iIndex == (int)tableItem.sex)
			{
				return;
			}
			JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(tableItem.OppositeSexJob, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			this._OnBaseJobSelected(tableItem2);
		}

		// Token: 0x0600AA1A RID: 43546 RVA: 0x00243FB8 File Offset: 0x002423B8
		[UIEventHandle("BtnCreate")]
		private void OnClickCreate()
		{
			if (CachedSelectedObject<JobTable, BaseJobItem>.Selected == null)
			{
				return;
			}
			if (CachedSelectedObject<JobTable, BaseJobItem>.Selected.Value == null)
			{
				return;
			}
			if (string.IsNullOrEmpty(this.input.text))
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("need_role_name"), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			int num = this._GetLength(this.input.text);
			if (this.input.text.Length > 7)
			{
				SystemNotifyManager.SystemNotify(8504, string.Empty);
				return;
			}
			if ((ulong)ClientApplication.playerinfo.appointmentRoleNum >= (ulong)((long)this.appointment_Max_Role) && ClientApplication.playerinfo.GetRoleHasApponintmentOccu(this.currentBaseJobID))
			{
				string msgContent = TR.Value("appointmentRoleFullDes");
				SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
				{
					this.CreateRoleReq();
				}, null, 0f, false);
				return;
			}
			this.CreateRoleReq();
		}

		// Token: 0x0600AA1B RID: 43547 RVA: 0x00244098 File Offset: 0x00242498
		private void CreateRoleReq()
		{
			GateCreateRoleReq gateCreateRoleReq = new GateCreateRoleReq();
			gateCreateRoleReq.name = this.input.text;
			gateCreateRoleReq.occupation = (byte)this.currentMovieJobID;
			NetManager netManager = NetManager.Instance();
			netManager.SendCommand<GateCreateRoleReq>(ServerType.GATE_SERVER, gateCreateRoleReq);
			ClientSystemLogin clientSystemLogin = Singleton<ClientSystemManager>.instance.CurrentSystem as ClientSystemLogin;
			if (clientSystemLogin != null)
			{
				clientSystemLogin.MarkNewActor(gateCreateRoleReq.name);
			}
		}

		// Token: 0x0600AA1C RID: 43548 RVA: 0x002440FC File Offset: 0x002424FC
		[UIEventHandle("BookingActivities")]
		private void OnClickBookingActivities()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.appointmenRoleID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<BookingActivitiesFrame>(FrameLayer.Middle, tableItem.AppointmentRoleID, string.Empty);
		}

		// Token: 0x0600AA1D RID: 43549 RVA: 0x00244147 File Offset: 0x00242547
		[UIEventHandle("BtnBack")]
		private void OnClickBack()
		{
			this.frameMgr.CloseFrame<CreateActorFrame>(this, false);
			if (!ClientApplication.HasRoles())
			{
				ClientApplication.DisconnectGateServerAtLogin();
			}
		}

		// Token: 0x0600AA1E RID: 43550 RVA: 0x00244168 File Offset: 0x00242568
		[MessageHandle(300303U, false, 0)]
		private void OnGateCreateRoleRet(MsgDATA msg)
		{
			GateCreateRoleRet gateCreateRoleRet = new GateCreateRoleRet();
			gateCreateRoleRet.decode(msg.bytes);
			if (gateCreateRoleRet.result != 0U)
			{
				SystemNotifyManager.SystemNotify((int)gateCreateRoleRet.result, string.Empty);
			}
			else
			{
				DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID = this.currentMovieJobID;
			}
		}

		// Token: 0x0600AA1F RID: 43551 RVA: 0x002441B8 File Offset: 0x002425B8
		public void OnClickChangeJobView()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.iSelectedID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				ChangeJobSelectFrame.Create(tableItem.ID, false);
			}
		}

		// Token: 0x0600AA20 RID: 43552 RVA: 0x002441F4 File Offset: 0x002425F4
		[UIEventHandle("BtnRandomName")]
		private void OnClickRandomName()
		{
			if (this.akNameFirst.Count == 0 && this.akNameSecond.Count == 0 && this.akNameMiddle.Count == 0)
			{
				Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<NameTable>();
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					NameTable nameTable = keyValuePair.Value as NameTable;
					if (nameTable.NameType == 0)
					{
						List<NameTable> list = this.akNameFirst;
						Dictionary<int, object>.Enumerator enumerator;
						KeyValuePair<int, object> keyValuePair2 = enumerator.Current;
						list.Add(keyValuePair2.Value as NameTable);
					}
					else if (nameTable.NameType == 1)
					{
						List<NameTable> list2 = this.akNameSecond;
						Dictionary<int, object>.Enumerator enumerator;
						KeyValuePair<int, object> keyValuePair3 = enumerator.Current;
						list2.Add(keyValuePair3.Value as NameTable);
					}
					else
					{
						List<NameTable> list3 = this.akNameMiddle;
						Dictionary<int, object>.Enumerator enumerator;
						KeyValuePair<int, object> keyValuePair4 = enumerator.Current;
						list3.Add(keyValuePair4.Value as NameTable);
					}
				}
			}
			if (this.akNameFirst.Count > 0 && this.akNameSecond.Count > 0 && this.akNameMiddle.Count > 0)
			{
				int num = Random.Range(0, this.akNameFirst.Count);
				int num2 = Random.Range(0, this.akNameSecond.Count);
				int num3 = Random.Range(0, this.akNameMiddle.Count);
				if (num >= this.akNameFirst.Count || num2 >= this.akNameSecond.Count || num3 >= this.akNameMiddle.Count)
				{
					Logger.LogErrorFormat("iRandomFist is {0},iRandomMiddle is {1},iRandomSecond is {2}", new object[]
					{
						num,
						num3,
						num2
					});
				}
				string text = this.akNameFirst[num].NameText + this.akNameMiddle[num3].NameText + this.akNameSecond[num2].NameText;
				this.input.text = text;
			}
			else
			{
				Logger.LogErrorFormat("OnClickRandomName akNameFirst.Count = {0},akNameMiddle = {1},akNameSecond.Count = {2}", new object[]
				{
					this.akNameFirst.Count,
					this.akNameMiddle.Count,
					this.akNameSecond.Count
				});
			}
		}

		// Token: 0x0600AA21 RID: 43553 RVA: 0x00244454 File Offset: 0x00242854
		private void _PlayMovie(string path)
		{
			if (this.mCtrlMovie != null)
			{
				this._StopMovie();
				this.mCtrlMovie.Load(path);
				if (this.mTxtMoive != null)
				{
					this.mTxtMoive.CustomActive(false);
				}
			}
		}

		// Token: 0x0600AA22 RID: 43554 RVA: 0x002444A1 File Offset: 0x002428A1
		private void _StopMovie()
		{
			if (this.mCtrlMovie != null && this.mCtrlMovie.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mCtrlMovie.Stop();
				this.mCtrlMovie.UnLoad();
			}
		}

		// Token: 0x0600AA23 RID: 43555 RVA: 0x002444DC File Offset: 0x002428DC
		private string _GetDifficult(int iDiff)
		{
			string result = string.Empty;
			if (iDiff >= 0 && iDiff < 2)
			{
				result = "简单";
			}
			else if (iDiff < 4)
			{
				result = "普通";
			}
			else
			{
				result = "困难";
			}
			return result;
		}

		// Token: 0x0600AA24 RID: 43556 RVA: 0x00244524 File Offset: 0x00242924
		private void ShowModule(int jobID, string path)
		{
			if (this.mObjRender != null)
			{
				this.mObjRender.gameObject.CustomActive(true);
				this.mObjRender.ClearObject();
				try
				{
					this.mObjRender.LoadObject(path, 20, null);
				}
				catch (Exception ex)
				{
					Logger.LogErrorFormat("create spineModule failed: {0}", new object[]
					{
						ex.ToString()
					});
				}
			}
		}

		// Token: 0x0600AA25 RID: 43557 RVA: 0x002445A4 File Offset: 0x002429A4
		private void HideModule()
		{
			if (this.mObjRender != null)
			{
				this.mObjRender.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600AA26 RID: 43558 RVA: 0x002445C8 File Offset: 0x002429C8
		private void ShowmRecommendProPerty(JobTable jobItem)
		{
			if (this.mRecommendProPerty != null)
			{
				this.mRecommendProPerty.text = jobItem.RecommendedAttribute;
			}
		}

		// Token: 0x0600AA27 RID: 43559 RVA: 0x002445EC File Offset: 0x002429EC
		private void ShowJobImage(JobTable jobItem)
		{
			if (jobItem.ID == this.currentShowPortraitID)
			{
				return;
			}
			this.currentShowPortraitID = jobItem.ID;
			if (this.objJobImage != null)
			{
				Object.DestroyImmediate(this.objJobImage);
				this.objJobImage = null;
			}
			if (jobItem.JobImage.Contains("Animation"))
			{
				this.ShowModule(jobItem.ID, jobItem.JobImage);
				this.mSpineRoot.SetActive(false);
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
				{
					this.mSpineRoot.CustomActive(true);
				}, 0, 0, false);
			}
			else
			{
				this.HideModule();
				this.objJobImage = Singleton<AssetLoader>.instance.LoadResAsGameObject(jobItem.JobImage, true, 0U);
				if (this.objJobImage != null && this.mJobImageRoot != null)
				{
					Utility.AttachTo(this.objJobImage, this.mJobImageRoot, false);
				}
				this.mJobImageRoot.SetActive(false);
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
				{
					this.mJobImageRoot.CustomActive(true);
				}, 0, 0, false);
			}
		}

		// Token: 0x0600AA28 RID: 43560 RVA: 0x00244712 File Offset: 0x00242B12
		public override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600AA29 RID: 43561 RVA: 0x00244718 File Offset: 0x00242B18
		private void RestartBGAudio()
		{
			if (this.BkgSoundHandle == 4294967295U)
			{
				this.BkgSoundHandle = MonoSingleton<AudioManager>.instance.PlaySound("Sound/Login", AudioType.AudioStream, Global.Settings.bgmStart, true, null, false, false, null, 1f);
			}
		}

		// Token: 0x0600AA2A RID: 43562 RVA: 0x0024475B File Offset: 0x00242B5B
		private void RemoveBGAudio()
		{
			if (this.BkgSoundHandle != 4294967295U)
			{
				MonoSingleton<AudioManager>.instance.Stop(this.BkgSoundHandle);
				this.BkgSoundHandle = uint.MaxValue;
			}
		}

		// Token: 0x0600AA2B RID: 43563 RVA: 0x00244780 File Offset: 0x00242B80
		private bool IsIOSAppstoreFuncHide()
		{
			return Singleton<IOSFunctionSwitchManager>.GetInstance().IsFunctionClosed(IOSFuncSwitchTable.eType.SELECT_CREATE_ROLE_TAB);
		}

		// Token: 0x04005F42 RID: 24386
		private int iSelectedID;

		// Token: 0x04005F43 RID: 24387
		private List<NameTable> akNameFirst = new List<NameTable>();

		// Token: 0x04005F44 RID: 24388
		private List<NameTable> akNameSecond = new List<NameTable>();

		// Token: 0x04005F45 RID: 24389
		private List<NameTable> akNameMiddle = new List<NameTable>();

		// Token: 0x04005F46 RID: 24390
		private int currentBaseJobID;

		// Token: 0x04005F47 RID: 24391
		private int currentMovieJobID;

		// Token: 0x04005F48 RID: 24392
		private int currentShowPortraitID;

		// Token: 0x04005F49 RID: 24393
		private int appointment_Max_Role;

		// Token: 0x04005F4A RID: 24394
		private int appointmenRoleID;

		// Token: 0x04005F4B RID: 24395
		private GameObject objJobImage;

		// Token: 0x04005F4C RID: 24396
		[UIControl("InputField", typeof(InputField), 0)]
		protected InputField input;

		// Token: 0x04005F4D RID: 24397
		[UIControl("sex/sex{0}", typeof(Toggle), 1)]
		private Toggle[] SexToggles = new Toggle[2];

		// Token: 0x04005F4E RID: 24398
		[UIControl("sex/sex{0}", typeof(UIGray), 1)]
		private UIGray[] SexTogglesGray = new UIGray[2];

		// Token: 0x04005F4F RID: 24399
		[UIControl("sex/sex{0}/Image", typeof(Image), 1)]
		private Image[] SexImgs = new Image[2];

		// Token: 0x04005F50 RID: 24400
		[UIControl("sex/sex{0}/sexgray", typeof(Image), 1)]
		private Image[] SexImgsGray = new Image[2];

		// Token: 0x04005F51 RID: 24401
		private MediaPlayerCtrl mCtrlMovie;

		// Token: 0x04005F52 RID: 24402
		private RawImage mImgMovie;

		// Token: 0x04005F53 RID: 24403
		private Text mTxtMoive;

		// Token: 0x04005F54 RID: 24404
		private GameObject mJobImageRoot;

		// Token: 0x04005F55 RID: 24405
		private Text mTxtJobSimpleDesc;

		// Token: 0x04005F56 RID: 24406
		private Image mImgJobName;

		// Token: 0x04005F57 RID: 24407
		private GeObjectRenderer mObjRender;

		// Token: 0x04005F58 RID: 24408
		private GameObject mSpineRoot;

		// Token: 0x04005F59 RID: 24409
		private GameObject mAppointmentActivity;

		// Token: 0x04005F5A RID: 24410
		private Text mRecommendProPerty;

		// Token: 0x04005F5B RID: 24411
		private Text mJobTips;

		// Token: 0x04005F5C RID: 24412
		private CachedObjectListManager<BaseJobItem> m_kBaseJobItems = new CachedObjectListManager<BaseJobItem>();

		// Token: 0x04005F5D RID: 24413
		private GameObject goBaseJobItemParent;

		// Token: 0x04005F5E RID: 24414
		private GameObject goBaseJobItemPrefab;

		// Token: 0x04005F5F RID: 24415
		private CachedObjectListManager<ChangeJobItem> m_kChangeJobItems = new CachedObjectListManager<ChangeJobItem>();

		// Token: 0x04005F60 RID: 24416
		private GameObject goChangeJobItemParent;

		// Token: 0x04005F61 RID: 24417
		private GameObject goChangeJobItemPrefab;

		// Token: 0x04005F62 RID: 24418
		protected uint BkgSoundHandle = uint.MaxValue;
	}
}
