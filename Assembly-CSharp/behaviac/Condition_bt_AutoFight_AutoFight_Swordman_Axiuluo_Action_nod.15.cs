using System;

namespace behaviac
{
	// Token: 0x020028AB RID: 10411
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node27 : Condition
	{
		// Token: 0x06013A90 RID: 80528 RVA: 0x005DEF5F File Offset: 0x005DD35F
		public Condition_bt_AutoFight_AutoFight_Swordman_Axiuluo_Action_node27()
		{
			this.opl_p0 = 1514;
		}

		// Token: 0x06013A91 RID: 80529 RVA: 0x005DEF74 File Offset: 0x005DD374
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D4ED RID: 54509
		private int opl_p0;
	}
}
