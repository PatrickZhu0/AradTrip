using System;

namespace behaviac
{
	// Token: 0x02002DEC RID: 11756
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node12 : Condition
	{
		// Token: 0x060144B5 RID: 83125 RVA: 0x00618D66 File Offset: 0x00617166
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node12()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1500;
		}

		// Token: 0x060144B6 RID: 83126 RVA: 0x00618D9C File Offset: 0x0061719C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE6D RID: 56941
		private int opl_p0;

		// Token: 0x0400DE6E RID: 56942
		private int opl_p1;

		// Token: 0x0400DE6F RID: 56943
		private int opl_p2;

		// Token: 0x0400DE70 RID: 56944
		private int opl_p3;
	}
}
