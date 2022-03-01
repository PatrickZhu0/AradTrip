using System;

namespace behaviac
{
	// Token: 0x0200363B RID: 13883
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node4 : Condition
	{
		// Token: 0x06015499 RID: 87193 RVA: 0x0066B2D3 File Offset: 0x006696D3
		public Condition_bt_Monster_AI_Monster_Daomuwang_Monster_Daomuwang_Action_maoxian_node4()
		{
			this.opl_p0 = 5428;
		}

		// Token: 0x0601549A RID: 87194 RVA: 0x0066B2E8 File Offset: 0x006696E8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EE52 RID: 61010
		private int opl_p0;
	}
}
