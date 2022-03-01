using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C49 RID: 7241
	public class TeamDuplicationGridMapFightBeginView : MonoBehaviour
	{
		// Token: 0x06011C8E RID: 72846 RVA: 0x005353D7 File Offset: 0x005337D7
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011C8F RID: 72847 RVA: 0x005353E8 File Offset: 0x005337E8
		private void InitData()
		{
			this._countDownShowTime = DataManager<TeamDuplicationDataManager>.GetInstance().FightCountDownShowTimeWith65Level;
			this._countDownTotalTime = DataManager<TeamDuplicationDataManager>.GetInstance().FightCountDownTotalTimeWith65Level;
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

		// Token: 0x06011C90 RID: 72848 RVA: 0x00535446 File Offset: 0x00533846
		private void InitView()
		{
		}

		// Token: 0x06011C91 RID: 72849 RVA: 0x00535448 File Offset: 0x00533848
		private void Update()
		{
			this._intervalTime += Time.deltaTime;
			if (this._intervalTime >= 1f)
			{
				this.UpdateTime();
				this._intervalTime = 0f;
			}
		}

		// Token: 0x06011C92 RID: 72850 RVA: 0x00535480 File Offset: 0x00533880
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

		// Token: 0x06011C93 RID: 72851 RVA: 0x005354CC File Offset: 0x005338CC
		private void OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationGridFightBeginMessage, null, null, null, null);
			TeamDuplicationUtility.OnCloseTeamDuplicationGridMapFightBeginFrame();
		}

		// Token: 0x0400B94D RID: 47437
		private int _countDownShowTime;

		// Token: 0x0400B94E RID: 47438
		private int _countDownTotalTime;

		// Token: 0x0400B94F RID: 47439
		private float _intervalTime;
	}
}
