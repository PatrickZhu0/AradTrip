using System;

namespace behaviac
{
	// Token: 0x02001D06 RID: 7430
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Demian_Action_node16 : Condition
	{
		// Token: 0x060123D1 RID: 74705 RVA: 0x00550E3D File Offset: 0x0054F23D
		public Condition_bt_APC_APC_Demian_Action_node16()
		{
			this.opl_p0 = BE_Target.Enemy;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = BE_State.DAODI;
		}

		// Token: 0x060123D2 RID: 74706 RVA: 0x00550E5C File Offset: 0x0054F25C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BDC9 RID: 48585
		private BE_Target opl_p0;

		// Token: 0x0400BDCA RID: 48586
		private BE_Equal opl_p1;

		// Token: 0x0400BDCB RID: 48587
		private BE_State opl_p2;
	}
}
