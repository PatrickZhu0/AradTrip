using System;

namespace behaviac
{
	// Token: 0x02003FAE RID: 16302
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node46 : Condition
	{
		// Token: 0x060166C6 RID: 91846 RVA: 0x006C847F File Offset: 0x006C687F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Gebulin_Action_node46()
		{
			this.opl_p0 = 5000;
			this.opl_p1 = 2000;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x060166C7 RID: 91847 RVA: 0x006C84B4 File Offset: 0x006C68B4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF18 RID: 65304
		private int opl_p0;

		// Token: 0x0400FF19 RID: 65305
		private int opl_p1;

		// Token: 0x0400FF1A RID: 65306
		private int opl_p2;

		// Token: 0x0400FF1B RID: 65307
		private int opl_p3;
	}
}
