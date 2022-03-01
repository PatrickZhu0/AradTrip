using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018D1 RID: 6353
	public class ActivityNote : MonoBehaviour, IDisposable
	{
		// Token: 0x0600F814 RID: 63508 RVA: 0x0043551C File Offset: 0x0043391C
		public void Init(ILimitTimeNote data, bool isShowLogoText = true, ComCommonBind extendBind = null)
		{
			if (this.mNoteBind == null)
			{
				if (extendBind != null)
				{
					this.mNoteBind = extendBind;
				}
				else
				{
					string prefabFullPath = (!string.IsNullOrEmpty(data.NotePrefabPath)) ? data.NotePrefabPath : "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeNote";
					GameObject gameObject = Singleton<CGameObjectPool>.instance.GetGameObject(prefabFullPath, enResourceType.UIPrefab, 2U);
					if (gameObject != null)
					{
						this.mNoteBind = gameObject.GetComponent<ComCommonBind>();
						gameObject.transform.SetParent(this.mLimitTimeNoteRoot, false);
					}
				}
			}
			if (this.mNoteBind)
			{
				this.mTextTime = this.mNoteBind.GetCom<Text>("ActivityTime");
				this.mTextRule = this.mNoteBind.GetCom<Text>("ActivityRole");
				this.mTextReceiveTime = this.mNoteBind.GetCom<Text>("ReceiveTime");
				this.mImageNoteBg = this.mNoteBind.GetCom<Image>("BgImg");
				this.mTextLogo = this.mNoteBind.GetCom<Text>("TextIntroduce");
				this.mImageLogo = this.mNoteBind.GetCom<Image>("LogoImg");
				this.mTextTime.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(data.StartTime), this._TransTimeStampToStr(data.EndTime)));
				this.mTextReceiveTime.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(data.StartTime), this._TransTimeStampToStr(data.EndTime)));
				this.mTextRule.SafeSetText(data.RuleDesc.Replace('|', '\n'));
				if (!string.IsNullOrEmpty(data.LogoDesc))
				{
					this.mTextLogo.SafeSetText(data.LogoDesc);
				}
				else
				{
					this.mTextLogo.SafeSetText(TR.Value("activity_login_introduce"));
				}
				this.mTextLogo.CustomActive(isShowLogoText);
				if (this.mImageLogo != null)
				{
					if (!string.IsNullOrEmpty(data.LogoPath))
					{
						ETCImageLoader.LoadSprite(ref this.mImageLogo, data.LogoPath, true);
					}
					else
					{
						ETCImageLoader.LoadSprite(ref this.mImageLogo, this.mDefaultLogoPath, true);
					}
					this.mImageLogo.SetNativeSize();
				}
				if (this.mImageNoteBg != null && !string.IsNullOrEmpty(data.NoteBgPath))
				{
					ETCImageLoader.LoadSprite(ref this.mImageNoteBg, data.NoteBgPath, true);
				}
			}
		}

		// Token: 0x0600F815 RID: 63509 RVA: 0x00435785 File Offset: 0x00433B85
		public void ShowLogoText(bool isShow)
		{
			this.mTextLogo.CustomActive(isShow);
		}

		// Token: 0x0600F816 RID: 63510 RVA: 0x00435793 File Offset: 0x00433B93
		public void SetActivityTimeStr(string timeStr)
		{
			this.mTextTime.SafeSetText(timeStr);
		}

		// Token: 0x0600F817 RID: 63511 RVA: 0x004357A4 File Offset: 0x00433BA4
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x0600F818 RID: 63512 RVA: 0x00435819 File Offset: 0x00433C19
		public void Dispose()
		{
			if (this.mNoteBind != null)
			{
				Singleton<CGameObjectPool>.instance.RecycleGameObject(this.mNoteBind.gameObject);
				this.mNoteBind = null;
			}
		}

		// Token: 0x0400992A RID: 39210
		[SerializeField]
		private RectTransform mLimitTimeNoteRoot;

		// Token: 0x0400992B RID: 39211
		[SerializeField]
		private string mDefaultLogoPath = "UI/Image/Background/UI_Xianshihuodong_SloganBg_01";

		// Token: 0x0400992C RID: 39212
		protected ComCommonBind mNoteBind;

		// Token: 0x0400992D RID: 39213
		private const string NotePrefabResPath = "UIFlatten/Prefabs/OperateActivity/LimitTime/ActivityLimitTimeNote";

		// Token: 0x0400992E RID: 39214
		private Text mTextTime;

		// Token: 0x0400992F RID: 39215
		private Text mTextRule;

		// Token: 0x04009930 RID: 39216
		private Text mTextReceiveTime;

		// Token: 0x04009931 RID: 39217
		private Image mImageNoteBg;

		// Token: 0x04009932 RID: 39218
		private Image mImageLogo;

		// Token: 0x04009933 RID: 39219
		private Text mTextLogo;
	}
}
