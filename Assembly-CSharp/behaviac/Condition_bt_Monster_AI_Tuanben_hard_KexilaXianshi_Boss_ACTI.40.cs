using System;

namespace behaviac
{
	// Token: 0x02003C9D RID: 15517
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node43 : Condition
	{
		// Token: 0x060160E1 RID: 90337 RVA: 0x006A9EF6 File Offset: 0x006A82F6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node43()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160E2 RID: 90338 RVA: 0x006A9F2C File Offset: 0x006A832C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F980 RID: 63872
		private int opl_p0;

		// Token: 0x0400F981 RID: 63873
		private int opl_p1;

		// Token: 0x0400F982 RID: 63874
		private int opl_p2;

		// Token: 0x0400F983 RID: 63875
		private int opl_p3;
	}
}
