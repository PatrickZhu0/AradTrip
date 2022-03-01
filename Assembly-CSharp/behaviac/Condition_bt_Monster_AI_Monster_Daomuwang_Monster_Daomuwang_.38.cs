using System;

namespace behaviac
{
	// Token: 0x0200364F RID: 13903
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node28 : Condition
	{
		// Token: 0x060154C0 RID: 87232 RVA: 0x0066C2A5 File Offset: 0x0066A6A5
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node28()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154C1 RID: 87233 RVA: 0x0066C2B8 File Offset: 0x0066A6B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE79 RID: 61049
		private float opl_p0;
	}
}
