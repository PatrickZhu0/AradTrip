using System;

namespace behaviac
{
	// Token: 0x02003DE9 RID: 15849
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node9 : Condition
	{
		// Token: 0x0601635E RID: 90974 RVA: 0x006B6EFE File Offset: 0x006B52FE
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node9()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2504;
		}

		// Token: 0x0601635F RID: 90975 RVA: 0x006B6F20 File Offset: 0x006B5320
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBC4 RID: 64452
		private BE_Target opl_p0;

		// Token: 0x0400FBC5 RID: 64453
		private BE_Equal opl_p1;

		// Token: 0x0400FBC6 RID: 64454
		private int opl_p2;
	}
}
