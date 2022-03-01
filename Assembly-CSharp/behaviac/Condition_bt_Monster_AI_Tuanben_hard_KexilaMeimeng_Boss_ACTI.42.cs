using System;

namespace behaviac
{
	// Token: 0x02003C48 RID: 15432
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node64 : Condition
	{
		// Token: 0x0601603A RID: 90170 RVA: 0x006A6E62 File Offset: 0x006A5262
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node64()
		{
			this.opl_p0 = 3500;
			this.opl_p1 = 2500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601603B RID: 90171 RVA: 0x006A6E98 File Offset: 0x006A5298
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8B0 RID: 63664
		private int opl_p0;

		// Token: 0x0400F8B1 RID: 63665
		private int opl_p1;

		// Token: 0x0400F8B2 RID: 63666
		private int opl_p2;

		// Token: 0x0400F8B3 RID: 63667
		private int opl_p3;
	}
}
