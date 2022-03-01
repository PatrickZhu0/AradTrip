using System;

namespace behaviac
{
	// Token: 0x02003D60 RID: 15712
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node15 : Condition
	{
		// Token: 0x06016256 RID: 90710 RVA: 0x006B129B File Offset: 0x006AF69B
		public Condition_bt_Monster_AI_Tuanben_hard_Shuiren_Boss_ACTION_hard_node15()
		{
			this.opl_p0 = 21080;
		}

		// Token: 0x06016257 RID: 90711 RVA: 0x006B12B0 File Offset: 0x006AF6B0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FAB0 RID: 64176
		private int opl_p0;
	}
}
