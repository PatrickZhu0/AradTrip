using System;

namespace behaviac
{
	// Token: 0x02003E84 RID: 16004
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node18 : Condition
	{
		// Token: 0x06016489 RID: 91273 RVA: 0x006BCCD6 File Offset: 0x006BB0D6
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node18()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601648A RID: 91274 RVA: 0x006BCD0C File Offset: 0x006BB10C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCC0 RID: 64704
		private int opl_p0;

		// Token: 0x0400FCC1 RID: 64705
		private int opl_p1;

		// Token: 0x0400FCC2 RID: 64706
		private int opl_p2;

		// Token: 0x0400FCC3 RID: 64707
		private int opl_p3;
	}
}
