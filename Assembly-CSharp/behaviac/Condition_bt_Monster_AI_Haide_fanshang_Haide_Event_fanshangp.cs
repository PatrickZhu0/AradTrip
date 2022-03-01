using System;

namespace behaviac
{
	// Token: 0x020033CE RID: 13262
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3 : Condition
	{
		// Token: 0x06014FF2 RID: 86002 RVA: 0x006539DC File Offset: 0x00651DDC
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2401;
		}

		// Token: 0x06014FF3 RID: 86003 RVA: 0x00653A00 File Offset: 0x00651E00
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8DB RID: 59611
		private BE_Target opl_p0;

		// Token: 0x0400E8DC RID: 59612
		private BE_Equal opl_p1;

		// Token: 0x0400E8DD RID: 59613
		private int opl_p2;
	}
}
