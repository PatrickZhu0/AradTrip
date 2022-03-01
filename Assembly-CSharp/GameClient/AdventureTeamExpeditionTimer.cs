using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200141B RID: 5147
	public class AdventureTeamExpeditionTimer : MonoBehaviour
	{
		// Token: 0x0600C78B RID: 51083 RVA: 0x003044D2 File Offset: 0x003028D2
		public void SetVisible(bool flag)
		{
			base.gameObject.SetActive(flag);
		}

		// Token: 0x0600C78C RID: 51084 RVA: 0x003044E0 File Offset: 0x003028E0
		public void StartTimer()
		{
			this.SetVisible(true);
			this.seconds = 0;
			this.run = true;
		}

		// Token: 0x0600C78D RID: 51085 RVA: 0x003044F7 File Offset: 0x003028F7
		public void SetCountdown(int seconds)
		{
			this.countdown = seconds;
			this.SetText(this.countdown);
		}

		// Token: 0x0600C78E RID: 51086 RVA: 0x0030450C File Offset: 0x0030290C
		public void Reset()
		{
			this.seconds = 0;
		}

		// Token: 0x0600C78F RID: 51087 RVA: 0x00304515 File Offset: 0x00302915
		public void StopTimer()
		{
			this.run = false;
		}

		// Token: 0x0600C790 RID: 51088 RVA: 0x00304520 File Offset: 0x00302920
		public void UpdateTimer(int delta)
		{
			if (!this.run)
			{
				return;
			}
			this.timeAcc += delta;
			if (this.timeAcc >= 1000)
			{
				this.timeAcc -= 1000;
				this.ShowSecond(1);
			}
		}

		// Token: 0x0600C791 RID: 51089 RVA: 0x00304570 File Offset: 0x00302970
		private void Update()
		{
			if (!this.useSystemUpdate)
			{
				return;
			}
			float num = Time.deltaTime * (float)GlobalLogic.VALUE_1000;
			this.UpdateTimer((int)num);
		}

		// Token: 0x0600C792 RID: 51090 RVA: 0x003045A0 File Offset: 0x003029A0
		private void ShowSecond(int add)
		{
			this.seconds += add;
			if (this.componetText != null)
			{
				int text = this.seconds;
				if (this.countdown > 0)
				{
					text = this.countdown - this.seconds;
				}
				else
				{
					text = 0;
				}
				this.SetText(text);
			}
		}

		// Token: 0x0600C793 RID: 51091 RVA: 0x003045FC File Offset: 0x003029FC
		private void SetText(int tmp)
		{
			this.ConverSeconds(tmp, ref this.time4);
			if (this.formatType == AdventureTeamExpeditionTimer.FormatType.ADVENTURE_TEAM_EXPEDITION)
			{
				if (this.time4.day > 0)
				{
					this.componetText.text = string.Format("剩余{0}天", this.time4.day);
				}
				else if (this.time4.hour <= 0 && this.time4.min > 0)
				{
					this.componetText.text = TR.Value("adventure_team_expedition_timer_tips") + string.Format("\n{0:00}分{1:00}秒", this.time4.min, this.time4.sec);
				}
				else if (this.time4.hour <= 0 && this.time4.min <= 0 && this.time4.sec > 0)
				{
					this.componetText.text = TR.Value("adventure_team_expedition_timer_tips") + string.Format("\n{0:00}秒", this.time4.sec);
				}
				else if (this.time4.hour > 0 || this.time4.min > 0 || this.time4.sec > 0)
				{
					this.componetText.text = TR.Value("adventure_team_expedition_timer_tips") + string.Format("\n{0:00}时{1:00}分{2:00}秒", this.time4.hour, this.time4.min, this.time4.sec);
				}
			}
		}

		// Token: 0x0600C794 RID: 51092 RVA: 0x003047C0 File Offset: 0x00302BC0
		public void ConverSeconds(int seconds, ref AdventureTeamExpeditionTimer.Time4 time)
		{
			time.day = seconds / 86400;
			seconds -= time.day * 86400;
			time.hour = seconds / 3600;
			seconds -= time.hour * 3600;
			time.min = seconds / 60;
			time.sec = seconds % 60;
		}

		// Token: 0x04007295 RID: 29333
		public bool useSystemUpdate;

		// Token: 0x04007296 RID: 29334
		public Text componetText;

		// Token: 0x04007297 RID: 29335
		private int timeAcc;

		// Token: 0x04007298 RID: 29336
		private int countdown;

		// Token: 0x04007299 RID: 29337
		private bool run;

		// Token: 0x0400729A RID: 29338
		private int seconds;

		// Token: 0x0400729B RID: 29339
		public AdventureTeamExpeditionTimer.FormatType formatType;

		// Token: 0x0400729C RID: 29340
		private AdventureTeamExpeditionTimer.Time4 time4 = new AdventureTeamExpeditionTimer.Time4();

		// Token: 0x0400729D RID: 29341
		private const int INTERVAL = 1000;

		// Token: 0x0200141C RID: 5148
		public enum FormatType
		{
			// Token: 0x0400729F RID: 29343
			ADVENTURE_TEAM_EXPEDITION
		}

		// Token: 0x0200141D RID: 5149
		public class Time4
		{
			// Token: 0x040072A0 RID: 29344
			public int day;

			// Token: 0x040072A1 RID: 29345
			public int hour;

			// Token: 0x040072A2 RID: 29346
			public int min;

			// Token: 0x040072A3 RID: 29347
			public int sec;
		}
	}
}
