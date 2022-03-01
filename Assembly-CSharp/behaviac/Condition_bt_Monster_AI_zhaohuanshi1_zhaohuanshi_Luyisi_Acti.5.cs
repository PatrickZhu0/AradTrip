using System;

namespace behaviac
{
	// Token: 0x0200407B RID: 16507
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node13 : Condition
	{
		// Token: 0x06016853 RID: 92243 RVA: 0x006D172B File Offset: 0x006CFB2B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node13()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x06016854 RID: 92244 RVA: 0x006D1760 File Offset: 0x006CFB60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401009C RID: 65692
		private int opl_p0;

		// Token: 0x0401009D RID: 65693
		private int opl_p1;

		// Token: 0x0401009E RID: 65694
		private int opl_p2;

		// Token: 0x0401009F RID: 65695
		private int opl_p3;
	}
}
