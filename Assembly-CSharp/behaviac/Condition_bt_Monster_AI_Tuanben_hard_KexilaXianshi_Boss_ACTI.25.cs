using System;

namespace behaviac
{
	// Token: 0x02003C88 RID: 15496
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node19 : Condition
	{
		// Token: 0x060160B7 RID: 90295 RVA: 0x006A954E File Offset: 0x006A794E
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node19()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160B8 RID: 90296 RVA: 0x006A9584 File Offset: 0x006A7984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F94D RID: 63821
		private int opl_p0;

		// Token: 0x0400F94E RID: 63822
		private int opl_p1;

		// Token: 0x0400F94F RID: 63823
		private int opl_p2;

		// Token: 0x0400F950 RID: 63824
		private int opl_p3;
	}
}
