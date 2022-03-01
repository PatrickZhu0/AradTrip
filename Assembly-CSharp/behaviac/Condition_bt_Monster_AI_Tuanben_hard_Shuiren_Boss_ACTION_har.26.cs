using System;

namespace behaviac
{
	// Token: 0x02003D64 RID: 15716
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node45 : Condition
	{
		// Token: 0x0601625E RID: 90718 RVA: 0x006B1453 File Offset: 0x006AF853
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node45()
		{
			this.opl_p0 = 21082;
		}

		// Token: 0x0601625F RID: 90719 RVA: 0x006B1468 File Offset: 0x006AF868
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAB8 RID: 64184
		private int opl_p0;
	}
}
