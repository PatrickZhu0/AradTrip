using System;

namespace behaviac
{
	// Token: 0x02002C43 RID: 11331
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node10 : Condition
	{
		// Token: 0x06014182 RID: 82306 RVA: 0x00608D12 File Offset: 0x00607112
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node10()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 521982;
		}

		// Token: 0x06014183 RID: 82307 RVA: 0x00608D34 File Offset: 0x00607134
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB48 RID: 56136
		private BE_Target opl_p0;

		// Token: 0x0400DB49 RID: 56137
		private BE_Equal opl_p1;

		// Token: 0x0400DB4A RID: 56138
		private int opl_p2;
	}
}
