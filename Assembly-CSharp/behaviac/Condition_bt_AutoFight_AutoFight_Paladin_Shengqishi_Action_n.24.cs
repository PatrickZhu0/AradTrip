using System;

namespace behaviac
{
	// Token: 0x02002831 RID: 10289
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node5 : Condition
	{
		// Token: 0x060139A0 RID: 80288 RVA: 0x005D9177 File Offset: 0x005D7577
		public Condition_bt_AutoFight_AutoFight_Paladin_Shengqishi_Action_node5()
		{
			this.opl_p0 = 3702;
		}

		// Token: 0x060139A1 RID: 80289 RVA: 0x005D918C File Offset: 0x005D758C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D3F9 RID: 54265
		private int opl_p0;
	}
}
