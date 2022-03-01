using System;

namespace behaviac
{
	// Token: 0x020020B6 RID: 8374
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node27 : Condition
	{
		// Token: 0x06012B03 RID: 76547 RVA: 0x0057C85E File Offset: 0x0057AC5E
		public Condition_bt_AutoFight_AutoFight_Fight_Gungirl_veryhard_Action_node27()
		{
			this.opl_p0 = 0.3f;
		}

		// Token: 0x06012B04 RID: 76548 RVA: 0x0057C874 File Offset: 0x0057AC74
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_GetRandom(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C4F6 RID: 50422
		private float opl_p0;
	}
}
