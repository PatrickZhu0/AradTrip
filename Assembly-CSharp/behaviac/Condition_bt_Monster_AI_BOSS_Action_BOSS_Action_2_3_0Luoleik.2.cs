using System;

namespace behaviac
{
	// Token: 0x02002F53 RID: 12115
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node4 : Condition
	{
		// Token: 0x06014775 RID: 83829 RVA: 0x00628995 File Offset: 0x00626D95
		public Condition_bt_Monster_AI_BOSS_Action_BOSS_Action_2_3_0Luoleikn_Action_node4()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06014776 RID: 83830 RVA: 0x006289A8 File Offset: 0x00626DA8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E0E5 RID: 57573
		private float opl_p0;
	}
}
