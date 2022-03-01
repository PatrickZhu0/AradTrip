using System;

namespace behaviac
{
	// Token: 0x02003C96 RID: 15510
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node34 : Condition
	{
		// Token: 0x060160D3 RID: 90323 RVA: 0x006A9BBE File Offset: 0x006A7FBE
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaXianshi_Boss_ACTION_hard_node34()
		{
			this.opl_p0 = 5500;
			this.opl_p1 = 2000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060160D4 RID: 90324 RVA: 0x006A9BF4 File Offset: 0x006A7FF4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F96F RID: 63855
		private int opl_p0;

		// Token: 0x0400F970 RID: 63856
		private int opl_p1;

		// Token: 0x0400F971 RID: 63857
		private int opl_p2;

		// Token: 0x0400F972 RID: 63858
		private int opl_p3;
	}
}
