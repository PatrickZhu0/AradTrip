using System;

namespace behaviac
{
	// Token: 0x02003DDF RID: 15839
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node8 : Condition
	{
		// Token: 0x0601634B RID: 90955 RVA: 0x006B6957 File Offset: 0x006B4D57
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangputong_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2401;
		}

		// Token: 0x0601634C RID: 90956 RVA: 0x006B6978 File Offset: 0x006B4D78
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBB1 RID: 64433
		private BE_Target opl_p0;

		// Token: 0x0400FBB2 RID: 64434
		private BE_Equal opl_p1;

		// Token: 0x0400FBB3 RID: 64435
		private int opl_p2;
	}
}
