using System;

namespace behaviac
{
	// Token: 0x02003E91 RID: 16017
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node11 : Condition
	{
		// Token: 0x060164A2 RID: 91298 RVA: 0x006BD9A5 File Offset: 0x006BBDA5
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node11()
		{
			this.opl_p0 = 6000;
			this.opl_p1 = 6000;
			this.opl_p2 = 6000;
			this.opl_p3 = 6000;
		}

		// Token: 0x060164A3 RID: 91299 RVA: 0x006BD9DC File Offset: 0x006BBDDC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCDA RID: 64730
		private int opl_p0;

		// Token: 0x0400FCDB RID: 64731
		private int opl_p1;

		// Token: 0x0400FCDC RID: 64732
		private int opl_p2;

		// Token: 0x0400FCDD RID: 64733
		private int opl_p3;
	}
}
