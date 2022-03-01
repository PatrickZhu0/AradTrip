using System;

namespace behaviac
{
	// Token: 0x02003AC8 RID: 15048
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node27 : Condition
	{
		// Token: 0x06015D4F RID: 89423 RVA: 0x0069881D File Offset: 0x00696C1D
		public Condition_bt_Monster_AI_Tuanben_Kuangsha_Action_node27()
		{
			this.opl_p0 = 21032;
		}

		// Token: 0x06015D50 RID: 89424 RVA: 0x00698830 File Offset: 0x00696C30
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F65F RID: 63071
		private int opl_p0;
	}
}
