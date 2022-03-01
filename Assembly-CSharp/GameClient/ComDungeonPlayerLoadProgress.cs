using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001095 RID: 4245
	public class ComDungeonPlayerLoadProgress : MonoBehaviour
	{
		// Token: 0x06009FFC RID: 40956 RVA: 0x002014AD File Offset: 0x001FF8AD
		public void Awake()
		{
			this._bindEvent();
		}

		// Token: 0x06009FFD RID: 40957 RVA: 0x002014B5 File Offset: 0x001FF8B5
		public void OnDestroy()
		{
			this._unbindEvent();
		}

		// Token: 0x06009FFE RID: 40958 RVA: 0x002014BD File Offset: 0x001FF8BD
		private void _bindEvent()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.DungeonPlayerLoadProgressChanged, new ClientEventSystem.UIEventHandler(this._updatePlayerLoadProcess));
		}

		// Token: 0x06009FFF RID: 40959 RVA: 0x002014DA File Offset: 0x001FF8DA
		private void _unbindEvent()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.DungeonPlayerLoadProgressChanged, new ClientEventSystem.UIEventHandler(this._updatePlayerLoadProcess));
		}

		// Token: 0x0600A000 RID: 40960 RVA: 0x002014F7 File Offset: 0x001FF8F7
		public void SetSeat(byte seat)
		{
			this.mSeat = seat;
			this._updatePlayerBaseInfo();
			this._updatePlayerBaseLoadProcess();
		}

		// Token: 0x0600A001 RID: 40961 RVA: 0x0020150C File Offset: 0x001FF90C
		private void _updatePlayerBaseInfo()
		{
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
			if (playerBySeat == null)
			{
				return;
			}
			if (null != this.name)
			{
				this.name.text = playerBySeat.playerInfo.name;
			}
			if (null != this.level)
			{
				this.level.text = playerBySeat.playerInfo.level.ToString();
			}
			if (null != this.icon)
			{
				this._getHeadIcon(ref this.icon);
			}
			if (null != this.job)
			{
				this.job.text = Utility.GetJobName((int)playerBySeat.playerInfo.occupation, 0);
			}
			if (null != this.rankIcon)
			{
				string mainSeasonLevelSmallIcon = DataManager<SeasonDataManager>.GetInstance().GetMainSeasonLevelSmallIcon((int)playerBySeat.playerInfo.seasonLevel);
				ETCImageLoader.LoadSprite(ref this.rankIcon, mainSeasonLevelSmallIcon, true);
			}
			if (null != this.rankIconNumber)
			{
				ETCImageLoader.LoadSprite(ref this.rankIconNumber, DataManager<SeasonDataManager>.GetInstance().GetSubSeasonLevelIcon((int)playerBySeat.playerInfo.seasonLevel), true);
				this.rankIconNumber.SetNativeSize();
			}
			if (null != this.rankLevel)
			{
				this.rankLevel.text = DataManager<SeasonDataManager>.GetInstance().GetRankName((int)playerBySeat.playerInfo.seasonLevel, true);
			}
			if (this.replaceHeadPortraitFrame != null)
			{
				if (playerBySeat.playerInfo.playerLabelInfo.headFrame != 0U)
				{
					this.replaceHeadPortraitFrame.ReplacePhotoFrame((int)playerBySeat.playerInfo.playerLabelInfo.headFrame);
				}
				else
				{
					this.replaceHeadPortraitFrame.ReplacePhotoFrame(HeadPortraitFrameDataManager.iDefaultHeadPortraitID);
				}
			}
		}

		// Token: 0x0600A002 RID: 40962 RVA: 0x002016D4 File Offset: 0x001FFAD4
		private void _getHeadIcon(ref Image image)
		{
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
			if (playerBySeat == null)
			{
				return;
			}
			JobTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>((int)playerBySeat.playerInfo.occupation, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			ResTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ResTable>(tableItem.Mode, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			ETCImageLoader.LoadSprite(ref image, tableItem2.IconPath, true);
		}

		// Token: 0x0600A003 RID: 40963 RVA: 0x00201758 File Offset: 0x001FFB58
		private void _updatePlayerBaseLoadProcess()
		{
			BattlePlayer playerBySeat = BattleMain.instance.GetPlayerManager().GetPlayerBySeat(this.mSeat);
			if (playerBySeat == null)
			{
				return;
			}
			if (null == this.slider)
			{
				return;
			}
			this.slider.value = (float)playerBySeat.loadRate / 100f;
			if (null != this.progress)
			{
				this.progress.text = playerBySeat.loadRate.ToString();
			}
		}

		// Token: 0x0600A004 RID: 40964 RVA: 0x002017DC File Offset: 0x001FFBDC
		private void _updatePlayerLoadProcess(UIEvent ui)
		{
			this._updatePlayerBaseLoadProcess();
		}

		// Token: 0x0400589A RID: 22682
		public Text name;

		// Token: 0x0400589B RID: 22683
		public Text level;

		// Token: 0x0400589C RID: 22684
		public Image icon;

		// Token: 0x0400589D RID: 22685
		public Slider slider;

		// Token: 0x0400589E RID: 22686
		public Text progress;

		// Token: 0x0400589F RID: 22687
		public Text job;

		// Token: 0x040058A0 RID: 22688
		public Image rankIcon;

		// Token: 0x040058A1 RID: 22689
		public Image rankIconNumber;

		// Token: 0x040058A2 RID: 22690
		public Text rankLevel;

		// Token: 0x040058A3 RID: 22691
		public ReplaceHeadPortraitFrame replaceHeadPortraitFrame;

		// Token: 0x040058A4 RID: 22692
		private byte mSeat = byte.MaxValue;
	}
}
