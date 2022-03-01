using System;

namespace behaviac
{
	// Token: 0x02003A34 RID: 14900
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node30 : Condition
	{
		// Token: 0x06015C32 RID: 89138 RVA: 0x006926D9 File Offset: 0x00690AD9
		public Condition_bt_Monster_AI_Tuanben_KexilaMeimeng_Boss_ACTION_node30()
		{
			this.opl_p0 = 21065;
		}

		// Token: 0x06015C33 RID: 89139 RVA: 0x006926EC File Offset: 0x00690AEC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F54A RID: 62794
		private int opl_p0;
	}
}
