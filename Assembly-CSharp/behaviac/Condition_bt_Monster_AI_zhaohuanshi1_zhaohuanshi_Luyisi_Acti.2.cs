using System;

namespace behaviac
{
	// Token: 0x02004077 RID: 16503
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node9 : Condition
	{
		// Token: 0x0601684B RID: 92235 RVA: 0x006D1577 File Offset: 0x006CF977
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_Luyisi_Action_node9()
		{
			this.opl_p0 = 8000;
			this.opl_p1 = 1200;
			this.opl_p2 = 2000;
			this.opl_p3 = 2000;
		}

		// Token: 0x0601684C RID: 92236 RVA: 0x006D15AC File Offset: 0x006CF9AC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x04010094 RID: 65684
		private int opl_p0;

		// Token: 0x04010095 RID: 65685
		private int opl_p1;

		// Token: 0x04010096 RID: 65686
		private int opl_p2;

		// Token: 0x04010097 RID: 65687
		private int opl_p3;
	}
}
