using System;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001518 RID: 5400
	internal class ChangeJobMovieFrame : ClientFrame
	{
		// Token: 0x0600D1C1 RID: 53697 RVA: 0x0033BE9A File Offset: 0x0033A29A
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/ChangeJob/ChangeJobMovieFrame";
		}

		// Token: 0x0600D1C2 RID: 53698 RVA: 0x0033BEA1 File Offset: 0x0033A2A1
		protected override void _OnOpenFrame()
		{
			if (this.userData == null)
			{
				return;
			}
			this.JobID = (int)this.userData;
			this.InitInterface();
		}

		// Token: 0x0600D1C3 RID: 53699 RVA: 0x0033BEC6 File Offset: 0x0033A2C6
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600D1C4 RID: 53700 RVA: 0x0033BECE File Offset: 0x0033A2CE
		private void ClearData()
		{
			if (this.mMovieCtrl != null && this.mMovieCtrl.GetCurrentState() != MediaPlayerCtrl.MEDIAPLAYER_STATE.NOT_READY)
			{
				this.mMovieCtrl.Stop();
				this.mMovieCtrl.UnLoad();
			}
			this.JobID = 0;
		}

		// Token: 0x0600D1C5 RID: 53701 RVA: 0x0033BF10 File Offset: 0x0033A310
		private void InitInterface()
		{
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(this.JobID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
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

		// Token: 0x0600D1C6 RID: 53702 RVA: 0x0033BFD3 File Offset: 0x0033A3D3
		private void _PlayMovie(string path)
		{
			if (this.mMovieCtrl != null)
			{
				this.mMovieCtrl.Load(path);
			}
		}

		// Token: 0x0600D1C7 RID: 53703 RVA: 0x0033BFF4 File Offset: 0x0033A3F4
		protected override void _bindExUI()
		{
			this.mMovieCtrl = this.mBind.GetCom<MediaPlayerCtrl>("MovieCtrl");
			this.mImgMovie = this.mBind.GetCom<RawImage>("imgMovie");
			this.mClose = this.mBind.GetCom<Button>("Close");
			this.mClose.onClick.AddListener(new UnityAction(this._onCloseButtonClick));
		}

		// Token: 0x0600D1C8 RID: 53704 RVA: 0x0033C05F File Offset: 0x0033A45F
		protected override void _unbindExUI()
		{
			this.mMovieCtrl = null;
			this.mImgMovie = null;
			this.mClose.onClick.RemoveListener(new UnityAction(this._onCloseButtonClick));
			this.mClose = null;
		}

		// Token: 0x0600D1C9 RID: 53705 RVA: 0x0033C092 File Offset: 0x0033A492
		private void _onCloseButtonClick()
		{
			this.frameMgr.CloseFrame<ChangeJobMovieFrame>(this, false);
		}

		// Token: 0x04007ABF RID: 31423
		private int JobID;

		// Token: 0x04007AC0 RID: 31424
		private MediaPlayerCtrl mMovieCtrl;

		// Token: 0x04007AC1 RID: 31425
		private RawImage mImgMovie;

		// Token: 0x04007AC2 RID: 31426
		private Button mClose;
	}
}
