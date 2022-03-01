using System;

namespace behaviac
{
	// Token: 0x020034CB RID: 13515
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node41 : Condition
	{
		// Token: 0x060151DC RID: 86492 RVA: 0x0065C82B File Offset: 0x0065AC2B
		public Condition_bt_Monster_AI_Heisedadi_Kongbu_Event_node41()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521721;
		}

		// Token: 0x060151DD RID: 86493 RVA: 0x0065C84C File Offset: 0x0065AC4C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EAEA RID: 60138
		private BE_Target opl_p0;

		// Token: 0x0400EAEB RID: 60139
		private BE_Equal opl_p1;

		// Token: 0x0400EAEC RID: 60140
		private int opl_p2;
	}
}
