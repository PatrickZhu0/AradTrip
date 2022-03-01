using System;

namespace behaviac
{
	// Token: 0x02003553 RID: 13651
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node4 : Condition
	{
		// Token: 0x060152E5 RID: 86757 RVA: 0x0066246F File Offset: 0x0066086F
		public Condition_bt_Monster_AI_Heisedadi_Yichangyuanhun_Action_node4()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060152E6 RID: 86758 RVA: 0x00662484 File Offset: 0x00660884
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EC9D RID: 60573
		private float opl_p0;
	}
}
