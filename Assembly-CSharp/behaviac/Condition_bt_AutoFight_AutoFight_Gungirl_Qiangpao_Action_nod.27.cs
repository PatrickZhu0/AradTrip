using System;

namespace behaviac
{
	// Token: 0x02002536 RID: 9526
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node61 : Condition
	{
		// Token: 0x060133B5 RID: 78773 RVA: 0x005B6A5F File Offset: 0x005B4E5F
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node61()
		{
			this.opl_p0 = 2609;
		}

		// Token: 0x060133B6 RID: 78774 RVA: 0x005B6A74 File Offset: 0x005B4E74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CDDC RID: 52700
		private int opl_p0;
	}
}
