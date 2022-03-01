using System;

namespace behaviac
{
	// Token: 0x02002656 RID: 9814
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node58 : Condition
	{
		// Token: 0x060135F1 RID: 79345 RVA: 0x005C3F36 File Offset: 0x005C2336
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node58()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060135F2 RID: 79346 RVA: 0x005C3F6C File Offset: 0x005C236C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D040 RID: 53312
		private int opl_p0;

		// Token: 0x0400D041 RID: 53313
		private int opl_p1;

		// Token: 0x0400D042 RID: 53314
		private int opl_p2;

		// Token: 0x0400D043 RID: 53315
		private int opl_p3;
	}
}
