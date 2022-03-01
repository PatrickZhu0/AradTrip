using System;

namespace behaviac
{
	// Token: 0x02002D3D RID: 11581
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node25 : Action
	{
		// Token: 0x0601435F RID: 82783 RVA: 0x00612491 File Offset: 0x00610891
		public Action_bt_Monster_AI_65Tuanben_65TB_YXG_Zhaohuan_JDYS_node25()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521973;
		}

		// Token: 0x06014360 RID: 82784 RVA: 0x006124B2 File Offset: 0x006108B2
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_RemoveBuff(this.method_p0, this.method_p1);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DD24 RID: 56612
		private BE_Target method_p0;

		// Token: 0x0400DD25 RID: 56613
		private int method_p1;
	}
}
