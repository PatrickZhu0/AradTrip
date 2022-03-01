using System;

namespace behaviac
{
	// Token: 0x02003EB9 RID: 16057
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node22 : Condition
	{
		// Token: 0x060164F0 RID: 91376 RVA: 0x006BF106 File Offset: 0x006BD506
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node22()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164F1 RID: 91377 RVA: 0x006BF13C File Offset: 0x006BD53C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD23 RID: 64803
		private int opl_p0;

		// Token: 0x0400FD24 RID: 64804
		private int opl_p1;

		// Token: 0x0400FD25 RID: 64805
		private int opl_p2;

		// Token: 0x0400FD26 RID: 64806
		private int opl_p3;
	}
}
