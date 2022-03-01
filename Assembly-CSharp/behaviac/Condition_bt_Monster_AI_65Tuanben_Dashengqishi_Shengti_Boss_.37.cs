using System;

namespace behaviac
{
	// Token: 0x02002E0D RID: 11789
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node148 : Condition
	{
		// Token: 0x060144F7 RID: 83191 RVA: 0x0061994A File Offset: 0x00617D4A
		public Condition_bt_Monster_AI_65Tuanben_Dashengqishi_Shengti_Boss_ACTION_node148()
		{
			this.opl_p0 = 21641;
		}

		// Token: 0x060144F8 RID: 83192 RVA: 0x00619960 File Offset: 0x00617D60
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DE9E RID: 56990
		private int opl_p0;
	}
}
