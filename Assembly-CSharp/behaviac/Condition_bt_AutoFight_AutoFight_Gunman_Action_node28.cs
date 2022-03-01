using System;

namespace behaviac
{
	// Token: 0x0200257C RID: 9596
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Gunman_Action_node28 : Condition
	{
		// Token: 0x06013440 RID: 78912 RVA: 0x005BA249 File Offset: 0x005B8649
		public Condition_bt_AutoFight_AutoFight_Gunman_Action_node28()
		{
			this.opl_p0 = 1011;
		}

		// Token: 0x06013441 RID: 78913 RVA: 0x005BA25C File Offset: 0x005B865C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400CE6A RID: 52842
		private int opl_p0;
	}
}
