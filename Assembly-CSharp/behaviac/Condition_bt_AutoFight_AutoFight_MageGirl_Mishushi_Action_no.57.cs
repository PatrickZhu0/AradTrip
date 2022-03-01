using System;

namespace behaviac
{
	// Token: 0x020026FB RID: 9979
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node32 : Condition
	{
		// Token: 0x06013739 RID: 79673 RVA: 0x005CA611 File Offset: 0x005C8A11
		public Condition_bt_AutoFight_AutoFight_MageGirl_Mishushi_Action_node32()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601373A RID: 79674 RVA: 0x005CA624 File Offset: 0x005C8A24
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D191 RID: 53649
		private float opl_p0;
	}
}
