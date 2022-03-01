using System;

namespace behaviac
{
	// Token: 0x02003C11 RID: 15377
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node8 : Condition
	{
		// Token: 0x06015FCD RID: 90061 RVA: 0x006A4D07 File Offset: 0x006A3107
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node8()
		{
			this.opl_p0 = 21474;
		}

		// Token: 0x06015FCE RID: 90062 RVA: 0x006A4D1C File Offset: 0x006A311C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F850 RID: 63568
		private int opl_p0;
	}
}
