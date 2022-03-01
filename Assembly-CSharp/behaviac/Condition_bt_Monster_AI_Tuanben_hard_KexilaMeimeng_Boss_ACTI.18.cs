using System;

namespace behaviac
{
	// Token: 0x02003C1F RID: 15391
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node19 : Condition
	{
		// Token: 0x06015FE9 RID: 90089 RVA: 0x006A5271 File Offset: 0x006A3671
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node19()
		{
			this.opl_p0 = 21068;
		}

		// Token: 0x06015FEA RID: 90090 RVA: 0x006A5284 File Offset: 0x006A3684
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F869 RID: 63593
		private int opl_p0;
	}
}
