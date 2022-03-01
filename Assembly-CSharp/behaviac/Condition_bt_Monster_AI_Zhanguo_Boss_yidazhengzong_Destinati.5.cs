using System;

namespace behaviac
{
	// Token: 0x02003E92 RID: 16018
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node14 : Condition
	{
		// Token: 0x060164A4 RID: 91300 RVA: 0x006BDA21 File Offset: 0x006BBE21
		public Condition_bt_Monster_AI_Zhanguo_Boss_yidazhengzong_DestinationSelect_node14()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1500;
			this.opl_p2 = 1500;
			this.opl_p3 = 1000;
		}

		// Token: 0x060164A5 RID: 91301 RVA: 0x006BDA58 File Offset: 0x006BBE58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FCDE RID: 64734
		private int opl_p0;

		// Token: 0x0400FCDF RID: 64735
		private int opl_p1;

		// Token: 0x0400FCE0 RID: 64736
		private int opl_p2;

		// Token: 0x0400FCE1 RID: 64737
		private int opl_p3;
	}
}
