using System;

namespace behaviac
{
	// Token: 0x02003C23 RID: 15395
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node16 : Condition
	{
		// Token: 0x06015FF1 RID: 90097 RVA: 0x006A5441 File Offset: 0x006A3841
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_node16()
		{
			this.opl_p0 = 21067;
		}

		// Token: 0x06015FF2 RID: 90098 RVA: 0x006A5454 File Offset: 0x006A3854
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F873 RID: 63603
		private int opl_p0;
	}
}
