using System;

namespace behaviac
{
	// Token: 0x02001D2D RID: 7469
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Guiqi_Action_node8 : Condition
	{
		// Token: 0x0601241C RID: 74780 RVA: 0x00552E61 File Offset: 0x00551261
		public Condition_bt_APC_APC_Guiqi_Action_node8()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x0601241D RID: 74781 RVA: 0x00552E80 File Offset: 0x00551280
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BE0D RID: 48653
		private BE_Target opl_p0;

		// Token: 0x0400BE0E RID: 48654
		private BE_Equal opl_p1;

		// Token: 0x0400BE0F RID: 48655
		private BE_State opl_p2;
	}
}
