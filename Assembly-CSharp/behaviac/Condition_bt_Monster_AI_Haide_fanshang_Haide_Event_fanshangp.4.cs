using System;

namespace behaviac
{
	// Token: 0x020033D3 RID: 13267
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node9 : Condition
	{
		// Token: 0x06014FFC RID: 86012 RVA: 0x00653B62 File Offset: 0x00651F62
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2501;
		}

		// Token: 0x06014FFD RID: 86013 RVA: 0x00653B84 File Offset: 0x00651F84
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8E6 RID: 59622
		private BE_Target opl_p0;

		// Token: 0x0400E8E7 RID: 59623
		private BE_Equal opl_p1;

		// Token: 0x0400E8E8 RID: 59624
		private int opl_p2;
	}
}
