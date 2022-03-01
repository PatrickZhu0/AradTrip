using System;

namespace behaviac
{
	// Token: 0x02003EA9 RID: 16041
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node2 : Condition
	{
		// Token: 0x060164D0 RID: 91344 RVA: 0x006BE8C1 File Offset: 0x006BCCC1
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node2()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 500;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164D1 RID: 91345 RVA: 0x006BE8F8 File Offset: 0x006BCCF8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD03 RID: 64771
		private int opl_p0;

		// Token: 0x0400FD04 RID: 64772
		private int opl_p1;

		// Token: 0x0400FD05 RID: 64773
		private int opl_p2;

		// Token: 0x0400FD06 RID: 64774
		private int opl_p3;
	}
}
