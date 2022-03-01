using System;

namespace behaviac
{
	// Token: 0x02003C9A RID: 15514
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node40 : Condition
	{
		// Token: 0x060160DB RID: 90331 RVA: 0x006A9D8B File Offset: 0x006A818B
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node40()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160DC RID: 90332 RVA: 0x006A9DC0 File Offset: 0x006A81C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F979 RID: 63865
		private int opl_p0;

		// Token: 0x0400F97A RID: 63866
		private int opl_p1;

		// Token: 0x0400F97B RID: 63867
		private int opl_p2;

		// Token: 0x0400F97C RID: 63868
		private int opl_p3;
	}
}
