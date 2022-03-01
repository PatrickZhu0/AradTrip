using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C4F RID: 7247
	public class TeamDuplicationFightSceneLeaveTipView : MonoBehaviour
	{
		// Token: 0x06011CB8 RID: 72888 RVA: 0x005358F4 File Offset: 0x00533CF4
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011CB9 RID: 72889 RVA: 0x005358FC File Offset: 0x00533CFC
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x06011CBA RID: 72890 RVA: 0x00535904 File Offset: 0x00533D04
		private void BindUiEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
				this.backButton.onClick.AddListener(new UnityAction(this.OnBackButtonClick));
			}
		}

		// Token: 0x06011CBB RID: 72891 RVA: 0x00535943 File Offset: 0x00533D43
		private void UnBindUiEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011CBC RID: 72892 RVA: 0x00535966 File Offset: 0x00533D66
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011CBD RID: 72893 RVA: 0x00535974 File Offset: 0x00533D74
		private void InitData()
		{
			this._intervalTime = this.countDownTime;
			if (this._intervalTime < 10f)
			{
				this._intervalTime = 10f;
			}
		}

		// Token: 0x06011CBE RID: 72894 RVA: 0x0053599D File Offset: 0x00533D9D
		private void InitView()
		{
			if (this.contentLabel != null)
			{
				this.contentLabel.text = TR.Value("team_duplication_back_build_scene_by_leave_team");
			}
			this.UpdateCountDownTimeTipLabel((int)this._intervalTime);
		}

		// Token: 0x06011CBF RID: 72895 RVA: 0x005359D2 File Offset: 0x00533DD2
		private void UpdateCountDownTimeTipLabel(int time)
		{
			if (this.countDownTimeTipLabel != null)
			{
				this.countDownTimeTipLabel.text = string.Format(TR.Value("team_duplication_back_build_count_down_time_tip"), time.ToString());
			}
		}

		// Token: 0x06011CC0 RID: 72896 RVA: 0x00535A0C File Offset: 0x00533E0C
		private void Update()
		{
			this._intervalTime -= Time.deltaTime;
			if (this._intervalTime < 0f)
			{
				this.BackToBuildScene();
			}
			else
			{
				this.UpdateCountDownTimeTipLabel((int)(this._intervalTime + 1f));
			}
		}

		// Token: 0x06011CC1 RID: 72897 RVA: 0x00535A59 File Offset: 0x00533E59
		private void OnBackButtonClick()
		{
			this.BackToBuildScene();
		}

		// Token: 0x06011CC2 RID: 72898 RVA: 0x00535A61 File Offset: 0x00533E61
		private void BackToBuildScene()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFightSceneLeaveTipFrame();
			if (TeamDuplicationUtility.IsTeamDuplicationInFightScene())
			{
				TeamDuplicationUtility.BackToTeamDuplicationBuildScene();
			}
		}

		// Token: 0x0400B960 RID: 47456
		private float _intervalTime;

		// Token: 0x0400B961 RID: 47457
		[Space(25f)]
		[Header("content")]
		[Space(10f)]
		[SerializeField]
		private float countDownTime = 10f;

		// Token: 0x0400B962 RID: 47458
		[SerializeField]
		private Text contentLabel;

		// Token: 0x0400B963 RID: 47459
		[SerializeField]
		private Text countDownTimeTipLabel;

		// Token: 0x0400B964 RID: 47460
		[SerializeField]
		private Button backButton;
	}
}
