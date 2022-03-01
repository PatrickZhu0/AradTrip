using System;

namespace behaviac
{
	// Token: 0x0200373A RID: 14138
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node8 : Condition
	{
		// Token: 0x0601567F RID: 87679 RVA: 0x00675562 File Offset: 0x00673962
		public Condition_bt_Monster_AI_Sikete_gedang_Sikete_Event_Hundun_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.GRAPED;
		}

		// Token: 0x06015680 RID: 87680 RVA: 0x00675580 File Offset: 0x00673980
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400F04E RID: 61518
		private BE_Target opl_p0;

		// Token: 0x0400F04F RID: 61519
		private BE_Equal opl_p1;

		// Token: 0x0400F050 RID: 61520
		private BE_State opl_p2;
	}
}
