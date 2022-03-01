using System;

namespace behaviac
{
	// Token: 0x02003CA5 RID: 15525
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node64 : Condition
	{
		// Token: 0x060160F1 RID: 90353 RVA: 0x006AA243 File Offset: 0x006A8643
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node64()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 2500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x060160F2 RID: 90354 RVA: 0x006AA278 File Offset: 0x006A8678
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F996 RID: 63894
		private int opl_p0;

		// Token: 0x0400F997 RID: 63895
		private int opl_p1;

		// Token: 0x0400F998 RID: 63896
		private int opl_p2;

		// Token: 0x0400F999 RID: 63897
		private int opl_p3;
	}
}
