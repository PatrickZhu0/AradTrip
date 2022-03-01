using System;

namespace behaviac
{
	// Token: 0x02002A32 RID: 10802
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node11 : Condition
	{
		// Token: 0x06013D91 RID: 81297 RVA: 0x005F1FF9 File Offset: 0x005F03F9
		public Condition_bt_Guanka_apc_Feiwuzhifengtianyu_node11()
		{
			this.opl_p0 = 0.8f;
		}

		// Token: 0x06013D92 RID: 81298 RVA: 0x005F200C File Offset: 0x005F040C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D802 RID: 55298
		private float opl_p0;
	}
}
