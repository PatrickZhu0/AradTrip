using System;

namespace behaviac
{
	// Token: 0x0200277C RID: 10108
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node32 : Condition
	{
		// Token: 0x06013839 RID: 79929 RVA: 0x005D0965 File Offset: 0x005CED65
		public Condition_bt_AutoFight_AutoFight_MageGirl_Zhaohuan_Action_node32()
		{
			this.opl_p0 = 0.6f;
		}

		// Token: 0x0601383A RID: 79930 RVA: 0x005D0978 File Offset: 0x005CED78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400D29B RID: 53915
		private float opl_p0;
	}
}
