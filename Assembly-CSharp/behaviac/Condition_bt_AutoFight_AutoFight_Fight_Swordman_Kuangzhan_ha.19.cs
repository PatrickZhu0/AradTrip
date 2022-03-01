using System;

namespace behaviac
{
	// Token: 0x0200237F RID: 9087
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node40 : Condition
	{
		// Token: 0x06013065 RID: 77925 RVA: 0x005A0D0F File Offset: 0x0059F10F
		public Condition_bt_AutoFight_AutoFight_Fight_Swordman_Kuangzhan_hard_Action_node40()
		{
			this.opl_p0 = 1512;
		}

		// Token: 0x06013066 RID: 77926 RVA: 0x005A0D24 File Offset: 0x0059F124
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CA7B RID: 51835
		private int opl_p0;
	}
}
