using System;

namespace behaviac
{
	// Token: 0x02001E26 RID: 7718
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node2 : Condition
	{
		// Token: 0x060125FC RID: 75260 RVA: 0x0055E50E File Offset: 0x0055C90E
		public Condition_bt_APC_APC_Tiantangmanbuzhe_DestinationSelect_node2()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060125FD RID: 75261 RVA: 0x0055E52C File Offset: 0x0055C92C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFE6 RID: 49126
		private BE_Target opl_p0;

		// Token: 0x0400BFE7 RID: 49127
		private BE_Equal opl_p1;

		// Token: 0x0400BFE8 RID: 49128
		private BE_State opl_p2;
	}
}
