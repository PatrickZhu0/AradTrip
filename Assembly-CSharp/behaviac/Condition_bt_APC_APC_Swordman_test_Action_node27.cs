using System;

namespace behaviac
{
	// Token: 0x02001E09 RID: 7689
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Swordman_test_Action_node27 : Condition
	{
		// Token: 0x060125C5 RID: 75205 RVA: 0x0055CC75 File Offset: 0x0055B075
		public Condition_bt_APC_APC_Swordman_test_Action_node27()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060125C6 RID: 75206 RVA: 0x0055CC94 File Offset: 0x0055B094
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFB2 RID: 49074
		private BE_Target opl_p0;

		// Token: 0x0400BFB3 RID: 49075
		private BE_Equal opl_p1;

		// Token: 0x0400BFB4 RID: 49076
		private BE_State opl_p2;
	}
}
