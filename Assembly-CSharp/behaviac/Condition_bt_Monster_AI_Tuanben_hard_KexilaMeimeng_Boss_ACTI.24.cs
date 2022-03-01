using System;

namespace behaviac
{
	// Token: 0x02003C2B RID: 15403
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node10 : Condition
	{
		// Token: 0x06016001 RID: 90113 RVA: 0x006A56E5 File Offset: 0x006A3AE5
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node10()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016002 RID: 90114 RVA: 0x006A571C File Offset: 0x006A3B1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F87D RID: 63613
		private int opl_p0;

		// Token: 0x0400F87E RID: 63614
		private int opl_p1;

		// Token: 0x0400F87F RID: 63615
		private int opl_p2;

		// Token: 0x0400F880 RID: 63616
		private int opl_p3;
	}
}
