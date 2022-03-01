using System;

namespace behaviac
{
	// Token: 0x02003663 RID: 13923
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node23 : Condition
	{
		// Token: 0x060154E8 RID: 87272 RVA: 0x0066CB29 File Offset: 0x0066AF29
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node23()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060154E9 RID: 87273 RVA: 0x0066CB3C File Offset: 0x0066AF3C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EEA1 RID: 61089
		private float opl_p0;
	}
}
