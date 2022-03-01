using System;

namespace behaviac
{
	// Token: 0x02003E7C RID: 15996
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node8 : Condition
	{
		// Token: 0x06016479 RID: 91257 RVA: 0x006BC912 File Offset: 0x006BAD12
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node8()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x0601647A RID: 91258 RVA: 0x006BC948 File Offset: 0x006BAD48
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCB0 RID: 64688
		private int opl_p0;

		// Token: 0x0400FCB1 RID: 64689
		private int opl_p1;

		// Token: 0x0400FCB2 RID: 64690
		private int opl_p2;

		// Token: 0x0400FCB3 RID: 64691
		private int opl_p3;
	}
}
