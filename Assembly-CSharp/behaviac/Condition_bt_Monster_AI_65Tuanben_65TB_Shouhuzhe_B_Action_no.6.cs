using System;

namespace behaviac
{
	// Token: 0x02002C62 RID: 11362
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node20 : Condition
	{
		// Token: 0x060141BF RID: 82367 RVA: 0x00609DC9 File Offset: 0x006081C9
		public Condition_bt_Monster_AI_65Tuanben_65TB_Shouhuzhe_B_Action_node20()
		{
			this.opl_p0 = 20779;
		}

		// Token: 0x060141C0 RID: 82368 RVA: 0x00609DDC File Offset: 0x006081DC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB7B RID: 56187
		private int opl_p0;
	}
}
