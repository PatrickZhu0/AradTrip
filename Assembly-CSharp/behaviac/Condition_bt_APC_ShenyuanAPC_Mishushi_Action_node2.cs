using System;

namespace behaviac
{
	// Token: 0x02001E8B RID: 7819
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node2 : Condition
	{
		// Token: 0x060126C0 RID: 75456 RVA: 0x005633CC File Offset: 0x005617CC
		public Condition_bt_APC_ShenyuanAPC_Mishushi_Action_node2()
		{
			this.opl_p0 = 6500;
			this.opl_p1 = 500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060126C1 RID: 75457 RVA: 0x00563400 File Offset: 0x00561800
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C0AB RID: 49323
		private int opl_p0;

		// Token: 0x0400C0AC RID: 49324
		private int opl_p1;

		// Token: 0x0400C0AD RID: 49325
		private int opl_p2;

		// Token: 0x0400C0AE RID: 49326
		private int opl_p3;
	}
}
