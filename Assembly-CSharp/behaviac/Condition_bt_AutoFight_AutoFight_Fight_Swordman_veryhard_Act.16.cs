using System;

namespace behaviac
{
	// Token: 0x0200246C RID: 9324
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node65 : Condition
	{
		// Token: 0x06013228 RID: 78376 RVA: 0x005AD6DB File Offset: 0x005ABADB
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_veryhard_Action_node65()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 0;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06013229 RID: 78377 RVA: 0x005AD70C File Offset: 0x005ABB0C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC4B RID: 52299
		private int opl_p0;

		// Token: 0x0400CC4C RID: 52300
		private int opl_p1;

		// Token: 0x0400CC4D RID: 52301
		private int opl_p2;

		// Token: 0x0400CC4E RID: 52302
		private int opl_p3;
	}
}
