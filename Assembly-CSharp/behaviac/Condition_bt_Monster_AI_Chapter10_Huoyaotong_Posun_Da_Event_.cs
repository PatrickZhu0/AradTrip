using System;

namespace behaviac
{
	// Token: 0x02003117 RID: 12567
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Da_Event_node1 : Condition
	{
		// Token: 0x06014AD6 RID: 84694 RVA: 0x0063A14A File Offset: 0x0063854A
		public Condition_bt_Monster_AI_Chapter10_Huoyaotong_Posun_Da_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522064;
		}

		// Token: 0x06014AD7 RID: 84695 RVA: 0x0063A16C File Offset: 0x0063856C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E443 RID: 58435
		private BE_Target opl_p0;

		// Token: 0x0400E444 RID: 58436
		private BE_Equal opl_p1;

		// Token: 0x0400E445 RID: 58437
		private int opl_p2;
	}
}
