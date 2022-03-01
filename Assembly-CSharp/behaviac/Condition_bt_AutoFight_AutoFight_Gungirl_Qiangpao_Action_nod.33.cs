using System;

namespace behaviac
{
	// Token: 0x0200253E RID: 9534
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node40 : Condition
	{
		// Token: 0x060133C5 RID: 78789 RVA: 0x005B6DCF File Offset: 0x005B51CF
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node40()
		{
			this.opl_p0 = 2600;
		}

		// Token: 0x060133C6 RID: 78790 RVA: 0x005B6DE4 File Offset: 0x005B51E4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDEC RID: 52716
		private int opl_p0;
	}
}
