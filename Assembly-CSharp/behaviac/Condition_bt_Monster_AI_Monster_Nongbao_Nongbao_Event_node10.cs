using System;

namespace behaviac
{
	// Token: 0x020036DB RID: 14043
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10 : Condition
	{
		// Token: 0x060155CC RID: 87500 RVA: 0x00671E57 File Offset: 0x00670257
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node10()
		{
			this.opl_p0 = 20387;
		}

		// Token: 0x060155CD RID: 87501 RVA: 0x00671E6C File Offset: 0x0067026C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EF9F RID: 61343
		private int opl_p0;
	}
}
