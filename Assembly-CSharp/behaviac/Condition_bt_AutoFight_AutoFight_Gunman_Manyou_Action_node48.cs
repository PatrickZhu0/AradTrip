using System;

namespace behaviac
{
	// Token: 0x0200262E RID: 9774
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node48 : Condition
	{
		// Token: 0x060135A2 RID: 79266 RVA: 0x005C196F File Offset: 0x005BFD6F
		public Condition_bt_AutoFight_AutoFight_Gunman_Manyou_Action_node48()
		{
			this.opl_p0 = 2200;
			this.opl_p1 = 800;
			this.opl_p2 = 1400;
			this.opl_p3 = 1400;
		}

		// Token: 0x060135A3 RID: 79267 RVA: 0x005C19A4 File Offset: 0x005BFDA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CFEF RID: 53231
		private int opl_p0;

		// Token: 0x0400CFF0 RID: 53232
		private int opl_p1;

		// Token: 0x0400CFF1 RID: 53233
		private int opl_p2;

		// Token: 0x0400CFF2 RID: 53234
		private int opl_p3;
	}
}
