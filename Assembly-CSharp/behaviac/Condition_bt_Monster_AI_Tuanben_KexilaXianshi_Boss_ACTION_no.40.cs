using System;

namespace behaviac
{
	// Token: 0x02003A6B RID: 14955
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node43 : Condition
	{
		// Token: 0x06015C9F RID: 89247 RVA: 0x0069470E File Offset: 0x00692B0E
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node43()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015CA0 RID: 89248 RVA: 0x00694744 File Offset: 0x00692B44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5D2 RID: 62930
		private int opl_p0;

		// Token: 0x0400F5D3 RID: 62931
		private int opl_p1;

		// Token: 0x0400F5D4 RID: 62932
		private int opl_p2;

		// Token: 0x0400F5D5 RID: 62933
		private int opl_p3;
	}
}
