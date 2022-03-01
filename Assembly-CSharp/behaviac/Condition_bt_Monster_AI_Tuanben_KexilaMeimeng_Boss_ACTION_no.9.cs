using System;

namespace behaviac
{
	// Token: 0x02003A26 RID: 14886
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node18 : Condition
	{
		// Token: 0x06015C16 RID: 89110 RVA: 0x0069216E File Offset: 0x0069056E
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node18()
		{
			this.opl_p0 = 6500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06015C17 RID: 89111 RVA: 0x006921A4 File Offset: 0x006905A4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F52E RID: 62766
		private int opl_p0;

		// Token: 0x0400F52F RID: 62767
		private int opl_p1;

		// Token: 0x0400F530 RID: 62768
		private int opl_p2;

		// Token: 0x0400F531 RID: 62769
		private int opl_p3;
	}
}
