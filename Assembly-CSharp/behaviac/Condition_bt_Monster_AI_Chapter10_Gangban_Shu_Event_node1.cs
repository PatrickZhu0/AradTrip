using System;

namespace behaviac
{
	// Token: 0x02003103 RID: 12547
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node1 : Condition
	{
		// Token: 0x06014AB2 RID: 84658 RVA: 0x00639600 File Offset: 0x00637A00
		public Condition_bt_Monster_AI_Chapter10_Gangban_Shu_Event_node1()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522065;
		}

		// Token: 0x06014AB3 RID: 84659 RVA: 0x00639624 File Offset: 0x00637A24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E425 RID: 58405
		private BE_Target opl_p0;

		// Token: 0x0400E426 RID: 58406
		private BE_Equal opl_p1;

		// Token: 0x0400E427 RID: 58407
		private int opl_p2;
	}
}
