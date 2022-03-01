using System;

namespace behaviac
{
	// Token: 0x0200403B RID: 16443
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node11 : Condition
	{
		// Token: 0x060167D5 RID: 92117 RVA: 0x006CEA6F File Offset: 0x006CCE6F
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Gebulin_Action_node11()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x060167D6 RID: 92118 RVA: 0x006CEAA4 File Offset: 0x006CCEA4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401001F RID: 65567
		private int opl_p0;

		// Token: 0x04010020 RID: 65568
		private int opl_p1;

		// Token: 0x04010021 RID: 65569
		private int opl_p2;

		// Token: 0x04010022 RID: 65570
		private int opl_p3;
	}
}
