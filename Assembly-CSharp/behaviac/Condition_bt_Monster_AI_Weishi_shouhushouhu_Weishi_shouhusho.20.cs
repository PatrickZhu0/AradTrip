using System;

namespace behaviac
{
	// Token: 0x02003DF0 RID: 15856
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node4 : Condition
	{
		// Token: 0x0601636B RID: 90987 RVA: 0x006B73E3 File Offset: 0x006B57E3
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2503;
		}

		// Token: 0x0601636C RID: 90988 RVA: 0x006B7404 File Offset: 0x006B5804
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBD2 RID: 64466
		private BE_Target opl_p0;

		// Token: 0x0400FBD3 RID: 64467
		private BE_Equal opl_p1;

		// Token: 0x0400FBD4 RID: 64468
		private int opl_p2;
	}
}
