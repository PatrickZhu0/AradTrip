using System;

namespace behaviac
{
	// Token: 0x02002487 RID: 9351
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8 : Condition
	{
		// Token: 0x0601325B RID: 78427 RVA: 0x005AEC7F File Offset: 0x005AD07F
		public Condition_bt_AutoFight_AutoFight_Fight_veryhard_Move_Jianhun_node8()
		{
			this.opl_p0 = 20000;
			this.opl_p1 = 20000;
			this.opl_p2 = 20000;
			this.opl_p3 = 20000;
		}

		// Token: 0x0601325C RID: 78428 RVA: 0x005AECB4 File Offset: 0x005AD0B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CC75 RID: 52341
		private int opl_p0;

		// Token: 0x0400CC76 RID: 52342
		private int opl_p1;

		// Token: 0x0400CC77 RID: 52343
		private int opl_p2;

		// Token: 0x0400CC78 RID: 52344
		private int opl_p3;
	}
}
