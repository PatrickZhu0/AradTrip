using System;

namespace behaviac
{
	// Token: 0x02002C2E RID: 11310
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node2 : Condition
	{
		// Token: 0x0601415A RID: 82266 RVA: 0x006080DB File Offset: 0x006064DB
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_A_Action_node2()
		{
			this.opl_p0 = 20778;
		}

		// Token: 0x0601415B RID: 82267 RVA: 0x006080F0 File Offset: 0x006064F0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB25 RID: 56101
		private int opl_p0;
	}
}
