using System;

namespace behaviac
{
	// Token: 0x02003DE5 RID: 15845
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node4 : Condition
	{
		// Token: 0x06016356 RID: 90966 RVA: 0x006B6DDB File Offset: 0x006B51DB
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node4()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2504;
		}

		// Token: 0x06016357 RID: 90967 RVA: 0x006B6DFC File Offset: 0x006B51FC
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBBC RID: 64444
		private BE_Target opl_p0;

		// Token: 0x0400FBBD RID: 64445
		private BE_Equal opl_p1;

		// Token: 0x0400FBBE RID: 64446
		private int opl_p2;
	}
}
