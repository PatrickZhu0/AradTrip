using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200193E RID: 6462
	public class PackageEquipPlanSwitchView : MonoBehaviour
	{
		// Token: 0x0600FB3A RID: 64314 RVA: 0x0044D8D6 File Offset: 0x0044BCD6
		private void Awake()
		{
			if (this.equipPlanButton != null)
			{
				this.equipPlanButton.onClick.RemoveAllListeners();
				this.equipPlanButton.onClick.AddListener(new UnityAction(this.OnEquipPlanButtonClick));
			}
		}

		// Token: 0x0600FB3B RID: 64315 RVA: 0x0044D915 File Offset: 0x0044BD15
		private void OnDestroy()
		{
			if (this.equipPlanButton != null)
			{
				this.equipPlanButton.onClick.RemoveAllListeners();
			}
			DataManager<EquipPlanDataManager>.GetInstance().EquipPlanSwitchCountDownLeftTime = 0f;
			DataManager<EquipPlanDataManager>.GetInstance().ResetUpdateCountDownTimeAction();
		}

		// Token: 0x0600FB3C RID: 64316 RVA: 0x0044D951 File Offset: 0x0044BD51
		private void OnEnable()
		{
			this.OnEnableEquipPlanController();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveEquipPlanSwitchMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveEquipPlanSwitchMessage));
			DataManager<EquipPlanDataManager>.GetInstance().SetUpdateCountDownTimeAction(new Action(this.UpdateEquipPlanSwitchState));
		}

		// Token: 0x0600FB3D RID: 64317 RVA: 0x0044D98A File Offset: 0x0044BD8A
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveEquipPlanSwitchMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveEquipPlanSwitchMessage));
			DataManager<EquipPlanDataManager>.GetInstance().ResetUpdateCountDownTimeAction();
		}

		// Token: 0x0600FB3E RID: 64318 RVA: 0x0044D9B1 File Offset: 0x0044BDB1
		private void OnEnableEquipPlanController()
		{
			this.UpdateEquipPlanButtonText();
			this.UpdateEquipPlanSwitchState();
		}

		// Token: 0x0600FB3F RID: 64319 RVA: 0x0044D9BF File Offset: 0x0044BDBF
		private void OnReceiveEquipPlanSwitchMessage(UIEvent uiEvent)
		{
			this.UpdateEquipPlanButtonText();
		}

		// Token: 0x0600FB40 RID: 64320 RVA: 0x0044D9C8 File Offset: 0x0044BDC8
		public void UpdateEquipPlanButtonText()
		{
			if (this.equipPlanButtonText == null)
			{
				return;
			}
			string equipPlanIdStr = EquipPlanUtility.GetEquipPlanIdStr(DataManager<EquipPlanDataManager>.GetInstance().CurrentSelectedEquipPlanId);
			string text = TR.Value("Equip_Plan_Format_String", equipPlanIdStr);
			this.equipPlanButtonText.text = text;
		}

		// Token: 0x0600FB41 RID: 64321 RVA: 0x0044DA10 File Offset: 0x0044BE10
		public void UpdateEquipPlanSwitchState()
		{
			float equipPlanSwitchCountDownLeftTime = DataManager<EquipPlanDataManager>.GetInstance().EquipPlanSwitchCountDownLeftTime;
			if (equipPlanSwitchCountDownLeftTime <= 0f)
			{
				CommonUtility.UpdateGameObjectVisible(this.countDownRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.countDownRoot, true);
			int num = Mathf.CeilToInt(equipPlanSwitchCountDownLeftTime);
			if (this.countDownTimeLabel != null)
			{
				this.countDownTimeLabel.text = num.ToString();
			}
			if (this.countDownImage != null)
			{
				float num2 = equipPlanSwitchCountDownLeftTime / 3f;
				if (num2 < 0f)
				{
					num2 = 0f;
				}
				else if (num2 > 1f)
				{
					num2 = 1f;
				}
				this.countDownImage.fillAmount = num2;
			}
		}

		// Token: 0x0600FB42 RID: 64322 RVA: 0x0044DAC8 File Offset: 0x0044BEC8
		private void OnEquipPlanButtonClick()
		{
			EquipPlanUtility.OnSwitchEquipPlanAction();
		}

		// Token: 0x04009CFF RID: 40191
		[Space(10f)]
		[Header("EquipPlanButton")]
		[Space(10f)]
		[SerializeField]
		private Text equipPlanButtonText;

		// Token: 0x04009D00 RID: 40192
		[SerializeField]
		private Button equipPlanButton;

		// Token: 0x04009D01 RID: 40193
		[Space(20f)]
		[Header("CountDownRoot")]
		[Space(10f)]
		[SerializeField]
		private GameObject countDownRoot;

		// Token: 0x04009D02 RID: 40194
		[SerializeField]
		private Image countDownImage;

		// Token: 0x04009D03 RID: 40195
		[SerializeField]
		private Text countDownTimeLabel;
	}
}
