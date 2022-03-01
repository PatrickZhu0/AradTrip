using System;

namespace behaviac
{
	// Token: 0x02003299 RID: 12953
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Digongfuben_Digong_Xianjing_Event_node3 : Action
	{
		// Token: 0x06014DAB RID: 85419 RVA: 0x0064832D File Offset: 0x0064672D
		public Action_bt_Monster_AI_Digongfuben_Digong_Xianjing_Event_node3()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = "危险区域！请注意躲避熔岩攻击！";
			this.method_p1 = 15f;
			this.method_p2 = 2;
		}

		// Token: 0x06014DAC RID: 85420 RVA: 0x00648359 File Offset: 0x00646759
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_ShowHeadText(this.method_p0, this.method_p1, this.method_p2);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E69F RID: 59039
		private string method_p0;

		// Token: 0x0400E6A0 RID: 59040
		private float method_p1;

		// Token: 0x0400E6A1 RID: 59041
		private int method_p2;
	}
}
