using System;

namespace behaviac
{
	// Token: 0x02003DEA RID: 15850
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node8 : Condition
	{
		// Token: 0x06016360 RID: 90976 RVA: 0x006B6F5F File Offset: 0x006B535F
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2404;
		}

		// Token: 0x06016361 RID: 90977 RVA: 0x006B6F80 File Offset: 0x006B5380
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBC7 RID: 64455
		private BE_Target opl_p0;

		// Token: 0x0400FBC8 RID: 64456
		private BE_Equal opl_p1;

		// Token: 0x0400FBC9 RID: 64457
		private int opl_p2;
	}
}
