using System;
using System.Collections;
using System.Text;
using AdsPush;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02000E4A RID: 3658
	internal class LoadingFrame : ClientFrame
	{
		// Token: 0x0600919B RID: 37275 RVA: 0x001AF424 File Offset: 0x001AD824
		private void LoadTips()
		{
			Type type = this.userData as Type;
			if (type == typeof(ClientSystemTown))
			{
				string randomCityLoadingRes = LoadingResourceManager.GetRandomCityLoadingRes();
				if (!string.IsNullOrEmpty(randomCityLoadingRes))
				{
					GameObject gameObject = Singleton<AssetLoader>.instance.LoadResAsGameObject(randomCityLoadingRes, true, 0U);
					GameObject gameObject2 = this.mBind.GetGameObject("LoadingParent");
					if (gameObject2 && gameObject)
					{
						gameObject.transform.SetParent(gameObject2.transform, false);
						this.SetBackgroundImg(gameObject);
					}
				}
			}
			else if (type == typeof(ClientSystemBattle))
			{
				string randomDugeonLoadingRes = LoadingResourceManager.GetRandomDugeonLoadingRes();
				if (!string.IsNullOrEmpty(randomDugeonLoadingRes))
				{
					GameObject gameObject3 = Singleton<AssetLoader>.instance.LoadResAsGameObject(randomDugeonLoadingRes, true, 0U);
					GameObject gameObject4 = this.mBind.GetGameObject("LoadingParent");
					if (gameObject4 && gameObject3)
					{
						gameObject3.transform.SetParent(gameObject4.transform, false);
						this.SetBackgroundImg(gameObject3);
					}
				}
			}
			else if (type == null)
			{
				string loadingIconPath = Singleton<LoginPushManager>.GetInstance().GetLoadingIconPath();
				if (!string.IsNullOrEmpty(loadingIconPath))
				{
					GameObject gameObject5 = Singleton<AssetLoader>.instance.LoadResAsGameObject(loadingIconPath, true, 0U);
					GameObject gameObject6 = this.mBind.GetGameObject("LoadingParent");
					if (gameObject6 && gameObject5)
					{
						gameObject5.transform.SetParent(gameObject6.transform, false);
					}
				}
				else
				{
					this.SetBackgroundImg(this.frame);
				}
			}
		}

		// Token: 0x0600919C RID: 37276 RVA: 0x001AF5AC File Offset: 0x001AD9AC
		protected override void _OnOpenFrame()
		{
			this.LoadTips();
			this._UpdateSpeed = Global.Settings.loadingProgressStep;
			this.strBuilder = StringBuilderCache.Acquire(256);
			this._targetProgress = 0;
			this._currentProgress = -1;
			base.StartCoroutine(this.UpdateProgress());
			int tableItemCount = Singleton<TableManager>.GetInstance().GetTableItemCount<TipsTable>();
			int iIndex = Random.Range(1, tableItemCount);
			TipsTable tableItemByIndex = Singleton<TableManager>.GetInstance().GetTableItemByIndex<TipsTable>(iIndex);
			if (tableItemByIndex != null)
			{
				this.TipsText.text = "温馨提示:" + tableItemByIndex.ObjectName;
			}
		}

		// Token: 0x0600919D RID: 37277 RVA: 0x001AF63A File Offset: 0x001ADA3A
		protected override void _OnCloseFrame()
		{
			StringBuilderCache.Release(this.strBuilder);
		}

		// Token: 0x0600919E RID: 37278 RVA: 0x001AF647 File Offset: 0x001ADA47
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Loading/LoadingFrame";
		}

		// Token: 0x0600919F RID: 37279 RVA: 0x001AF64E File Offset: 0x001ADA4E
		protected override bool _IsLoadingFrame()
		{
			return true;
		}

		// Token: 0x060091A0 RID: 37280 RVA: 0x001AF654 File Offset: 0x001ADA54
		public IEnumerator UpdateProgress()
		{
			while (this._targetProgress <= 100)
			{
				while (this._currentProgress < this._targetProgress)
				{
					this._currentProgress += this._UpdateSpeed;
					if (this._currentProgress > this._targetProgress)
					{
						this._currentProgress = this._targetProgress;
					}
					this._SetProgress(this._currentProgress);
					yield return Yielders.EndOfFrame;
				}
				if (this._targetProgress == 100)
				{
					yield return MonoSingleton<GameFrameWork>.instance.OpenFadeFrame(delegate
					{
						this.frameMgr.CloseFrame<LoadingFrame>(this, false);
						GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SystemLoadingCompelete, null, null, null, null);
					}, delegate
					{
						GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.SystemLoadingCompelete, null, null, null, null);
					}, null, 0.4f, 0.6f);
					break;
				}
				yield return Yielders.EndOfFrame;
				this._targetProgress = (int)(Singleton<ClientSystemManager>.GetInstance().SwitchProgress * 100f);
			}
			yield break;
		}

		// Token: 0x060091A1 RID: 37281 RVA: 0x001AF670 File Offset: 0x001ADA70
		protected void _SetProgress(int progress)
		{
			if (progress < 0)
			{
				progress = 0;
			}
			if (progress > 100)
			{
				progress = 100;
			}
			this.loadProcess.value = (float)progress / 100f;
			MyExtensionMethods.Clear(this.strBuilder);
			this.strBuilder.AppendFormat("{0}%", progress);
			this.loadingProgressText.text = this.strBuilder.ToString();
		}

		// Token: 0x060091A2 RID: 37282 RVA: 0x001AF6DE File Offset: 0x001ADADE
		protected override bool GetNeedOpenSound()
		{
			return false;
		}

		// Token: 0x060091A3 RID: 37283 RVA: 0x001AF6E1 File Offset: 0x001ADAE1
		protected override bool GetNeedCloseSound()
		{
			return false;
		}

		// Token: 0x060091A4 RID: 37284 RVA: 0x001AF6E4 File Offset: 0x001ADAE4
		private void SetBackgroundImg(GameObject tips)
		{
			if (tips)
			{
				ComCommonBind component = tips.GetComponent<ComCommonBind>();
				if (component == null)
				{
					return;
				}
				Image com = component.GetCom<Image>("BgImg");
				if (com != null)
				{
					string sdklogoPath = PluginManager.GetSDKLogoPath(SDKInterface.SDKLogoType.LoadingLogo);
					if (string.IsNullOrEmpty(sdklogoPath))
					{
						return;
					}
					ETCImageLoader.LoadSprite(ref com, sdklogoPath, true);
				}
			}
		}

		// Token: 0x040048CC RID: 18636
		protected int _UpdateSpeed = 10;

		// Token: 0x040048CD RID: 18637
		protected StringBuilder strBuilder;

		// Token: 0x040048CE RID: 18638
		protected int _targetProgress;

		// Token: 0x040048CF RID: 18639
		protected int _currentProgress = -1;

		// Token: 0x040048D0 RID: 18640
		[UIControl("loading", null, 0)]
		private Slider loadProcess;

		// Token: 0x040048D1 RID: 18641
		[UIControl("loading/loadingText", null, 0)]
		private Text loadingProgressText;

		// Token: 0x040048D2 RID: 18642
		[UIControl("loadText", null, 0)]
		private Text TipsText;
	}
}
