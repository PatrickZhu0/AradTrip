using System;

namespace behaviac
{
	// Token: 0x02003A73 RID: 14963
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node64 : Condition
	{
		// Token: 0x06015CAF RID: 89263 RVA: 0x00694A5B File Offset: 0x00692E5B
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node64()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 2500;
			this.opl_p2 = 3000;
			this.opl_p3 = 3000;
		}

		// Token: 0x06015CB0 RID: 89264 RVA: 0x00694A90 File Offset: 0x00692E90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5E8 RID: 62952
		private int opl_p0;

		// Token: 0x0400F5E9 RID: 62953
		private int opl_p1;

		// Token: 0x0400F5EA RID: 62954
		private int opl_p2;

		// Token: 0x0400F5EB RID: 62955
		private int opl_p3;
	}
}
