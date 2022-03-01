using System;

namespace behaviac
{
	// Token: 0x02003C17 RID: 15383
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node30 : Condition
	{
		// Token: 0x06015FD9 RID: 90073 RVA: 0x006A4F1F File Offset: 0x006A331F
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node30()
		{
			this.opl_p0 = 21474;
		}

		// Token: 0x06015FDA RID: 90074 RVA: 0x006A4F34 File Offset: 0x006A3334
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F859 RID: 63577
		private int opl_p0;
	}
}
