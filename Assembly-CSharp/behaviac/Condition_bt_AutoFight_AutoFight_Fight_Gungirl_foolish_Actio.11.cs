using System;

namespace behaviac
{
	// Token: 0x02001FA3 RID: 8099
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node27 : Condition
	{
		// Token: 0x060128E5 RID: 76005 RVA: 0x0056F686 File Offset: 0x0056DA86
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_foolish_Action_node27()
		{
			this.opl_p0 = 0.7f;
		}

		// Token: 0x060128E6 RID: 76006 RVA: 0x0056F69C File Offset: 0x0056DA9C
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C2D7 RID: 49879
		private float opl_p0;
	}
}
