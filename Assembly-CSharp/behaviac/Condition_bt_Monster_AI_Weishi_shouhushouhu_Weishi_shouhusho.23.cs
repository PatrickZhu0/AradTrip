using System;

namespace behaviac
{
	// Token: 0x02003DF5 RID: 15861
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node8 : Condition
	{
		// Token: 0x06016375 RID: 90997 RVA: 0x006B7567 File Offset: 0x006B5967
		public Condition_bt_Monster_AI_Weishi_shouhushouhu_Weishi_shouhushouhu_Event_fanshangyongshi_node8()
		{
			this.opl_p0 = BE_Target.Self;
			this.opl_p1 = BE_Equal.NotEqual;
			this.opl_p2 = 2403;
		}

		// Token: 0x06016376 RID: 90998 RVA: 0x006B7588 File Offset: 0x006B5988
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CheckHasBuff(this.opl_p0, this.opl_p1, this.opl_p2);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400FBDD RID: 64477
		private BE_Target opl_p0;

		// Token: 0x0400FBDE RID: 64478
		private BE_Equal opl_p1;

		// Token: 0x0400FBDF RID: 64479
		private int opl_p2;
	}
}
