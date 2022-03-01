using System;

namespace behaviac
{
	// Token: 0x02003EB1 RID: 16049
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node13 : Condition
	{
		// Token: 0x060164E0 RID: 91360 RVA: 0x006BEC8A File Offset: 0x006BD08A
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node13()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164E1 RID: 91361 RVA: 0x006BECC0 File Offset: 0x006BD0C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD13 RID: 64787
		private int opl_p0;

		// Token: 0x0400FD14 RID: 64788
		private int opl_p1;

		// Token: 0x0400FD15 RID: 64789
		private int opl_p2;

		// Token: 0x0400FD16 RID: 64790
		private int opl_p3;
	}
}
