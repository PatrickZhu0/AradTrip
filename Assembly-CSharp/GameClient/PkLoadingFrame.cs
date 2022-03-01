using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using GamePool;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001996 RID: 6550
	internal class PkLoadingFrame : ClientFrame
	{
		// Token: 0x0600FF01 RID: 65281 RVA: 0x0046964C File Offset: 0x00467A4C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Pk/PkLoading";
		}

		// Token: 0x0600FF02 RID: 65282 RVA: 0x00469653 File Offset: 0x00467A53
		protected override void _OnOpenFrame()
		{
			this.mLeftProgress.value = 0f;
			this.mRightProgress.value = 0f;
			this.getAnimationTime();
			this.InitUI();
			this.comBase = this.frame.AddComponent<ComGameBase>();
		}

		// Token: 0x0600FF03 RID: 65283 RVA: 0x00469692 File Offset: 0x00467A92
		protected override void _OnCloseFrame()
		{
			this.ClearData();
		}

		// Token: 0x0600FF04 RID: 65284 RVA: 0x0046969A File Offset: 0x00467A9A
		private void ClearData()
		{
			this.animTime = 0f;
		}

		// Token: 0x0600FF05 RID: 65285 RVA: 0x004696A8 File Offset: 0x00467AA8
		private void InitUI()
		{
			if (ClientApplication.racePlayerInfo.Length < 2)
			{
				Logger.LogError("init pk players num < 2");
				return;
			}
			RacePlayerInfo racePlayerInfo = ClientApplication.racePlayerInfo[0];
			if (racePlayerInfo == null)
			{
				Logger.LogError("init pk Left player is null");
				return;
			}
			RacePlayerInfo racePlayerInfo2 = ClientApplication.racePlayerInfo[1];
			if (racePlayerInfo2 == null)
			{
				Logger.LogError("init pk right player is null");
				return;
			}
			this.mLeftName.text = racePlayerInfo.name;
			this.mRightName.text = racePlayerInfo2.name;
			this.mLeftJob.text = Utility.GetJobName((int)racePlayerInfo.occupation, 0);
			this.mRightJob.text = Utility.GetJobName((int)racePlayerInfo2.occupation, 0);
			if (this.mLeftPerson)
			{
				JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)racePlayerInfo.occupation, string.Empty, string.Empty);
				if (tableItem != null && tableItem.JobPortrayal != string.Empty && tableItem.JobPortrayal != "-")
				{
					ETCImageLoader.LoadSprite(ref this.mLeftPerson, tableItem.JobPortrayal, true);
				}
			}
			if (this.mRightPerson)
			{
				JobTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)racePlayerInfo2.occupation, string.Empty, string.Empty);
				if (tableItem2 != null && tableItem2.JobPortrayal != string.Empty && tableItem2.JobPortrayal != "-")
				{
					ETCImageLoader.LoadSprite(ref this.mRightPerson, tableItem2.JobPortrayal, true);
				}
			}
			this.mLeftPkLv.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)racePlayerInfo.seasonLevel, true);
			this.mRightPkLv.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)racePlayerInfo2.seasonLevel, true);
			if (racePlayerInfo.guildName != string.Empty)
			{
				this.mLeftGuild.text = string.Format("公会:{0}", racePlayerInfo.guildName);
			}
			else
			{
				this.mLeftGuild.text = string.Empty;
			}
			if (racePlayerInfo2.guildName != string.Empty)
			{
				this.mRightGuild.text = string.Format("公会:{0}", racePlayerInfo2.guildName);
			}
			else
			{
				this.mRightGuild.text = string.Empty;
			}
			if (racePlayerInfo2.zoneId != racePlayerInfo.zoneId && racePlayerInfo2.zoneId != 0U && racePlayerInfo.zoneId != 0U)
			{
				this.mRightServerText.text = racePlayerInfo2.serverName;
				this.mLeftServerText.text = racePlayerInfo.serverName;
			}
			else
			{
				this.mRightServerText.text = string.Empty;
				this.mLeftServerText.text = string.Empty;
			}
			if (DataManager<GuildDataManager>.GetInstance().CurTargetCrossManorIDIsYGWZ())
			{
				this.mRightGuild.text = string.Empty;
				this.mLeftGuild.text = string.Empty;
				this.mRightServerText.text = string.Empty;
				this.mLeftServerText.text = string.Empty;
				if (racePlayerInfo.accid != ClientApplication.playerinfo.accid)
				{
					this.mLeftName.text = DataManager<GuildDataManager>.GetInstance().GuildPVPBattleHideName;
				}
				else if (racePlayerInfo2.accid != ClientApplication.playerinfo.accid)
				{
					this.mRightName.text = DataManager<GuildDataManager>.GetInstance().GuildPVPBattleHideName;
				}
			}
			this.frame.GetComponentsInChildren<DOTweenAnimation>();
		}

		// Token: 0x0600FF06 RID: 65286 RVA: 0x00469A10 File Offset: 0x00467E10
		protected void getAnimationTime()
		{
			List<DOTweenAnimation> list = ListPool<DOTweenAnimation>.Get();
			this.frame.GetComponentsInChildren<DOTweenAnimation>(list);
			this.animTime = 0f;
			for (int i = 0; i < list.Count; i++)
			{
				DOTweenAnimation dotweenAnimation = list[i];
				float num = dotweenAnimation.delay + dotweenAnimation.duration;
				if (this.animTime < num)
				{
					this.animTime = num;
				}
			}
			ListPool<DOTweenAnimation>.Release(list);
		}

		// Token: 0x0600FF07 RID: 65287 RVA: 0x00469A80 File Offset: 0x00467E80
		public IEnumerator LoadStartLoading()
		{
			float time = Time.realtimeSinceStartup;
			while (Time.realtimeSinceStartup - time < this.animTime)
			{
				yield return Yielders.EndOfFrame;
			}
			yield return Yielders.GetWaitForSeconds(0.5f);
			this.comBase.StartCoroutine(this.UpdateProgress());
			yield break;
		}

		// Token: 0x0600FF08 RID: 65288 RVA: 0x00469A9C File Offset: 0x00467E9C
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
					yield break;
				}
				yield return Yielders.EndOfFrame;
				this._targetProgress = (int)(Singleton<ClientSystemManager>.GetInstance().SwitchProgress * 100f);
			}
			yield break;
		}

		// Token: 0x0600FF09 RID: 65289 RVA: 0x00469AB8 File Offset: 0x00467EB8
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
			if (this.mLeftProgress == null || this.mRightProgress == null)
			{
				return;
			}
			this.mLeftProgress.value = (float)progress / 100f;
			this.mRightProgress.value = (float)progress / 100f;
			this.mLeftProgressText.text = string.Format("{0}%", progress);
			this.mRightProgressText.text = string.Format("{0}%", progress);
		}

		// Token: 0x0600FF0A RID: 65290 RVA: 0x00469B5C File Offset: 0x00467F5C
		protected override void _bindExUI()
		{
			this.mLeftGuild = this.mBind.GetCom<Text>("LeftGuild");
			this.mRightGuild = this.mBind.GetCom<Text>("RightGuild");
			this.mRightPerson = this.mBind.GetCom<Image>("RightPerson");
			this.mLeftPerson = this.mBind.GetCom<Image>("LeftPerson");
			this.mRightName = this.mBind.GetCom<Text>("RightName");
			this.mLeftName = this.mBind.GetCom<Text>("LeftName");
			this.mRightJob = this.mBind.GetCom<Text>("RightJob");
			this.mLeftJob = this.mBind.GetCom<Text>("LeftJob");
			this.mRightPkLv = this.mBind.GetCom<Text>("RightPkLv");
			this.mLeftPkLv = this.mBind.GetCom<Text>("LeftPkLv");
			this.mRightProgress = this.mBind.GetCom<Slider>("RightProgress");
			this.mLeftProgress = this.mBind.GetCom<Slider>("LeftProgress");
			this.mRightProgressText = this.mBind.GetCom<Text>("RightProgressText");
			this.mLeftProgressText = this.mBind.GetCom<Text>("LeftProgressText");
			this.mRightServerText = this.mBind.GetCom<Text>("RightServerText");
			this.mLeftServerText = this.mBind.GetCom<Text>("LeftServerText");
		}

		// Token: 0x0600FF0B RID: 65291 RVA: 0x00469CCC File Offset: 0x004680CC
		protected override void _unbindExUI()
		{
			this.mLeftGuild = null;
			this.mRightGuild = null;
			this.mRightPerson = null;
			this.mLeftPerson = null;
			this.mRightName = null;
			this.mLeftName = null;
			this.mRightJob = null;
			this.mLeftJob = null;
			this.mRightPkLv = null;
			this.mLeftPkLv = null;
			this.mRightProgress = null;
			this.mLeftProgress = null;
			this.mRightProgressText = null;
			this.mLeftProgressText = null;
			this.mRightServerText = null;
			this.mLeftServerText = null;
		}

		// Token: 0x0400A0D5 RID: 41173
		public float animTime;

		// Token: 0x0400A0D6 RID: 41174
		protected int _UpdateSpeed = 10;

		// Token: 0x0400A0D7 RID: 41175
		protected int _targetProgress;

		// Token: 0x0400A0D8 RID: 41176
		protected int _currentProgress = -1;

		// Token: 0x0400A0D9 RID: 41177
		private ComGameBase comBase;

		// Token: 0x0400A0DA RID: 41178
		private Text mLeftGuild;

		// Token: 0x0400A0DB RID: 41179
		private Text mRightGuild;

		// Token: 0x0400A0DC RID: 41180
		private Image mRightPerson;

		// Token: 0x0400A0DD RID: 41181
		private Image mLeftPerson;

		// Token: 0x0400A0DE RID: 41182
		private Text mRightName;

		// Token: 0x0400A0DF RID: 41183
		private Text mLeftName;

		// Token: 0x0400A0E0 RID: 41184
		private Text mRightJob;

		// Token: 0x0400A0E1 RID: 41185
		private Text mLeftJob;

		// Token: 0x0400A0E2 RID: 41186
		private Text mRightPkLv;

		// Token: 0x0400A0E3 RID: 41187
		private Text mLeftPkLv;

		// Token: 0x0400A0E4 RID: 41188
		private Slider mRightProgress;

		// Token: 0x0400A0E5 RID: 41189
		private Slider mLeftProgress;

		// Token: 0x0400A0E6 RID: 41190
		private Text mRightProgressText;

		// Token: 0x0400A0E7 RID: 41191
		private Text mLeftProgressText;

		// Token: 0x0400A0E8 RID: 41192
		private Text mRightServerText;

		// Token: 0x0400A0E9 RID: 41193
		private Text mLeftServerText;
	}
}
