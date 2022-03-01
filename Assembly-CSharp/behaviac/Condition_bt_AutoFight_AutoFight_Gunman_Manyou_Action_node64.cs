using System;

namespace behaviac
{
	// Token: 0x02002614 RID: 9748
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node64 : Condition
	{
		// Token: 0x0601356E RID: 79214 RVA: 0x005C0D9F File Offset: 0x005BF19F
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node64()
		{
			this.opl_p0 = 2200;
			this.opl_p1 = 2200;
			this.opl_p2 = 2200;
			this.opl_p3 = 2200;
		}

		// Token: 0x0601356F RID: 79215 RVA: 0x005C0DD4 File Offset: 0x005BF1D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFB9 RID: 53177
		private int opl_p0;

		// Token: 0x0400CFBA RID: 53178
		private int opl_p1;

		// Token: 0x0400CFBB RID: 53179
		private int opl_p2;

		// Token: 0x0400CFBC RID: 53180
		private int opl_p3;
	}
}
