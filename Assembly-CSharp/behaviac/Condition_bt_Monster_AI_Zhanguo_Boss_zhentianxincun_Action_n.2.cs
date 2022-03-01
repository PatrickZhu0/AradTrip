using System;

namespace behaviac
{
	// Token: 0x02003EBF RID: 16063
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node2 : Condition
	{
		// Token: 0x060164FB RID: 91387 RVA: 0x006BFBF9 File Offset: 0x006BDFF9
		public Condition_bt_Monster_AI_Zhanguo_Boss_zhentianxincun_Action_node2()
		{
			this.opl_p0 = 3000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164FC RID: 91388 RVA: 0x006BFC30 File Offset: 0x006BE030
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FD2F RID: 64815
		private int opl_p0;

		// Token: 0x0400FD30 RID: 64816
		private int opl_p1;

		// Token: 0x0400FD31 RID: 64817
		private int opl_p2;

		// Token: 0x0400FD32 RID: 64818
		private int opl_p3;
	}
}
