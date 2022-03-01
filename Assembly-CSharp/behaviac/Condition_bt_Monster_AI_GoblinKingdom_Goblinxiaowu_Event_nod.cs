using System;

namespace behaviac
{
	// Token: 0x020032DA RID: 13018
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node2 : Condition
	{
		// Token: 0x06014E23 RID: 85539 RVA: 0x0064ADB0 File Offset: 0x006491B0
		public Condition_bt_Monster_AI_GoblinKingdom_Goblinxiaowu_Event_node2()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 29;
		}

		// Token: 0x06014E24 RID: 85540 RVA: 0x0064ADD0 File Offset: 0x006491D0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E700 RID: 59136
		private BE_Target opl_p0;

		// Token: 0x0400E701 RID: 59137
		private BE_Equal opl_p1;

		// Token: 0x0400E702 RID: 59138
		private int opl_p2;
	}
}
