using System;

namespace behaviac
{
	// Token: 0x02002DF8 RID: 11768
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node58 : Condition
	{
		// Token: 0x060144CD RID: 83149 RVA: 0x006191D9 File Offset: 0x006175D9
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node58()
		{
			this.opl_p0 = 21639;
		}

		// Token: 0x060144CE RID: 83150 RVA: 0x006191EC File Offset: 0x006175EC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE81 RID: 56961
		private int opl_p0;
	}
}
