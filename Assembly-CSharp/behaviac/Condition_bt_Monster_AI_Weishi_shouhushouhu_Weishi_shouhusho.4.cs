using System;

namespace behaviac
{
	// Token: 0x02003DD3 RID: 15827
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node9 : Condition
	{
		// Token: 0x06016334 RID: 90932 RVA: 0x006B62EE File Offset: 0x006B46EE
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2502;
		}

		// Token: 0x06016335 RID: 90933 RVA: 0x006B6310 File Offset: 0x006B4710
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB98 RID: 64408
		private BE_Target opl_p0;

		// Token: 0x0400FB99 RID: 64409
		private BE_Equal opl_p1;

		// Token: 0x0400FB9A RID: 64410
		private int opl_p2;
	}
}
