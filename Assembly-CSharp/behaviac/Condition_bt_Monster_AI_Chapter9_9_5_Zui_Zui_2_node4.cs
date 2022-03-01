using System;

namespace behaviac
{
	// Token: 0x020031E8 RID: 12776
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node4 : Condition
	{
		// Token: 0x06014C5C RID: 85084 RVA: 0x006420B1 File Offset: 0x006404B1
		public Condition_bt_Monster_AI_Chapter9_9_5_Zui_Zui_2_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = 570263;
		}

		// Token: 0x06014C5D RID: 85085 RVA: 0x006420D4 File Offset: 0x006404D4
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400E5B4 RID: 58804
		private BE_Target opl_p0;

		// Token: 0x0400E5B5 RID: 58805
		private BE_Equal opl_p1;

		// Token: 0x0400E5B6 RID: 58806
		private int opl_p2;
	}
}
