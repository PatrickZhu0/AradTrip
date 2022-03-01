using System;
using Protocol;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C55 RID: 7253
	public class TeamDuplicationFightStageEndDescriptionView : MonoBehaviour
	{
		// Token: 0x06011CEB RID: 72939 RVA: 0x005361CE File Offset: 0x005345CE
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x06011CEC RID: 72940 RVA: 0x005361D6 File Offset: 0x005345D6
		private void ClearData()
		{
			this._stageId = 0;
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011CED RID: 72941 RVA: 0x005361E6 File Offset: 0x005345E6
		public void Init(int stageId, bool isIn65LevelTeamDuplication = false, TC2PassType passTypeIn65LevelTeamDuplication = TC2PassType.TC_2_PASS_TYPE_COMMON)
		{
			this._stageId = stageId;
			this._isIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
			this._passType = passTypeIn65LevelTeamDuplication;
			this._curIntervalTime = 0f;
			this._lastIntervalTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationStageEndIntervalTime;
			this._isCloseFrame = false;
			this.InitView();
		}

		// Token: 0x06011CEE RID: 72942 RVA: 0x00536228 File Offset: 0x00534628
		private void InitView()
		{
			this.ResetStageRoot();
			if (this._isIn65LevelTeamDuplication)
			{
				CommonUtility.UpdateGameObjectVisible(this.stageWith65LevelRoot, true);
				string goPath = this.pathWith65LevelNormalTypeStr;
				if (this._passType == TC2PassType.TC_2_PASS_TYPE_WEAKEN)
				{
					goPath = this.pathWith65LevelWeakTypeStr;
				}
				else if (this._passType == TC2PassType.TC_2_PASS_TYPE_ENHANCE)
				{
					goPath = this.pathWith65LevelStrongTypeStr;
				}
				CommonUtility.LoadGameObjectWithPath(this.stageWith65LevelRoot, goPath);
			}
			else if (this._stageId == 2)
			{
				CommonUtility.UpdateGameObjectVisible(this.secondStageRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.firstStageRoot, true);
			}
		}

		// Token: 0x06011CEF RID: 72943 RVA: 0x005362BF File Offset: 0x005346BF
		private void ResetStageRoot()
		{
			CommonUtility.UpdateGameObjectVisible(this.firstStageRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.secondStageRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.stageWith65LevelRoot, false);
		}

		// Token: 0x06011CF0 RID: 72944 RVA: 0x005362E5 File Offset: 0x005346E5
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

		// Token: 0x06011CF1 RID: 72945 RVA: 0x00536324 File Offset: 0x00534724
		private void OnCloseFrame()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveTeamDuplicationStageEndDescriptionCloseMessage, this._stageId, this._passType, null, null);
			TeamDuplicationUtility.OnCloseTeamDuplicationFightStageEndDescriptionFrame();
		}

		// Token: 0x0400B976 RID: 47478
		private float _lastIntervalTime = 1f;

		// Token: 0x0400B977 RID: 47479
		private bool _isBegin;

		// Token: 0x0400B978 RID: 47480
		private int _stageId = 1;

		// Token: 0x0400B979 RID: 47481
		private float _curIntervalTime;

		// Token: 0x0400B97A RID: 47482
		private bool _isCloseFrame;

		// Token: 0x0400B97B RID: 47483
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B97C RID: 47484
		private TC2PassType _passType;

		// Token: 0x0400B97D RID: 47485
		[Space(15f)]
		[Header("Stage")]
		[Space(10f)]
		[SerializeField]
		private GameObject firstStageRoot;

		// Token: 0x0400B97E RID: 47486
		[SerializeField]
		private GameObject secondStageRoot;

		// Token: 0x0400B97F RID: 47487
		[Space(15f)]
		[Header("65Level")]
		[Space(10f)]
		[SerializeField]
		private GameObject stageWith65LevelRoot;

		// Token: 0x0400B980 RID: 47488
		[SerializeField]
		private string pathWith65LevelNormalTypeStr;

		// Token: 0x0400B981 RID: 47489
		[SerializeField]
		private string pathWith65LevelWeakTypeStr;

		// Token: 0x0400B982 RID: 47490
		[SerializeField]
		private string pathWith65LevelStrongTypeStr;
	}
}
