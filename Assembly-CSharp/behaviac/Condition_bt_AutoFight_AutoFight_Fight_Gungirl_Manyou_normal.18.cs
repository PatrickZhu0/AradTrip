using System;

namespace behaviac
{
	// Token: 0x0200205B RID: 8283
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node43 : Condition
	{
		// Token: 0x06012A50 RID: 76368 RVA: 0x00577E83 File Offset: 0x00576283
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_Manyou_normal_Action_node43()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06012A51 RID: 76369 RVA: 0x00577EB8 File Offset: 0x005762B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C442 RID: 50242
		private int opl_p0;

		// Token: 0x0400C443 RID: 50243
		private int opl_p1;

		// Token: 0x0400C444 RID: 50244
		private int opl_p2;

		// Token: 0x0400C445 RID: 50245
		private int opl_p3;
	}
}
