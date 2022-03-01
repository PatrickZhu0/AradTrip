using System;

namespace behaviac
{
	// Token: 0x02002BC8 RID: 11208
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2 : Action
	{
		// Token: 0x06014092 RID: 82066 RVA: 0x00604906 File Offset: 0x00602D06
		public Action_bt_Monster_AI_65Tuanben_65TB_Saiche_huoyaotong_Event_node2()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 522223;
			this.method_p2 = 1000;
			this.method_p3 = 65;
			this.method_p4 = 0;
		}

		// Token: 0x06014093 RID: 82067 RVA: 0x00604941 File Offset: 0x00602D41
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA81 RID: 55937
		private BE_Target method_p0;

		// Token: 0x0400DA82 RID: 55938
		private int method_p1;

		// Token: 0x0400DA83 RID: 55939
		private int method_p2;

		// Token: 0x0400DA84 RID: 55940
		private int method_p3;

		// Token: 0x0400DA85 RID: 55941
		private int method_p4;
	}
}
