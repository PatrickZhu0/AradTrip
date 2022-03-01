using System;

namespace behaviac
{
	// Token: 0x02004083 RID: 16515
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node4 : Condition
	{
		// Token: 0x06016863 RID: 92259 RVA: 0x006D1A93 File Offset: 0x006CFE93
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node4()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1200;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06016864 RID: 92260 RVA: 0x006D1AC8 File Offset: 0x006CFEC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x040100AC RID: 65708
		private int opl_p0;

		// Token: 0x040100AD RID: 65709
		private int opl_p1;

		// Token: 0x040100AE RID: 65710
		private int opl_p2;

		// Token: 0x040100AF RID: 65711
		private int opl_p3;
	}
}
