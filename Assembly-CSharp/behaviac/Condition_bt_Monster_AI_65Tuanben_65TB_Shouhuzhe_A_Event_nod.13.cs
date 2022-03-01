using System;

namespace behaviac
{
	// Token: 0x02002C4E RID: 11342
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node22 : Condition
	{
		// Token: 0x06014198 RID: 82328 RVA: 0x006090FB File Offset: 0x006074FB
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Event_node22()
		{
			this.opl_p0 = 20782;
		}

		// Token: 0x06014199 RID: 82329 RVA: 0x00609110 File Offset: 0x00607510
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB5F RID: 56159
		private int opl_p0;
	}
}
