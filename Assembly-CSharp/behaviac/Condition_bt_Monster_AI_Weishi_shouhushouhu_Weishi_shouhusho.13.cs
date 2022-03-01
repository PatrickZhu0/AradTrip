using System;

namespace behaviac
{
	// Token: 0x02003DE4 RID: 15844
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node3 : Condition
	{
		// Token: 0x06016354 RID: 90964 RVA: 0x006B6D78 File Offset: 0x006B5178
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangwangzhe_node3()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2404;
		}

		// Token: 0x06016355 RID: 90965 RVA: 0x006B6D9C File Offset: 0x006B519C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBB9 RID: 64441
		private BE_Target opl_p0;

		// Token: 0x0400FBBA RID: 64442
		private BE_Equal opl_p1;

		// Token: 0x0400FBBB RID: 64443
		private int opl_p2;
	}
}
