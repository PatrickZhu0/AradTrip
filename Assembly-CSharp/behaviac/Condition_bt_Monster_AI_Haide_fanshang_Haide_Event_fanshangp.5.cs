using System;

namespace behaviac
{
	// Token: 0x020033D4 RID: 13268
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node8 : Condition
	{
		// Token: 0x06014FFE RID: 86014 RVA: 0x00653BC3 File Offset: 0x00651FC3
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2401;
		}

		// Token: 0x06014FFF RID: 86015 RVA: 0x00653BE4 File Offset: 0x00651FE4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8E9 RID: 59625
		private BE_Target opl_p0;

		// Token: 0x0400E8EA RID: 59626
		private BE_Equal opl_p1;

		// Token: 0x0400E8EB RID: 59627
		private int opl_p2;
	}
}
