using System;
using GameClient;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

// Token: 0x02000EEF RID: 3823
[RequireComponent(typeof(Button))]
public class ComGoToMallButton : MonoBehaviour
{
	// Token: 0x060095AF RID: 38319 RVA: 0x001C4156 File Offset: 0x001C2556
	private void Awake()
	{
		this.mButton = base.GetComponent<Button>();
		this.mButton.onClick.AddListener(new UnityAction(this.OnButtonClick));
	}

	// Token: 0x060095B0 RID: 38320 RVA: 0x001C4180 File Offset: 0x001C2580
	private void OnDestroy()
	{
		this.mButton.onClick.RemoveListener(new UnityAction(this.OnButtonClick));
	}

	// Token: 0x060095B1 RID: 38321 RVA: 0x001C41A0 File Offset: 0x001C25A0
	private void OnButtonClick()
	{
		MallNewFrameParamData mallNewFrameParamData = new MallNewFrameParamData();
		if (this.Param.MainTab == MallType.Gift)
		{
			mallNewFrameParamData.MallNewType = MallNewType.LimitTimeMall;
		}
		else if (this.Param.MainTab == MallType.Recharge)
		{
			mallNewFrameParamData.MallNewType = MallNewType.ReChargeMall;
		}
		else if (this.Param.MainTab == MallType.FashionMall)
		{
			mallNewFrameParamData.MallNewType = MallNewType.FashionMall;
		}
		else
		{
			mallNewFrameParamData.MallNewType = MallNewType.PropertyMall;
		}
		mallNewFrameParamData.Index = this.Param.SubTab;
		Singleton<ClientSystemManager>.GetInstance().OpenFrame<MallNewFrame>(FrameLayer.Middle, mallNewFrameParamData, string.Empty);
	}

	// Token: 0x04004C98 RID: 19608
	[SerializeField]
	private OutComeData Param;

	// Token: 0x04004C99 RID: 19609
	private Button mButton;
}
