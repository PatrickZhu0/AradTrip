using System;

namespace behaviac
{
	// Token: 0x02002B85 RID: 11141
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node31 : Condition
	{
		// Token: 0x06014016 RID: 81942 RVA: 0x00601ECE File Offset: 0x006002CE
		public Condition_bt_Monster_AI_65Tuanben_65TB_HundunYashou_Action_node31()
		{
			this.opl_p0 = 20769;
		}

		// Token: 0x06014017 RID: 81943 RVA: 0x00601EE4 File Offset: 0x006002E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DA14 RID: 55828
		private int opl_p0;
	}
}
