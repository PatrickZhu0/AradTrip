using System;

namespace behaviac
{
	// Token: 0x02003EB5 RID: 16053
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node30 : Condition
	{
		// Token: 0x060164E8 RID: 91368 RVA: 0x006BEE3E File Offset: 0x006BD23E
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_kuang_Action_node30()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164E9 RID: 91369 RVA: 0x006BEE74 File Offset: 0x006BD274
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD1B RID: 64795
		private int opl_p0;

		// Token: 0x0400FD1C RID: 64796
		private int opl_p1;

		// Token: 0x0400FD1D RID: 64797
		private int opl_p2;

		// Token: 0x0400FD1E RID: 64798
		private int opl_p3;
	}
}
