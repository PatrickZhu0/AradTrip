using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200150A RID: 5386
	public class ChampionshipMainPlayGroupView : MonoBehaviour
	{
		// Token: 0x0600D133 RID: 53555 RVA: 0x0033A00B File Offset: 0x0033840B
		private void OnDestroy()
		{
			this.ClearData();
		}

		// Token: 0x0600D134 RID: 53556 RVA: 0x0033A013 File Offset: 0x00338413
		private void OnEnable()
		{
		}

		// Token: 0x0600D135 RID: 53557 RVA: 0x0033A015 File Offset: 0x00338415
		private void OnDisable()
		{
			this.ResetCountDownTimeController();
		}

		// Token: 0x0600D136 RID: 53558 RVA: 0x0033A01D File Offset: 0x0033841D
		private void ClearData()
		{
		}

		// Token: 0x0600D137 RID: 53559 RVA: 0x0033A020 File Offset: 0x00338420
		public void InitPlayerGroupView()
		{
			if (this.contentLabel != null)
			{
				string arg = TR.Value("Championship_Fight_Group_Format", DataManager<ChampionshipDataManager>.GetInstance().ChampionshipScoreFightGroupId);
				string originalStr = TR.Value("Championship_Fight_Group_Notice_Content", arg);
				string finalStringByUpdateChangeLineFlag = CommonUtility.GetFinalStringByUpdateChangeLineFlag(originalStr);
				this.contentLabel.text = finalStringByUpdateChangeLineFlag;
			}
			if (this.countDownTimeController != null)
			{
				uint endTime = 3U + DataManager<TimeManager>.GetInstance().GetServerTime();
				this.countDownTimeController.SetCountDownTimeController(endTime, new OnCountDownTimeCallback(this.OnCountDownTimeEndCallBack));
			}
		}

		// Token: 0x0600D138 RID: 53560 RVA: 0x0033A0AD File Offset: 0x003384AD
		private void ResetCountDownTimeController()
		{
			if (this.countDownTimeController != null)
			{
				this.countDownTimeController.ResetCountDownTimeController();
			}
		}

		// Token: 0x0600D139 RID: 53561 RVA: 0x0033A0CB File Offset: 0x003384CB
		private void OnCountDownTimeEndCallBack()
		{
			Object.Destroy(base.gameObject);
		}

		// Token: 0x04007A78 RID: 31352
		[Space(10f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text contentLabel;

		// Token: 0x04007A79 RID: 31353
		[SerializeField]
		private CountDownTimeController countDownTimeController;
	}
}
