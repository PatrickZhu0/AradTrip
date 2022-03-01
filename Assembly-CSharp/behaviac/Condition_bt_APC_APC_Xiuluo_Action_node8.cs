using System;

namespace behaviac
{
	// Token: 0x02001E32 RID: 7730
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Xiuluo_Action_node8 : Condition
	{
		// Token: 0x06012612 RID: 75282 RVA: 0x0055EB59 File Offset: 0x0055CF59
		public Condition_bt_APC_APC_Xiuluo_Action_node8()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x06012613 RID: 75283 RVA: 0x0055EB78 File Offset: 0x0055CF78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BFF9 RID: 49145
		private BE_Target opl_p0;

		// Token: 0x0400BFFA RID: 49146
		private BE_Equal opl_p1;

		// Token: 0x0400BFFB RID: 49147
		private BE_State opl_p2;
	}
}
