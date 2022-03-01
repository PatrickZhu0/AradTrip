using System;

namespace behaviac
{
	// Token: 0x02003DF4 RID: 15860
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node9 : Condition
	{
		// Token: 0x06016373 RID: 90995 RVA: 0x006B7506 File Offset: 0x006B5906
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2503;
		}

		// Token: 0x06016374 RID: 90996 RVA: 0x006B7528 File Offset: 0x006B5928
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBDA RID: 64474
		private BE_Target opl_p0;

		// Token: 0x0400FBDB RID: 64475
		private BE_Equal opl_p1;

		// Token: 0x0400FBDC RID: 64476
		private int opl_p2;
	}
}
