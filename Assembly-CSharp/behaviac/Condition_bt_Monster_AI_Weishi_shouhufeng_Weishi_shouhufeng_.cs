using System;

namespace behaviac
{
	// Token: 0x02003DBC RID: 15804
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node4 : Condition
	{
		// Token: 0x06016307 RID: 90887 RVA: 0x006B5632 File Offset: 0x006B3A32
		public Condition_bt_Monster_AI_Weishi_shouhufeng_Weishi_shouhufeng_Event_Yinshen_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.Equal;
			this.opl_p2 = BE_State.BEIJI;
		}

		// Token: 0x06016308 RID: 90888 RVA: 0x006B5650 File Offset: 0x006B3A50
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckState(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB5B RID: 64347
		private BE_Target opl_p0;

		// Token: 0x0400FB5C RID: 64348
		private BE_Equal opl_p1;

		// Token: 0x0400FB5D RID: 64349
		private BE_State opl_p2;
	}
}
