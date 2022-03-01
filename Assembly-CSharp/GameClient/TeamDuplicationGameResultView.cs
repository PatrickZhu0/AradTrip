using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CA7 RID: 7335
	public class TeamDuplicationGameResultView : MonoBehaviour
	{
		// Token: 0x0601200D RID: 73741 RVA: 0x005434E1 File Offset: 0x005418E1
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x0601200E RID: 73742 RVA: 0x005434E9 File Offset: 0x005418E9
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ResetCloseFrameCountDownController();
		}

		// Token: 0x0601200F RID: 73743 RVA: 0x005434F8 File Offset: 0x005418F8
		private void BindUiEvents()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(new OnCountDownTimeCallback(this.OnCloseFrame));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseFrame));
			}
		}

		// Token: 0x06012010 RID: 73744 RVA: 0x0054356A File Offset: 0x0054196A
		private void UnBindUiEvents()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.SetCountDownTimeCallback(null);
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06012011 RID: 73745 RVA: 0x005435AC File Offset: 0x005419AC
		public void Init(bool isSuccess = false)
		{
			MonoSingleton<AudioManager>.instance.PlaySound(5065);
			if (isSuccess)
			{
				CommonUtility.UpdateGameObjectVisible(this.gameFailRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.gameSucceedRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.gameSucceedRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.gameFailRoot, true);
			}
			this.SetCloseFrameCountDownController();
		}

		// Token: 0x06012012 RID: 73746 RVA: 0x0054360A File Offset: 0x00541A0A
		private void SetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController == null)
			{
				return;
			}
			this.closeCountDownTimeController.EndTime = DataManager<TimeManager>.GetInstance().GetServerTime() + (uint)DataManager<TeamDuplicationDataManager>.GetInstance().GameResultShowTime;
			this.closeCountDownTimeController.InitCountDownTimeController();
		}

		// Token: 0x06012013 RID: 73747 RVA: 0x00543649 File Offset: 0x00541A49
		private void ResetCloseFrameCountDownController()
		{
			if (this.closeCountDownTimeController != null)
			{
				this.closeCountDownTimeController.ResetCountDownTimeController();
			}
		}

		// Token: 0x06012014 RID: 73748 RVA: 0x00543667 File Offset: 0x00541A67
		private void OnCloseFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationGameResultFrame();
		}

		// Token: 0x06012015 RID: 73749 RVA: 0x0054366E File Offset: 0x00541A6E
		private void OrderShowFinish()
		{
			CommonUtility.UpdateButtonVisible(this.closeButton, true);
		}

		// Token: 0x0400BBA7 RID: 48039
		[Space(25f)]
		[Header("GameResult")]
		[Space(15f)]
		[SerializeField]
		private GameObject gameSucceedRoot;

		// Token: 0x0400BBA8 RID: 48040
		[SerializeField]
		private CommonGameObjectOrderShowControl succeedOrderShowControl;

		// Token: 0x0400BBA9 RID: 48041
		[SerializeField]
		private GameObject gameFailRoot;

		// Token: 0x0400BBAA RID: 48042
		[SerializeField]
		private CommonGameObjectOrderShowControl failedOrderShowControl;

		// Token: 0x0400BBAB RID: 48043
		[Space(25f)]
		[Header("CloseCountDownTimeController")]
		[Space(15f)]
		[SerializeField]
		private CountDownTimeController closeCountDownTimeController;

		// Token: 0x0400BBAC RID: 48044
		[SerializeField]
		private Button closeButton;
	}
}
