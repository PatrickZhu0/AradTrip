using System;

namespace behaviac
{
	// Token: 0x020040BE RID: 16574
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node13 : Condition
	{
		// Token: 0x060168D4 RID: 92372 RVA: 0x006D430B File Offset: 0x006D270B
		public Condition_bt_Monster_AI_zhaohuanshi1_zhaohuanshi_yijiabeila_DestinationSelect_node13()
		{
			this.opl_p0 = 7000;
			this.opl_p1 = 7000;
			this.opl_p2 = 7000;
			this.opl_p3 = 7000;
		}

		// Token: 0x060168D5 RID: 92373 RVA: 0x006D4340 File Offset: 0x006D2740
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0401011A RID: 65818
		private int opl_p0;

		// Token: 0x0401011B RID: 65819
		private int opl_p1;

		// Token: 0x0401011C RID: 65820
		private int opl_p2;

		// Token: 0x0401011D RID: 65821
		private int opl_p3;
	}
}
