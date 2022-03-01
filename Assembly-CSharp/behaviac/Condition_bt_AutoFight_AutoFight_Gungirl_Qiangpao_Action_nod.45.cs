using System;

namespace behaviac
{
	// Token: 0x0200254E RID: 9550
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node86 : Condition
	{
		// Token: 0x060133E5 RID: 78821 RVA: 0x005B74A3 File Offset: 0x005B58A3
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node86()
		{
			this.opl_p0 = 2504;
		}

		// Token: 0x060133E6 RID: 78822 RVA: 0x005B74B8 File Offset: 0x005B58B8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE0C RID: 52748
		private int opl_p0;
	}
}
