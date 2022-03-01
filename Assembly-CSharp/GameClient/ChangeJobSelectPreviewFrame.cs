using System;
using System.Collections.Generic;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200151B RID: 5403
	internal class ChangeJobSelectPreviewFrame : ClientFrame
	{
		// Token: 0x0600D1FC RID: 53756 RVA: 0x0033D5C8 File Offset: 0x0033B9C8
		protected sealed override void _bindExUI()
		{
			this.mImgMovie = this.mBind.GetCom<RawImage>("imgMovie");
			this.mJobinfodes = this.mBind.GetCom<Text>("jobinfodes");
			this.mJobinfoname = this.mBind.GetCom<Text>("jobinfoname");
			this.mJobImageRoot = this.mBind.GetGameObject("jobImageRoot");
			this.mObjRender = this.mBind.GetCom<GeObjectRenderer>("ObjRender");
			this.mSpineRoot = this.mBind.GetGameObject("SpineRoot");
			this.mMovieCtrl = this.mBind.GetCom<MediaPlayerCtrl>("MovieCtrl");
		}

		// Token: 0x0600D1FD RID: 53757 RVA: 0x0033D66F File Offset: 0x0033BA6F
		protected sealed override void _unbindExUI()
		{
			this.mImgMovie = null;
			this.mJobinfodes = null;
			this.mJobinfoname = null;
			this.mJobImageRoot = null;
			this.mObjRender = null;
			this.mSpineRoot = null;
			this.mMovieCtrl = null;
		}

		// Token: 0x0600D1FE RID: 53758 RVA: 0x0033D6A2 File Offset: 0x0033BAA2
		public sealed override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ChangeJob/ChangeJobSelectPreview";
		}

		// Token: 0x0600D1FF RID: 53759 RVA: 0x0033D6A9 File Offset: 0x0033BAA9
		protected sealed override void _OnOpenFrame()
		{
			this.currentShowPortraitID = 0;
			this.InitInterface(DataManager<PlayerBaseData>.GetInstance().JobTableID);
		}

		// Token: 0x0600D200 RID: 53760 RVA: 0x0033D6C2 File Offset: 0x0033BAC2
		protected sealed override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600D201 RID: 53761 RVA: 0x0033D6CC File Offset: 0x0033BACC
		private void ClearData()
		{
			this.JobsID.Clear();
			if (this.mMovieCtrl != null && this.mMovieCtrl.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl.Stop();
				this.mMovieCtrl.UnLoad();
			}
			this.CurChooseJobIndex = -1;
		}

		// Token: 0x0600D202 RID: 53762 RVA: 0x0033D724 File Offset: 0x0033BB24
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

		// Token: 0x0600D203 RID: 53763 RVA: 0x0033D794 File Offset: 0x0033BB94
		private void _updateJobInfo()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobsID[this.CurChooseJobIndex], string.Empty, string.Empty);
			this.UpdateJobNewSkill(tableItem);
			this.UpdateMoveInfo(tableItem);
			this.ShowJobImage(tableItem);
			this.currentShowPortraitID = tableItem.ID;
		}

		// Token: 0x0600D204 RID: 53764 RVA: 0x0033D7E8 File Offset: 0x0033BBE8
		private void InitInterface(int JobID = 0)
		{
			this.CurChooseJobIndex = -1;
			if (JobID <= 0)
			{
				return;
			}
			IList<int> nextJobsIDByCurJobID = Singleton<TableManager>.GetInstance().GetNextJobsIDByCurJobID(JobID);
			if (nextJobsIDByCurJobID == null)
			{
				Logger.LogErrorFormat("[GetNextJobsIDByCurJobID] is null, JobID = {0}, JobTableID = {1}", new object[]
				{
					JobID,
					DataManager<PlayerBaseData>.GetInstance().JobTableID
				});
				return;
			}
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
		}

		// Token: 0x0600D205 RID: 53765 RVA: 0x0033DBA4 File Offset: 0x0033BFA4
		private void ShowJobImage(JobTable jobItem)
		{
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
				if (null != this.mSpineRoot)
				{
					this.mSpineRoot.SetActive(false);
				}
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
				{
					if (null != this.mSpineRoot)
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
				if (null != this.mJobImageRoot)
				{
					this.mJobImageRoot.SetActive(false);
				}
				Singleton<ClientSystemManager>.GetInstance().delayCaller.DelayCall(100, delegate
				{
					if (null != this.mJobImageRoot)
					{
						this.mJobImageRoot.SetActive(true);
					}
				}, 0, 0, false);
			}
		}

		// Token: 0x0600D206 RID: 53766 RVA: 0x0033DCE0 File Offset: 0x0033C0E0
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

		// Token: 0x0600D207 RID: 53767 RVA: 0x0033DD60 File Offset: 0x0033C160
		private void HideModule()
		{
			if (this.mObjRender != null)
			{
				this.mObjRender.gameObject.CustomActive(false);
			}
		}

		// Token: 0x0600D208 RID: 53768 RVA: 0x0033DD84 File Offset: 0x0033C184
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
			this.mJobinfoname.text = data.Name;
			this.mJobinfodes.text = data.JobDes[0];
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
					if (this.mImgMovie != null)
					{
						this.mImgMovie.CustomActive(true);
						this.mImgMovie.color = Color.black;
						DOTween.To(() => this.mImgMovie.color, delegate(Color value)
						{
							this.mImgMovie.color = value;
						}, Color.white, 1f);
					}
					if (this.mMovieCtrl != null)
					{
						this.mMovieCtrl.SetVolume(0f);
						DOTween.To(() => this.mMovieCtrl.GetVolume(), delegate(float value)
						{
							this.mMovieCtrl.SetVolume(value);
						}, 1f, 1f);
						this.mMovieCtrl.Play();
					}
				}));
			}
			this._PlayMovie(data.Video);
		}

		// Token: 0x0600D209 RID: 53769 RVA: 0x0033DE66 File Offset: 0x0033C266
		private void _PlayMovie(string path)
		{
			if (this.mMovieCtrl != null)
			{
				this.mMovieCtrl.Load(path);
			}
		}

		// Token: 0x0600D20A RID: 53770 RVA: 0x0033DE88 File Offset: 0x0033C288
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

		// Token: 0x04007AE8 RID: 31464
		private const int MaxJobNum = 6;

		// Token: 0x04007AE9 RID: 31465
		private const int MaxSkillNum = 4;

		// Token: 0x04007AEA RID: 31466
		private int CurChooseJobIndex = -1;

		// Token: 0x04007AEB RID: 31467
		private int currentShowPortraitID;

		// Token: 0x04007AEC RID: 31468
		private GameObject objJobImage;

		// Token: 0x04007AED RID: 31469
		private List<int> JobsID = new List<int>();

		// Token: 0x04007AEE RID: 31470
		private RawImage mImgMovie;

		// Token: 0x04007AEF RID: 31471
		private Text mJobinfodes;

		// Token: 0x04007AF0 RID: 31472
		private Text mJobinfoname;

		// Token: 0x04007AF1 RID: 31473
		private GameObject mJobImageRoot;

		// Token: 0x04007AF2 RID: 31474
		private GeObjectRenderer mObjRender;

		// Token: 0x04007AF3 RID: 31475
		private GameObject mSpineRoot;

		// Token: 0x04007AF4 RID: 31476
		private MediaPlayerCtrl mMovieCtrl;

		// Token: 0x04007AF5 RID: 31477
		[UIControl("Jobs/Job{0}", typeof(Toggle), 1)]
		private Toggle[] Jobs = new Toggle[6];

		// Token: 0x04007AF6 RID: 31478
		[UIControl("Jobs/Job{0}/JobOpen/title/name", typeof(Text), 1)]
		private Text[] JobNames = new Text[6];

		// Token: 0x04007AF7 RID: 31479
		[UIControl("Jobs/Job{0}/JobOpen/Icon/icon", typeof(Image), 1)]
		private Image[] JobIcon = new Image[6];

		// Token: 0x04007AF8 RID: 31480
		[UIControl("Jobs/Job{0}/JobOpen/property/RecProperty", typeof(Text), 1)]
		private Text[] RecProperty = new Text[6];

		// Token: 0x04007AF9 RID: 31481
		[UIControl("Jobs/Job{0}/JobOpen", typeof(RectTransform), 1)]
		private RectTransform[] JobOpens = new RectTransform[6];

		// Token: 0x04007AFA RID: 31482
		[UIControl("Jobs/Job{0}/JobClose", typeof(RectTransform), 1)]
		private RectTransform[] JobCloses = new RectTransform[6];

		// Token: 0x04007AFB RID: 31483
		[UIControl("Jobs/Job{0}/JobClose/name", typeof(Text), 1)]
		private Text[] JobCloseNames = new Text[6];

		// Token: 0x04007AFC RID: 31484
		[UIControl("JobInfo/skillRoot/NewSkill/SkillIcon/icon{0}/icon", typeof(Image), 1)]
		private Image[] mNewJobSkillIcons = new Image[4];

		// Token: 0x04007AFD RID: 31485
		[UIControl("Jobs/Job{0}/JobOpen/title/CurUse", typeof(Text), 1)]
		private Text[] CurUse = new Text[6];
	}
}
