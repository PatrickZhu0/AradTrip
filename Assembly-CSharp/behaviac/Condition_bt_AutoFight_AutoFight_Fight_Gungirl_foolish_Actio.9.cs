using System;

namespace behaviac
{
	// Token: 0x02001F9F RID: 8095
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node22 : Condition
	{
		// Token: 0x060128DD RID: 75997 RVA: 0x0056F4EA File Offset: 0x0056D8EA
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node22()
		{
			this.opl_p0 = 0.4f;
		}

		// Token: 0x060128DE RID: 75998 RVA: 0x0056F500 File Offset: 0x0056D900
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2CF RID: 49871
		private float opl_p0;
	}
}
