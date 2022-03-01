using System;

namespace behaviac
{
	// Token: 0x020023E5 RID: 9189
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node16 : Condition
	{
		// Token: 0x0601312C RID: 78124 RVA: 0x005A793A File Offset: 0x005A5D3A
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node16()
		{
			this.opl_p0 = 2500;
			this.opl_p1 = 3000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x0601312D RID: 78125 RVA: 0x005A7970 File Offset: 0x005A5D70
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB58 RID: 52056
		private int opl_p0;

		// Token: 0x0400CB59 RID: 52057
		private int opl_p1;

		// Token: 0x0400CB5A RID: 52058
		private int opl_p2;

		// Token: 0x0400CB5B RID: 52059
		private int opl_p3;
	}
}
