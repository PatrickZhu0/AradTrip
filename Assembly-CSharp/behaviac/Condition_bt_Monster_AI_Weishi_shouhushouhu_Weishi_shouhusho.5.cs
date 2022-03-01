using System;

namespace behaviac
{
	// Token: 0x02003DD4 RID: 15828
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node8 : Condition
	{
		// Token: 0x06016336 RID: 90934 RVA: 0x006B634F File Offset: 0x006B474F
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangmaoxian_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2402;
		}

		// Token: 0x06016337 RID: 90935 RVA: 0x006B6370 File Offset: 0x006B4770
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FB9B RID: 64411
		private BE_Target opl_p0;

		// Token: 0x0400FB9C RID: 64412
		private BE_Equal opl_p1;

		// Token: 0x0400FB9D RID: 64413
		private int opl_p2;
	}
}
