using System;

namespace behaviac
{
	// Token: 0x02002562 RID: 9570
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node106 : Condition
	{
		// Token: 0x0601340D RID: 78861 RVA: 0x005B7D27 File Offset: 0x005B6127
		public Condition_bt_AutoFight_AutoFight_Gungirl_Qiangpao_Action_node106()
		{
			this.opl_p0 = 2510;
		}

		// Token: 0x0601340E RID: 78862 RVA: 0x005B7D3C File Offset: 0x005B613C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE34 RID: 52788
		private int opl_p0;
	}
}
