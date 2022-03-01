using System;

namespace behaviac
{
	// Token: 0x020036DF RID: 14047
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node14 : Condition
	{
		// Token: 0x060155D4 RID: 87508 RVA: 0x0067200B File Offset: 0x0067040B
		public Condition_bt_Monster_AI_Monster_Nongbao_Nongbao_Event_node14()
		{
			this.opl_p0 = 20388;
		}

		// Token: 0x060155D5 RID: 87509 RVA: 0x00672020 File Offset: 0x00670420
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400EFA8 RID: 61352
		private int opl_p0;
	}
}
