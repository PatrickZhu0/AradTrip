using System;

namespace behaviac
{
	// Token: 0x0200278D RID: 10125
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node9 : Condition
	{
		// Token: 0x0601385A RID: 79962 RVA: 0x005D22B7 File Offset: 0x005D06B7
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node9()
		{
			this.opl_p0 = 3505;
		}

		// Token: 0x0601385B RID: 79963 RVA: 0x005D22CC File Offset: 0x005D06CC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2BA RID: 53946
		private int opl_p0;
	}
}
