using System;

namespace behaviac
{
	// Token: 0x02002C67 RID: 11367
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node1 : Condition
	{
		// Token: 0x060141C7 RID: 82375 RVA: 0x0060A48E File Offset: 0x0060888E
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521985;
		}

		// Token: 0x060141C8 RID: 82376 RVA: 0x0060A4B0 File Offset: 0x006088B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB80 RID: 56192
		private BE_Target opl_p0;

		// Token: 0x0400DB81 RID: 56193
		private BE_Equal opl_p1;

		// Token: 0x0400DB82 RID: 56194
		private int opl_p2;
	}
}
