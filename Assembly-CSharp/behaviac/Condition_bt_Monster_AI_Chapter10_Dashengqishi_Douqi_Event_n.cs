using System;

namespace behaviac
{
	// Token: 0x020030DE RID: 12510
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter10_Dashengqishi_Douqi_Event_node3 : Condition
	{
		// Token: 0x06014A71 RID: 84593 RVA: 0x00638222 File Offset: 0x00636622
		public Condition_bt_Monster_AI_Chapter10_Dashengqishi_Douqi_Event_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 522052;
		}

		// Token: 0x06014A72 RID: 84594 RVA: 0x00638244 File Offset: 0x00636644
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag != flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E3DC RID: 58332
		private BE_Target opl_p0;

		// Token: 0x0400E3DD RID: 58333
		private BE_Equal opl_p1;

		// Token: 0x0400E3DE RID: 58334
		private int opl_p2;
	}
}
