using System;

namespace behaviac
{
	// Token: 0x02001EFC RID: 7932
	[GeneratedTypeMetaInfo]
	internal class Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node45 : Condition
	{
		// Token: 0x0601279C RID: 75676 RVA: 0x00567E4F File Offset: 0x0056624F
		public Condition_bt_AutoFight_AutoFight_Fightergirl_qigong_Action_node45()
		{
			this.opl_p0 = 3116;
		}

		// Token: 0x0601279D RID: 75677 RVA: 0x00567E64 File Offset: 0x00566264
		protected override EBTStatus update_impl(Agent pAgent, EBTStatus childStatus)
		{
			bool flag = ((BTAgent)pAgent).Condition_CanUseSkill(this.opl_p0);
			bool flag2 = true;
			bool flag3 = flag == flag2;
			return (!flag3) ? EBTStatus.BT_FAILURE : EBTStatus.BT_SUCCESS;
		}

		// Token: 0x0400C191 RID: 49553
		private int opl_p0;
	}
}
