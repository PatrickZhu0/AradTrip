using System;

namespace behaviac
{
	// Token: 0x02003C32 RID: 15410
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node8 : Condition
	{
		// Token: 0x0601600E RID: 90126 RVA: 0x006A6603 File Offset: 0x006A4A03
		public Condition_bt_Monster_AI_Tuanben_hard_KexilaMeimeng_Boss_ACTION_hard_Shenyuan_node8()
		{
			this.opl_p0 = 21474;
		}

		// Token: 0x0601600F RID: 90127 RVA: 0x006A6618 File Offset: 0x006A4A18
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F88A RID: 63626
		private int opl_p0;
	}
}
