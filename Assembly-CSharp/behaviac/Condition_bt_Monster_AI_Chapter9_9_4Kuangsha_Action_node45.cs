using System;

namespace behaviac
{
	// Token: 0x0200318C RID: 12684
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node45 : Condition
	{
		// Token: 0x06014BAF RID: 84911 RVA: 0x0063DC57 File Offset: 0x0063C057
		public Condition_bt_Monster_AI_Chapter9_9_4Kuangsha_Action_node45()
		{
			this.opl_p0 = 0.9f;
		}

		// Token: 0x06014BB0 RID: 84912 RVA: 0x0063DC6C File Offset: 0x0063C06C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E51D RID: 58653
		private float opl_p0;
	}
}
