using System;

namespace behaviac
{
	// Token: 0x02003559 RID: 13657
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2 : Condition
	{
		// Token: 0x060152F0 RID: 86768 RVA: 0x00662731 File Offset: 0x00660B31
		public Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node2()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x060152F1 RID: 86769 RVA: 0x00662744 File Offset: 0x00660B44
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECA3 RID: 60579
		private float opl_p0;
	}
}
