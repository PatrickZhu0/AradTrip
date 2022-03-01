using System;

namespace behaviac
{
	// Token: 0x02002E0B RID: 11787
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node37 : Condition
	{
		// Token: 0x060144F3 RID: 83187 RVA: 0x00619856 File Offset: 0x00617C56
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node37()
		{
			this.opl_p0 = 21636;
		}

		// Token: 0x060144F4 RID: 83188 RVA: 0x0061986C File Offset: 0x00617C6C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE9B RID: 56987
		private int opl_p0;
	}
}
