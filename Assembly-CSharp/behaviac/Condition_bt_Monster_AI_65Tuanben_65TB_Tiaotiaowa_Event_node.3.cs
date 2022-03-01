using System;

namespace behaviac
{
	// Token: 0x02002D10 RID: 11536
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node12 : Condition
	{
		// Token: 0x0601430E RID: 82702 RVA: 0x00610B23 File Offset: 0x0060EF23
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node12()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 506409;
		}

		// Token: 0x0601430F RID: 82703 RVA: 0x00610B44 File Offset: 0x0060EF44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCBA RID: 56506
		private BE_Target opl_p0;

		// Token: 0x0400DCBB RID: 56507
		private BE_Equal opl_p1;

		// Token: 0x0400DCBC RID: 56508
		private int opl_p2;
	}
}
