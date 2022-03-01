using System;

namespace behaviac
{
	// Token: 0x02003F82 RID: 16258
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node15 : Condition
	{
		// Token: 0x06016670 RID: 91760 RVA: 0x006C6CE3 File Offset: 0x006C50E3
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Bingnaisi_Action_node15()
		{
			this.opl_p0 = 4000;
			this.opl_p1 = 2500;
			this.opl_p2 = 2500;
			this.opl_p3 = 2500;
		}

		// Token: 0x06016671 RID: 91761 RVA: 0x006C6D18 File Offset: 0x006C5118
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FEC4 RID: 65220
		private int opl_p0;

		// Token: 0x0400FEC5 RID: 65221
		private int opl_p1;

		// Token: 0x0400FEC6 RID: 65222
		private int opl_p2;

		// Token: 0x0400FEC7 RID: 65223
		private int opl_p3;
	}
}
