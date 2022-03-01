using System;

namespace behaviac
{
	// Token: 0x02003EE2 RID: 16098
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node22 : Condition
	{
		// Token: 0x0601653F RID: 91455 RVA: 0x006C1475 File Offset: 0x006BF875
		public Condition_bt_Monster_AI_Zhanguo_Chenhao_yidazhengzong_kuang_Action_node22()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x06016540 RID: 91456 RVA: 0x006C14AC File Offset: 0x006BF8AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD6F RID: 64879
		private int opl_p0;

		// Token: 0x0400FD70 RID: 64880
		private int opl_p1;

		// Token: 0x0400FD71 RID: 64881
		private int opl_p2;

		// Token: 0x0400FD72 RID: 64882
		private int opl_p3;
	}
}
