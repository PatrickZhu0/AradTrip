using System;

namespace behaviac
{
	// Token: 0x020033CF RID: 13263
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4 : Condition
	{
		// Token: 0x06014FF4 RID: 86004 RVA: 0x00653A3F File Offset: 0x00651E3F
		public Condition_bt_Monster_AI_Haide_fanshang_Haide_Event_fanshangputong_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2501;
		}

		// Token: 0x06014FF5 RID: 86005 RVA: 0x00653A60 File Offset: 0x00651E60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E8DE RID: 59614
		private BE_Target opl_p0;

		// Token: 0x0400E8DF RID: 59615
		private BE_Equal opl_p1;

		// Token: 0x0400E8E0 RID: 59616
		private int opl_p2;
	}
}
