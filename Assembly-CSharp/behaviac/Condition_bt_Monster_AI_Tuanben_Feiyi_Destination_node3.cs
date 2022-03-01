using System;

namespace behaviac
{
	// Token: 0x020039C5 RID: 14789
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node3 : Condition
	{
		// Token: 0x06015B5C RID: 88924 RVA: 0x0068E8FA File Offset: 0x0068CCFA
		public Condition_bt_Monster_AI_Tuanben_Feiyi_Destination_node3()
		{
			this.opl_p0 = 0.15f;
		}

		// Token: 0x06015B5D RID: 88925 RVA: 0x0068E910 File Offset: 0x0068CD10
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F4B8 RID: 62648
		private float opl_p0;
	}
}
