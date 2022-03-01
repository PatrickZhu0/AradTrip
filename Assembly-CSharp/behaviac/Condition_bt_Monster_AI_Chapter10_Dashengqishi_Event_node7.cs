using System;

namespace behaviac
{
	// Token: 0x020030E3 RID: 12515
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node7 : Condition
	{
		// Token: 0x06014A79 RID: 84601 RVA: 0x00638452 File Offset: 0x00636852
		public Condition_bt_Monster_AI_Chapter10_Dashengqishi_Event_node7()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522996;
		}

		// Token: 0x06014A7A RID: 84602 RVA: 0x00638474 File Offset: 0x00636874
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3E6 RID: 58342
		private BE_Target opl_p0;

		// Token: 0x0400E3E7 RID: 58343
		private BE_Equal opl_p1;

		// Token: 0x0400E3E8 RID: 58344
		private int opl_p2;
	}
}
