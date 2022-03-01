using System;

namespace behaviac
{
	// Token: 0x02001DC1 RID: 7617
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_APC_APC_Mishushi_Action_node56 : Condition
	{
		// Token: 0x0601253A RID: 75066 RVA: 0x00559E5B File Offset: 0x0055825B
		public Condition_bt_APC_APC_Mishushi_Action_node56()
		{
			this.opl_p0 = 9743;
		}

		// Token: 0x0601253B RID: 75067 RVA: 0x00559E70 File Offset: 0x00558270
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400BF2F RID: 48943
		private int opl_p0;
	}
}
