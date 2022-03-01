using System;

namespace behaviac
{
	// Token: 0x02001FA7 RID: 8103
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node2 : Condition
	{
		// Token: 0x060128EC RID: 76012 RVA: 0x0056FF2A File Offset: 0x0056E32A
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_hard_Action_node2()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x060128ED RID: 76013 RVA: 0x0056FF40 File Offset: 0x0056E340
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2DE RID: 49886
		private float opl_p0;
	}
}
