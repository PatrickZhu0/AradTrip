using System;

namespace behaviac
{
	// Token: 0x02003479 RID: 13433
	[GeneratedTypeMetaInfo]
	internal class Action_bt_Monster_AI_Heisedadi_Juewang_Event_node38 : Action
	{
		// Token: 0x0601513B RID: 86331 RVA: 0x00659F67 File Offset: 0x00658367
		public Action_bt_Monster_AI_Heisedadi_Juewang_Event_node38()
		{
			this.m_resultOption = EBTStatus.BT_SUCCESS;
			this.method_p0 = BE_Target.Self;
			this.method_p1 = 521726;
			this.method_p2 = 0;
			this.method_p3 = 60;
			this.method_p4 = 0;
		}

		// Token: 0x0601513C RID: 86332 RVA: 0x00659F9E File Offset: 0x0065839E
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			((BTAgent)pAgent).Action_AddBuff(this.method_p0, this.method_p1, this.method_p2, this.method_p3, this.method_p4);
			return EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EA3A RID: 59962
		private BE_Target method_p0;

		// Token: 0x0400EA3B RID: 59963
		private int method_p1;

		// Token: 0x0400EA3C RID: 59964
		private int method_p2;

		// Token: 0x0400EA3D RID: 59965
		private int method_p3;

		// Token: 0x0400EA3E RID: 59966
		private int method_p4;
	}
}
