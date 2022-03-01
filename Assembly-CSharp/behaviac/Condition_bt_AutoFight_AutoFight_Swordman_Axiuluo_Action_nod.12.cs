using System;

namespace behaviac
{
	// Token: 0x020028A7 RID: 10407
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node32 : Condition
	{
		// Token: 0x06013A88 RID: 80520 RVA: 0x005DEDAB File Offset: 0x005DD1AB
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node32()
		{
			this.opl_p0 = 1707;
		}

		// Token: 0x06013A89 RID: 80521 RVA: 0x005DEDC0 File Offset: 0x005DD1C0
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4E5 RID: 54501
		private int opl_p0;
	}
}
