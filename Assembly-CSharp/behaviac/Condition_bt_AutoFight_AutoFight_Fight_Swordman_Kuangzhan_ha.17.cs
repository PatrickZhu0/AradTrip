using System;

namespace behaviac
{
	// Token: 0x0200237D RID: 9085
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node38 : Condition
	{
		// Token: 0x06013061 RID: 77921 RVA: 0x005A0C37 File Offset: 0x0059F037
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node38()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06013062 RID: 77922 RVA: 0x005A0C6C File Offset: 0x0059F06C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA74 RID: 51828
		private int opl_p0;

		// Token: 0x0400CA75 RID: 51829
		private int opl_p1;

		// Token: 0x0400CA76 RID: 51830
		private int opl_p2;

		// Token: 0x0400CA77 RID: 51831
		private int opl_p3;
	}
}
