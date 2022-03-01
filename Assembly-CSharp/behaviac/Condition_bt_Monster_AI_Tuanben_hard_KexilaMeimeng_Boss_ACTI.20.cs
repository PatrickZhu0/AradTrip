using System;

namespace behaviac
{
	// Token: 0x02003C22 RID: 15394
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node14 : Condition
	{
		// Token: 0x06015FEF RID: 90095 RVA: 0x006A53C6 File Offset: 0x006A37C6
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node14()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015FF0 RID: 90096 RVA: 0x006A53FC File Offset: 0x006A37FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F86F RID: 63599
		private int opl_p0;

		// Token: 0x0400F870 RID: 63600
		private int opl_p1;

		// Token: 0x0400F871 RID: 63601
		private int opl_p2;

		// Token: 0x0400F872 RID: 63602
		private int opl_p3;
	}
}
