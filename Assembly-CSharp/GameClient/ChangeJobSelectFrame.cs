using System;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200151A RID: 5402
	internal class ChangeJobSelectFrame : ClientFrame
	{
		// Token: 0x0600D1E0 RID: 53728 RVA: 0x0033C7A4 File Offset: 0x0033ABA4
		protected sealed override void _bindExUI()
		{
			this.mImgMovie = this.mBind.GetCom<RawImage>("imgMovie");
			this.mJobinfodes = this.mBind.GetCom<Text>("jobinfodes");
			this.mJobinfoname = this.mBind.GetCom<Text>("jobinfoname");
			this.mMovieCtrl = this.mBind.GetCom<MediaPlayerCtrl>("MovieCtrl");
			this.mJobImageRoot = this.mBind.GetGameObject("jobImageRoot");
			this.mObjRender = this.mBind.GetCom<GeObjectRenderer>("ObjRender");
			this.mSpineRoot = this.mBind.GetGameObject("SpineRoot");
		}

		// Token: 0x0600D1E1 RID: 53729 RVA: 0x0033C84B File Offset: 0x0033AC4B
		protected sealed override void _unbindExUI()
		{
			this.mImgMovie = null;
			this.mJobinfodes = null;
			this.mJobinfoname = null;
			this.mMovieCtrl = null;
			this.mJobImageRoot = null;
			this.mObjRender = null;
			this.mSpineRoot = null;
		}

		// Token: 0x0600D1E2 RID: 53730 RVA: 0x0033C87E File Offset: 0x0033AC7E
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ChangeJob/ChangeJobSelect";
		}

		// Token: 0x0600D1E3 RID: 53731 RVA: 0x0033C885 File Offset: 0x0033AC85
		protected sealed override void _OnOpenFrame()
		{
			this.currentShowPortraitID = 0;
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateChangeTask));
		}

		// Token: 0x0600D1E4 RID: 53732 RVA: 0x0033C8B4 File Offset: 0x0033ACB4
		protected sealed override void _OnCloseFrame()
		{
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this.OnUpdateChangeTask));
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeJobSelectDialog, this.JobsID[this.CurChooseJobIndex], null, null, null);
			this.ClearData();
		}

		// Token: 0x0600D1E5 RID: 53733 RVA: 0x0033C915 File Offset: 0x0033AD15
		[UIEventHandle("Title/btClose")]
		private void OnClose()
		{
			this.frameMgr.CloseFrame<ChangeJobSelectFrame>(this, false);
		}

		// Token: 0x0600D1E6 RID: 53734 RVA: 0x0033C924 File Offset: 0x0033AD24
		[UIEventHandle("JobInfo/btChangeJob")]
		private void _onChangeJobBtnClick()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[this.CurChooseJobIndex], string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("not get JobTable [tableID is {0}]", new object[]
				{
					this.JobsID[this.CurChooseJobIndex]
				});
			}
			string msgContent = TR.Value("changejob_tip", tableItem.Name);
			SystemNotifyManager.SysNotifyMsgBoxOkCancel(msgContent, delegate()
			{
				if (this.JobsID != null && this.CurChooseJobIndex >= 0 && this.CurChooseJobIndex < this.JobsID.Count)
				{
					DataManager<MissionManager>.GetInstance().AcceptChangeJobMissions(this.JobsID[this.CurChooseJobIndex]);
				}
				this.frameMgr.CloseFrame<ChangeJobSelectFrame>(this, false);
			}, null, 0f, false);
		}

		// Token: 0x0600D1E7 RID: 53735 RVA: 0x0033C9B0 File Offset: 0x0033ADB0
		private void ClearData()
		{
			this.NormalChangeJob = false;
			this.bAtLeastOpenOneJob = false;
			this.CurChooseJobIndex = -1;
			this.JobsID.Clear();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onAddNewMission = (MissionManager.DelegateAddNewMission)Delegate.Remove(instance.onAddNewMission, new MissionManager.DelegateAddNewMission(this.OnUpdateChangeTask));
			if (this.mMovieCtrl != null && this.mMovieCtrl.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl.Stop();
				this.mMovieCtrl.UnLoad();
			}
		}

		// Token: 0x0600D1E8 RID: 53736 RVA: 0x0033CA3C File Offset: 0x0033AE3C
		public void OnUpdateChangeTask(uint iMissionID)
		{
			if (!Utility.IsChangeJobTask(iMissionID))
			{
				return;
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChangeJobTaskProPanel>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobTaskProPanel>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChangeJobTaskProPanel>(FrameLayer.Middle, null, string.Empty);
			this.OnClose();
		}

		// Token: 0x0600D1E9 RID: 53737 RVA: 0x0033CA8C File Offset: 0x0033AE8C
		[UIEventHandle("Jobs/Job{0}", typeof(Toggle), typeof(UnityAction<int, bool>), 1, 6)]
		private void OnChooseJob(int iIndex, bool value)
		{
			if (iIndex < 0 || !value || iIndex >= this.JobsID.Count)
			{
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[iIndex], string.Empty, string.Empty);
			if (tableItem == null || tableItem.Open != 1)
			{
				return;
			}
			this.CurChooseJobIndex = iIndex;
			this._updateJobInfo();
		}

		// Token: 0x0600D1EA RID: 53738 RVA: 0x0033CAFC File Offset: 0x0033AEFC
		private void InitInterface(int JobID = 0)
		{
			this.CurChooseJobIndex = -1;
			if (JobID <= 0)
			{
				return;
			}
			IList<int> nextJobsIDByCurJobID = Singleton<TableManager>.GetInstance().GetNextJobsIDByCurJobID(JobID);
			this.JobsID.Clear();
			for (int i = 0; i < nextJobsIDByCurJobID.Count; i++)
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(nextJobsIDByCurJobID[i], string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (tableItem.Open > 0)
					{
						this.JobsID.Insert(0, nextJobsIDByCurJobID[i]);
					}
					else
					{
						this.JobsID.Add(nextJobsIDByCurJobID[i]);
					}
				}
			}
			for (int j = 0; j < this.JobsID.Count; j++)
			{
				for (int k = j + 1; k < this.JobsID.Count; k++)
				{
					JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[j], string.Empty, string.Empty);
					JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[k], string.Empty, string.Empty);
					if (tableItem2.Open > 0 && tableItem3.Open > 0 && tableItem2.JobSort > tableItem3.JobSort)
					{
						int value = this.JobsID[j];
						this.JobsID[j] = this.JobsID[k];
						this.JobsID[k] = value;
					}
				}
			}
			for (int l = 0; l < this.JobsID.Count; l++)
			{
				JobTable tableItem4 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[l], string.Empty, string.Empty);
				if (tableItem4 != null)
				{
					if (tableItem4.Open == 1)
					{
						this.JobOpens[l].gameObject.CustomActive(true);
						this.JobCloses[l].gameObject.CustomActive(false);
						this.Jobs[l].gameObject.SetActive(true);
						this.JobNames[l].text = tableItem4.Name;
						if (tableItem4.JobCreateName != string.Empty && tableItem4.JobCreateName != "-")
						{
							ETCImageLoader.LoadSprite(ref this.JobIcon[l], tableItem4.JobCreateName, true);
							this.JobIcon[l].SetNativeSize();
							this.JobIcon[l].GetComponent<RectTransform>().transform.localPosition = new Vector3((float)tableItem4.JobPortrayalPosX, (float)tableItem4.JobPortrayalPosY, 0f);
						}
						else
						{
							this.JobIcon[l].gameObject.SetActive(false);
						}
						if (this.JobsID[l] == DataManager<PlayerBaseData>.GetInstance().PreChangeJobTableID && this.CurChooseJobIndex == -1)
						{
							this.CurChooseJobIndex = l;
							this.Jobs[l].isOn = true;
						}
						this.RecProperty[l].text = tableItem4.RecDefence;
						this.bAtLeastOpenOneJob = true;
					}
					else
					{
						this.JobOpens[l].gameObject.CustomActive(false);
						this.JobCloses[l].gameObject.CustomActive(true);
						this.JobCloseNames[l].text = tableItem4.Name;
						this.Jobs[l].enabled = false;
					}
				}
			}
			if (!this.bAtLeastOpenOneJob)
			{
				SystemNotifyManager.SysNotifyMsgBoxOK("请检查职业表，至少开放一个转职职业", null, string.Empty, false);
			}
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.ChangeJobSelectFrameOpen, null, null, null, null);
		}

		// Token: 0x0600D1EB RID: 53739 RVA: 0x0033CEBC File Offset: 0x0033B2BC
		private void _updateJobInfo()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[this.CurChooseJobIndex], string.Empty, string.Empty);
			this.UpdateJobNewSkill(tableItem);
			this.UpdateMoveInfo(tableItem);
			this.ShowJobImage(tableItem);
			this.currentShowPortraitID = tableItem.ID;
		}

		// Token: 0x0600D1EC RID: 53740 RVA: 0x0033CF10 File Offset: 0x0033B310
		private void ShowJobImage(JobTable jobItem)
		{
			if (jobItem == null)
			{
				return;
			}
			if (jobItem.ID == this.currentShowPortraitID)
			{
				return;
			}
			if (this.objJobImage != null)
			{
				Object.DestroyImmediate(this.objJobImage);
				this.objJobImage = null;
			}
			if (jobItem.JobImage.Contains("Animation"))
			{
				this.ShowModule(jobItem.ID, jobItem.JobImage);
				if (this.mSpineRoot != null)
				{
					this.mSpineRoot.SetActive(false);
				}
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
				{
					if (this.mSpineRoot != null)
					{
						this.mSpineRoot.SetActive(true);
					}
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
				if (this.mJobImageRoot != null)
				{
					this.mJobImageRoot.SetActive(false);
					Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
					{
						if (this.mJobImageRoot != null)
						{
							this.mJobImageRoot.SetActive(true);
						}
					}, 0, 0, false);
				}
			}
		}

		// Token: 0x0600D1ED RID: 53741 RVA: 0x0033D054 File Offset: 0x0033B454
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

		// Token: 0x0600D1EE RID: 53742 RVA: 0x0033D0D4 File Offset: 0x0033B4D4
		private void HideModule()
		{
			if (this.mObjRender != null)
			{
				this.mObjRender.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600D1EF RID: 53743 RVA: 0x0033D0F8 File Offset: 0x0033B4F8
		private void UpdateMoveInfo(JobTable data)
		{
			if (data == null)
			{
				return;
			}
			if (data.ID == this.currentShowPortraitID)
			{
				return;
			}
			if (this.mJobinfoname != null)
			{
				this.mJobinfoname.text = data.Name;
			}
			if (this.mJobinfodes != null)
			{
				this.mJobinfodes.text = data.JobDes[0];
			}
			if (this.mImgMovie != null)
			{
				Vector3 localScale = this.mImgMovie.transform.localScale;
				localScale.y = -1f;
				this.mImgMovie.transform.localScale = localScale;
			}
			if (this.mMovieCtrl != null && this.mImgMovie != null)
			{
				MediaPlayerCtrl mediaPlayerCtrl = this.mMovieCtrl;
				mediaPlayerCtrl.OnReady = (MediaPlayerCtrl.VideoReady)Delegate.Combine(mediaPlayerCtrl.OnReady, new MediaPlayerCtrl.VideoReady(delegate()
				{
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
					if (this.mMovieCtrl != null)
					{
						this.mMovieCtrl.SetVolume(0f);
					}
					DOTween.To(delegate()
					{
						if (this.mMovieCtrl != null)
						{
							return this.mMovieCtrl.GetVolume();
						}
						return 1f;
					}, delegate(float value)
					{
						if (this.mMovieCtrl != null)
						{
							this.mMovieCtrl.SetVolume(value);
						}
					}, 1f, 1f);
					if (this.mMovieCtrl != null)
					{
						this.mMovieCtrl.Play();
					}
				}));
			}
			this._PlayMovie(data.Video);
		}

		// Token: 0x0600D1F0 RID: 53744 RVA: 0x0033D1FC File Offset: 0x0033B5FC
		private void _PlayMovie(string path)
		{
			if (this.mMovieCtrl != null)
			{
				this.mMovieCtrl.Load(path);
			}
		}

		// Token: 0x0600D1F1 RID: 53745 RVA: 0x0033D21C File Offset: 0x0033B61C
		private void UpdateJobNewSkill(JobTable data)
		{
			if (data.ID == this.currentShowPortraitID)
			{
				return;
			}
			Image[] array = new Image[4];
			array = this.mNewJobSkillIcons;
			for (int i = 0; i < array.Length; i++)
			{
				if (i < data.SkillIcon.Count && data.SkillIcon[i] != string.Empty && data.SkillIcon[i] != "-")
				{
					ETCImageLoader.LoadSprite(ref array[i], data.SkillIcon[i], true);
					array[i].gameObject.SetActive(true);
				}
				else
				{
					array[i].gameObject.SetActive(false);
				}
			}
		}

		// Token: 0x0600D1F2 RID: 53746 RVA: 0x0033D2E0 File Offset: 0x0033B6E0
		public static void Create(int JobID, bool NormalChangeJob = false)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ChangeJobSelectFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobSelectFrame>(null, false);
			}
			ChangeJobSelectFrame changeJobSelectFrame = Singleton<ClientSystemManager>.GetInstance().OpenFrame<ChangeJobSelectFrame>(FrameLayer.Middle, null, string.Empty) as ChangeJobSelectFrame;
			if (changeJobSelectFrame != null)
			{
				changeJobSelectFrame.NormalChangeJob = NormalChangeJob;
				changeJobSelectFrame.InitInterface(JobID);
				changeJobSelectFrame.frame.GetComponent<RectTransform>().SetAsLastSibling();
			}
		}

		// Token: 0x04007AD0 RID: 31440
		private const int MaxJobNum = 6;

		// Token: 0x04007AD1 RID: 31441
		private const int MaxSkillNum = 4;

		// Token: 0x04007AD2 RID: 31442
		private List<int> JobsID = new List<int>();

		// Token: 0x04007AD3 RID: 31443
		private bool NormalChangeJob;

		// Token: 0x04007AD4 RID: 31444
		private bool bAtLeastOpenOneJob;

		// Token: 0x04007AD5 RID: 31445
		private int CurChooseJobIndex = -1;

		// Token: 0x04007AD6 RID: 31446
		private GameObject objJobImage;

		// Token: 0x04007AD7 RID: 31447
		private int currentShowPortraitID;

		// Token: 0x04007AD8 RID: 31448
		private RawImage mImgMovie;

		// Token: 0x04007AD9 RID: 31449
		private Text mJobinfodes;

		// Token: 0x04007ADA RID: 31450
		private Text mJobinfoname;

		// Token: 0x04007ADB RID: 31451
		private MediaPlayerCtrl mMovieCtrl;

		// Token: 0x04007ADC RID: 31452
		private GameObject mJobImageRoot;

		// Token: 0x04007ADD RID: 31453
		private GeObjectRenderer mObjRender;

		// Token: 0x04007ADE RID: 31454
		private GameObject mSpineRoot;

		// Token: 0x04007ADF RID: 31455
		[UIControl("Jobs/Job{0}", typeof(Toggle), 1)]
		private Toggle[] Jobs = new Toggle[6];

		// Token: 0x04007AE0 RID: 31456
		[UIControl("Jobs/Job{0}/JobOpen/title/name", typeof(Text), 1)]
		private Text[] JobNames = new Text[6];

		// Token: 0x04007AE1 RID: 31457
		[UIControl("Jobs/Job{0}/JobOpen/Icon/icon", typeof(Image), 1)]
		private Image[] JobIcon = new Image[6];

		// Token: 0x04007AE2 RID: 31458
		[UIControl("Jobs/Job{0}/JobOpen/property/RecProperty", typeof(Text), 1)]
		private Text[] RecProperty = new Text[6];

		// Token: 0x04007AE3 RID: 31459
		[UIControl("Jobs/Job{0}/JobOpen", typeof(RectTransform), 1)]
		private RectTransform[] JobOpens = new RectTransform[6];

		// Token: 0x04007AE4 RID: 31460
		[UIControl("Jobs/Job{0}/JobClose", typeof(RectTransform), 1)]
		private RectTransform[] JobCloses = new RectTransform[6];

		// Token: 0x04007AE5 RID: 31461
		[UIControl("Jobs/Job{0}/JobClose/name", typeof(Text), 1)]
		private Text[] JobCloseNames = new Text[6];

		// Token: 0x04007AE6 RID: 31462
		[UIControl("JobInfo/skillRoot/NewSkill/SkillIcon/icon{0}/icon", typeof(Image), 1)]
		private Image[] mNewJobSkillIcons = new Image[4];

		// Token: 0x04007AE7 RID: 31463
		[UIControl("Jobs/Job{0}/JobOpen/title/CurUse", typeof(Text), 1)]
		private Text[] CurUse = new Text[6];
	}
}
