using System;

namespace behaviac
{
	// Token: 0x0200263A RID: 9786
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node86 : Condition
	{
		// Token: 0x060135BA RID: 79290 RVA: 0x005C1E8B File Offset: 0x005C028B
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node86()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060135BB RID: 79291 RVA: 0x005C1EC0 File Offset: 0x005C02C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D007 RID: 53255
		private int opl_p0;

		// Token: 0x0400D008 RID: 53256
		private int opl_p1;

		// Token: 0x0400D009 RID: 53257
		private int opl_p2;

		// Token: 0x0400D00A RID: 53258
		private int opl_p3;
	}
}
