using System;

namespace behaviac
{
	// Token: 0x02003A76 RID: 14966
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node68 : Condition
	{
		// Token: 0x06015CB5 RID: 89269 RVA: 0x00694BC6 File Offset: 0x00692FC6
		public Condition_bt_Monster_AI_Tuanben_KexilaXianshi_Boss_ACTION_node68()
		{
			this.opl_p0 = 6700;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015CB6 RID: 89270 RVA: 0x00694BFC File Offset: 0x00692FFC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F5EF RID: 62959
		private int opl_p0;

		// Token: 0x0400F5F0 RID: 62960
		private int opl_p1;

		// Token: 0x0400F5F1 RID: 62961
		private int opl_p2;

		// Token: 0x0400F5F2 RID: 62962
		private int opl_p3;
	}
}
