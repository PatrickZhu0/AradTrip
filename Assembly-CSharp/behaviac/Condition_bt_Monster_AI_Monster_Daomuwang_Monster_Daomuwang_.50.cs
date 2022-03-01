using System;

namespace behaviac
{
	// Token: 0x0200365F RID: 13919
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node18 : Condition
	{
		// Token: 0x060154E0 RID: 87264 RVA: 0x0066C975 File Offset: 0x0066AD75
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_wangzhe_node18()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x060154E1 RID: 87265 RVA: 0x0066C988 File Offset: 0x0066AD88
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE99 RID: 61081
		private float opl_p0;
	}
}
