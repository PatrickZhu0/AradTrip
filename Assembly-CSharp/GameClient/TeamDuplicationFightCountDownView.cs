using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C4B RID: 7243
	public class TeamDuplicationFightCountDownView : MonoBehaviour
	{
		// Token: 0x06011C9A RID: 72858 RVA: 0x00535542 File Offset: 0x00533942
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011C9B RID: 72859 RVA: 0x00535550 File Offset: 0x00533950
		private void InitData()
		{
			this._countDownShowTime = DataManager<TeamDuplicationDataManager>.GetInstance().FightCountDownShowTime;
			this._countDownTotalTime = DataManager<TeamDuplicationDataManager>.GetInstance().FightCountDownTotalTime;
			if (this._countDownShowTime < 3)
			{
				this._countDownShowTime = 3;
			}
			if (this._countDownTotalTime < 6)
			{
				this._countDownTotalTime = 6;
			}
			this._intervalTime = 0f;
		}

		// Token: 0x06011C9C RID: 72860 RVA: 0x005355AE File Offset: 0x005339AE
		private void InitView()
		{
		}

		// Token: 0x06011C9D RID: 72861 RVA: 0x005355B0 File Offset: 0x005339B0
		private void Update()
		{
			this._intervalTime += Time.deltaTime;
			if (this._intervalTime >= 1f)
			{
				this.UpdateTime();
				this._intervalTime = 0f;
			}
		}

		// Token: 0x06011C9E RID: 72862 RVA: 0x005355E8 File Offset: 0x005339E8
		private void UpdateTime()
		{
			if (this._countDownShowTime > 0)
			{
				this._countDownShowTime--;
			}
			if (this._countDownTotalTime <= 0)
			{
				this.OnCloseFrame();
			}
			else
			{
				this._countDownTotalTime--;
			}
		}

		// Token: 0x06011C9F RID: 72863 RVA: 0x00535634 File Offset: 0x00533A34
		private void OnCloseFrame()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationFightStageBeginDescriptionFrame(DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageId);
			TeamDuplicationUtility.OnCloseTeamDuplicationFightCountDownFrame();
		}

		// Token: 0x0400B951 RID: 47441
		private int _countDownShowTime;

		// Token: 0x0400B952 RID: 47442
		private int _countDownTotalTime;

		// Token: 0x0400B953 RID: 47443
		private float _intervalTime;

		// Token: 0x0400B954 RID: 47444
		[Space(25f)]
		[Header("Root")]
		[Space(10f)]
		[SerializeField]
		private GameObject countDownRoot;

		// Token: 0x0400B955 RID: 47445
		[SerializeField]
		private GameObject fightBeginRoot;

		// Token: 0x0400B956 RID: 47446
		[Space(25f)]
		[Header("Image")]
		[Space(10f)]
		[SerializeField]
		private Image countDownTimeThreeImage;

		// Token: 0x0400B957 RID: 47447
		[SerializeField]
		private Image countDownTimeSecondImage;

		// Token: 0x0400B958 RID: 47448
		[SerializeField]
		private Image countDownTimeFirstImage;
	}
}
