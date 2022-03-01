using System;

namespace behaviac
{
	// Token: 0x02002669 RID: 9833
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node46 : Condition
	{
		// Token: 0x06013617 RID: 79383 RVA: 0x005C477A File Offset: 0x005C2B7A
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node46()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013618 RID: 79384 RVA: 0x005C47B0 File Offset: 0x005C2BB0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D069 RID: 53353
		private int opl_p0;

		// Token: 0x0400D06A RID: 53354
		private int opl_p1;

		// Token: 0x0400D06B RID: 53355
		private int opl_p2;

		// Token: 0x0400D06C RID: 53356
		private int opl_p3;
	}
}
