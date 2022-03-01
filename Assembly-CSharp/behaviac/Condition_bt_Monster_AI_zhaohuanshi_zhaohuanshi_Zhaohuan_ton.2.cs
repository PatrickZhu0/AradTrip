using System;

namespace behaviac
{
	// Token: 0x0200401C RID: 16412
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node5 : Condition
	{
		// Token: 0x0601679A RID: 92058 RVA: 0x006CD767 File Offset: 0x006CBB67
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Zhaohuan_tongyong_node5()
		{
			this.opl_p0 = 15000;
			this.opl_p1 = 15000;
			this.opl_p2 = 15000;
			this.opl_p3 = 15000;
		}

		// Token: 0x0601679B RID: 92059 RVA: 0x006CD79C File Offset: 0x006CBB9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FFE7 RID: 65511
		private int opl_p0;

		// Token: 0x0400FFE8 RID: 65512
		private int opl_p1;

		// Token: 0x0400FFE9 RID: 65513
		private int opl_p2;

		// Token: 0x0400FFEA RID: 65514
		private int opl_p3;
	}
}
