using System;

namespace behaviac
{
	// Token: 0x0200404B RID: 16459
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node31 : Condition
	{
		// Token: 0x060167F5 RID: 92149 RVA: 0x006CF13F File Offset: 0x006CD53F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node31()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060167F6 RID: 92150 RVA: 0x006CF174 File Offset: 0x006CD574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401003F RID: 65599
		private int opl_p0;

		// Token: 0x04010040 RID: 65600
		private int opl_p1;

		// Token: 0x04010041 RID: 65601
		private int opl_p2;

		// Token: 0x04010042 RID: 65602
		private int opl_p3;
	}
}
