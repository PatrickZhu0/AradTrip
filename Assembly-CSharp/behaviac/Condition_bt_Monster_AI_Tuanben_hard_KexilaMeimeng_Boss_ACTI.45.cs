using System;

namespace behaviac
{
	// Token: 0x02003C4D RID: 15437
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node11 : Condition
	{
		// Token: 0x06016044 RID: 90180 RVA: 0x006A705D File Offset: 0x006A545D
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node11()
		{
			this.opl_p0 = 21065;
		}

		// Token: 0x06016045 RID: 90181 RVA: 0x006A7070 File Offset: 0x006A5470
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F8BB RID: 63675
		private int opl_p0;
	}
}
