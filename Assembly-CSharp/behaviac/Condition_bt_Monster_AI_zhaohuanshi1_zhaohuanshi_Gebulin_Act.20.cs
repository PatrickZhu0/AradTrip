using System;

namespace behaviac
{
	// Token: 0x0200404F RID: 16463
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node36 : Condition
	{
		// Token: 0x060167FD RID: 92157 RVA: 0x006CF2F3 File Offset: 0x006CD6F3
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node36()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060167FE RID: 92158 RVA: 0x006CF328 File Offset: 0x006CD728
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010047 RID: 65607
		private int opl_p0;

		// Token: 0x04010048 RID: 65608
		private int opl_p1;

		// Token: 0x04010049 RID: 65609
		private int opl_p2;

		// Token: 0x0401004A RID: 65610
		private int opl_p3;
	}
}
