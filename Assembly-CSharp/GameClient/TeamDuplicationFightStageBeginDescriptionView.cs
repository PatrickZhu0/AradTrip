using System;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C53 RID: 7251
	public class TeamDuplicationFightStageBeginDescriptionView : MonoBehaviour
	{
		// Token: 0x06011CE0 RID: 72928 RVA: 0x0053601B File Offset: 0x0053441B
		public void Init(int stageId, bool isBegin = true)
		{
			this._stageId = stageId;
			this._isBegin = isBegin;
			this._curIntervalTime = 0f;
			this._lastIntervalTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationStageBeginIntervalTime;
			this._isCloseFrame = false;
			this.InitView();
		}

		// Token: 0x06011CE1 RID: 72929 RVA: 0x00536053 File Offset: 0x00534453
		private void InitView()
		{
			this.ResetStageRoot();
			if (this._stageId == 1)
			{
				CommonUtility.UpdateGameObjectVisible(this.firstStageRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.secondStageRoot, true);
			}
		}

		// Token: 0x06011CE2 RID: 72930 RVA: 0x00536084 File Offset: 0x00534484
		private void ResetStageRoot()
		{
			CommonUtility.UpdateGameObjectVisible(this.firstStageRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.secondStageRoot, false);
		}

		// Token: 0x06011CE3 RID: 72931 RVA: 0x0053609E File Offset: 0x0053449E
		private void Update()
		{
			if (this._isCloseFrame)
			{
				return;
			}
			if (this._curIntervalTime >= this._lastIntervalTime)
			{
				this.OnCloseFrame();
				this._isCloseFrame = true;
				return;
			}
			this._curIntervalTime += Time.deltaTime;
		}

		// Token: 0x06011CE4 RID: 72932 RVA: 0x005360E0 File Offset: 0x005344E0
		private void OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTeamDuplicationFightStageBeginMessage, this._stageId, null, null, null);
			if (this._stageId == 2)
			{
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationFightStageEndShowFinishMessage, null, null, null, null);
			}
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStageBeginDescriptionFrame();
		}

		// Token: 0x0400B96E RID: 47470
		private float _lastIntervalTime = 1f;

		// Token: 0x0400B96F RID: 47471
		private bool _isBegin;

		// Token: 0x0400B970 RID: 47472
		private int _stageId = 1;

		// Token: 0x0400B971 RID: 47473
		private float _curIntervalTime;

		// Token: 0x0400B972 RID: 47474
		private bool _isCloseFrame;

		// Token: 0x0400B973 RID: 47475
		[Space(15f)]
		[Header("Stage")]
		[Space(10f)]
		[SerializeField]
		private GameObject firstStageRoot;

		// Token: 0x0400B974 RID: 47476
		[SerializeField]
		private GameObject secondStageRoot;
	}
}
