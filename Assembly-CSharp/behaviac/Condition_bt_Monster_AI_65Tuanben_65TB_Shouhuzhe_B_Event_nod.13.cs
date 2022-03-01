using System;

namespace behaviac
{
	// Token: 0x02002C77 RID: 11383
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node22 : Condition
	{
		// Token: 0x060141E7 RID: 82407 RVA: 0x0060AA57 File Offset: 0x00608E57
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Event_node22()
		{
			this.opl_p0 = 20782;
		}

		// Token: 0x060141E8 RID: 82408 RVA: 0x0060AA6C File Offset: 0x00608E6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DBA9 RID: 56233
		private int opl_p0;
	}
}
