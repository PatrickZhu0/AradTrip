using System;

namespace behaviac
{
	// Token: 0x0200279C RID: 10140
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Paladin_Action_node18 : Condition
	{
		// Token: 0x06013878 RID: 79992 RVA: 0x005D2941 File Offset: 0x005D0D41
		public Condition_bt_AutoFight_AutoFight_Paladin_Action_node18()
		{
			this.opl_p0 = 0.2f;
		}

		// Token: 0x06013879 RID: 79993 RVA: 0x005D2954 File Offset: 0x005D0D54
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D2D9 RID: 53977
		private float opl_p0;
	}
}
