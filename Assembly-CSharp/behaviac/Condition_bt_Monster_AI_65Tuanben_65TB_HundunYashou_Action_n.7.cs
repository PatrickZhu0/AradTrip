using System;

namespace behaviac
{
	// Token: 0x02002B8C RID: 11148
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node20 : Condition
	{
		// Token: 0x06014024 RID: 81956 RVA: 0x006020FD File Offset: 0x006004FD
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node20()
		{
			this.opl_p0 = 6500;
			this.opl_p1 = 1500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06014025 RID: 81957 RVA: 0x00602134 File Offset: 0x00600534
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA1A RID: 55834
		private int opl_p0;

		// Token: 0x0400DA1B RID: 55835
		private int opl_p1;

		// Token: 0x0400DA1C RID: 55836
		private int opl_p2;

		// Token: 0x0400DA1D RID: 55837
		private int opl_p3;
	}
}
