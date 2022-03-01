using System;

namespace behaviac
{
	// Token: 0x02004057 RID: 16471
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node46 : Condition
	{
		// Token: 0x0601680D RID: 92173 RVA: 0x006CF65B File Offset: 0x006CDA5B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node46()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601680E RID: 92174 RVA: 0x006CF690 File Offset: 0x006CDA90
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010057 RID: 65623
		private int opl_p0;

		// Token: 0x04010058 RID: 65624
		private int opl_p1;

		// Token: 0x04010059 RID: 65625
		private int opl_p2;

		// Token: 0x0401005A RID: 65626
		private int opl_p3;
	}
}
