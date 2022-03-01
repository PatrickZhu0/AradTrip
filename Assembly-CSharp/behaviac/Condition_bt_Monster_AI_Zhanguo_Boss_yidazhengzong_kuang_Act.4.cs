using System;

namespace behaviac
{
	// Token: 0x02003EA8 RID: 16040
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node3 : Condition
	{
		// Token: 0x060164CE RID: 91342 RVA: 0x006BE846 File Offset: 0x006BCC46
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node3()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060164CF RID: 91343 RVA: 0x006BE87C File Offset: 0x006BCC7C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCFF RID: 64767
		private int opl_p0;

		// Token: 0x0400FD00 RID: 64768
		private int opl_p1;

		// Token: 0x0400FD01 RID: 64769
		private int opl_p2;

		// Token: 0x0400FD02 RID: 64770
		private int opl_p3;
	}
}
