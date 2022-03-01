using System;

namespace behaviac
{
	// Token: 0x0200266D RID: 9837
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node37 : Condition
	{
		// Token: 0x0601361F RID: 79391 RVA: 0x005C492E File Offset: 0x005C2D2E
		public Condition_bt_AutoFight_AutoFight_Gunman_Qiangpao_Action_node37()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013620 RID: 79392 RVA: 0x005C4964 File Offset: 0x005C2D64
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D071 RID: 53361
		private int opl_p0;

		// Token: 0x0400D072 RID: 53362
		private int opl_p1;

		// Token: 0x0400D073 RID: 53363
		private int opl_p2;

		// Token: 0x0400D074 RID: 53364
		private int opl_p3;
	}
}
