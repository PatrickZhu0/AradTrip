using System;

namespace behaviac
{
	// Token: 0x02003EA4 RID: 16036
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node18 : Condition
	{
		// Token: 0x060164C6 RID: 91334 RVA: 0x006BE691 File Offset: 0x006BCA91
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node18()
		{
			this.opl_p0 = 10000;
			this.opl_p1 = 10000;
			this.opl_p2 = 10000;
			this.opl_p3 = 10000;
		}

		// Token: 0x060164C7 RID: 91335 RVA: 0x006BE6C8 File Offset: 0x006BCAC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCF7 RID: 64759
		private int opl_p0;

		// Token: 0x0400FCF8 RID: 64760
		private int opl_p1;

		// Token: 0x0400FCF9 RID: 64761
		private int opl_p2;

		// Token: 0x0400FCFA RID: 64762
		private int opl_p3;
	}
}
