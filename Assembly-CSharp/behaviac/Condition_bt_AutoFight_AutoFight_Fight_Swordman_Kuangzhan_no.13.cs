using System;

namespace behaviac
{
	// Token: 0x020023EF RID: 9199
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node30 : Condition
	{
		// Token: 0x0601313E RID: 78142 RVA: 0x005A7D1E File Offset: 0x005A611E
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_normal_Action_node30()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 0;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x0601313F RID: 78143 RVA: 0x005A7D50 File Offset: 0x005A6150
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CB68 RID: 52072
		private int opl_p0;

		// Token: 0x0400CB69 RID: 52073
		private int opl_p1;

		// Token: 0x0400CB6A RID: 52074
		private int opl_p2;

		// Token: 0x0400CB6B RID: 52075
		private int opl_p3;
	}
}
