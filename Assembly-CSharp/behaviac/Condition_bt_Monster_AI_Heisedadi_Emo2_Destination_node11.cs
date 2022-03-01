using System;

namespace behaviac
{
	// Token: 0x020033F7 RID: 13303
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node11 : Condition
	{
		// Token: 0x06015041 RID: 86081 RVA: 0x00654DED File Offset: 0x006531ED
		public Condition_bt_Monster_AI_Heisedadi_Emo2_Destination_node11()
		{
			this.opl_p0 = 1f;
		}

		// Token: 0x06015042 RID: 86082 RVA: 0x00654E00 File Offset: 0x00653200
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E929 RID: 59689
		private float opl_p0;
	}
}
