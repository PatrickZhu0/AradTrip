using System;

namespace behaviac
{
	// Token: 0x02003E77 RID: 15991
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node3 : Condition
	{
		// Token: 0x0601646F RID: 91247 RVA: 0x006BC6E0 File Offset: 0x006BAAE0
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_Action_node3()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 500;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x06016470 RID: 91248 RVA: 0x006BC714 File Offset: 0x006BAB14
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCA4 RID: 64676
		private int opl_p0;

		// Token: 0x0400FCA5 RID: 64677
		private int opl_p1;

		// Token: 0x0400FCA6 RID: 64678
		private int opl_p2;

		// Token: 0x0400FCA7 RID: 64679
		private int opl_p3;
	}
}
