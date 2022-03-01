using System;

namespace behaviac
{
	// Token: 0x020024C4 RID: 9412
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Action_node50 : Condition
	{
		// Token: 0x060132D3 RID: 78547 RVA: 0x005B115E File Offset: 0x005AF55E
		public Condition_bt_AutoFight_AutoFight_Gungirl_Action_node50()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x060132D4 RID: 78548 RVA: 0x005B1174 File Offset: 0x005AF574
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CCF0 RID: 52464
		private float opl_p0;
	}
}
