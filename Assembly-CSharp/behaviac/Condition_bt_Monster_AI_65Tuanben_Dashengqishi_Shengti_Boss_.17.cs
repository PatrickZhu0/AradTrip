using System;

namespace behaviac
{
	// Token: 0x02002DE7 RID: 11751
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node24 : Condition
	{
		// Token: 0x060144AB RID: 83115 RVA: 0x00618B08 File Offset: 0x00616F08
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node24()
		{
			this.opl_p0 = 21626;
		}

		// Token: 0x060144AC RID: 83116 RVA: 0x00618B1C File Offset: 0x00616F1C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE63 RID: 56931
		private int opl_p0;
	}
}
