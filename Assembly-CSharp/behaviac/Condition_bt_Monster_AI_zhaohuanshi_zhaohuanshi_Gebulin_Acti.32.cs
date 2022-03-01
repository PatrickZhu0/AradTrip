using System;

namespace behaviac
{
	// Token: 0x02003FB6 RID: 16310
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node56 : Condition
	{
		// Token: 0x060166D6 RID: 91862 RVA: 0x006C87E7 File Offset: 0x006C6BE7
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node56()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 5000;
			this.opl_p2 = 5000;
			this.opl_p3 = 5000;
		}

		// Token: 0x060166D7 RID: 91863 RVA: 0x006C881C File Offset: 0x006C6C1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF28 RID: 65320
		private int opl_p0;

		// Token: 0x0400FF29 RID: 65321
		private int opl_p1;

		// Token: 0x0400FF2A RID: 65322
		private int opl_p2;

		// Token: 0x0400FF2B RID: 65323
		private int opl_p3;
	}
}
