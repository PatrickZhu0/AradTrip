using System;

namespace behaviac
{
	// Token: 0x020026FF RID: 9983
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node45 : Condition
	{
		// Token: 0x06013741 RID: 79681 RVA: 0x005CA793 File Offset: 0x005C8B93
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node45()
		{
			this.opl_p0 = 2000;
			this.opl_p1 = 1000;
			this.opl_p2 = 1500;
			this.opl_p3 = 1500;
		}

		// Token: 0x06013742 RID: 79682 RVA: 0x005CA7C8 File Offset: 0x005C8BC8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_IsTargetInAttackArea(this.opl_p0, this.opl_p1, this.opl_p2, this.opl_p3);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D196 RID: 53654
		private int opl_p0;

		// Token: 0x0400D197 RID: 53655
		private int opl_p1;

		// Token: 0x0400D198 RID: 53656
		private int opl_p2;

		// Token: 0x0400D199 RID: 53657
		private int opl_p3;
	}
}
