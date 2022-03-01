using System;

namespace behaviac
{
	// Token: 0x02003557 RID: 13655
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node5 : Condition
	{
		// Token: 0x060152EC RID: 86764 RVA: 0x006626BF File Offset: 0x00660ABF
		public Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Destiation_node5()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060152ED RID: 86765 RVA: 0x006626D4 File Offset: 0x00660AD4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400ECA1 RID: 60577
		private float opl_p0;
	}
}
