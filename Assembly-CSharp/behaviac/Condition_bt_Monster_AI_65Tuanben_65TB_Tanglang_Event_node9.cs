using System;

namespace behaviac
{
	// Token: 0x02002CA9 RID: 11433
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node9 : Condition
	{
		// Token: 0x06014247 RID: 82503 RVA: 0x0060CC1F File Offset: 0x0060B01F
		public Condition_bt_Monster_AI_65Tuanben_65TB_Tanglang_Event_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521947;
		}

		// Token: 0x06014248 RID: 82504 RVA: 0x0060CC40 File Offset: 0x0060B040
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBFF RID: 56319
		private BE_Target opl_p0;

		// Token: 0x0400DC00 RID: 56320
		private BE_Equal opl_p1;

		// Token: 0x0400DC01 RID: 56321
		private int opl_p2;
	}
}
