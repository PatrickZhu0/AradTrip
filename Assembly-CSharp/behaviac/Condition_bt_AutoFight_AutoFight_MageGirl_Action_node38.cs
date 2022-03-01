using System;

namespace behaviac
{
	// Token: 0x020026AA RID: 9898
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Action_node38 : Condition
	{
		// Token: 0x06013698 RID: 79512 RVA: 0x005C760B File Offset: 0x005C5A0B
		public Condition_bt_AutoFight_AutoFight_MageGirl_Action_node38()
		{
			this.opl_p0 = 2010;
		}

		// Token: 0x06013699 RID: 79513 RVA: 0x005C7620 File Offset: 0x005C5A20
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D0EC RID: 53484
		private int opl_p0;
	}
}
