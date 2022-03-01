using System;

namespace behaviac
{
	// Token: 0x02002C18 RID: 11288
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node128 : Condition
	{
		// Token: 0x0601412F RID: 82223 RVA: 0x006061CD File Offset: 0x006045CD
		public Condition_bt_Monster_AI_65Tuanben_65TB_Saiche_liucheng_BOSS_node128()
		{
			this.opl_p0 = 21835;
		}

		// Token: 0x06014130 RID: 82224 RVA: 0x006061E0 File Offset: 0x006045E0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400DB02 RID: 56066
		private int opl_p0;
	}
}
