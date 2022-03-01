using System;

namespace behaviac
{
	// Token: 0x02003C1E RID: 15390
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node18 : Condition
	{
		// Token: 0x06015FE7 RID: 90087 RVA: 0x006A51F6 File Offset: 0x006A35F6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node18()
		{
			this.opl_p0 = 6500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015FE8 RID: 90088 RVA: 0x006A522C File Offset: 0x006A362C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F865 RID: 63589
		private int opl_p0;

		// Token: 0x0400F866 RID: 63590
		private int opl_p1;

		// Token: 0x0400F867 RID: 63591
		private int opl_p2;

		// Token: 0x0400F868 RID: 63592
		private int opl_p3;
	}
}
