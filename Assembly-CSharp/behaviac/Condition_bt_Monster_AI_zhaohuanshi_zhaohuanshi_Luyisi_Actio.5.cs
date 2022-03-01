using System;

namespace behaviac
{
	// Token: 0x02003FD2 RID: 16338
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node13 : Condition
	{
		// Token: 0x0601670C RID: 91916 RVA: 0x006CA54F File Offset: 0x006C894F
		public Condition_bt_Monster_AI_zhaohuanshi_zhaohuanshi_Luyisi_Action_node13()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x0601670D RID: 91917 RVA: 0x006CA584 File Offset: 0x006C8984
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FF5D RID: 65373
		private int opl_p0;

		// Token: 0x0400FF5E RID: 65374
		private int opl_p1;

		// Token: 0x0400FF5F RID: 65375
		private int opl_p2;

		// Token: 0x0400FF60 RID: 65376
		private int opl_p3;
	}
}
