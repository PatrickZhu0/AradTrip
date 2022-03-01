using System;
using GameClient;
using UnityEngine;
using UnityEngine.UI;

namespace ActivityLimitTime
{
	// Token: 0x020018C8 RID: 6344
	public class ActivityLTNote : ActivityLTItem<ActivityLTNote>
	{
		// Token: 0x0600F7E6 RID: 63462 RVA: 0x00434798 File Offset: 0x00432B98
		public override void Init(GameObject parent, ActivityLimitTimeFrame frame, ActivityLimitTimeData data)
		{
			this.Create();
			this.goParent = parent;
			this.currFrame = frame;
			this.currActivityData = data;
			if (this.goSelf != null)
			{
				this.mBind = this.goSelf.GetComponent<ComCommonBind>();
				if (this.mBind)
				{
					this.activityTime = this.mBind.GetCom<Text>("ActivityTime");
					this.activityRole = this.mBind.GetCom<Text>("ActivityRole");
					this.receiveTime = this.mBind.GetCom<Text>("ReceiveTime");
					this.bgImg = this.mBind.GetCom<Image>("BgImg");
					this.logoText = this.mBind.GetCom<Text>("TextIntroduce");
				}
				Utility.AttachTo(this.goSelf, this.goParent, false);
				this.SetDataToView();
			}
		}

		// Token: 0x0600F7E7 RID: 63463 RVA: 0x00434878 File Offset: 0x00432C78
		public override void Create()
		{
			base.Create();
			this.goSelf = MonoSingleton<ActivityItemObjectManager>.instance.GetActNoteGo();
		}

		// Token: 0x0600F7E8 RID: 63464 RVA: 0x00434890 File Offset: 0x00432C90
		public override void Destory()
		{
			base.Destory();
			MonoSingleton<ActivityItemObjectManager>.instance.ReleaseActNoteGo(this.goSelf);
			this.Reset();
		}

		// Token: 0x0600F7E9 RID: 63465 RVA: 0x004348B0 File Offset: 0x00432CB0
		protected override void SetDataToView()
		{
			if (this.currActivityData != null && this.activityTime && this.activityRole)
			{
				this.activityTime.text = string.Format("{0}~{1}", this.TransTimeStampToStr(this.currActivityData.ActivityStartTime), this.TransTimeStampToStr(this.currActivityData.ActivityEndTime));
				this.receiveTime.text = string.Format("{0}~{1}", this.TransTimeStampToStr(this.currActivityData.ActivityStartTime), this.TransTimeStampToStr(this.currActivityData.ActivityEndTime));
				this.activityRole.text = string.Format("{0}", this.currActivityData.ActivityRole);
				this.logoText.SafeSetText(string.IsNullOrEmpty(this.currActivityData.LogoDesc) ? string.Empty : this.currActivityData.LogoDesc);
			}
		}

		// Token: 0x0600F7EA RID: 63466 RVA: 0x004349AB File Offset: 0x00432DAB
		public override void RefreshView(ActivityLimitTimeData data)
		{
			this.currActivityData = data;
			this.SetDataToView();
		}

		// Token: 0x0600F7EB RID: 63467 RVA: 0x004349BA File Offset: 0x00432DBA
		public override void Reset()
		{
			base.Reset();
			this.activityTime = null;
			this.activityRole = null;
			this.receiveTime = null;
			this.bgImg = null;
		}

		// Token: 0x0600F7EC RID: 63468 RVA: 0x004349DE File Offset: 0x00432DDE
		public void SetTimeString(string str)
		{
			if (this.activityTime)
			{
				this.activityTime.text = str;
			}
		}

		// Token: 0x0600F7ED RID: 63469 RVA: 0x004349FC File Offset: 0x00432DFC
		private string TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}月{1}日{2:HH:mm}", dateTime.Month, dateTime.Day, dateTime);
		}

		// Token: 0x0400990B RID: 39179
		private Text activityTime;

		// Token: 0x0400990C RID: 39180
		private Text activityRole;

		// Token: 0x0400990D RID: 39181
		private Text receiveTime;

		// Token: 0x0400990E RID: 39182
		private Image bgImg;

		// Token: 0x0400990F RID: 39183
		private Text logoText;
	}
}
