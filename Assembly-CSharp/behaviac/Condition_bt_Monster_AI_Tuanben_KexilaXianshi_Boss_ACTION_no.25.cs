using System;

namespace behaviac
{
	// Token: 0x02003A56 RID: 14934
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node19 : Condition
	{
		// Token: 0x06015C75 RID: 89205 RVA: 0x00693D66 File Offset: 0x00692166
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node19()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C76 RID: 89206 RVA: 0x00693D9C File Offset: 0x0069219C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F59F RID: 62879
		private int opl_p0;

		// Token: 0x0400F5A0 RID: 62880
		private int opl_p1;

		// Token: 0x0400F5A1 RID: 62881
		private int opl_p2;

		// Token: 0x0400F5A2 RID: 62882
		private int opl_p3;
	}
}
