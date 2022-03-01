using System;

namespace behaviac
{
	// Token: 0x02003662 RID: 13922
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node22 : Condition
	{
		// Token: 0x060154E6 RID: 87270 RVA: 0x0066CAAE File Offset: 0x0066AEAE
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node22()
		{
			this.opl_p0 = 1500;
			this.opl_p1 = 1000;
			this.opl_p2 = 1000;
			this.opl_p3 = 1000;
		}

		// Token: 0x060154E7 RID: 87271 RVA: 0x0066CAE4 File Offset: 0x0066AEE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE9D RID: 61085
		private int opl_p0;

		// Token: 0x0400EE9E RID: 61086
		private int opl_p1;

		// Token: 0x0400EE9F RID: 61087
		private int opl_p2;

		// Token: 0x0400EEA0 RID: 61088
		private int opl_p3;
	}
}
