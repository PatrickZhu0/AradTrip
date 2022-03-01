using System;

namespace behaviac
{
	// Token: 0x02003187 RID: 12679
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node29 : Condition
	{
		// Token: 0x06014BA5 RID: 84901 RVA: 0x0063DA43 File Offset: 0x0063BE43
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node29()
		{
			this.opl_p0 = 0.5f;
		}

		// Token: 0x06014BA6 RID: 84902 RVA: 0x0063DA58 File Offset: 0x0063BE58
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E512 RID: 58642
		private float opl_p0;
	}
}
