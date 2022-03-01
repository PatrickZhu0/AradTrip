using System;

namespace behaviac
{
	// Token: 0x02003291 RID: 12945
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6 : Condition
	{
		// Token: 0x06014D9C RID: 85404 RVA: 0x00647DE5 File Offset: 0x006461E5
		public Condition_bt_Monster_AI_Digongfuben_Digong_Tishi4_Event_node6()
		{
			this.opl_p0 = 570173;
		}

		// Token: 0x06014D9D RID: 85405 RVA: 0x00647DF8 File Offset: 0x006461F8
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_PlayerHaveBuff(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E69A RID: 59034
		private int opl_p0;
	}
}
