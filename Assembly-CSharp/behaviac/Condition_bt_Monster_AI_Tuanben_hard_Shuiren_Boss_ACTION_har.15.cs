using System;

namespace behaviac
{
	// Token: 0x02003D54 RID: 15700
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node30 : Condition
	{
		// Token: 0x0601623E RID: 90686 RVA: 0x006B0EEB File Offset: 0x006AF2EB
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node30()
		{
			this.opl_p0 = 21081;
		}

		// Token: 0x0601623F RID: 90687 RVA: 0x006B0F00 File Offset: 0x006AF300
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FA9D RID: 64157
		private int opl_p0;
	}
}
