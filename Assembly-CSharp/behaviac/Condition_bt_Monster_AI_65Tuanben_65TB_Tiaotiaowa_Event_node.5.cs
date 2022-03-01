using System;

namespace behaviac
{
	// Token: 0x02002D13 RID: 11539
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node16 : Condition
	{
		// Token: 0x06014314 RID: 82708 RVA: 0x00610C46 File Offset: 0x0060F046
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tiaotiaowa_Event_node16()
		{
			this.opl_p0 = 506410;
		}

		// Token: 0x06014315 RID: 82709 RVA: 0x00610C5C File Offset: 0x0060F05C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DCC5 RID: 56517
		private int opl_p0;
	}
}
