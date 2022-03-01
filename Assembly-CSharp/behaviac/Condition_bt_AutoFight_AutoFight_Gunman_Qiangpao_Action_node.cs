using System;

namespace behaviac
{
	// Token: 0x0200263E RID: 9790
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node50 : Condition
	{
		// Token: 0x060135C1 RID: 79297 RVA: 0x005C358B File Offset: 0x005C198B
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node50()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060135C2 RID: 79298 RVA: 0x005C35C0 File Offset: 0x005C19C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D00E RID: 53262
		private int opl_p0;

		// Token: 0x0400D00F RID: 53263
		private int opl_p1;

		// Token: 0x0400D010 RID: 53264
		private int opl_p2;

		// Token: 0x0400D011 RID: 53265
		private int opl_p3;
	}
}
