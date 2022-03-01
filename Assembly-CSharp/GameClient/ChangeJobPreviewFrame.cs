using System;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001519 RID: 5401
	internal class ChangeJobPreviewFrame : ClientFrame
	{
		// Token: 0x0600D1D0 RID: 53712 RVA: 0x0033C182 File Offset: 0x0033A582
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ChangeJob/ChangeJobPreviewFrame";
		}

		// Token: 0x0600D1D1 RID: 53713 RVA: 0x0033C189 File Offset: 0x0033A589
		protected override void _OnOpenFrame()
		{
			if (this.userData != null)
			{
				this.SelJobID = (int)this.userData;
			}
			this.InitInterface();
		}

		// Token: 0x0600D1D2 RID: 53714 RVA: 0x0033C1AD File Offset: 0x0033A5AD
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600D1D3 RID: 53715 RVA: 0x0033C1B5 File Offset: 0x0033A5B5
		private void ClearData()
		{
			if (this.mMovieCtrl != null && this.mMovieCtrl.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl.Stop();
				this.mMovieCtrl.UnLoad();
			}
			this.SelJobID = 0;
		}

		// Token: 0x0600D1D4 RID: 53716 RVA: 0x0033C1F8 File Offset: 0x0033A5F8
		private void InitInterface()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.SelJobID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			this.mJobName.text = tableItem.Name;
			this.mSelJobName.text = tableItem.Name;
			this.mArmor.text = tableItem.RecDefence;
			this.mDes.text = tableItem.JobDes[0];
			GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(tableItem.JobImage, true, 0U);
			if (gameObject != null)
			{
				gameObject.GetComponent<Transform>().localScale = new Vector3(0.7f, 0.7f, 0.7f);
				Utility.AttachTo(gameObject, this.mJobImageRoot, false);
			}
			if (this.mImgMovie != null)
			{
				Vector3 localScale = this.mImgMovie.transform.localScale;
				localScale.y = -1f;
				this.mImgMovie.transform.localScale = localScale;
			}
			for (int i = 0; i < this.SkillIcon.Length; i++)
			{
				if (i < tableItem.SkillIcon.Count && tableItem.SkillIcon[i] != string.Empty && tableItem.SkillIcon[i] != "-")
				{
					string text = tableItem.SkillIcon[i];
					if (!string.IsNullOrEmpty(text) && text != "-")
					{
						ETCImageLoader.LoadSprite(ref this.SkillIcon[i], text, true);
					}
					this.SkillIcon[i].gameObject.CustomActive(true);
				}
				else
				{
					this.SkillIcon[i].gameObject.CustomActive(false);
				}
			}
			if (this.mMovieCtrl != null && this.mImgMovie != null)
			{
				MediaPlayerCtrl mediaPlayerCtrl = this.mMovieCtrl;
				mediaPlayerCtrl.OnReady = (MediaPlayerCtrl.VideoReady)Delegate.Combine(mediaPlayerCtrl.OnReady, new MediaPlayerCtrl.VideoReady(delegate()
				{
					if (this.mTxtMoive != null)
					{
						this.mTxtMoive.CustomActive(false);
					}
					this.mImgMovie.CustomActive(true);
					this.mImgMovie.color = Color.black;
					DOTween.To(() => this.mImgMovie.color, delegate(Color value)
					{
						this.mImgMovie.color = value;
					}, Color.white, 1f);
					this.mMovieCtrl.SetVolume(0f);
					DOTween.To(() => this.mMovieCtrl.GetVolume(), delegate(float value)
					{
						this.mMovieCtrl.SetVolume(value);
					}, 1f, 1f);
					this.mMovieCtrl.Play();
				}));
			}
			this._PlayMovie(tableItem.Video);
		}

		// Token: 0x0600D1D5 RID: 53717 RVA: 0x0033C41B File Offset: 0x0033A81B
		private void _PlayMovie(string path)
		{
			if (this.mMovieCtrl != null)
			{
				this.mMovieCtrl.Load(path);
			}
		}

		// Token: 0x0600D1D6 RID: 53718 RVA: 0x0033C43C File Offset: 0x0033A83C
		protected override void _bindExUI()
		{
			this.mJobName = this.mBind.GetCom<Text>("JobName");
			this.mSelJobName = this.mBind.GetCom<Text>("SelJobName");
			this.mArmor = this.mBind.GetCom<Text>("Armor");
			this.mJobImageRoot = this.mBind.GetGameObject("JobImageRoot");
			this.mDes = this.mBind.GetCom<Text>("Des");
			this.mMovieCtrl = this.mBind.GetCom<MediaPlayerCtrl>("MovieCtrl");
			this.mImgMovie = this.mBind.GetCom<RawImage>("imgMovie");
			this.mTxtMoive = this.mBind.GetCom<Text>("txtMoive");
			this.mBtBack = this.mBind.GetCom<Button>("btBack");
			this.mBtBack.onClick.AddListener(new UnityAction(this._onBtBackButtonClick));
			this.mBtChangeJob = this.mBind.GetCom<Button>("btChangeJob");
			this.mBtChangeJob.onClick.AddListener(new UnityAction(this._onBtChangeJobButtonClick));
		}

		// Token: 0x0600D1D7 RID: 53719 RVA: 0x0033C560 File Offset: 0x0033A960
		protected override void _unbindExUI()
		{
			this.mJobName = null;
			this.mSelJobName = null;
			this.mArmor = null;
			this.mJobImageRoot = null;
			this.mDes = null;
			this.mMovieCtrl = null;
			this.mImgMovie = null;
			this.mTxtMoive = null;
			this.mBtBack.onClick.RemoveListener(new UnityAction(this._onBtBackButtonClick));
			this.mBtBack = null;
			this.mBtChangeJob.onClick.RemoveListener(new UnityAction(this._onBtChangeJobButtonClick));
			this.mBtChangeJob = null;
		}

		// Token: 0x0600D1D8 RID: 53720 RVA: 0x0033C5EB File Offset: 0x0033A9EB
		private void _onBtBackButtonClick()
		{
			this.frameMgr.CloseFrame<ChangeJobPreviewFrame>(this, false);
		}

		// Token: 0x0600D1D9 RID: 53721 RVA: 0x0033C5FA File Offset: 0x0033A9FA
		private void _onBtChangeJobButtonClick()
		{
			DataManager<MissionManager>.GetInstance().AcceptChangeJobMissions(this.SelJobID);
			Singleton<ClientSystemManager>.GetInstance().CloseFrame<ChangeJobSelectFrame>(null, false);
			this.frameMgr.CloseFrame<ChangeJobPreviewFrame>(this, false);
		}

		// Token: 0x04007AC3 RID: 31427
		private const int SkillIconNum = 4;

		// Token: 0x04007AC4 RID: 31428
		private int SelJobID;

		// Token: 0x04007AC5 RID: 31429
		[UIControl("SkillIcon/icon{0}", typeof(Image), 1)]
		private Image[] SkillIcon = new Image[4];

		// Token: 0x04007AC6 RID: 31430
		private Text mJobName;

		// Token: 0x04007AC7 RID: 31431
		private Text mSelJobName;

		// Token: 0x04007AC8 RID: 31432
		private Text mArmor;

		// Token: 0x04007AC9 RID: 31433
		private GameObject mJobImageRoot;

		// Token: 0x04007ACA RID: 31434
		private Text mDes;

		// Token: 0x04007ACB RID: 31435
		private MediaPlayerCtrl mMovieCtrl;

		// Token: 0x04007ACC RID: 31436
		private RawImage mImgMovie;

		// Token: 0x04007ACD RID: 31437
		private Text mTxtMoive;

		// Token: 0x04007ACE RID: 31438
		private Button mBtBack;

		// Token: 0x04007ACF RID: 31439
		private Button mBtChangeJob;
	}
}
