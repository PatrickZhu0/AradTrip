using System;

namespace behaviac
{
	// Token: 0x020021C7 RID: 8647
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node48 : Condition
	{
		// Token: 0x06012D1D RID: 77085 RVA: 0x005892E3 File Offset: 0x005876E3
		public Condition_bt_AutoFight_AutoFight_Fight_Gunman_Manyou_veryhard_Action_node48()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06012D1E RID: 77086 RVA: 0x00589318 File Offset: 0x00587718
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C70F RID: 50959
		private int opl_p0;

		// Token: 0x0400C710 RID: 50960
		private int opl_p1;

		// Token: 0x0400C711 RID: 50961
		private int opl_p2;

		// Token: 0x0400C712 RID: 50962
		private int opl_p3;
	}
}
